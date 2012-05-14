namespace PRJPLR
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Grbx_connection = new System.Windows.Forms.GroupBox();
            this.Lbl_BaudRate = new System.Windows.Forms.Label();
            this.Lbl_PortNum = new System.Windows.Forms.Label();
            this.Tbx_BaudRate = new System.Windows.Forms.TextBox();
            this.Tbx_PortNum = new System.Windows.Forms.TextBox();
            this.btn_openconnexion = new System.Windows.Forms.Button();
            this.Grbx_Logs = new System.Windows.Forms.GroupBox();
            this.Lbx_Logs = new System.Windows.Forms.ListBox();
            this.Btn_ExportLogs = new System.Windows.Forms.Button();
            this.TimerRefreshLogs = new System.Windows.Forms.Timer(this.components);
            this.Grbx_connection.SuspendLayout();
            this.Grbx_Logs.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grbx_connection
            // 
            this.Grbx_connection.Controls.Add(this.Lbl_BaudRate);
            this.Grbx_connection.Controls.Add(this.Lbl_PortNum);
            this.Grbx_connection.Controls.Add(this.Tbx_BaudRate);
            this.Grbx_connection.Controls.Add(this.Tbx_PortNum);
            this.Grbx_connection.Controls.Add(this.btn_openconnexion);
            this.Grbx_connection.Location = new System.Drawing.Point(12, 12);
            this.Grbx_connection.Name = "Grbx_connection";
            this.Grbx_connection.Size = new System.Drawing.Size(260, 78);
            this.Grbx_connection.TabIndex = 0;
            this.Grbx_connection.TabStop = false;
            this.Grbx_connection.Text = "Connexion";
            // 
            // Lbl_BaudRate
            // 
            this.Lbl_BaudRate.AutoSize = true;
            this.Lbl_BaudRate.Location = new System.Drawing.Point(6, 52);
            this.Lbl_BaudRate.Name = "Lbl_BaudRate";
            this.Lbl_BaudRate.Size = new System.Drawing.Size(55, 13);
            this.Lbl_BaudRate.TabIndex = 2;
            this.Lbl_BaudRate.Text = "BaudRate";
            // 
            // Lbl_PortNum
            // 
            this.Lbl_PortNum.AutoSize = true;
            this.Lbl_PortNum.Location = new System.Drawing.Point(6, 26);
            this.Lbl_PortNum.Name = "Lbl_PortNum";
            this.Lbl_PortNum.Size = new System.Drawing.Size(81, 13);
            this.Lbl_PortNum.TabIndex = 2;
            this.Lbl_PortNum.Text = "Numéro de Port";
            // 
            // Tbx_BaudRate
            // 
            this.Tbx_BaudRate.Location = new System.Drawing.Point(93, 49);
            this.Tbx_BaudRate.Name = "Tbx_BaudRate";
            this.Tbx_BaudRate.Size = new System.Drawing.Size(52, 20);
            this.Tbx_BaudRate.TabIndex = 1;
            this.Tbx_BaudRate.Text = "19200";
            // 
            // Tbx_PortNum
            // 
            this.Tbx_PortNum.Location = new System.Drawing.Point(93, 23);
            this.Tbx_PortNum.Name = "Tbx_PortNum";
            this.Tbx_PortNum.Size = new System.Drawing.Size(52, 20);
            this.Tbx_PortNum.TabIndex = 1;
            this.Tbx_PortNum.Text = "COM1";
            // 
            // btn_openconnexion
            // 
            this.btn_openconnexion.Location = new System.Drawing.Point(181, 45);
            this.btn_openconnexion.Name = "btn_openconnexion";
            this.btn_openconnexion.Size = new System.Drawing.Size(73, 27);
            this.btn_openconnexion.TabIndex = 0;
            this.btn_openconnexion.Text = "Ouvrir";
            this.btn_openconnexion.UseVisualStyleBackColor = true;
            this.btn_openconnexion.Click += new System.EventHandler(this.btn_openconnexion_Click);
            // 
            // Grbx_Logs
            // 
            this.Grbx_Logs.Controls.Add(this.Lbx_Logs);
            this.Grbx_Logs.Controls.Add(this.Btn_ExportLogs);
            this.Grbx_Logs.Enabled = false;
            this.Grbx_Logs.Location = new System.Drawing.Point(12, 97);
            this.Grbx_Logs.Name = "Grbx_Logs";
            this.Grbx_Logs.Size = new System.Drawing.Size(260, 184);
            this.Grbx_Logs.TabIndex = 1;
            this.Grbx_Logs.TabStop = false;
            this.Grbx_Logs.Text = "Logs";
            // 
            // Lbx_Logs
            // 
            this.Lbx_Logs.FormattingEnabled = true;
            this.Lbx_Logs.Location = new System.Drawing.Point(9, 20);
            this.Lbx_Logs.Name = "Lbx_Logs";
            this.Lbx_Logs.Size = new System.Drawing.Size(245, 121);
            this.Lbx_Logs.TabIndex = 0;
            // 
            // Btn_ExportLogs
            // 
            this.Btn_ExportLogs.Location = new System.Drawing.Point(181, 147);
            this.Btn_ExportLogs.Name = "Btn_ExportLogs";
            this.Btn_ExportLogs.Size = new System.Drawing.Size(73, 27);
            this.Btn_ExportLogs.TabIndex = 0;
            this.Btn_ExportLogs.Text = "Exporter";
            this.Btn_ExportLogs.UseVisualStyleBackColor = true;
            this.Btn_ExportLogs.Click += new System.EventHandler(this.Btn_ExportLogs_Click);
            // 
            // TimerRefreshLogs
            // 
            this.TimerRefreshLogs.Tick += new System.EventHandler(this.TimerRefreshLogs_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 288);
            this.Controls.Add(this.Grbx_Logs);
            this.Controls.Add(this.Grbx_connection);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Grbx_connection.ResumeLayout(false);
            this.Grbx_connection.PerformLayout();
            this.Grbx_Logs.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Grbx_connection;
        private System.Windows.Forms.TextBox Tbx_PortNum;
        private System.Windows.Forms.Button btn_openconnexion;
        private System.Windows.Forms.Label Lbl_PortNum;
        private System.Windows.Forms.Label Lbl_BaudRate;
        private System.Windows.Forms.TextBox Tbx_BaudRate;
        private System.Windows.Forms.GroupBox Grbx_Logs;
        private System.Windows.Forms.ListBox Lbx_Logs;
        private System.Windows.Forms.Button Btn_ExportLogs;
        private System.Windows.Forms.Timer TimerRefreshLogs;
    }
}