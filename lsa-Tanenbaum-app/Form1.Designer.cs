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
            this.textReceiveFromIp = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.textTargetIp = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textProcessName = new System.Windows.Forms.TextBox();
            this.textReceiveFromPort = new System.Windows.Forms.TextBox();
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
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numPriority = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.ringSynchronizationBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.addressesListBox = new System.Windows.Forms.ListBox();
            this.prioritiesListBox = new System.Windows.Forms.ListBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.knowledgeGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConnectionStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPriority)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.knowledgeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.textTargetPort);
            this.groupBox1.Controls.Add(this.textReceiveFromIp);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.textTargetIp);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textProcessName);
            this.groupBox1.Controls.Add(this.textReceiveFromPort);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textProcessPort);
            this.groupBox1.Controls.Add(this.textProcessIp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 270);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Process";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 17);
            this.label4.TabIndex = 24;
            this.label4.Text = ":";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(172, 214);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(12, 17);
            this.label13.TabIndex = 23;
            this.label13.Text = ":";
            // 
            // textTargetPort
            // 
            this.textTargetPort.Location = new System.Drawing.Point(187, 211);
            this.textTargetPort.MaxLength = 6;
            this.textTargetPort.Name = "textTargetPort";
            this.textTargetPort.Size = new System.Drawing.Size(54, 22);
            this.textTargetPort.TabIndex = 7;
            this.textTargetPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textTargetPort.TextChanged += new System.EventHandler(this.processConfigChanged);
            // 
            // textReceiveFromIp
            // 
            this.textReceiveFromIp.Location = new System.Drawing.Point(10, 157);
            this.textReceiveFromIp.MaxLength = 25;
            this.textReceiveFromIp.Name = "textReceiveFromIp";
            this.textReceiveFromIp.Size = new System.Drawing.Size(158, 22);
            this.textReceiveFromIp.TabIndex = 4;
            this.textReceiveFromIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textReceiveFromIp.TextChanged += new System.EventHandler(this.processConfigChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(172, 160);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(12, 17);
            this.label15.TabIndex = 22;
            this.label15.Text = ":";
            // 
            // textTargetIp
            // 
            this.textTargetIp.Location = new System.Drawing.Point(10, 211);
            this.textTargetIp.MaxLength = 25;
            this.textTargetIp.Name = "textTargetIp";
            this.textTargetIp.Size = new System.Drawing.Size(158, 22);
            this.textTargetIp.TabIndex = 6;
            this.textTargetIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textTargetIp.TextChanged += new System.EventHandler(this.processConfigChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 137);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(91, 17);
            this.label14.TabIndex = 20;
            this.label14.Text = "Receive from";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 191);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Send to";
            // 
            // textProcessName
            // 
            this.textProcessName.Location = new System.Drawing.Point(10, 48);
            this.textProcessName.MaxLength = 25;
            this.textProcessName.Name = "textProcessName";
            this.textProcessName.Size = new System.Drawing.Size(158, 22);
            this.textProcessName.TabIndex = 1;
            this.textProcessName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textProcessName.TextChanged += new System.EventHandler(this.processConfigChanged);
            // 
            // textReceiveFromPort
            // 
            this.textReceiveFromPort.Location = new System.Drawing.Point(187, 157);
            this.textReceiveFromPort.MaxLength = 6;
            this.textReceiveFromPort.Name = "textReceiveFromPort";
            this.textReceiveFromPort.Size = new System.Drawing.Size(54, 22);
            this.textReceiveFromPort.TabIndex = 5;
            this.textReceiveFromPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textReceiveFromPort.TextChanged += new System.EventHandler(this.processConfigChanged);
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
            this.textProcessPort.Location = new System.Drawing.Point(187, 103);
            this.textProcessPort.MaxLength = 6;
            this.textProcessPort.Name = "textProcessPort";
            this.textProcessPort.Size = new System.Drawing.Size(54, 22);
            this.textProcessPort.TabIndex = 3;
            this.textProcessPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textProcessPort.TextChanged += new System.EventHandler(this.processConfigChanged);
            // 
            // textProcessIp
            // 
            this.textProcessIp.Location = new System.Drawing.Point(10, 102);
            this.textProcessIp.MaxLength = 25;
            this.textProcessIp.Name = "textProcessIp";
            this.textProcessIp.Size = new System.Drawing.Size(158, 22);
            this.textProcessIp.TabIndex = 2;
            this.textProcessIp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textProcessIp.TextChanged += new System.EventHandler(this.processConfigChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Address";
            // 
            // connectToTargetBtn
            // 
            this.connectToTargetBtn.Enabled = false;
            this.connectToTargetBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.connectToTargetBtn.Location = new System.Drawing.Point(104, 354);
            this.connectToTargetBtn.Name = "connectToTargetBtn";
            this.connectToTargetBtn.Size = new System.Drawing.Size(127, 56);
            this.connectToTargetBtn.TabIndex = 2;
            this.connectToTargetBtn.Text = "Connect";
            this.connectToTargetBtn.UseVisualStyleBackColor = true;
            this.connectToTargetBtn.Click += new System.EventHandler(this.connectToTargetBtn_Click);
            // 
            // disconnectFromTargetBtn
            // 
            this.disconnectFromTargetBtn.BackColor = System.Drawing.Color.PaleVioletRed;
            this.disconnectFromTargetBtn.FlatAppearance.BorderSize = 0;
            this.disconnectFromTargetBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.disconnectFromTargetBtn.Location = new System.Drawing.Point(161, 39);
            this.disconnectFromTargetBtn.Name = "disconnectFromTargetBtn";
            this.disconnectFromTargetBtn.Size = new System.Drawing.Size(92, 26);
            this.disconnectFromTargetBtn.TabIndex = 6;
            this.disconnectFromTargetBtn.Text = "Disconnect";
            this.disconnectFromTargetBtn.UseVisualStyleBackColor = false;
            this.disconnectFromTargetBtn.Click += new System.EventHandler(this.disconnectFromTargetBtn_Click);
            // 
            // pictureBoxConnectionStatus
            // 
            this.pictureBoxConnectionStatus.Image = global::lsa_Tanenbaum_app.Properties.Resources.status_notconnected;
            this.pictureBoxConnectionStatus.Location = new System.Drawing.Point(12, 39);
            this.pictureBoxConnectionStatus.Name = "pictureBoxConnectionStatus";
            this.pictureBoxConnectionStatus.Size = new System.Drawing.Size(13, 23);
            this.pictureBoxConnectionStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxConnectionStatus.TabIndex = 7;
            this.pictureBoxConnectionStatus.TabStop = false;
            // 
            // labelConnectionStatus
            // 
            this.labelConnectionStatus.AutoSize = true;
            this.labelConnectionStatus.Location = new System.Drawing.Point(31, 42);
            this.labelConnectionStatus.Name = "labelConnectionStatus";
            this.labelConnectionStatus.Size = new System.Drawing.Size(102, 17);
            this.labelConnectionStatus.TabIndex = 8;
            this.labelConnectionStatus.Text = "Not Connected";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(39, 6);
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
            this.label8.Location = new System.Drawing.Point(333, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(221, 31);
            this.label8.TabIndex = 11;
            this.label8.Text = "Parameters Setup";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(291, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(5, 500);
            this.label9.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(994, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 31);
            this.label10.TabIndex = 13;
            this.label10.Text = "Log";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(336, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 6;
            this.label5.Text = "Priority";
            // 
            // numPriority
            // 
            this.numPriority.Location = new System.Drawing.Point(339, 110);
            this.numPriority.Name = "numPriority";
            this.numPriority.Size = new System.Drawing.Size(167, 22);
            this.numPriority.TabIndex = 14;
            this.numPriority.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(336, 153);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 17);
            this.label11.TabIndex = 15;
            this.label11.Text = "Ping frequency (s)";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(339, 177);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(167, 22);
            this.numericUpDown2.TabIndex = 16;
            // 
            // ringSynchronizationBtn
            // 
            this.ringSynchronizationBtn.Enabled = false;
            this.ringSynchronizationBtn.Location = new System.Drawing.Point(104, 435);
            this.ringSynchronizationBtn.Name = "ringSynchronizationBtn";
            this.ringSynchronizationBtn.Size = new System.Drawing.Size(127, 56);
            this.ringSynchronizationBtn.TabIndex = 17;
            this.ringSynchronizationBtn.Text = "Ring sync.";
            this.ringSynchronizationBtn.UseVisualStyleBackColor = true;
            this.ringSynchronizationBtn.Click += new System.EventHandler(this.ringSynchronizationBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Leelawadee", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(48, 364);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 36);
            this.label1.TabIndex = 25;
            this.label1.Text = "1.";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Leelawadee", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(48, 445);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 36);
            this.label16.TabIndex = 26;
            this.label16.Text = "2.";
            // 
            // logBox
            // 
            this.logBox.BackColor = System.Drawing.Color.LightGray;
            this.logBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.logBox.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.logBox.HideSelection = false;
            this.logBox.Location = new System.Drawing.Point(694, 96);
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.Size = new System.Drawing.Size(498, 480);
            this.logBox.TabIndex = 27;
            this.logBox.Text = "// ------------------------------------------\n// LSA - Tanenbaum log\n// ---------" +
    "---------------------------------\n";
            this.logBox.WordWrap = false;
            // 
            // addressesListBox
            // 
            this.addressesListBox.BackColor = System.Drawing.SystemColors.Control;
            this.addressesListBox.FormattingEnabled = true;
            this.addressesListBox.ItemHeight = 16;
            this.addressesListBox.Location = new System.Drawing.Point(21, 62);
            this.addressesListBox.Name = "addressesListBox";
            this.addressesListBox.Size = new System.Drawing.Size(191, 148);
            this.addressesListBox.TabIndex = 30;
            // 
            // prioritiesListBox
            // 
            this.prioritiesListBox.BackColor = System.Drawing.SystemColors.Control;
            this.prioritiesListBox.FormattingEnabled = true;
            this.prioritiesListBox.ItemHeight = 16;
            this.prioritiesListBox.Location = new System.Drawing.Point(218, 62);
            this.prioritiesListBox.Name = "prioritiesListBox";
            this.prioritiesListBox.Size = new System.Drawing.Size(41, 148);
            this.prioritiesListBox.TabIndex = 31;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(18, 42);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(75, 17);
            this.label17.TabIndex = 32;
            this.label17.Text = "Addresses";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(207, 42);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(63, 17);
            this.label18.TabIndex = 34;
            this.label18.Text = "Priorities";
            // 
            // knowledgeGroupBox
            // 
            this.knowledgeGroupBox.Controls.Add(this.label18);
            this.knowledgeGroupBox.Controls.Add(this.label17);
            this.knowledgeGroupBox.Controls.Add(this.addressesListBox);
            this.knowledgeGroupBox.Controls.Add(this.prioritiesListBox);
            this.knowledgeGroupBox.Location = new System.Drawing.Point(399, 334);
            this.knowledgeGroupBox.Name = "knowledgeGroupBox";
            this.knowledgeGroupBox.Size = new System.Drawing.Size(289, 242);
            this.knowledgeGroupBox.TabIndex = 35;
            this.knowledgeGroupBox.TabStop = false;
            this.knowledgeGroupBox.Text = "My knowledge";
            this.knowledgeGroupBox.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 635);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ringSynchronizationBtn);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.numPriority);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
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
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LSA - Tanenbaum";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConnectionStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPriority)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.knowledgeGroupBox.ResumeLayout(false);
            this.knowledgeGroupBox.PerformLayout();
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
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numPriority;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Button ringSynchronizationBtn;
        private System.Windows.Forms.TextBox textReceiveFromPort;
        private System.Windows.Forms.TextBox textReceiveFromIp;
        private System.Windows.Forms.Label label14;
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
    }
}

