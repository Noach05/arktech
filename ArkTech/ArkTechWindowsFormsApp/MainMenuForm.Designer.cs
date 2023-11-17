namespace ArkTechWindowsFormsApp
{
    partial class MainMenuForm
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
            this.btnProductMng = new System.Windows.Forms.Button();
            this.btnUserMng = new System.Windows.Forms.Button();
            this.btnViewSales = new System.Windows.Forms.Button();
            this.btnDiscountMng = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.lbWelcomeBack = new System.Windows.Forms.Label();
            this.btnProductRegistr = new System.Windows.Forms.Button();
            this.btProfile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProductMng
            // 
            this.btnProductMng.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(90)))), ((int)(((byte)(95)))));
            this.btnProductMng.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProductMng.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnProductMng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(232)))), ((int)(((byte)(209)))));
            this.btnProductMng.Location = new System.Drawing.Point(12, 141);
            this.btnProductMng.Name = "btnProductMng";
            this.btnProductMng.Size = new System.Drawing.Size(142, 74);
            this.btnProductMng.TabIndex = 0;
            this.btnProductMng.Text = "Product Management";
            this.btnProductMng.UseVisualStyleBackColor = false;
            this.btnProductMng.Click += new System.EventHandler(this.btnProductMng_Click);
            // 
            // btnUserMng
            // 
            this.btnUserMng.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(90)))), ((int)(((byte)(95)))));
            this.btnUserMng.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUserMng.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnUserMng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(232)))), ((int)(((byte)(209)))));
            this.btnUserMng.Location = new System.Drawing.Point(12, 301);
            this.btnUserMng.Name = "btnUserMng";
            this.btnUserMng.Size = new System.Drawing.Size(142, 74);
            this.btnUserMng.TabIndex = 1;
            this.btnUserMng.Text = "User Management";
            this.btnUserMng.UseVisualStyleBackColor = false;
            this.btnUserMng.Click += new System.EventHandler(this.btnUserMng_Click);
            // 
            // btnViewSales
            // 
            this.btnViewSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(90)))), ((int)(((byte)(95)))));
            this.btnViewSales.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnViewSales.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnViewSales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(232)))), ((int)(((byte)(209)))));
            this.btnViewSales.Location = new System.Drawing.Point(12, 461);
            this.btnViewSales.Name = "btnViewSales";
            this.btnViewSales.Size = new System.Drawing.Size(142, 74);
            this.btnViewSales.TabIndex = 2;
            this.btnViewSales.Text = "View Sales";
            this.btnViewSales.UseVisualStyleBackColor = false;
            this.btnViewSales.Click += new System.EventHandler(this.btnViewSales_Click);
            // 
            // btnDiscountMng
            // 
            this.btnDiscountMng.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(90)))), ((int)(((byte)(95)))));
            this.btnDiscountMng.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDiscountMng.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDiscountMng.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(232)))), ((int)(((byte)(209)))));
            this.btnDiscountMng.Location = new System.Drawing.Point(12, 381);
            this.btnDiscountMng.Name = "btnDiscountMng";
            this.btnDiscountMng.Size = new System.Drawing.Size(142, 74);
            this.btnDiscountMng.TabIndex = 3;
            this.btnDiscountMng.Text = "Discount Management";
            this.btnDiscountMng.UseVisualStyleBackColor = false;
            this.btnDiscountMng.Click += new System.EventHandler(this.btnDiscountMng_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ArkTechWindowsFormsApp.Properties.Resources.linkArm_;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(142, 87);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(43)))), ((int)(((byte)(48)))));
            this.pnlMain.Controls.Add(this.lbWelcomeBack);
            this.pnlMain.Location = new System.Drawing.Point(174, 12);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1213, 645);
            this.pnlMain.TabIndex = 6;
            // 
            // lbWelcomeBack
            // 
            this.lbWelcomeBack.AutoSize = true;
            this.lbWelcomeBack.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbWelcomeBack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(232)))), ((int)(((byte)(209)))));
            this.lbWelcomeBack.Location = new System.Drawing.Point(400, 98);
            this.lbWelcomeBack.Name = "lbWelcomeBack";
            this.lbWelcomeBack.Size = new System.Drawing.Size(0, 41);
            this.lbWelcomeBack.TabIndex = 0;
            // 
            // btnProductRegistr
            // 
            this.btnProductRegistr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(90)))), ((int)(((byte)(95)))));
            this.btnProductRegistr.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnProductRegistr.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnProductRegistr.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(232)))), ((int)(((byte)(209)))));
            this.btnProductRegistr.Location = new System.Drawing.Point(12, 221);
            this.btnProductRegistr.Name = "btnProductRegistr";
            this.btnProductRegistr.Size = new System.Drawing.Size(142, 74);
            this.btnProductRegistr.TabIndex = 7;
            this.btnProductRegistr.Text = "Product Registering";
            this.btnProductRegistr.UseVisualStyleBackColor = false;
            this.btnProductRegistr.Click += new System.EventHandler(this.btnProductRegistr_Click);
            // 
            // btProfile
            // 
            this.btProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(90)))), ((int)(((byte)(95)))));
            this.btProfile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btProfile.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btProfile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(232)))), ((int)(((byte)(209)))));
            this.btProfile.Location = new System.Drawing.Point(12, 541);
            this.btProfile.Name = "btProfile";
            this.btProfile.Size = new System.Drawing.Size(142, 74);
            this.btProfile.TabIndex = 8;
            this.btProfile.Text = "View Profile";
            this.btProfile.UseVisualStyleBackColor = false;
            this.btProfile.Click += new System.EventHandler(this.btProfile_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(40)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1399, 669);
            this.Controls.Add(this.btProfile);
            this.Controls.Add(this.btnProductRegistr);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnDiscountMng);
            this.Controls.Add(this.btnViewSales);
            this.Controls.Add(this.btnUserMng);
            this.Controls.Add(this.btnProductMng);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainMenuForm";
            this.Text = "ArkTech";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenuForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnProductMng;
        private Button btnUserMng;
        private Button btnViewSales;
        private Button btnDiscountMng;
        private PictureBox pictureBox1;
        private Panel pnlMain;
        private Button btnProductRegistr;
        private Label lbWelcomeBack;
        private Button btProfile;
    }
}