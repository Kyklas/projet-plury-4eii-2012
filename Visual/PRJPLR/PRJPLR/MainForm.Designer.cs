namespace PRJPLR
{
    partial class Gravitron
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
            this.Grbx_Tags = new System.Windows.Forms.GroupBox();
            this.Grbx_CorrectionNum = new System.Windows.Forms.GroupBox();
            this.Btn_Applied = new System.Windows.Forms.Button();
            this.Grbx_Equation = new System.Windows.Forms.GroupBox();
            this.Nud_GainOUT = new System.Windows.Forms.NumericUpDown();
            this.Lbl_GainOUT = new System.Windows.Forms.Label();
            this.Mtbx_Yk1 = new System.Windows.Forms.MaskedTextBox();
            this.Lbl_GainIN = new System.Windows.Forms.Label();
            this.Nud_GainIN = new System.Windows.Forms.NumericUpDown();
            this.Mtbx_Xk1 = new System.Windows.Forms.MaskedTextBox();
            this.Mtbx_Xk = new System.Windows.Forms.MaskedTextBox();
            this.Lbl_Equation = new System.Windows.Forms.Label();
            this.Grbx_ConnexionType = new System.Windows.Forms.GroupBox();
            this.Rbtn_Numeric = new System.Windows.Forms.RadioButton();
            this.Rbtn_Analogic = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.Nud_Alpha = new System.Windows.Forms.NumericUpDown();
            this.Nud_Te = new System.Windows.Forms.NumericUpDown();
            this.Lbl_Te = new System.Windows.Forms.Label();
            this.Lbl_Alpha = new System.Windows.Forms.Label();
            this.Nud_Kd = new System.Windows.Forms.NumericUpDown();
            this.Nud_Td = new System.Windows.Forms.NumericUpDown();
            this.Lbl_Td = new System.Windows.Forms.Label();
            this.Lbl_Kd = new System.Windows.Forms.Label();
            this.TimerMESURE = new System.Windows.Forms.Timer(this.components);
            this.Btn_ExportMesure = new System.Windows.Forms.Button();
            this.Grbx_connection.SuspendLayout();
            this.Grbx_Logs.SuspendLayout();
            this.Grbx_Tags.SuspendLayout();
            this.Grbx_CorrectionNum.SuspendLayout();
            this.Grbx_Equation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_GainOUT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_GainIN)).BeginInit();
            this.Grbx_ConnexionType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_Alpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_Te)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_Kd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_Td)).BeginInit();
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
            this.Grbx_Logs.Size = new System.Drawing.Size(260, 179);
            this.Grbx_Logs.TabIndex = 1;
            this.Grbx_Logs.TabStop = false;
            this.Grbx_Logs.Text = "Logs";
            // 
            // Lbx_Logs
            // 
            this.Lbx_Logs.FormattingEnabled = true;
            this.Lbx_Logs.Location = new System.Drawing.Point(9, 20);
            this.Lbx_Logs.Name = "Lbx_Logs";
            this.Lbx_Logs.ScrollAlwaysVisible = true;
            this.Lbx_Logs.Size = new System.Drawing.Size(245, 121);
            this.Lbx_Logs.TabIndex = 0;
            // 
            // Btn_ExportLogs
            // 
            this.Btn_ExportLogs.Location = new System.Drawing.Point(181, 146);
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
            // Grbx_Tags
            // 
            this.Grbx_Tags.Controls.Add(this.Grbx_CorrectionNum);
            this.Grbx_Tags.Controls.Add(this.Grbx_ConnexionType);
            this.Grbx_Tags.Controls.Add(this.Btn_ExportMesure);
            this.Grbx_Tags.Enabled = false;
            this.Grbx_Tags.Location = new System.Drawing.Point(278, 12);
            this.Grbx_Tags.Name = "Grbx_Tags";
            this.Grbx_Tags.Size = new System.Drawing.Size(392, 264);
            this.Grbx_Tags.TabIndex = 2;
            this.Grbx_Tags.TabStop = false;
            // 
            // Grbx_CorrectionNum
            // 
            this.Grbx_CorrectionNum.Controls.Add(this.label1);
            this.Grbx_CorrectionNum.Controls.Add(this.Nud_Alpha);
            this.Grbx_CorrectionNum.Controls.Add(this.Lbl_Alpha);
            this.Grbx_CorrectionNum.Controls.Add(this.Nud_Te);
            this.Grbx_CorrectionNum.Controls.Add(this.Lbl_Te);
            this.Grbx_CorrectionNum.Controls.Add(this.Nud_Kd);
            this.Grbx_CorrectionNum.Controls.Add(this.Lbl_Kd);
            this.Grbx_CorrectionNum.Controls.Add(this.Btn_Applied);
            this.Grbx_CorrectionNum.Controls.Add(this.Grbx_Equation);
            this.Grbx_CorrectionNum.Controls.Add(this.Nud_Td);
            this.Grbx_CorrectionNum.Controls.Add(this.Lbl_Td);
            this.Grbx_CorrectionNum.Location = new System.Drawing.Point(6, 85);
            this.Grbx_CorrectionNum.Name = "Grbx_CorrectionNum";
            this.Grbx_CorrectionNum.Size = new System.Drawing.Size(377, 173);
            this.Grbx_CorrectionNum.TabIndex = 1;
            this.Grbx_CorrectionNum.TabStop = false;
            this.Grbx_CorrectionNum.Text = "Correction Numérique";
            // 
            // Btn_Applied
            // 
            this.Btn_Applied.Location = new System.Drawing.Point(298, 19);
            this.Btn_Applied.Name = "Btn_Applied";
            this.Btn_Applied.Size = new System.Drawing.Size(71, 26);
            this.Btn_Applied.TabIndex = 1;
            this.Btn_Applied.Text = "Appliquer";
            this.Btn_Applied.UseVisualStyleBackColor = true;
            this.Btn_Applied.Click += new System.EventHandler(this.Btn_Applied_Click);
            // 
            // Grbx_Equation
            // 
            this.Grbx_Equation.Controls.Add(this.Nud_GainOUT);
            this.Grbx_Equation.Controls.Add(this.Lbl_GainOUT);
            this.Grbx_Equation.Controls.Add(this.Mtbx_Yk1);
            this.Grbx_Equation.Controls.Add(this.Lbl_GainIN);
            this.Grbx_Equation.Controls.Add(this.Nud_GainIN);
            this.Grbx_Equation.Controls.Add(this.Mtbx_Xk1);
            this.Grbx_Equation.Controls.Add(this.Mtbx_Xk);
            this.Grbx_Equation.Controls.Add(this.Lbl_Equation);
            this.Grbx_Equation.Location = new System.Drawing.Point(6, 88);
            this.Grbx_Equation.Name = "Grbx_Equation";
            this.Grbx_Equation.Size = new System.Drawing.Size(363, 79);
            this.Grbx_Equation.TabIndex = 0;
            this.Grbx_Equation.TabStop = false;
            // 
            // Nud_GainOUT
            // 
            this.Nud_GainOUT.DecimalPlaces = 1;
            this.Nud_GainOUT.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Nud_GainOUT.Location = new System.Drawing.Point(271, 50);
            this.Nud_GainOUT.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.Nud_GainOUT.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Nud_GainOUT.Name = "Nud_GainOUT";
            this.Nud_GainOUT.Size = new System.Drawing.Size(46, 20);
            this.Nud_GainOUT.TabIndex = 2;
            this.Nud_GainOUT.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // Lbl_GainOUT
            // 
            this.Lbl_GainOUT.AutoSize = true;
            this.Lbl_GainOUT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_GainOUT.Location = new System.Drawing.Point(181, 50);
            this.Lbl_GainOUT.Name = "Lbl_GainOUT";
            this.Lbl_GainOUT.Size = new System.Drawing.Size(84, 16);
            this.Lbl_GainOUT.TabIndex = 3;
            this.Lbl_GainOUT.Text = "Gain OUT :";
            // 
            // Mtbx_Yk1
            // 
            this.Mtbx_Yk1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mtbx_Yk1.Location = new System.Drawing.Point(259, 13);
            this.Mtbx_Yk1.Mask = "0.000";
            this.Mtbx_Yk1.Name = "Mtbx_Yk1";
            this.Mtbx_Yk1.Size = new System.Drawing.Size(46, 22);
            this.Mtbx_Yk1.TabIndex = 2;
            // 
            // Lbl_GainIN
            // 
            this.Lbl_GainIN.AutoSize = true;
            this.Lbl_GainIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_GainIN.Location = new System.Drawing.Point(43, 50);
            this.Lbl_GainIN.Name = "Lbl_GainIN";
            this.Lbl_GainIN.Size = new System.Drawing.Size(67, 16);
            this.Lbl_GainIN.TabIndex = 3;
            this.Lbl_GainIN.Text = "Gain IN :";
            // 
            // Nud_GainIN
            // 
            this.Nud_GainIN.DecimalPlaces = 1;
            this.Nud_GainIN.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Nud_GainIN.Location = new System.Drawing.Point(116, 50);
            this.Nud_GainIN.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.Nud_GainIN.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Nud_GainIN.Name = "Nud_GainIN";
            this.Nud_GainIN.Size = new System.Drawing.Size(46, 20);
            this.Nud_GainIN.TabIndex = 2;
            this.Nud_GainIN.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // Mtbx_Xk1
            // 
            this.Mtbx_Xk1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mtbx_Xk1.Location = new System.Drawing.Point(147, 13);
            this.Mtbx_Xk1.Mask = "0.000";
            this.Mtbx_Xk1.Name = "Mtbx_Xk1";
            this.Mtbx_Xk1.Size = new System.Drawing.Size(46, 22);
            this.Mtbx_Xk1.TabIndex = 2;
            // 
            // Mtbx_Xk
            // 
            this.Mtbx_Xk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mtbx_Xk.Location = new System.Drawing.Point(55, 15);
            this.Mtbx_Xk.Mask = "0.000";
            this.Mtbx_Xk.Name = "Mtbx_Xk";
            this.Mtbx_Xk.Size = new System.Drawing.Size(46, 22);
            this.Mtbx_Xk.TabIndex = 2;
            // 
            // Lbl_Equation
            // 
            this.Lbl_Equation.AutoSize = true;
            this.Lbl_Equation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Equation.Location = new System.Drawing.Point(6, 16);
            this.Lbl_Equation.Name = "Lbl_Equation";
            this.Lbl_Equation.Size = new System.Drawing.Size(349, 16);
            this.Lbl_Equation.TabIndex = 0;
            this.Lbl_Equation.Text = "y(k) =               x(k) -              x(k -1) +              y(k-1) ";
            // 
            // Grbx_ConnexionType
            // 
            this.Grbx_ConnexionType.Controls.Add(this.Rbtn_Numeric);
            this.Grbx_ConnexionType.Controls.Add(this.Rbtn_Analogic);
            this.Grbx_ConnexionType.Location = new System.Drawing.Point(6, 12);
            this.Grbx_ConnexionType.Name = "Grbx_ConnexionType";
            this.Grbx_ConnexionType.Size = new System.Drawing.Size(91, 66);
            this.Grbx_ConnexionType.TabIndex = 0;
            this.Grbx_ConnexionType.TabStop = false;
            this.Grbx_ConnexionType.Text = "Correction";
            // 
            // Rbtn_Numeric
            // 
            this.Rbtn_Numeric.AutoSize = true;
            this.Rbtn_Numeric.Location = new System.Drawing.Point(6, 42);
            this.Rbtn_Numeric.Name = "Rbtn_Numeric";
            this.Rbtn_Numeric.Size = new System.Drawing.Size(76, 17);
            this.Rbtn_Numeric.TabIndex = 0;
            this.Rbtn_Numeric.Text = "Numerique";
            this.Rbtn_Numeric.UseVisualStyleBackColor = true;
            this.Rbtn_Numeric.CheckedChanged += new System.EventHandler(this.Rbtn_Numeric_CheckedChanged);
            // 
            // Rbtn_Analogic
            // 
            this.Rbtn_Analogic.AutoSize = true;
            this.Rbtn_Analogic.Checked = true;
            this.Rbtn_Analogic.Location = new System.Drawing.Point(6, 19);
            this.Rbtn_Analogic.Name = "Rbtn_Analogic";
            this.Rbtn_Analogic.Size = new System.Drawing.Size(78, 17);
            this.Rbtn_Analogic.TabIndex = 0;
            this.Rbtn_Analogic.TabStop = true;
            this.Rbtn_Analogic.Text = "Analogique";
            this.Rbtn_Analogic.UseVisualStyleBackColor = true;
            this.Rbtn_Analogic.CheckedChanged += new System.EventHandler(this.Rbtn_Analogic_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(218, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "s";
            this.label1.Visible = false;
            // 
            // Nud_Alpha
            // 
            this.Nud_Alpha.DecimalPlaces = 1;
            this.Nud_Alpha.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.Nud_Alpha.Location = new System.Drawing.Point(162, 46);
            this.Nud_Alpha.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.Nud_Alpha.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.Nud_Alpha.Name = "Nud_Alpha";
            this.Nud_Alpha.Size = new System.Drawing.Size(54, 20);
            this.Nud_Alpha.TabIndex = 8;
            this.Nud_Alpha.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.Nud_Alpha.Visible = false;
            // 
            // Nud_Te
            // 
            this.Nud_Te.DecimalPlaces = 3;
            this.Nud_Te.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.Nud_Te.Location = new System.Drawing.Point(162, 19);
            this.Nud_Te.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.Nud_Te.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.Nud_Te.Name = "Nud_Te";
            this.Nud_Te.Size = new System.Drawing.Size(54, 20);
            this.Nud_Te.TabIndex = 6;
            this.Nud_Te.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.Nud_Te.Visible = false;
            // 
            // Lbl_Te
            // 
            this.Lbl_Te.AutoSize = true;
            this.Lbl_Te.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Te.Location = new System.Drawing.Point(122, 20);
            this.Lbl_Te.Name = "Lbl_Te";
            this.Lbl_Te.Size = new System.Drawing.Size(35, 16);
            this.Lbl_Te.TabIndex = 7;
            this.Lbl_Te.Text = "Te :";
            this.Lbl_Te.Visible = false;
            // 
            // Lbl_Alpha
            // 
            this.Lbl_Alpha.AutoSize = true;
            this.Lbl_Alpha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Alpha.Location = new System.Drawing.Point(122, 47);
            this.Lbl_Alpha.Name = "Lbl_Alpha";
            this.Lbl_Alpha.Size = new System.Drawing.Size(25, 16);
            this.Lbl_Alpha.TabIndex = 9;
            this.Lbl_Alpha.Text = "a :";
            this.Lbl_Alpha.Visible = false;
            // 
            // Nud_Kd
            // 
            this.Nud_Kd.DecimalPlaces = 1;
            this.Nud_Kd.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.Nud_Kd.Location = new System.Drawing.Point(52, 45);
            this.Nud_Kd.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.Nud_Kd.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.Nud_Kd.Name = "Nud_Kd";
            this.Nud_Kd.Size = new System.Drawing.Size(55, 20);
            this.Nud_Kd.TabIndex = 4;
            this.Nud_Kd.Value = new decimal(new int[] {
            3,
            0,
            0,
            65536});
            this.Nud_Kd.Visible = false;
            // 
            // Nud_Td
            // 
            this.Nud_Td.DecimalPlaces = 4;
            this.Nud_Td.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.Nud_Td.Location = new System.Drawing.Point(52, 19);
            this.Nud_Td.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.Nud_Td.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.Nud_Td.Name = "Nud_Td";
            this.Nud_Td.Size = new System.Drawing.Size(55, 20);
            this.Nud_Td.TabIndex = 2;
            this.Nud_Td.Value = new decimal(new int[] {
            393,
            0,
            0,
            262144});
            this.Nud_Td.Visible = false;
            // 
            // Lbl_Td
            // 
            this.Lbl_Td.AutoSize = true;
            this.Lbl_Td.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Td.Location = new System.Drawing.Point(12, 20);
            this.Lbl_Td.Name = "Lbl_Td";
            this.Lbl_Td.Size = new System.Drawing.Size(35, 16);
            this.Lbl_Td.TabIndex = 3;
            this.Lbl_Td.Text = "Td :";
            this.Lbl_Td.Visible = false;
            // 
            // Lbl_Kd
            // 
            this.Lbl_Kd.AutoSize = true;
            this.Lbl_Kd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Kd.Location = new System.Drawing.Point(12, 46);
            this.Lbl_Kd.Name = "Lbl_Kd";
            this.Lbl_Kd.Size = new System.Drawing.Size(34, 16);
            this.Lbl_Kd.TabIndex = 5;
            this.Lbl_Kd.Text = "Kd :";
            this.Lbl_Kd.Visible = false;
            // 
            // TimerMESURE
            // 
            this.TimerMESURE.Tick += new System.EventHandler(this.TimerMESURE_Tick);
            // 
            // Btn_ExportMesure
            // 
            this.Btn_ExportMesure.Location = new System.Drawing.Point(263, 19);
            this.Btn_ExportMesure.Name = "Btn_ExportMesure";
            this.Btn_ExportMesure.Size = new System.Drawing.Size(120, 26);
            this.Btn_ExportMesure.TabIndex = 1;
            this.Btn_ExportMesure.Text = "Exporter les mesures";
            this.Btn_ExportMesure.UseVisualStyleBackColor = true;
            this.Btn_ExportMesure.Click += new System.EventHandler(this.Btn_ExportMesure_Click);
            // 
            // Gravitron
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 288);
            this.Controls.Add(this.Grbx_Tags);
            this.Controls.Add(this.Grbx_Logs);
            this.Controls.Add(this.Grbx_connection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Gravitron";
            this.Text = "Gravitron";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Grbx_connection.ResumeLayout(false);
            this.Grbx_connection.PerformLayout();
            this.Grbx_Logs.ResumeLayout(false);
            this.Grbx_Tags.ResumeLayout(false);
            this.Grbx_CorrectionNum.ResumeLayout(false);
            this.Grbx_CorrectionNum.PerformLayout();
            this.Grbx_Equation.ResumeLayout(false);
            this.Grbx_Equation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_GainOUT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_GainIN)).EndInit();
            this.Grbx_ConnexionType.ResumeLayout(false);
            this.Grbx_ConnexionType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_Alpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_Te)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_Kd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_Td)).EndInit();
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
        private System.Windows.Forms.GroupBox Grbx_Tags;
        private System.Windows.Forms.GroupBox Grbx_ConnexionType;
        private System.Windows.Forms.RadioButton Rbtn_Numeric;
        private System.Windows.Forms.RadioButton Rbtn_Analogic;
        private System.Windows.Forms.GroupBox Grbx_CorrectionNum;
        private System.Windows.Forms.GroupBox Grbx_Equation;
        private System.Windows.Forms.Label Lbl_Equation;
        private System.Windows.Forms.Button Btn_Applied;
        private System.Windows.Forms.MaskedTextBox Mtbx_Yk1;
        private System.Windows.Forms.MaskedTextBox Mtbx_Xk1;
        private System.Windows.Forms.MaskedTextBox Mtbx_Xk;
        private System.Windows.Forms.Label Lbl_GainIN;
        private System.Windows.Forms.NumericUpDown Nud_GainIN;
        private System.Windows.Forms.Label Lbl_GainOUT;
        private System.Windows.Forms.NumericUpDown Nud_GainOUT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown Nud_Alpha;
        private System.Windows.Forms.Label Lbl_Alpha;
        private System.Windows.Forms.NumericUpDown Nud_Te;
        private System.Windows.Forms.Label Lbl_Te;
        private System.Windows.Forms.NumericUpDown Nud_Kd;
        private System.Windows.Forms.Label Lbl_Kd;
        private System.Windows.Forms.NumericUpDown Nud_Td;
        private System.Windows.Forms.Label Lbl_Td;
        private System.Windows.Forms.Timer TimerMESURE;
        private System.Windows.Forms.Button Btn_ExportMesure;
    }
}