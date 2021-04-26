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
            this.textProcessPort = new System.Windows.Forms.TextBox();
            this.textProcessIp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textSourcePort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textSourceIp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.connectToTargetBtn = new System.Windows.Forms.Button();
            this.listMessage = new System.Windows.Forms.ListBox();
            this.textMessage = new System.Windows.Forms.TextBox();
            this.sendMessageBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textProcessPort);
            this.groupBox1.Controls.Add(this.textProcessIp);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 155);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Process";
            // 
            // textProcessPort
            // 
            this.textProcessPort.Location = new System.Drawing.Point(119, 87);
            this.textProcessPort.Name = "textProcessPort";
            this.textProcessPort.Size = new System.Drawing.Size(130, 22);
            this.textProcessPort.TabIndex = 3;
            // 
            // textProcessIp
            // 
            this.textProcessIp.Location = new System.Drawing.Point(119, 37);
            this.textProcessIp.Name = "textProcessIp";
            this.textProcessIp.Size = new System.Drawing.Size(130, 22);
            this.textProcessIp.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Process Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Process IP";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textSourcePort);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textSourceIp);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(369, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(320, 155);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Target";
            // 
            // textSourcePort
            // 
            this.textSourcePort.Location = new System.Drawing.Point(137, 87);
            this.textSourcePort.Name = "textSourcePort";
            this.textSourcePort.Size = new System.Drawing.Size(100, 22);
            this.textSourcePort.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Target Port";
            // 
            // textSourceIp
            // 
            this.textSourceIp.Location = new System.Drawing.Point(137, 37);
            this.textSourceIp.Name = "textSourceIp";
            this.textSourceIp.Size = new System.Drawing.Size(100, 22);
            this.textSourceIp.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Target IP";
            // 
            // connectToTargetBtn
            // 
            this.connectToTargetBtn.Location = new System.Drawing.Point(713, 12);
            this.connectToTargetBtn.Name = "connectToTargetBtn";
            this.connectToTargetBtn.Size = new System.Drawing.Size(127, 54);
            this.connectToTargetBtn.TabIndex = 2;
            this.connectToTargetBtn.Text = "Connect";
            this.connectToTargetBtn.UseVisualStyleBackColor = true;
            this.connectToTargetBtn.Click += new System.EventHandler(this.connectToTargetBtn_Click);
            // 
            // listMessage
            // 
            this.listMessage.FormattingEnabled = true;
            this.listMessage.ItemHeight = 16;
            this.listMessage.Location = new System.Drawing.Point(623, 201);
            this.listMessage.Name = "listMessage";
            this.listMessage.Size = new System.Drawing.Size(373, 212);
            this.listMessage.TabIndex = 3;
            // 
            // textMessage
            // 
            this.textMessage.Location = new System.Drawing.Point(623, 429);
            this.textMessage.Name = "textMessage";
            this.textMessage.Size = new System.Drawing.Size(373, 22);
            this.textMessage.TabIndex = 4;
            // 
            // sendMessageBtn
            // 
            this.sendMessageBtn.Location = new System.Drawing.Point(623, 469);
            this.sendMessageBtn.Name = "sendMessageBtn";
            this.sendMessageBtn.Size = new System.Drawing.Size(109, 43);
            this.sendMessageBtn.TabIndex = 5;
            this.sendMessageBtn.Text = "msg";
            this.sendMessageBtn.UseVisualStyleBackColor = true;
            this.sendMessageBtn.Click += new System.EventHandler(this.sendMessageBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 556);
            this.Controls.Add(this.sendMessageBtn);
            this.Controls.Add(this.textMessage);
            this.Controls.Add(this.listMessage);
            this.Controls.Add(this.connectToTargetBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "LSA - Tanenbaum";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.TextBox textSourcePort;
        private System.Windows.Forms.TextBox textSourceIp;
        private System.Windows.Forms.ListBox listMessage;
        private System.Windows.Forms.TextBox textMessage;
        private System.Windows.Forms.Button sendMessageBtn;
    }
}

