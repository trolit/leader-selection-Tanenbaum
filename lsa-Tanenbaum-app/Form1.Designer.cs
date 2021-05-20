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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textTargetPort = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textTargetIp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textProcessName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textProcessPort = new System.Windows.Forms.TextBox();
            this.textProcessIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.connectToTargetBtn = new System.Windows.Forms.Button();
            this.disconnectFromTargetBtn = new System.Windows.Forms.Button();
            this.pictureBoxConnectionStatus = new System.Windows.Forms.PictureBox();
            this.labelConnectionStatus = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
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
            this.ringCoordinatorPriorityText = new System.Windows.Forms.Label();
            this.ringCoordinatorAddressText = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.updatePriorityBtn = new System.Windows.Forms.Button();
            this.priorityTrackBar = new System.Windows.Forms.TrackBar();
            this.textPriority = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.diagnosticPingGroupBox = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.replyTimeout = new System.Windows.Forms.NumericUpDown();
            this.disableDiagnosticPingBtn = new System.Windows.Forms.Button();
            this.enableDiagnosticPingBtn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConnectionStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnosticPingFrequency)).BeginInit();
            this.knowledgeGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priorityTrackBar)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.diagnosticPingGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.replyTimeout)).BeginInit();
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
            this.groupBox1.Controls.Add(this.textProcessPort);
            this.groupBox1.Controls.Add(this.textProcessIp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textTargetPort);
            this.groupBox1.Location = new System.Drawing.Point(12, 100);
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
            // textTargetPort
            // 
            this.textTargetPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTargetPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textTargetPort.Location = new System.Drawing.Point(187, 165);
            this.textTargetPort.MaxLength = 6;
            this.textTargetPort.Name = "textTargetPort";
            this.textTargetPort.Size = new System.Drawing.Size(54, 24);
            this.textTargetPort.TabIndex = 7;
            this.textTargetPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textTargetPort.TextChanged += new System.EventHandler(this.processConfigChanged);
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
            this.textTargetIp.MaxLength = 25;
            this.textTargetIp.Name = "textTargetIp";
            this.textTargetIp.Size = new System.Drawing.Size(158, 24);
            this.textTargetIp.TabIndex = 6;
            this.textTargetIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textTargetIp.TextChanged += new System.EventHandler(this.processConfigChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Send to";
            // 
            // textProcessName
            // 
            this.textProcessName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textProcessName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textProcessName.Location = new System.Drawing.Point(10, 48);
            this.textProcessName.MaxLength = 25;
            this.textProcessName.Name = "textProcessName";
            this.textProcessName.Size = new System.Drawing.Size(158, 24);
            this.textProcessName.TabIndex = 1;
            this.textProcessName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textProcessName.TextChanged += new System.EventHandler(this.processConfigChanged);
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
            // textProcessPort
            // 
            this.textProcessPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textProcessPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textProcessPort.Location = new System.Drawing.Point(187, 108);
            this.textProcessPort.MaxLength = 6;
            this.textProcessPort.Name = "textProcessPort";
            this.textProcessPort.Size = new System.Drawing.Size(54, 24);
            this.textProcessPort.TabIndex = 3;
            this.textProcessPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textProcessPort.TextChanged += new System.EventHandler(this.processConfigChanged);
            // 
            // textProcessIp
            // 
            this.textProcessIp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textProcessIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textProcessIp.Location = new System.Drawing.Point(10, 107);
            this.textProcessIp.MaxLength = 25;
            this.textProcessIp.Name = "textProcessIp";
            this.textProcessIp.Size = new System.Drawing.Size(158, 24);
            this.textProcessIp.TabIndex = 2;
            this.textProcessIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textProcessIp.TextChanged += new System.EventHandler(this.processConfigChanged);
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
            // connectToTargetBtn
            // 
            this.connectToTargetBtn.CausesValidation = false;
            this.connectToTargetBtn.Enabled = false;
            this.connectToTargetBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.connectToTargetBtn.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.connectToTargetBtn.Location = new System.Drawing.Point(104, 416);
            this.connectToTargetBtn.Name = "connectToTargetBtn";
            this.connectToTargetBtn.Size = new System.Drawing.Size(127, 56);
            this.connectToTargetBtn.TabIndex = 2;
            this.connectToTargetBtn.TabStop = false;
            this.connectToTargetBtn.Text = "Connect";
            this.connectToTargetBtn.UseVisualStyleBackColor = true;
            this.connectToTargetBtn.Click += new System.EventHandler(this.connectToTargetBtn_Click);
            // 
            // disconnectFromTargetBtn
            // 
            this.disconnectFromTargetBtn.BackColor = System.Drawing.Color.LightGray;
            this.disconnectFromTargetBtn.CausesValidation = false;
            this.disconnectFromTargetBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.disconnectFromTargetBtn.FlatAppearance.BorderSize = 0;
            this.disconnectFromTargetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.disconnectFromTargetBtn.Location = new System.Drawing.Point(161, 68);
            this.disconnectFromTargetBtn.Name = "disconnectFromTargetBtn";
            this.disconnectFromTargetBtn.Size = new System.Drawing.Size(110, 26);
            this.disconnectFromTargetBtn.TabIndex = 6;
            this.disconnectFromTargetBtn.TabStop = false;
            this.disconnectFromTargetBtn.Text = "Disconnect";
            this.disconnectFromTargetBtn.UseVisualStyleBackColor = false;
            this.disconnectFromTargetBtn.Click += new System.EventHandler(this.disconnectFromTargetBtn_Click);
            // 
            // pictureBoxConnectionStatus
            // 
            this.pictureBoxConnectionStatus.Image = global::lsa_Tanenbaum_app.Properties.Resources.status_notconnected;
            this.pictureBoxConnectionStatus.Location = new System.Drawing.Point(12, 68);
            this.pictureBoxConnectionStatus.Name = "pictureBoxConnectionStatus";
            this.pictureBoxConnectionStatus.Size = new System.Drawing.Size(13, 23);
            this.pictureBoxConnectionStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxConnectionStatus.TabIndex = 7;
            this.pictureBoxConnectionStatus.TabStop = false;
            // 
            // labelConnectionStatus
            // 
            this.labelConnectionStatus.AutoSize = true;
            this.labelConnectionStatus.Location = new System.Drawing.Point(31, 71);
            this.labelConnectionStatus.Name = "labelConnectionStatus";
            this.labelConnectionStatus.Size = new System.Drawing.Size(102, 17);
            this.labelConnectionStatus.TabIndex = 8;
            this.labelConnectionStatus.Text = "Not Connected";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(70, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 31);
            this.label6.TabIndex = 10;
            this.label6.Text = "Configuration";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(393, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(221, 31);
            this.label8.TabIndex = 11;
            this.label8.Text = "Parameters Setup";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(284, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(5, 500);
            this.label9.TabIndex = 12;
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
            // 
            // ringSynchronizationBtn
            // 
            this.ringSynchronizationBtn.CausesValidation = false;
            this.ringSynchronizationBtn.Enabled = false;
            this.ringSynchronizationBtn.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ringSynchronizationBtn.Location = new System.Drawing.Point(104, 497);
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
            this.label1.Location = new System.Drawing.Point(48, 426);
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
            this.label16.Location = new System.Drawing.Point(48, 507);
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
            this.logBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.logBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.logBox.HideSelection = false;
            this.logBox.Location = new System.Drawing.Point(709, 100);
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.Size = new System.Drawing.Size(487, 505);
            this.logBox.TabIndex = 27;
            this.logBox.TabStop = false;
            this.logBox.Text = "// *********************************************\n// LSA - Tanenbaum\n// **********" +
    "***********************************\n";
            this.logBox.WordWrap = false;
            // 
            // addressesListBox
            // 
            this.addressesListBox.BackColor = System.Drawing.SystemColors.Control;
            this.addressesListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.addressesListBox.FormattingEnabled = true;
            this.addressesListBox.ItemHeight = 16;
            this.addressesListBox.Location = new System.Drawing.Point(67, 45);
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
            this.prioritiesListBox.Location = new System.Drawing.Point(264, 45);
            this.prioritiesListBox.Name = "prioritiesListBox";
            this.prioritiesListBox.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.prioritiesListBox.Size = new System.Drawing.Size(41, 114);
            this.prioritiesListBox.TabIndex = 31;
            this.prioritiesListBox.TabStop = false;
            this.prioritiesListBox.UseTabStops = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(125, 25);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(75, 17);
            this.label17.TabIndex = 32;
            this.label17.Text = "Addresses";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(253, 25);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 17);
            this.label18.TabIndex = 34;
            this.label18.Text = "Priorities";
            // 
            // knowledgeGroupBox
            // 
            this.knowledgeGroupBox.Controls.Add(this.ringCoordinatorPriorityText);
            this.knowledgeGroupBox.Controls.Add(this.ringCoordinatorAddressText);
            this.knowledgeGroupBox.Controls.Add(this.label33);
            this.knowledgeGroupBox.Controls.Add(this.label18);
            this.knowledgeGroupBox.Controls.Add(this.label17);
            this.knowledgeGroupBox.Controls.Add(this.addressesListBox);
            this.knowledgeGroupBox.Controls.Add(this.prioritiesListBox);
            this.knowledgeGroupBox.Location = new System.Drawing.Point(305, 393);
            this.knowledgeGroupBox.Name = "knowledgeGroupBox";
            this.knowledgeGroupBox.Size = new System.Drawing.Size(370, 211);
            this.knowledgeGroupBox.TabIndex = 35;
            this.knowledgeGroupBox.TabStop = false;
            this.knowledgeGroupBox.Text = "My knowledge";
            this.knowledgeGroupBox.Visible = false;
            // 
            // ringCoordinatorPriorityText
            // 
            this.ringCoordinatorPriorityText.AutoSize = true;
            this.ringCoordinatorPriorityText.Location = new System.Drawing.Point(100, 188);
            this.ringCoordinatorPriorityText.Name = "ringCoordinatorPriorityText";
            this.ringCoordinatorPriorityText.Size = new System.Drawing.Size(169, 17);
            this.ringCoordinatorPriorityText.TabIndex = 37;
            this.ringCoordinatorPriorityText.Text = "with priority 50 (12:02:22)";
            // 
            // ringCoordinatorAddressText
            // 
            this.ringCoordinatorAddressText.AutoSize = true;
            this.ringCoordinatorAddressText.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ringCoordinatorAddressText.Location = new System.Drawing.Point(201, 171);
            this.ringCoordinatorAddressText.Name = "ringCoordinatorAddressText";
            this.ringCoordinatorAddressText.Size = new System.Drawing.Size(109, 17);
            this.ringCoordinatorAddressText.TabIndex = 36;
            this.ringCoordinatorAddressText.Text = "0.0.0.0:00000";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(58, 171);
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
            this.updatePriorityBtn.Location = new System.Drawing.Point(11, 93);
            this.updatePriorityBtn.Name = "updatePriorityBtn";
            this.updatePriorityBtn.Size = new System.Drawing.Size(336, 29);
            this.updatePriorityBtn.TabIndex = 36;
            this.updatePriorityBtn.TabStop = false;
            this.updatePriorityBtn.Text = "call priority update";
            this.updatePriorityBtn.UseVisualStyleBackColor = true;
            this.updatePriorityBtn.Click += new System.EventHandler(this.callPriorityUpdateBtn_Click);
            // 
            // priorityTrackBar
            // 
            this.priorityTrackBar.Location = new System.Drawing.Point(0, 48);
            this.priorityTrackBar.Maximum = 100;
            this.priorityTrackBar.Minimum = 1;
            this.priorityTrackBar.Name = "priorityTrackBar";
            this.priorityTrackBar.Size = new System.Drawing.Size(289, 56);
            this.priorityTrackBar.TabIndex = 37;
            this.priorityTrackBar.TabStop = false;
            this.priorityTrackBar.Value = 5;
            this.priorityTrackBar.ValueChanged += new System.EventHandler(this.onPriorityTrackBarValueChange);
            // 
            // textPriority
            // 
            this.textPriority.Location = new System.Drawing.Point(298, 59);
            this.textPriority.MaxLength = 5;
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
            this.groupBox2.Controls.Add(this.updatePriorityBtn);
            this.groupBox2.Controls.Add(this.priorityTrackBar);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.textPriority);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Location = new System.Drawing.Point(305, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(370, 136);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Priority";
            // 
            // diagnosticPingGroupBox
            // 
            this.diagnosticPingGroupBox.Controls.Add(this.label21);
            this.diagnosticPingGroupBox.Controls.Add(this.replyTimeout);
            this.diagnosticPingGroupBox.Controls.Add(this.disableDiagnosticPingBtn);
            this.diagnosticPingGroupBox.Controls.Add(this.enableDiagnosticPingBtn);
            this.diagnosticPingGroupBox.Controls.Add(this.label11);
            this.diagnosticPingGroupBox.Controls.Add(this.diagnosticPingFrequency);
            this.diagnosticPingGroupBox.Location = new System.Drawing.Point(305, 257);
            this.diagnosticPingGroupBox.Name = "diagnosticPingGroupBox";
            this.diagnosticPingGroupBox.Size = new System.Drawing.Size(370, 130);
            this.diagnosticPingGroupBox.TabIndex = 41;
            this.diagnosticPingGroupBox.TabStop = false;
            this.diagnosticPingGroupBox.Text = "Diagnostic ping";
            this.diagnosticPingGroupBox.Visible = false;
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
            // label10
            // 
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Location = new System.Drawing.Point(688, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(5, 500);
            this.label10.TabIndex = 42;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Sitka Small", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label20.Location = new System.Drawing.Point(50, 575);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(203, 40);
            this.label20.TabIndex = 35;
            this.label20.Text = "Successfull synchronization\r\ninitializes starting leader.";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1204, 635);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.diagnosticPingGroupBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ringSynchronizationBtn);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelConnectionStatus);
            this.Controls.Add(this.pictureBoxConnectionStatus);
            this.Controls.Add(this.disconnectFromTargetBtn);
            this.Controls.Add(this.connectToTargetBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.knowledgeGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LSA - Tanenbaum";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConnectionStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diagnosticPingFrequency)).EndInit();
            this.knowledgeGroupBox.ResumeLayout(false);
            this.knowledgeGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.priorityTrackBar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.diagnosticPingGroupBox.ResumeLayout(false);
            this.diagnosticPingGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.replyTimeout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button connectToTargetBtn;
        private System.Windows.Forms.TextBox textProcessPort;
        private System.Windows.Forms.TextBox textProcessIp;
        private System.Windows.Forms.TextBox textTargetPort;
        private System.Windows.Forms.TextBox textTargetIp;
        private System.Windows.Forms.Button disconnectFromTargetBtn;
        private System.Windows.Forms.PictureBox pictureBoxConnectionStatus;
        private System.Windows.Forms.Label labelConnectionStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
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
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label ringCoordinatorAddressText;
        private System.Windows.Forms.Label ringCoordinatorPriorityText;
        private System.Windows.Forms.NumericUpDown replyTimeout;
        private System.Windows.Forms.Label label21;
    }
}

