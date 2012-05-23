using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

namespace PRJPLR
{
    public class Log
    {
        public string Message;
        public DateTime Date;
        public override string ToString() { return Date.ToShortTimeString() + " - " + Message; }
        
        public Log(Log l) 
        {
            Message = l.Message;
            Date = l.Date;
        }

        public Log()
        {
            Message = "";
            Date = DateTime.Now;
        }
    }

    class SerialMachine
    {
        private enum MachineState { Control, DataReceive, Log }
        private enum DataReceiveState { MMSB, MLSB, LMSB, LLSB }
        // MMSB : Most  Most  Significant Bits : 1er 
        // MLSB : Most  Least Significant Bits : 2ème
        // LMSB : Least Most  Significant Bits : 3ème
        // LLSB : Least Least Significant Bits : 4ème

        // Membres
        SerialPort _serialPort;
        MachineState _state = MachineState.Control;
        Dictionary<short, string> _tagNames = new Dictionary<short, string>();
        string _currentTagName;
        DataReceiveState _currentTagState;
        Log _currentLog = new Log();
        byte[] _currentTagValue = new byte[4];

        // Propriétés
        public List<Log> Logs = new List<Log>();
        public Dictionary<string, short> Tags = new Dictionary<string,short>();

        public SerialMachine()
        {
            _serialPort = new SerialPort();
            _serialPort.BaudRate = 19200;
            _serialPort.Parity = Parity.None;
            _serialPort.StopBits = StopBits.One;
            _serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialMachine_DataReceived);
            
            _tagNames[0] = "CorrectionType";
            Tags["CorrectionType"] = 0;
            _tagNames[1] = "Xk";
            Tags["Xk"] = 0;
            _tagNames[2] = "Xk1";
            Tags["Xk1"] = 0;
            _tagNames[3] = "Yk1";
            Tags["Yk1"] = 0;
            _tagNames[4] = "GainIN";
            Tags["GainIN"] = 0;
            _tagNames[5] = "GainOUT";
            Tags["GainOUT"] = 0;
            _tagNames[7] = "MESURE";
            Tags["MESURE"] = 0;
        }

        public void Open(string portName)
        {
            _serialPort.PortName = portName;
            if (!_serialPort.IsOpen)
            {
                _serialPort.Open();
                _serialPort.Write("U");
            }
        }

        public void Open(string portName, int baudRate)
        {
            _serialPort.PortName = portName;
            _serialPort.BaudRate = baudRate;
            if (!_serialPort.IsOpen)
            {
                _serialPort.Open();
                _serialPort.Write("U");
            }
        }
        
        public void Close()
        {
            _serialPort.Close();
        }

        void SerialMachine_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] rxbuffer = new byte[_serialPort.BytesToRead];
            string temp = rxbuffer.ToString();
            _serialPort.Read(rxbuffer, 0, _serialPort.BytesToRead); 

            foreach (byte rxbyte in rxbuffer)
            {
                // Si c'est un byte de contrôle, on passe en mode "Control"
                if (Convert.ToBoolean(rxbyte & 0x80)) 
                    _state = MachineState.Control;
                switch (_state)
                {
                    case MachineState.Control:
                        if (!(Convert.ToBoolean(rxbyte & 0x80)))
                        {
                            _state = MachineState.Control;
                            break;
                        }

                        if (Convert.ToBoolean(rxbyte & 0x20))
                        {
                            _state = MachineState.Log;
                            _currentLog.Message = "";
                            _currentLog.Date = DateTime.Now;
                        }
                        else
                        {
                            _state = MachineState.DataReceive;
                            _currentTagName = _tagNames[(short)(rxbyte & 0x1F)];
                            Tags[_currentTagName] = 0;
                            _currentTagState = DataReceiveState.MMSB;
                        }
                        break;

                    case MachineState.DataReceive:
                        switch (_currentTagState)
                        {
                            case DataReceiveState.MMSB:
                                Tags[_currentTagName] |= (short)(rxbyte & 0x0F);
                                _currentTagState = DataReceiveState.MLSB;
                                break;

                            case DataReceiveState.MLSB:
                                Tags[_currentTagName] = (short)((int)Tags[_currentTagName] << 4);
                                Tags[_currentTagName] |= (short)(rxbyte & 0x0F);
                                _currentTagState = DataReceiveState.LMSB;
                                break;

                            case DataReceiveState.LMSB:
                                Tags[_currentTagName] = (short)((int)Tags[_currentTagName] << 4);
                                Tags[_currentTagName] |= (short)(rxbyte & 0x0F);
                                _currentTagState = DataReceiveState.LLSB;
                                break;

                            case DataReceiveState.LLSB:
                                Tags[_currentTagName] = (short)((int)Tags[_currentTagName] << 4);
                                Tags[_currentTagName] |= (short)(rxbyte & 0x0F);
                                _currentTagState = DataReceiveState.MMSB;
                                break;
                        }
                        break;

                    case MachineState.Log:
                        _currentLog.Message += (char)rxbyte;
                        if (rxbyte == 0)
                            Logs.Add(new Log(_currentLog));
                        break;

                    default: // Cas improbable, mais au cas où !
                        _state = MachineState.Control;
                        break;

                }
            }
        }

        public void Send_Data(byte index, short data)
        {
            byte[] buffer = new byte[5];

            buffer[0] = (byte)(0xC0 | (index & 0x1F));
            buffer[4] = (byte)(data & 0x000F);
            buffer[3] = (byte)((data >> 4) & 0x000F);
            buffer[2] = (byte)((data >> 8) & 0x000F);
            buffer[1] = (byte)((data >> 12) & 0x000F);

            _serialPort.Write(buffer, 0, 5);
        }

        public void Read_Data(byte index)
        {
            byte[] buffer = new byte[1];

            buffer[0] = (byte)(0x80 | (index & 0x1F));
            _serialPort.Write(buffer, 0, 1);
        }
    }
}
