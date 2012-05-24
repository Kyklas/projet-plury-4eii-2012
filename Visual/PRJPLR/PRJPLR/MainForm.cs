using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace PRJPLR
{
    public partial class Gravitron : Form
    {
        SerialMachine _serialMachine;

        public Gravitron()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _serialMachine = new SerialMachine();
        }

        private void btn_openconnexion_Click(object sender, EventArgs e)
        {
            try
            {
                _serialMachine.Open(Tbx_PortNum.Text, int.Parse(Tbx_BaudRate.Text));
                Grbx_Logs.Enabled = true;
                Grbx_Tags.Enabled = true;
                Grbx_CorrectionNum.Enabled = false;
                TimerRefreshLogs.Start();
                TimerMESURE.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TimerRefreshLogs_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < _serialMachine.Logs.Count; i++)
            {
                if (!Lbx_Logs.Items.Contains(_serialMachine.Logs[i])) Lbx_Logs.Items.Add(_serialMachine.Logs[i]);
            }
        }

        private void Btn_ExportLogs_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter logsTxt = new StreamWriter("log.txt", true);
                foreach (Log log in _serialMachine.Logs)
                {
                    logsTxt.WriteLine(log.Date.ToString() + " - " + log.Message);
                }
                logsTxt.Close();
                MessageBox.Show("Exportation réussi !", "logs", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Exportation : Erreur", "logs", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void Rbtn_Analogic_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbtn_Analogic.Checked)
            {
                _serialMachine.Send_Data(0, 0);
                Grbx_CorrectionNum.Enabled = false;
            }

        }

        private void Rbtn_Numeric_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbtn_Numeric.Checked)
            {
                _serialMachine.Send_Data(0, 1);
                Grbx_CorrectionNum.Enabled = true;
                //Grbx_Equation.Enabled = false;

                Thread.Sleep(100);
                _serialMachine.Read_Data(1);
                Thread.Sleep(100);
                _serialMachine.Read_Data(2);
                Thread.Sleep(100);
                _serialMachine.Read_Data(3);
                Thread.Sleep(100);
                _serialMachine.Read_Data(4);
                Thread.Sleep(100);
                _serialMachine.Read_Data(5);
                Thread.Sleep(100);

                Mtbx_Xk.Text = ((float)(_serialMachine.Tags["Xk"]) / 1000).ToString();
                Mtbx_Xk1.Text = ((float)(_serialMachine.Tags["Xk1"]) / 1000).ToString();
                Mtbx_Yk1.Text = ((float)(_serialMachine.Tags["Yk1"]) / 1000).ToString();
                Nud_GainIN.Text = ((float)(_serialMachine.Tags["GainIN"]) / 1000).ToString();
                Nud_GainOUT.Text = ((float)(_serialMachine.Tags["GainOUT"]) / 1000).ToString();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _serialMachine.Send_Data(6, 1);
            Thread.Sleep(100);
            _serialMachine.Close();
        }

        private void Btn_Applied_Click(object sender, EventArgs e)
        {

            //float Te = float.Parse(Nud_Te.Text);
            //float Td = float.Parse(Nud_Td.Text);
            //float Kd = float.Parse(Nud_Kd.Text);
            //float a = float.Parse(Nud_Alpha.Text);
            //if ((1 / a) > 9.99)
            //    Mtbx_Xk.Text = "9,999";
            //else Mtbx_Xk.Text = (1 / a).ToString();
            //Mtbx_Xk1.Text = ((Te-Td)/(a*Td)).ToString();
            //Mtbx_Yk1.Text = ((Te - a*Td) / (a * Td)).ToString();
            //Nud_GainOUT.Text = Kd.ToString();
            
            _serialMachine.Send_Data(1, (short)(float.Parse(Mtbx_Xk.Text) * 1000));
            Thread.Sleep(100);
            _serialMachine.Send_Data(2, (short)(float.Parse(Mtbx_Xk1.Text) * 1000));
            Thread.Sleep(100);
            _serialMachine.Send_Data(3, (short)(float.Parse(Mtbx_Yk1.Text) * 1000));
            Thread.Sleep(100);
            _serialMachine.Send_Data(4, (short)(float.Parse(Nud_GainIN.Text) * 1000));
            Thread.Sleep(100);
            _serialMachine.Send_Data(5, (short)(float.Parse(Nud_GainOUT.Text) * 1000));
            Thread.Sleep(100);
        }

        List<short> Mesures = new List<short>();
        private void TimerMESURE_Tick(object sender, EventArgs e)
        {
            if (Rbtn_Analogic.Checked)
            {
                _serialMachine.Read_Data(7);
                Thread.Sleep(50);
                Mesures.Add(_serialMachine.Tags["MESURE"]);
            }
        }

        private void Btn_ExportMesure_Click(object sender, EventArgs e)
        {
            StreamWriter logsTxt = new StreamWriter("Mesures.csv", false);
            logsTxt.WriteLine("Mesure;");
            foreach (short m in Mesures)
            {
                logsTxt.WriteLine(m.ToString() + ";");
            }
            logsTxt.Close();
        }
    }
}
