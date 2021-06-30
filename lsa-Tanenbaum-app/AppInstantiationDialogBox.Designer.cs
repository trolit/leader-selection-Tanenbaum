
namespace lsa_Tanenbaum_app
{
    partial class AppInstantiationDialogBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppInstantiationDialogBox));
            this.executeBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numberOfInstancesNumeric = new System.Windows.Forms.NumericUpDown();
            this.baseIpTextBox = new System.Windows.Forms.TextBox();
            this.basePortTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfInstancesNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // executeBtn
            // 
            this.executeBtn.BackColor = System.Drawing.Color.Chartreuse;
            this.executeBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.executeBtn.FlatAppearance.BorderSize = 0;
            this.executeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.executeBtn.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.executeBtn.Location = new System.Drawing.Point(34, 194);
            this.executeBtn.Name = "executeBtn";
            this.executeBtn.Size = new System.Drawing.Size(111, 36);
            this.executeBtn.TabIndex = 3;
            this.executeBtn.TabStop = false;
            this.executeBtn.Text = "execute";
            this.executeBtn.UseVisualStyleBackColor = false;
            this.executeBtn.Click += new System.EventHandler(this.executeBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.LightCoral;
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.cancelBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelBtn.Font = new System.Drawing.Font("Malgun Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelBtn.Location = new System.Drawing.Point(260, 205);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(85, 25);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.TabStop = false;
            this.cancelBtn.Text = "cancel";
            this.cancelBtn.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-2, 56);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label1.Size = new System.Drawing.Size(385, 46);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fill in base address, port and number of instances to launch and press \'execute\' " +
    "to proceed";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(3, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(380, 48);
            this.label2.TabIndex = 4;
            this.label2.Text = "💬";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numberOfInstancesNumeric
            // 
            this.numberOfInstancesNumeric.Location = new System.Drawing.Point(270, 138);
            this.numberOfInstancesNumeric.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numberOfInstancesNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberOfInstancesNumeric.Name = "numberOfInstancesNumeric";
            this.numberOfInstancesNumeric.Size = new System.Drawing.Size(75, 22);
            this.numberOfInstancesNumeric.TabIndex = 2;
            this.numberOfInstancesNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numberOfInstancesNumeric.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // baseIpTextBox
            // 
            this.baseIpTextBox.Location = new System.Drawing.Point(37, 137);
            this.baseIpTextBox.MaxLength = 15;
            this.baseIpTextBox.Name = "baseIpTextBox";
            this.baseIpTextBox.Size = new System.Drawing.Size(137, 22);
            this.baseIpTextBox.TabIndex = 0;
            this.baseIpTextBox.Text = "255.255.255.255";
            this.baseIpTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // basePortTextBox
            // 
            this.basePortTextBox.Location = new System.Drawing.Point(186, 137);
            this.basePortTextBox.MaxLength = 5;
            this.basePortTextBox.Name = "basePortTextBox";
            this.basePortTextBox.Size = new System.Drawing.Size(72, 22);
            this.basePortTextBox.TabIndex = 1;
            this.basePortTextBox.Text = "80";
            this.basePortTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(37, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "IP address";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(186, 117);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Port";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(270, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Instances";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(-2, 240);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.label6.Size = new System.Drawing.Size(385, 46);
            this.label6.TabIndex = 10;
            this.label6.Text = "On execute, all processes will be initialized automatically.";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AppInstantiationDialogBox
            // 
            this.AcceptButton = this.executeBtn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(383, 277);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.basePortTextBox);
            this.Controls.Add(this.baseIpTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numberOfInstancesNumeric);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.executeBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AppInstantiationDialogBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LSA - Tanenbaum";
            ((System.ComponentModel.ISupportInitialize)(this.numberOfInstancesNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button executeBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numberOfInstancesNumeric;
        private System.Windows.Forms.TextBox baseIpTextBox;
        private System.Windows.Forms.TextBox basePortTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}