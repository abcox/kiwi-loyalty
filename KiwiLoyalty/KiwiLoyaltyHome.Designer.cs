namespace KiwiLoyalty
{
    partial class KiwiLoyaltyHomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KiwiLoyaltyHomeForm));
            this.homeTasksGroupBox = new System.Windows.Forms.GroupBox();
            this.homeRedeemCustomerPointsButton = new System.Windows.Forms.Button();
            this.homeViewCustomerInformation = new System.Windows.Forms.Button();
            this.homeAddPointsButton = new System.Windows.Forms.Button();
            this.homeNewCustomerButton = new System.Windows.Forms.Button();
            this.homeButtonQuit = new System.Windows.Forms.Button();
            this.homeWelcomeTitleLabel = new System.Windows.Forms.Label();
            this.KiwiLoyaltyLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.homeTasksGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KiwiLoyaltyLogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // homeTasksGroupBox
            // 
            this.homeTasksGroupBox.Controls.Add(this.homeRedeemCustomerPointsButton);
            this.homeTasksGroupBox.Controls.Add(this.homeViewCustomerInformation);
            this.homeTasksGroupBox.Controls.Add(this.homeAddPointsButton);
            this.homeTasksGroupBox.Controls.Add(this.homeNewCustomerButton);
            this.homeTasksGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeTasksGroupBox.Location = new System.Drawing.Point(103, 192);
            this.homeTasksGroupBox.Name = "homeTasksGroupBox";
            this.homeTasksGroupBox.Size = new System.Drawing.Size(573, 140);
            this.homeTasksGroupBox.TabIndex = 2;
            this.homeTasksGroupBox.TabStop = false;
            this.homeTasksGroupBox.Text = "What would you like to do ?";
            // 
            // homeRedeemCustomerPointsButton
            // 
            this.homeRedeemCustomerPointsButton.Location = new System.Drawing.Point(307, 35);
            this.homeRedeemCustomerPointsButton.Name = "homeRedeemCustomerPointsButton";
            this.homeRedeemCustomerPointsButton.Size = new System.Drawing.Size(126, 91);
            this.homeRedeemCustomerPointsButton.TabIndex = 7;
            this.homeRedeemCustomerPointsButton.Text = "Redeem Points";
            this.homeRedeemCustomerPointsButton.UseVisualStyleBackColor = true;
            this.homeRedeemCustomerPointsButton.Click += new System.EventHandler(this.homeRedeemCustomerPointsButton_Click);
            // 
            // homeViewCustomerInformation
            // 
            this.homeViewCustomerInformation.Location = new System.Drawing.Point(439, 35);
            this.homeViewCustomerInformation.Name = "homeViewCustomerInformation";
            this.homeViewCustomerInformation.Size = new System.Drawing.Size(126, 91);
            this.homeViewCustomerInformation.TabIndex = 6;
            this.homeViewCustomerInformation.Text = "View Customer Information";
            this.homeViewCustomerInformation.UseVisualStyleBackColor = true;
            this.homeViewCustomerInformation.Click += new System.EventHandler(this.homeViewCustomerInformation_Click);
            // 
            // homeAddPointsButton
            // 
            this.homeAddPointsButton.Location = new System.Drawing.Point(177, 35);
            this.homeAddPointsButton.Name = "homeAddPointsButton";
            this.homeAddPointsButton.Size = new System.Drawing.Size(126, 91);
            this.homeAddPointsButton.TabIndex = 5;
            this.homeAddPointsButton.Text = "Add Points";
            this.homeAddPointsButton.UseVisualStyleBackColor = true;
            this.homeAddPointsButton.Click += new System.EventHandler(this.homeAddPointsButton_Click);
            // 
            // homeNewCustomerButton
            // 
            this.homeNewCustomerButton.Location = new System.Drawing.Point(45, 35);
            this.homeNewCustomerButton.Name = "homeNewCustomerButton";
            this.homeNewCustomerButton.Size = new System.Drawing.Size(126, 91);
            this.homeNewCustomerButton.TabIndex = 4;
            this.homeNewCustomerButton.Text = "New Customer";
            this.homeNewCustomerButton.UseVisualStyleBackColor = true;
            this.homeNewCustomerButton.Click += new System.EventHandler(this.homeNewCustomerButton_Click);
            // 
            // homeButtonQuit
            // 
            this.homeButtonQuit.Location = new System.Drawing.Point(713, 415);
            this.homeButtonQuit.Name = "homeButtonQuit";
            this.homeButtonQuit.Size = new System.Drawing.Size(75, 23);
            this.homeButtonQuit.TabIndex = 3;
            this.homeButtonQuit.Text = "Quit";
            this.homeButtonQuit.UseVisualStyleBackColor = true;
            this.homeButtonQuit.Click += new System.EventHandler(this.homeButtonQuit_Click);
            // 
            // homeWelcomeTitleLabel
            // 
            this.homeWelcomeTitleLabel.AutoSize = true;
            this.homeWelcomeTitleLabel.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeWelcomeTitleLabel.Location = new System.Drawing.Point(12, 9);
            this.homeWelcomeTitleLabel.Name = "homeWelcomeTitleLabel";
            this.homeWelcomeTitleLabel.Size = new System.Drawing.Size(211, 26);
            this.homeWelcomeTitleLabel.TabIndex = 4;
            this.homeWelcomeTitleLabel.Text = "The Brogue Loyalty";
            // 
            // KiwiLoyaltyLogoPictureBox
            // 
            this.KiwiLoyaltyLogoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("KiwiLoyaltyLogoPictureBox.Image")));
            this.KiwiLoyaltyLogoPictureBox.Location = new System.Drawing.Point(489, 9);
            this.KiwiLoyaltyLogoPictureBox.Name = "KiwiLoyaltyLogoPictureBox";
            this.KiwiLoyaltyLogoPictureBox.Size = new System.Drawing.Size(299, 138);
            this.KiwiLoyaltyLogoPictureBox.TabIndex = 5;
            this.KiwiLoyaltyLogoPictureBox.TabStop = false;
            // 
            // KiwiLoyaltyHomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.KiwiLoyaltyLogoPictureBox);
            this.Controls.Add(this.homeWelcomeTitleLabel);
            this.Controls.Add(this.homeButtonQuit);
            this.Controls.Add(this.homeTasksGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KiwiLoyaltyHomeForm";
            this.Text = "KiwiLoyalty - Home";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.homeTasksGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KiwiLoyaltyLogoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox homeTasksGroupBox;
        private System.Windows.Forms.Button homeButtonQuit;
        private System.Windows.Forms.Button homeNewCustomerButton;
        private System.Windows.Forms.Label homeWelcomeTitleLabel;
        private System.Windows.Forms.Button homeViewCustomerInformation;
        private System.Windows.Forms.Button homeAddPointsButton;
        private System.Windows.Forms.Button homeRedeemCustomerPointsButton;
        private System.Windows.Forms.PictureBox KiwiLoyaltyLogoPictureBox;
    }
}

