namespace lsa_Tanenbaum_app
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textTargetIp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textProcessName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textSourcePort = new System.Windows.Forms.TextBox();
            this.textSourceIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textTargetPort = new System.Windows.Forms.TextBox();
            this.initializeSocketBtn = new System.Windows.Forms.Button();
            this.stopSocketBtn = new System.Windows.Forms.Button();
            this.labelConnectionStatus = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.diagnosticPingFrequency = new System.Windows.Forms.NumericUpDown();
            this.ringSynchronizationBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.addressesListBox = new System.Windows.Forms.ListBox();
            this.prioritiesListBox = new System.Windows.Forms.ListBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.knowledgeGroupBox = new System.Windows.Forms.GroupBox();
            this.label26 = new System.Windows.Forms.Label();
            this.ringCoordinatorPriorityText = new System.Windows.Forms.Label();
            this.ringCoordinatorAddressText = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.updatePriorityBtn = new System.Windows.Forms.Button();
            this.priorityTrackBar = new System.Windows.Forms.TrackBar();
            this.textPriority = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label25 = new System.Windows.Forms.Label();
            this.diagnosticPingGroupBox = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.replyTimeout = new System.Windows.Forms.NumericUpDown();
            this.disableDiagnosticPingBtn = new System.Windows.Forms.Button();
            this.enableDiagnosticPingBtn = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.resizeWindowBtn = new System.Windows.Forms.Button();
            this.toolTipControl = new System.Windows.Forms.ToolTip(this.components);
            this.toggleCreditsBtn = new System.Windows.Forms.Button();
            this.createAppInstanceBtn = new System.Windows.Forms.Button();
            this.creditsPanel = new System.Windows.Forms.Panel();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBoxConnectionStatus = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diagnosticPingFrequency)).BeginInit();
            this.knowledgeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priorityTrackBar)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.diagnosticPingGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.replyTimeout)).BeginInit();
            this.creditsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConnectionStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.textTargetIp);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textProcessName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textSourcePort);
            this.groupBox1.Controls.Add(this.textSourceIp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textTargetPort);
            this.groupBox1.Location = new System.Drawing.Point(12, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 213);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Process";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 17);
            this.label4.TabIndex = 24;
            this.label4.Text = ":";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(172, 168);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(12, 17);
            this.label13.TabIndex = 23;
            this.label13.Text = ":";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(172, 170);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(12, 17);
            this.label15.TabIndex = 22;
            this.label15.Text = ":";
            // 
            // textTargetIp
            // 
            this.textTargetIp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTargetIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textTargetIp.Location = new System.Drawing.Point(10, 165);
            this.textTargetIp.MaxLength = 15;
            this.textTargetIp.Name = "textTargetIp";
            this.textTargetIp.Size = new System.Drawing.Size(158, 24);
            this.textTargetIp.TabIndex = 6;
            this.textTargetIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textTargetIp.TextChanged += new System.EventHandler(this.configTextBoxChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Address of consequent";
            // 
            // textProcessName
            // 
            this.textProcessName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textProcessName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textProcessName.Location = new System.Drawing.Point(10, 48);
            this.textProcessName.MaxLength = 25;
            this.textProcessName.Name = "textProcessName";
            this.textProcessName.ReadOnly = true;
            this.textProcessName.Size = new System.Drawing.Size(158, 24);
            this.textProcessName.TabIndex = 155;
            this.textProcessName.TabStop = false;
            this.textProcessName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textProcessName.TextChanged += new System.EventHandler(this.configTextBoxChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "Name";
            // 
            // textSourcePort
            // 
            this.textSourcePort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textSourcePort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textSourcePort.Location = new System.Drawing.Point(187, 108);
            this.textSourcePort.MaxLength = 5;
            this.textSourcePort.Name = "textSourcePort";
            this.textSourcePort.Size = new System.Drawing.Size(54, 24);
            this.textSourcePort.TabIndex = 3;
            this.textSourcePort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textSourcePort.TextChanged += new System.EventHandler(this.configTextBoxChanged);
            // 
            // textSourceIp
            // 
            this.textSourceIp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textSourceIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textSourceIp.Location = new System.Drawing.Point(10, 107);
            this.textSourceIp.MaxLength = 15;
            this.textSourceIp.Name = "textSourceIp";
            this.textSourceIp.Size = new System.Drawing.Size(158, 24);
            this.textSourceIp.TabIndex = 2;
            this.textSourceIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textSourceIp.TextChanged += new System.EventHandler(this.configTextBoxChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Address";
            // 
            // textTargetPort
            // 
            this.textTargetPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTargetPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textTargetPort.Location = new System.Drawing.Point(187, 165);
            this.textTargetPort.MaxLength = 5;
            this.textTargetPort.Name = "textTargetPort";
            this.textTargetPort.Size = new System.Drawing.Size(54, 24);
            this.textTargetPort.TabIndex = 7;
            this.textTargetPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textTargetPort.TextChanged += new System.EventHandler(this.configTextBoxChanged);
            // 
            // initializeSocketBtn
            // 
            this.initializeSocketBtn.CausesValidation = false;
            this.initializeSocketBtn.Enabled = false;
            this.initializeSocketBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.initializeSocketBtn.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.initializeSocketBtn.Location = new System.Drawing.Point(97, 364);
            this.initializeSocketBtn.Name = "initializeSocketBtn";
            this.initializeSocketBtn.Size = new System.Drawing.Size(127, 56);
            this.initializeSocketBtn.TabIndex = 2;
            this.initializeSocketBtn.TabStop = false;
            this.initializeSocketBtn.Text = "Initialize";
            this.initializeSocketBtn.UseVisualStyleBackColor = true;
            this.initializeSocketBtn.Click += new System.EventHandler(this.initializeSocketBtn_Click);
            // 
            // stopSocketBtn
            // 
            this.stopSocketBtn.BackColor = System.Drawing.Color.LightGray;
            this.stopSocketBtn.CausesValidation = false;
            this.stopSocketBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stopSocketBtn.Enabled = false;
            this.stopSocketBtn.FlatAppearance.BorderSize = 0;
            this.stopSocketBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.stopSocketBtn.Location = new System.Drawing.Point(171, 77);
            this.stopSocketBtn.Name = "stopSocketBtn";
            this.stopSocketBtn.Size = new System.Drawing.Size(100, 26);
            this.stopSocketBtn.TabIndex = 6;
            this.stopSocketBtn.TabStop = false;
            this.stopSocketBtn.Text = "Disconnect";
            this.stopSocketBtn.UseVisualStyleBackColor = false;
            this.stopSocketBtn.Click += new System.EventHandler(this.stopSocketBtn_Click);
            // 
            // labelConnectionStatus
            // 
            this.labelConnectionStatus.AutoSize = true;
            this.labelConnectionStatus.Location = new System.Drawing.Point(41, 80);
            this.labelConnectionStatus.Name = "labelConnectionStatus";
            this.labelConnectionStatus.Size = new System.Drawing.Size(102, 17);
            this.labelConnectionStatus.TabIndex = 8;
            this.labelConnectionStatus.Text = "Not Connected";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Dubai", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(70, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 40);
            this.label6.TabIndex = 10;
            this.label6.Text = "Configuration";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Dubai", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label8.Location = new System.Drawing.Point(375, 34);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(194, 40);
            this.label8.TabIndex = 11;
            this.label8.Text = "Parameters Setup";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(295, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Priority";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 17);
            this.label11.TabIndex = 15;
            this.label11.Text = "Ping frequency (s)";
            // 
            // diagnosticPingFrequency
            // 
            this.diagnosticPingFrequency.DecimalPlaces = 1;
            this.diagnosticPingFrequency.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.diagnosticPingFrequency.Location = new System.Drawing.Point(16, 56);
            this.diagnosticPingFrequency.Maximum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.diagnosticPingFrequency.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.diagnosticPingFrequency.Name = "diagnosticPingFrequency";
            this.diagnosticPingFrequency.Size = new System.Drawing.Size(121, 22);
            this.diagnosticPingFrequency.TabIndex = 16;
            this.diagnosticPingFrequency.TabStop = false;
            this.diagnosticPingFrequency.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.diagnosticPingFrequency.ValueChanged += new System.EventHandler(this.onPingFrequencyValueChange);
            // 
            // ringSynchronizationBtn
            // 
            this.ringSynchronizationBtn.CausesValidation = false;
            this.ringSynchronizationBtn.Enabled = false;
            this.ringSynchronizationBtn.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ringSynchronizationBtn.Location = new System.Drawing.Point(97, 445);
            this.ringSynchronizationBtn.Name = "ringSynchronizationBtn";
            this.ringSynchronizationBtn.Size = new System.Drawing.Size(127, 56);
            this.ringSynchronizationBtn.TabIndex = 17;
            this.ringSynchronizationBtn.TabStop = false;
            this.ringSynchronizationBtn.Text = "Ring sync.";
            this.ringSynchronizationBtn.UseVisualStyleBackColor = true;
            this.ringSynchronizationBtn.Click += new System.EventHandler(this.ringSynchronizationBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Leelawadee", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(41, 374);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 36);
            this.label1.TabIndex = 25;
            this.label1.Text = "1.";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Leelawadee", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label16.Location = new System.Drawing.Point(41, 455);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 36);
            this.label16.TabIndex = 26;
            this.label16.Text = "2.";
            // 
            // logBox
            // 
            this.logBox.BackColor = System.Drawing.Color.Silver;
            this.logBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.logBox.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.logBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.logBox.HideSelection = false;
            this.logBox.Location = new System.Drawing.Point(699, 39);
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.Size = new System.Drawing.Size(544, 592);
            this.logBox.TabIndex = 27;
            this.logBox.TabStop = false;
            this.logBox.Text = "// *************************************************************\n// 🔷 Leader Sel" +
    "ection Algorithm log\n// Tanenbaum\'s variant \n// ********************************" +
    "*****************************\n";
            // 
            // addressesListBox
            // 
            this.addressesListBox.BackColor = System.Drawing.SystemColors.Control;
            this.addressesListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addressesListBox.FormattingEnabled = true;
            this.addressesListBox.ItemHeight = 16;
            this.addressesListBox.Location = new System.Drawing.Point(48, 45);
            this.addressesListBox.Name = "addressesListBox";
            this.addressesListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.addressesListBox.Size = new System.Drawing.Size(191, 114);
            this.addressesListBox.TabIndex = 30;
            this.addressesListBox.TabStop = false;
            this.addressesListBox.UseTabStops = false;
            // 
            // prioritiesListBox
            // 
            this.prioritiesListBox.BackColor = System.Drawing.SystemColors.Control;
            this.prioritiesListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.prioritiesListBox.DisplayMember = "5";
            this.prioritiesListBox.FormattingEnabled = true;
            this.prioritiesListBox.ItemHeight = 16;
            this.prioritiesListBox.Location = new System.Drawing.Point(245, 45);
            this.prioritiesListBox.Name = "prioritiesListBox";
            this.prioritiesListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.prioritiesListBox.Size = new System.Drawing.Size(65, 114);
            this.prioritiesListBox.TabIndex = 31;
            this.prioritiesListBox.TabStop = false;
            this.prioritiesListBox.UseTabStops = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(106, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(75, 17);
            this.label17.TabIndex = 32;
            this.label17.Text = "Addresses";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(242, 25);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 17);
            this.label18.TabIndex = 34;
            this.label18.Text = "Priorities";
            // 
            // knowledgeGroupBox
            // 
            this.knowledgeGroupBox.Controls.Add(this.label26);
            this.knowledgeGroupBox.Controls.Add(this.ringCoordinatorPriorityText);
            this.knowledgeGroupBox.Controls.Add(this.ringCoordinatorAddressText);
            this.knowledgeGroupBox.Controls.Add(this.label33);
            this.knowledgeGroupBox.Controls.Add(this.label18);
            this.knowledgeGroupBox.Controls.Add(this.label17);
            this.knowledgeGroupBox.Controls.Add(this.addressesListBox);
            this.knowledgeGroupBox.Controls.Add(this.prioritiesListBox);
            this.knowledgeGroupBox.Location = new System.Drawing.Point(293, 420);
            this.knowledgeGroupBox.Name = "knowledgeGroupBox";
            this.knowledgeGroupBox.Size = new System.Drawing.Size(389, 211);
            this.knowledgeGroupBox.TabIndex = 35;
            this.knowledgeGroupBox.TabStop = false;
            this.knowledgeGroupBox.Text = "My knowledge";
            this.knowledgeGroupBox.Visible = false;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label26.Location = new System.Drawing.Point(353, 10);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(33, 29);
            this.label26.TabIndex = 47;
            this.label26.Text = "❔";
            this.toolTipControl.SetToolTip(this.label26, "Knowledge represents what single process\r\nknows about ring and it\'s leader.");
            // 
            // ringCoordinatorPriorityText
            // 
            this.ringCoordinatorPriorityText.AutoSize = true;
            this.ringCoordinatorPriorityText.Location = new System.Drawing.Point(103, 188);
            this.ringCoordinatorPriorityText.Name = "ringCoordinatorPriorityText";
            this.ringCoordinatorPriorityText.Size = new System.Drawing.Size(169, 17);
            this.ringCoordinatorPriorityText.TabIndex = 37;
            this.ringCoordinatorPriorityText.Text = "with priority 50 (12:02:22)";
            // 
            // ringCoordinatorAddressText
            // 
            this.ringCoordinatorAddressText.AutoSize = true;
            this.ringCoordinatorAddressText.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ringCoordinatorAddressText.Location = new System.Drawing.Point(191, 171);
            this.ringCoordinatorAddressText.Name = "ringCoordinatorAddressText";
            this.ringCoordinatorAddressText.Size = new System.Drawing.Size(109, 17);
            this.ringCoordinatorAddressText.TabIndex = 36;
            this.ringCoordinatorAddressText.Text = "0.0.0.0:00000";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(48, 171);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(145, 17);
            this.label33.TabIndex = 35;
            this.label33.Text = "Current ring leader is:";
            // 
            // updatePriorityBtn
            // 
            this.updatePriorityBtn.Enabled = false;
            this.updatePriorityBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.updatePriorityBtn.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.updatePriorityBtn.Location = new System.Drawing.Point(29, 93);
            this.updatePriorityBtn.Name = "updatePriorityBtn";
            this.updatePriorityBtn.Size = new System.Drawing.Size(300, 29);
            this.updatePriorityBtn.TabIndex = 36;
            this.updatePriorityBtn.TabStop = false;
            this.updatePriorityBtn.Text = "call priority update";
            this.updatePriorityBtn.UseVisualStyleBackColor = true;
            this.updatePriorityBtn.Click += new System.EventHandler(this.callPriorityUpdateBtn_Click);
            // 
            // priorityTrackBar
            // 
            this.priorityTrackBar.Location = new System.Drawing.Point(6, 48);
            this.priorityTrackBar.Maximum = 100;
            this.priorityTrackBar.Minimum = 1;
            this.priorityTrackBar.Name = "priorityTrackBar";
            this.priorityTrackBar.Size = new System.Drawing.Size(283, 56);
            this.priorityTrackBar.TabIndex = 37;
            this.priorityTrackBar.TabStop = false;
            this.priorityTrackBar.Value = 5;
            this.priorityTrackBar.ValueChanged += new System.EventHandler(this.onPriorityTrackBarValueChange);
            // 
            // textPriority
            // 
            this.textPriority.Location = new System.Drawing.Point(298, 59);
            this.textPriority.MaxLength = 4;
            this.textPriority.Name = "textPriority";
            this.textPriority.Size = new System.Drawing.Size(49, 22);
            this.textPriority.TabIndex = 25;
            this.textPriority.TabStop = false;
            this.textPriority.Text = "5";
            this.textPriority.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textPriority.TextChanged += new System.EventHandler(this.onPriorityTextBoxValueChange);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 29);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 17);
            this.label12.TabIndex = 38;
            this.label12.Text = "1";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(247, 29);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(32, 17);
            this.label19.TabIndex = 39;
            this.label19.Text = "100";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label25);
            this.groupBox2.Controls.Add(this.updatePriorityBtn);
            this.groupBox2.Controls.Add(this.priorityTrackBar);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.textPriority);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(293, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(389, 136);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Priority";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label25.Location = new System.Drawing.Point(353, 10);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(33, 29);
            this.label25.TabIndex = 45;
            this.label25.Text = "❔";
            this.toolTipControl.SetToolTip(this.label25, "Set priority via slider(accepted values 1-100)\r\nor input field (max 9999). Note t" +
        "hat priority\r\ncan be set before initialization process.");
            // 
            // diagnosticPingGroupBox
            // 
            this.diagnosticPingGroupBox.Controls.Add(this.label24);
            this.diagnosticPingGroupBox.Controls.Add(this.label21);
            this.diagnosticPingGroupBox.Controls.Add(this.replyTimeout);
            this.diagnosticPingGroupBox.Controls.Add(this.disableDiagnosticPingBtn);
            this.diagnosticPingGroupBox.Controls.Add(this.enableDiagnosticPingBtn);
            this.diagnosticPingGroupBox.Controls.Add(this.label11);
            this.diagnosticPingGroupBox.Controls.Add(this.diagnosticPingFrequency);
            this.diagnosticPingGroupBox.Location = new System.Drawing.Point(293, 272);
            this.diagnosticPingGroupBox.Name = "diagnosticPingGroupBox";
            this.diagnosticPingGroupBox.Size = new System.Drawing.Size(389, 130);
            this.diagnosticPingGroupBox.TabIndex = 41;
            this.diagnosticPingGroupBox.TabStop = false;
            this.diagnosticPingGroupBox.Text = "Diagnostic ping";
            this.diagnosticPingGroupBox.Visible = false;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label24.Location = new System.Drawing.Point(352, 10);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(33, 29);
            this.label24.TabIndex = 46;
            this.label24.Text = "❔";
            this.toolTipControl.SetToolTip(this.label24, "Ping frequency specifies time period between \r\neach ping requests sent to ring co" +
        "ordinator \r\nwhile reply timeout stands for maximum \r\nwaiting time until request " +
        "is considered as \r\n\"timed out\".");
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(165, 31);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(115, 17);
            this.label21.TabIndex = 43;
            this.label21.Text = "Reply timeout (s)";
            // 
            // replyTimeout
            // 
            this.replyTimeout.DecimalPlaces = 1;
            this.replyTimeout.Location = new System.Drawing.Point(168, 56);
            this.replyTimeout.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.replyTimeout.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.replyTimeout.Name = "replyTimeout";
            this.replyTimeout.Size = new System.Drawing.Size(137, 22);
            this.replyTimeout.TabIndex = 42;
            this.replyTimeout.TabStop = false;
            this.replyTimeout.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.replyTimeout.ValueChanged += new System.EventHandler(this.onReplyTimeOutValueChange);
            // 
            // disableDiagnosticPingBtn
            // 
            this.disableDiagnosticPingBtn.BackColor = System.Drawing.Color.Tan;
            this.disableDiagnosticPingBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.disableDiagnosticPingBtn.Enabled = false;
            this.disableDiagnosticPingBtn.FlatAppearance.BorderSize = 0;
            this.disableDiagnosticPingBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disableDiagnosticPingBtn.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.disableDiagnosticPingBtn.Location = new System.Drawing.Point(194, 95);
            this.disableDiagnosticPingBtn.Name = "disableDiagnosticPingBtn";
            this.disableDiagnosticPingBtn.Size = new System.Drawing.Size(85, 28);
            this.disableDiagnosticPingBtn.TabIndex = 41;
            this.disableDiagnosticPingBtn.TabStop = false;
            this.disableDiagnosticPingBtn.Text = "disable";
            this.disableDiagnosticPingBtn.UseVisualStyleBackColor = false;
            this.disableDiagnosticPingBtn.Click += new System.EventHandler(this.deactivateDiagnosticPingBtn_Click);
            // 
            // enableDiagnosticPingBtn
            // 
            this.enableDiagnosticPingBtn.BackColor = System.Drawing.Color.PaleGreen;
            this.enableDiagnosticPingBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.enableDiagnosticPingBtn.FlatAppearance.BorderColor = System.Drawing.Color.PaleGreen;
            this.enableDiagnosticPingBtn.FlatAppearance.BorderSize = 0;
            this.enableDiagnosticPingBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enableDiagnosticPingBtn.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.enableDiagnosticPingBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.enableDiagnosticPingBtn.Location = new System.Drawing.Point(84, 95);
            this.enableDiagnosticPingBtn.Name = "enableDiagnosticPingBtn";
            this.enableDiagnosticPingBtn.Size = new System.Drawing.Size(92, 29);
            this.enableDiagnosticPingBtn.TabIndex = 40;
            this.enableDiagnosticPingBtn.TabStop = false;
            this.enableDiagnosticPingBtn.Text = "enable";
            this.enableDiagnosticPingBtn.UseVisualStyleBackColor = false;
            this.enableDiagnosticPingBtn.Click += new System.EventHandler(this.activateDiagnosticPingBtn_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Sitka Small", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label20.Location = new System.Drawing.Point(34, 531);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(219, 100);
            this.label20.TabIndex = 35;
            this.label20.Text = "Important:\r\n* Successfull synchronization \r\ninitializes starting leader.\r\n* Prior" +
    "ity can be set before \r\nring synchronization.";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // resizeWindowBtn
            // 
            this.resizeWindowBtn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.resizeWindowBtn.CausesValidation = false;
            this.resizeWindowBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.resizeWindowBtn.FlatAppearance.BorderSize = 0;
            this.resizeWindowBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resizeWindowBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.resizeWindowBtn.ForeColor = System.Drawing.Color.Cornsilk;
            this.resizeWindowBtn.Location = new System.Drawing.Point(22, -13);
            this.resizeWindowBtn.Name = "resizeWindowBtn";
            this.resizeWindowBtn.Size = new System.Drawing.Size(50, 39);
            this.resizeWindowBtn.TabIndex = 42;
            this.resizeWindowBtn.TabStop = false;
            this.resizeWindowBtn.Text = "➖▶";
            this.resizeWindowBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTipControl.SetToolTip(this.resizeWindowBtn, "Show / hide log section\r\n");
            this.resizeWindowBtn.UseVisualStyleBackColor = false;
            this.resizeWindowBtn.Click += new System.EventHandler(this.resizeWindowBtn_Click);
            // 
            // toolTipControl
            // 
            this.toolTipControl.AutoPopDelay = 7500;
            this.toolTipControl.InitialDelay = 300;
            this.toolTipControl.ReshowDelay = 100;
            this.toolTipControl.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // toggleCreditsBtn
            // 
            this.toggleCreditsBtn.BackColor = System.Drawing.Color.DimGray;
            this.toggleCreditsBtn.CausesValidation = false;
            this.toggleCreditsBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.toggleCreditsBtn.FlatAppearance.BorderSize = 0;
            this.toggleCreditsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toggleCreditsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.toggleCreditsBtn.ForeColor = System.Drawing.Color.Cornsilk;
            this.toggleCreditsBtn.Location = new System.Drawing.Point(78, -13);
            this.toggleCreditsBtn.Name = "toggleCreditsBtn";
            this.toggleCreditsBtn.Size = new System.Drawing.Size(50, 39);
            this.toggleCreditsBtn.TabIndex = 43;
            this.toggleCreditsBtn.TabStop = false;
            this.toggleCreditsBtn.Text = "🔰";
            this.toggleCreditsBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTipControl.SetToolTip(this.toggleCreditsBtn, "Toggle \"credits\" section");
            this.toggleCreditsBtn.UseVisualStyleBackColor = false;
            this.toggleCreditsBtn.Click += new System.EventHandler(this.toggleCreditsBtn_Click);
            // 
            // createAppInstanceBtn
            // 
            this.createAppInstanceBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.createAppInstanceBtn.CausesValidation = false;
            this.createAppInstanceBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.createAppInstanceBtn.FlatAppearance.BorderSize = 0;
            this.createAppInstanceBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createAppInstanceBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.createAppInstanceBtn.ForeColor = System.Drawing.Color.Cornsilk;
            this.createAppInstanceBtn.Location = new System.Drawing.Point(134, -13);
            this.createAppInstanceBtn.Name = "createAppInstanceBtn";
            this.createAppInstanceBtn.Size = new System.Drawing.Size(50, 39);
            this.createAppInstanceBtn.TabIndex = 46;
            this.createAppInstanceBtn.TabStop = false;
            this.createAppInstanceBtn.Text = "🔷";
            this.createAppInstanceBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTipControl.SetToolTip(this.createAppInstanceBtn, "Instantiate app {N} times and automatically \r\ninitialize all processes.");
            this.createAppInstanceBtn.UseVisualStyleBackColor = false;
            this.createAppInstanceBtn.Click += new System.EventHandler(this.createAppInstanceBtn_Click);
            // 
            // creditsPanel
            // 
            this.creditsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.creditsPanel.Controls.Add(this.label23);
            this.creditsPanel.Controls.Add(this.label22);
            this.creditsPanel.Controls.Add(this.label14);
            this.creditsPanel.Controls.Add(this.label10);
            this.creditsPanel.Controls.Add(this.label9);
            this.creditsPanel.Location = new System.Drawing.Point(22, 42);
            this.creditsPanel.Name = "creditsPanel";
            this.creditsPanel.Size = new System.Drawing.Size(529, 201);
            this.creditsPanel.TabIndex = 44;
            this.creditsPanel.Visible = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Lucida Bright", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(215, 3);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(79, 55);
            this.label23.TabIndex = 160;
            this.label23.Text = "🎓";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Lucida Bright", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label22.Location = new System.Drawing.Point(39, 112);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(410, 17);
            this.label22.TabIndex = 159;
            this.label22.Text = "https://github.com/trolit/leader-selection-Tanenbaum";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Lucida Bright", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label14.Location = new System.Drawing.Point(143, 171);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(193, 17);
            this.label14.TabIndex = 158;
            this.label14.Text = "https://github.com/trolit";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Lucida Bright", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(176, 149);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(138, 17);
            this.label10.TabIndex = 157;
            this.label10.Text = "Pawel Idzikowski";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Lucida Bright", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(19, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(455, 34);
            this.label9.TabIndex = 156;
            this.label9.Text = "Leader Selection algorithm simulation (Tanenbaum\'s variant)\r\nin distributed syste" +
    "ms using .NET sockets.";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxConnectionStatus
            // 
            this.pictureBoxConnectionStatus.Image = global::lsa_Tanenbaum_app.Properties.Resources.status_notconnected;
            this.pictureBoxConnectionStatus.Location = new System.Drawing.Point(22, 77);
            this.pictureBoxConnectionStatus.Name = "pictureBoxConnectionStatus";
            this.pictureBoxConnectionStatus.Size = new System.Drawing.Size(13, 23);
            this.pictureBoxConnectionStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxConnectionStatus.TabIndex = 7;
            this.pictureBoxConnectionStatus.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(1255, 642);
            this.Controls.Add(this.creditsPanel);
            this.Controls.Add(this.createAppInstanceBtn);
            this.Controls.Add(this.toggleCreditsBtn);
            this.Controls.Add(this.resizeWindowBtn);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.diagnosticPingGroupBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ringSynchronizationBtn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelConnectionStatus);
            this.Controls.Add(this.pictureBoxConnectionStatus);
            this.Controls.Add(this.stopSocketBtn);
            this.Controls.Add(this.initializeSocketBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.knowledgeGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LSA - Tanenbaum";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diagnosticPingFrequency)).EndInit();
            this.knowledgeGroupBox.ResumeLayout(false);
            this.knowledgeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priorityTrackBar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.diagnosticPingGroupBox.ResumeLayout(false);
            this.diagnosticPingGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.replyTimeout)).EndInit();
            this.creditsPanel.ResumeLayout(false);
            this.creditsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConnectionStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button stopSocketBtn;
        private System.Windows.Forms.PictureBox pictureBoxConnectionStatus;
        private System.Windows.Forms.Label labelConnectionStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown diagnosticPingFrequency;
        private System.Windows.Forms.Button ringSynchronizationBtn;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textProcessName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.RichTextBox logBox;
        private System.Windows.Forms.ListBox addressesListBox;
        private System.Windows.Forms.ListBox prioritiesListBox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox knowledgeGroupBox;
        private System.Windows.Forms.Button updatePriorityBtn;
        private System.Windows.Forms.TrackBar priorityTrackBar;
        private System.Windows.Forms.TextBox textPriority;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox diagnosticPingGroupBox;
        private System.Windows.Forms.Button enableDiagnosticPingBtn;
        private System.Windows.Forms.Button disableDiagnosticPingBtn;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label ringCoordinatorAddressText;
        private System.Windows.Forms.Label ringCoordinatorPriorityText;
        private System.Windows.Forms.NumericUpDown replyTimeout;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Button resizeWindowBtn;
        private System.Windows.Forms.ToolTip toolTipControl;
        private System.Windows.Forms.Button toggleCreditsBtn;
        private System.Windows.Forms.Panel creditsPanel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button createAppInstanceBtn;
        public System.Windows.Forms.TextBox textSourceIp;
        public System.Windows.Forms.TextBox textSourcePort;
        public System.Windows.Forms.TextBox textTargetPort;
        public System.Windows.Forms.TextBox textTargetIp;
        public System.Windows.Forms.Button initializeSocketBtn;
    }
}

