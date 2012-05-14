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
    }

    class SerialMachine
    {
        private enum MachineState { Control, DataReceive, Log }
        private enum DataReceiveState { Name, MMSB, MLSB, LMSB, LLSB }
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

        void SerialMachine_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            byte[] rxbuffer = new byte[_serialPort.BytesToRead];
            _serialPort.Read(rxbuffer, 0, _serialPort.BytesToRead); 

            foreach (byte rxbyte in rxbuffer)
            {
                // Si c'est un byte de contrôle, on passe en mode "Control"
                if (Convert.ToBoolean(rxbyte & 0x80)) _state = MachineState.Control;
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
                            Logs.Add(new Log());
                            _currentLog.Date = DateTime.Now;
                            _currentLog.Message = "";
                        }
                        else
                        {
                            _state = MachineState.DataReceive;
                            _currentTagState = DataReceiveState.Name;
                        }
                        break;

                    case MachineState.DataReceive:
                        switch (_currentTagState)
                        {
                            case DataReceiveState.Name:
                                _currentTagName = _tagNames[(short)(rxbyte & 0x1F)];
                                Tags[_currentTagName] = 0;
                                _currentTagState = DataReceiveState.MMSB;
                                break;
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
                                _currentTagState = DataReceiveState.Name;
                                break;
                        }
                        break;

                    case MachineState.Log:
                        _currentLog.Message += (char)rxbyte;
                        if (rxbyte == 0)
                            Logs[Logs.Count - 1] = _currentLog;
                        break;

                    default: // Cas improbable, mais au cas où !
                        _state = MachineState.Control;
                        break;

                }
            }
        }

        public void Send()
        {

        }
    }
}
