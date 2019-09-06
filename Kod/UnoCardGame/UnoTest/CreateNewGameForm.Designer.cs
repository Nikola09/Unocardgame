namespace UnoTest
{
    partial class CreateNewGameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateNewGameForm));
            this.lblNewGame = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnCreateNewGame = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblMaxP = new System.Windows.Forms.Label();
            this.dUpDown = new System.Windows.Forms.DomainUpDown();
            this.SuspendLayout();
            // 
            // lblNewGame
            // 
            this.lblNewGame.AutoSize = true;
            this.lblNewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewGame.Location = new System.Drawing.Point(79, 7);
            this.lblNewGame.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNewGame.Name = "lblNewGame";
            this.lblNewGame.Size = new System.Drawing.Size(466, 63);
            this.lblNewGame.TabIndex = 0;
            this.lblNewGame.Text = "Create new game";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(86, 101);
            this.lblName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(108, 39);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(205, 101);
            this.txtName.Margin = new System.Windows.Forms.Padding(2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(305, 38);
            this.txtName.TabIndex = 2;
            // 
            // btnCreateNewGame
            // 
            this.btnCreateNewGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateNewGame.Location = new System.Drawing.Point(92, 254);
            this.btnCreateNewGame.Margin = new System.Windows.Forms.Padding(2);
            this.btnCreateNewGame.Name = "btnCreateNewGame";
            this.btnCreateNewGame.Size = new System.Drawing.Size(158, 42);
            this.btnCreateNewGame.TabIndex = 3;
            this.btnCreateNewGame.Text = "Create game";
            this.btnCreateNewGame.UseVisualStyleBackColor = true;
            this.btnCreateNewGame.Click += new System.EventHandler(this.BtnCreateNewGame_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(368, 254);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(141, 42);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // lblMaxP
            // 
            this.lblMaxP.AutoSize = true;
            this.lblMaxP.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxP.Location = new System.Drawing.Point(86, 176);
            this.lblMaxP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMaxP.Name = "lblMaxP";
            this.lblMaxP.Size = new System.Drawing.Size(192, 39);
            this.lblMaxP.TabIndex = 5;
            this.lblMaxP.Text = "Max. player";
            // 
            // dUpDown
            // 
            this.dUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dUpDown.Items.Add("2");
            this.dUpDown.Items.Add("3");
            this.dUpDown.Items.Add("4");
            this.dUpDown.Location = new System.Drawing.Point(287, 181);
            this.dUpDown.Margin = new System.Windows.Forms.Padding(2);
            this.dUpDown.Name = "dUpDown";
            this.dUpDown.Size = new System.Drawing.Size(52, 38);
            this.dUpDown.TabIndex = 6;
            // 
            // CreateNewGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.dUpDown);
            this.Controls.Add(this.lblMaxP);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreateNewGame);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblNewGame);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateNewGameForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNewGame;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnCreateNewGame;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblMaxP;
        private System.Windows.Forms.DomainUpDown dUpDown;
    }
}