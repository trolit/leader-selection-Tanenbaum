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
            this.textProcessName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textProcessPort = new System.Windows.Forms.TextBox();
            this.textProcessIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textTargetPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textTargetIp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.connectToTargetBtn = new System.Windows.Forms.Button();
            this.listMessage = new System.Windows.Forms.ListBox();
            this.textMessage = new System.Windows.Forms.TextBox();
            this.sendMessageBtn = new System.Windows.Forms.Button();
            this.disconnectFromTargetBtn = new System.Windows.Forms.Button();
            this.pictureBoxConnectionStatus = new System.Windows.Forms.PictureBox();
            this.labelConnectionStatus = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.obtainRingBtn = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textReceiveFromPort = new System.Windows.Forms.TextBox();
            this.textReceiveFromIp = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConnectionStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textProcessName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textProcessPort);
            this.groupBox1.Controls.Add(this.textProcessIp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 90);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 207);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Process";
            // 
            // textProcessName
            // 
            this.textProcessName.Location = new System.Drawing.Point(30, 47);
            this.textProcessName.MaxLength = 25;
            this.textProcessName.Name = "textProcessName";
            this.textProcessName.Size = new System.Drawing.Size(158, 22);
            this.textProcessName.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "Name";
            // 
            // textProcessPort
            // 
            this.textProcessPort.Location = new System.Drawing.Point(30, 158);
            this.textProcessPort.MaxLength = 25;
            this.textProcessPort.Name = "textProcessPort";
            this.textProcessPort.Size = new System.Drawing.Size(158, 22);
            this.textProcessPort.TabIndex = 3;
            // 
            // textProcessIp
            // 
            this.textProcessIp.Location = new System.Drawing.Point(30, 102);
            this.textProcessIp.MaxLength = 25;
            this.textProcessIp.Name = "textProcessIp";
            this.textProcessIp.Size = new System.Drawing.Size(158, 22);
            this.textProcessIp.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "IP";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textTargetPort);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textTargetIp);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(12, 315);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(222, 155);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Target Process";
            // 
            // textTargetPort
            // 
            this.textTargetPort.Location = new System.Drawing.Point(30, 112);
            this.textTargetPort.MaxLength = 25;
            this.textTargetPort.Name = "textTargetPort";
            this.textTargetPort.Size = new System.Drawing.Size(158, 22);
            this.textTargetPort.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Port";
            // 
            // textTargetIp
            // 
            this.textTargetIp.Location = new System.Drawing.Point(30, 57);
            this.textTargetIp.MaxLength = 25;
            this.textTargetIp.Name = "textTargetIp";
            this.textTargetIp.Size = new System.Drawing.Size(158, 22);
            this.textTargetIp.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "IP";
            // 
            // connectToTargetBtn
            // 
            this.connectToTargetBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.connectToTargetBtn.Location = new System.Drawing.Point(17, 472);
            this.connectToTargetBtn.Name = "connectToTargetBtn";
            this.connectToTargetBtn.Size = new System.Drawing.Size(99, 54);
            this.connectToTargetBtn.TabIndex = 2;
            this.connectToTargetBtn.Text = "Connect";
            this.connectToTargetBtn.UseVisualStyleBackColor = true;
            this.connectToTargetBtn.Click += new System.EventHandler(this.connectToTargetBtn_Click);
            // 
            // listMessage
            // 
            this.listMessage.FormattingEnabled = true;
            this.listMessage.ItemHeight = 16;
            this.listMessage.Location = new System.Drawing.Point(809, 127);
            this.listMessage.Name = "listMessage";
            this.listMessage.Size = new System.Drawing.Size(383, 340);
            this.listMessage.TabIndex = 3;
            // 
            // textMessage
            // 
            this.textMessage.Location = new System.Drawing.Point(623, 482);
            this.textMessage.Name = "textMessage";
            this.textMessage.Size = new System.Drawing.Size(373, 22);
            this.textMessage.TabIndex = 4;
            // 
            // sendMessageBtn
            // 
            this.sendMessageBtn.Location = new System.Drawing.Point(623, 522);
            this.sendMessageBtn.Name = "sendMessageBtn";
            this.sendMessageBtn.Size = new System.Drawing.Size(109, 43);
            this.sendMessageBtn.TabIndex = 5;
            this.sendMessageBtn.Text = "msg";
            this.sendMessageBtn.UseVisualStyleBackColor = true;
            this.sendMessageBtn.Click += new System.EventHandler(this.sendMessageBtn_Click);
            // 
            // disconnectFromTargetBtn
            // 
            this.disconnectFromTargetBtn.Location = new System.Drawing.Point(122, 472);
            this.disconnectFromTargetBtn.Name = "disconnectFromTargetBtn";
            this.disconnectFromTargetBtn.Size = new System.Drawing.Size(105, 54);
            this.disconnectFromTargetBtn.TabIndex = 6;
            this.disconnectFromTargetBtn.Text = "Disconnect";
            this.disconnectFromTargetBtn.UseVisualStyleBackColor = true;
            this.disconnectFromTargetBtn.Click += new System.EventHandler(this.disconnectFromTargetBtn_Click);
            // 
            // pictureBoxConnectionStatus
            // 
            this.pictureBoxConnectionStatus.Image = global::lsa_Tanenbaum_app.Properties.Resources.status_notconnected;
            this.pictureBoxConnectionStatus.Location = new System.Drawing.Point(12, 56);
            this.pictureBoxConnectionStatus.Name = "pictureBoxConnectionStatus";
            this.pictureBoxConnectionStatus.Size = new System.Drawing.Size(13, 23);
            this.pictureBoxConnectionStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxConnectionStatus.TabIndex = 7;
            this.pictureBoxConnectionStatus.TabStop = false;
            // 
            // labelConnectionStatus
            // 
            this.labelConnectionStatus.AutoSize = true;
            this.labelConnectionStatus.Location = new System.Drawing.Point(31, 59);
            this.labelConnectionStatus.Name = "labelConnectionStatus";
            this.labelConnectionStatus.Size = new System.Drawing.Size(102, 17);
            this.labelConnectionStatus.TabIndex = 8;
            this.labelConnectionStatus.Text = "Not Connected";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(39, 20);
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
            this.label8.Location = new System.Drawing.Point(333, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(221, 31);
            this.label8.TabIndex = 11;
            this.label8.Text = "Parameters Setup";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Location = new System.Drawing.Point(277, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(5, 500);
            this.label9.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("MV Boli", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(994, 20);
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
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(339, 110);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(167, 22);
            this.numericUpDown1.TabIndex = 14;
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
            // obtainRingBtn
            // 
            this.obtainRingBtn.Location = new System.Drawing.Point(34, 542);
            this.obtainRingBtn.Name = "obtainRingBtn";
            this.obtainRingBtn.Size = new System.Drawing.Size(167, 31);
            this.obtainRingBtn.TabIndex = 17;
            this.obtainRingBtn.Text = "Obtain Ring";
            this.obtainRingBtn.UseVisualStyleBackColor = true;
            this.obtainRingBtn.Click += new System.EventHandler(this.obtainRingBtn_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(806, 71);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 17);
            this.label12.TabIndex = 18;
            this.label12.Text = "Hierarchy";
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Location = new System.Drawing.Point(17, 534);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(210, 5);
            this.label13.TabIndex = 19;
            // 
            // textReceiveFromPort
            // 
            this.textReceiveFromPort.Location = new System.Drawing.Point(318, 321);
            this.textReceiveFromPort.MaxLength = 25;
            this.textReceiveFromPort.Name = "textReceiveFromPort";
            this.textReceiveFromPort.Size = new System.Drawing.Size(158, 22);
            this.textReceiveFromPort.TabIndex = 7;
            // 
            // textReceiveFromIp
            // 
            this.textReceiveFromIp.Location = new System.Drawing.Point(318, 384);
            this.textReceiveFromIp.MaxLength = 25;
            this.textReceiveFromIp.Name = "textReceiveFromIp";
            this.textReceiveFromIp.Size = new System.Drawing.Size(158, 22);
            this.textReceiveFromIp.TabIndex = 21;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(315, 364);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(161, 17);
            this.label14.TabIndex = 20;
            this.label14.Text = "Begin Receive From (IP)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(315, 301);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(175, 17);
            this.label15.TabIndex = 22;
            this.label15.Text = "Begin Receive From (Port)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1204, 600);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.textReceiveFromIp);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textReceiveFromPort);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.obtainRingBtn);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelConnectionStatus);
            this.Controls.Add(this.pictureBoxConnectionStatus);
            this.Controls.Add(this.disconnectFromTargetBtn);
            this.Controls.Add(this.sendMessageBtn);
            this.Controls.Add(this.textMessage);
            this.Controls.Add(this.listMessage);
            this.Controls.Add(this.connectToTargetBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LSA - Tanenbaum";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConnectionStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button connectToTargetBtn;
        private System.Windows.Forms.TextBox textProcessPort;
        private System.Windows.Forms.TextBox textProcessIp;
        private System.Windows.Forms.TextBox textTargetPort;
        private System.Windows.Forms.TextBox textTargetIp;
        private System.Windows.Forms.ListBox listMessage;
        private System.Windows.Forms.TextBox textMessage;
        private System.Windows.Forms.Button sendMessageBtn;
        private System.Windows.Forms.Button disconnectFromTargetBtn;
        private System.Windows.Forms.PictureBox pictureBoxConnectionStatus;
        private System.Windows.Forms.Label labelConnectionStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textProcessName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Button obtainRingBtn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textReceiveFromPort;
        private System.Windows.Forms.TextBox textReceiveFromIp;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
    }
}

