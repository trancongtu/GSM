namespace CrawFB
{
    partial class FloginFb
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
            this.btnLoginFb = new System.Windows.Forms.Button();
            this.txbCookie = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.profile = new System.Windows.Forms.Label();
            this.txbProfile = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txbProfileName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnLoginFb
            // 
            this.btnLoginFb.Location = new System.Drawing.Point(780, 104);
            this.btnLoginFb.Name = "btnLoginFb";
            this.btnLoginFb.Size = new System.Drawing.Size(191, 71);
            this.btnLoginFb.TabIndex = 0;
            this.btnLoginFb.Text = "Kết Nối";
            this.btnLoginFb.UseVisualStyleBackColor = true;
            this.btnLoginFb.Click += new System.EventHandler(this.button1_Click);
            // 
            // txbCookie
            // 
            this.txbCookie.Location = new System.Drawing.Point(276, 104);
            this.txbCookie.Name = "txbCookie";
            this.txbCookie.Size = new System.Drawing.Size(398, 22);
            this.txbCookie.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(83, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Điền Cookie";
            // 
            // profile
            // 
            this.profile.AutoSize = true;
            this.profile.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profile.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.profile.Location = new System.Drawing.Point(83, 153);
            this.profile.Name = "profile";
            this.profile.Size = new System.Drawing.Size(132, 19);
            this.profile.TabIndex = 3;
            this.profile.Text = "Điền Tên Profile";
            // 
            // txbProfile
            // 
            this.txbProfile.Location = new System.Drawing.Point(276, 153);
            this.txbProfile.Name = "txbProfile";
            this.txbProfile.Size = new System.Drawing.Size(398, 22);
            this.txbProfile.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(73, 211);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(180, 34);
            this.button1.TabIndex = 6;
            this.button1.Text = "Chọn Nơi Lưu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // txbProfileName
            // 
            this.txbProfileName.Location = new System.Drawing.Point(276, 217);
            this.txbProfileName.Name = "txbProfileName";
            this.txbProfileName.ReadOnly = true;
            this.txbProfileName.Size = new System.Drawing.Size(398, 22);
            this.txbProfileName.TabIndex = 7;
            // 
            // FloginFb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 493);
            this.Controls.Add(this.txbProfileName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txbProfile);
            this.Controls.Add(this.profile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbCookie);
            this.Controls.Add(this.btnLoginFb);
            this.Name = "FloginFb";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoginFb;
        private System.Windows.Forms.TextBox txbCookie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label profile;
        private System.Windows.Forms.TextBox txbProfile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txbProfileName;
    }
}

