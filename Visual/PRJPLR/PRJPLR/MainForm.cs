using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PRJPLR
{
    public partial class MainForm : Form
    {
        SerialMachine _serialMachine;

        public MainForm()
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
                TimerRefreshLogs.Start();
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

            TbxTestRead.Text = _serialMachine.Tags["Test"].ToString();

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
                _serialMachine.Send_Data(0, 0);
        }

        private void Rbtn_Numeric_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbtn_Numeric.Checked)
                _serialMachine.Send_Data(0, 1);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _serialMachine.Close();
        }

        private void TbxTestWrite_TextChanged(object sender, EventArgs e)
        {
            _serialMachine.Send_Data(1, short.Parse(TbxTestWrite.Text));
        }

        private void BtnTestRead_Click(object sender, EventArgs e)
        {
            _serialMachine.Read_Data(1);
        }
    }
}
