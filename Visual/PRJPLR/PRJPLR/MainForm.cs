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
                TimerRefreshLogs.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TimerRefreshLogs_Tick(object sender, EventArgs e)
        {
            foreach (Log log in _serialMachine.Logs)
            {
                if (!Lbx_Logs.Items.Contains(log)) Lbx_Logs.Items.Add(log);
            }
            
        }

        private void Btn_ExportLogs_Click(object sender, EventArgs e)
        {
            StreamWriter logsTxt = new StreamWriter("log.txt", true);
            foreach (Log log in _serialMachine.Logs)
            {
                logsTxt.WriteLine(log.Date.ToString() + " - " + log.Message);
            }
            logsTxt.Close();
        }

        private void Rdio_Ana_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}
