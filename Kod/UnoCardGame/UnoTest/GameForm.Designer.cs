namespace UnoTest
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.lblGameName = new System.Windows.Forms.Label();
            this.pbxDeck = new System.Windows.Forms.PictureBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.pbxField = new System.Windows.Forms.PictureBox();
            this.panelMyCards = new System.Windows.Forms.Panel();
            this.listPlayers = new System.Windows.Forms.ListView();
            this.UsernameC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CardsLeftC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnEndTurn = new System.Windows.Forms.Button();
            this.txtOnTurn = new System.Windows.Forms.Label();
            this.lblOnTurn = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDeck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxField)).BeginInit();
            this.SuspendLayout();
            // 
            // lblGameName
            // 
            this.lblGameName.AutoSize = true;
            this.lblGameName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGameName.Location = new System.Drawing.Point(617, 10);
            this.lblGameName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGameName.Name = "lblGameName";
            this.lblGameName.Size = new System.Drawing.Size(125, 25);
            this.lblGameName.TabIndex = 0;
            this.lblGameName.Text = "GameName";
            // 
            // pbxDeck
            // 
            this.pbxDeck.Image = global::UnoTest.Properties.Resources.unoBack;
            this.pbxDeck.InitialImage = global::UnoTest.Properties.Resources.unoBack;
            this.pbxDeck.Location = new System.Drawing.Point(559, 121);
            this.pbxDeck.Margin = new System.Windows.Forms.Padding(2);
            this.pbxDeck.Name = "pbxDeck";
            this.pbxDeck.Size = new System.Drawing.Size(102, 151);
            this.pbxDeck.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxDeck.TabIndex = 1;
            this.pbxDeck.TabStop = false;
            this.pbxDeck.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PbxDeck_MouseClick);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(9, 10);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(154, 80);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Leave game";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // pbxField
            // 
            this.pbxField.Location = new System.Drawing.Point(677, 121);
            this.pbxField.Name = "pbxField";
            this.pbxField.Size = new System.Drawing.Size(106, 151);
            this.pbxField.TabIndex = 11;
            this.pbxField.TabStop = false;
            // 
            // panelMyCards
            // 
            this.panelMyCards.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelMyCards.Location = new System.Drawing.Point(0, 354);
            this.panelMyCards.Name = "panelMyCards";
            this.panelMyCards.Size = new System.Drawing.Size(1360, 375);
            this.panelMyCards.TabIndex = 12;
            // 
            // listPlayers
            // 
            this.listPlayers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.UsernameC,
            this.CardsLeftC});
            this.listPlayers.GridLines = true;
            this.listPlayers.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listPlayers.HideSelection = false;
            this.listPlayers.Location = new System.Drawing.Point(1116, 37);
            this.listPlayers.Name = "listPlayers";
            this.listPlayers.Size = new System.Drawing.Size(124, 262);
            this.listPlayers.TabIndex = 13;
            this.listPlayers.UseCompatibleStateImageBehavior = false;
            this.listPlayers.View = System.Windows.Forms.View.Details;
            // 
            // UsernameC
            // 
            this.UsernameC.Text = "Player";
            // 
            // CardsLeftC
            // 
            this.CardsLeftC.Text = "Cards ";
            // 
            // btnEndTurn
            // 
            this.btnEndTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEndTurn.Location = new System.Drawing.Point(9, 268);
            this.btnEndTurn.Name = "btnEndTurn";
            this.btnEndTurn.Size = new System.Drawing.Size(154, 80);
            this.btnEndTurn.TabIndex = 14;
            this.btnEndTurn.Text = "End turn";
            this.btnEndTurn.UseVisualStyleBackColor = true;
            this.btnEndTurn.Click += new System.EventHandler(this.BtnEndTurn_Click);
            // 
            // txtOnTurn
            // 
            this.txtOnTurn.AutoSize = true;
            this.txtOnTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOnTurn.Location = new System.Drawing.Point(1113, 10);
            this.txtOnTurn.Name = "txtOnTurn";
            this.txtOnTurn.Size = new System.Drawing.Size(193, 17);
            this.txtOnTurn.TabIndex = 15;
            this.txtOnTurn.Text = "Waiting for other players.";
            // 
            // lblOnTurn
            // 
            this.lblOnTurn.AutoSize = true;
            this.lblOnTurn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOnTurn.Location = new System.Drawing.Point(1043, 10);
            this.lblOnTurn.Name = "lblOnTurn";
            this.lblOnTurn.Size = new System.Drawing.Size(64, 17);
            this.lblOnTurn.TabIndex = 16;
            this.lblOnTurn.Text = "On turn :";
            // 
            // txtStatus
            // 
            this.txtStatus.AutoSize = true;
            this.txtStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatus.ForeColor = System.Drawing.Color.Red;
            this.txtStatus.Location = new System.Drawing.Point(619, 37);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(70, 15);
            this.txtStatus.TabIndex = 17;
            this.txtStatus.Text = "Not active";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1360, 729);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lblOnTurn);
            this.Controls.Add(this.txtOnTurn);
            this.Controls.Add(this.btnEndTurn);
            this.Controls.Add(this.listPlayers);
            this.Controls.Add(this.panelMyCards);
            this.Controls.Add(this.pbxField);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.pbxDeck);
            this.Controls.Add(this.lblGameName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1376, 768);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1376, 768);
            this.Name = "GameForm";
            this.Text = "Username";
            this.Load += new System.EventHandler(this.GameForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxDeck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGameName;
        private System.Windows.Forms.PictureBox pbxDeck;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.PictureBox pbxField;
        private System.Windows.Forms.Panel panelMyCards;
        private System.Windows.Forms.ListView listPlayers;
        private System.Windows.Forms.ColumnHeader UsernameC;
        private System.Windows.Forms.Button btnEndTurn;
        private System.Windows.Forms.Label txtOnTurn;
        private System.Windows.Forms.Label lblOnTurn;
        private System.Windows.Forms.Label txtStatus;
        private System.Windows.Forms.ColumnHeader CardsLeftC;
    }
}