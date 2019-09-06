namespace UnoTest
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblP = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.txtUsernameReg = new System.Windows.Forms.TextBox();
            this.txtPassReg = new System.Windows.Forms.TextBox();
            this.btnBackLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(208, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Register";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(104, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username";
            // 
            // lblP
            // 
            this.lblP.AutoSize = true;
            this.lblP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblP.Location = new System.Drawing.Point(104, 152);
            this.lblP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblP.Name = "lblP";
            this.lblP.Size = new System.Drawing.Size(98, 25);
            this.lblP.TabIndex = 2;
            this.lblP.Text = "Password";
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.Location = new System.Drawing.Point(216, 200);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(2);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(201, 46);
            this.btnRegister.TabIndex = 3;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // txtUsernameReg
            // 
            this.txtUsernameReg.Location = new System.Drawing.Point(216, 103);
            this.txtUsernameReg.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsernameReg.Name = "txtUsernameReg";
            this.txtUsernameReg.Size = new System.Drawing.Size(202, 20);
            this.txtUsernameReg.TabIndex = 4;
            // 
            // txtPassReg
            // 
            this.txtPassReg.Location = new System.Drawing.Point(216, 158);
            this.txtPassReg.Margin = new System.Windows.Forms.Padding(2);
            this.txtPassReg.Name = "txtPassReg";
            this.txtPassReg.PasswordChar = '*';
            this.txtPassReg.Size = new System.Drawing.Size(202, 20);
            this.txtPassReg.TabIndex = 5;
            // 
            // btnBackLog
            // 
            this.btnBackLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackLog.Location = new System.Drawing.Point(216, 266);
            this.btnBackLog.Margin = new System.Windows.Forms.Padding(2);
            this.btnBackLog.Name = "btnBackLog";
            this.btnBackLog.Size = new System.Drawing.Size(201, 40);
            this.btnBackLog.TabIndex = 6;
            this.btnBackLog.Text = "Return to log screen";
            this.btnBackLog.UseVisualStyleBackColor = true;
            this.btnBackLog.Click += new System.EventHandler(this.BtnBackLog_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.btnBackLog);
            this.Controls.Add(this.txtPassReg);
            this.Controls.Add(this.txtUsernameReg);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.lblP);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegisterForm";
            this.Text = "Register";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblP;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox txtUsernameReg;
        private System.Windows.Forms.TextBox txtPassReg;
        private System.Windows.Forms.Button btnBackLog;
    }
}