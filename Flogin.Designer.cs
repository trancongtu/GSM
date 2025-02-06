namespace GSM
{
    partial class Flogin
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
            this.txbCookie = new System.Windows.Forms.TextBox();
            this.btnLoginFb = new System.Windows.Forms.Button();
            this.txbProfile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbProfileName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbCookie
            // 
            this.txbCookie.Location = new System.Drawing.Point(190, 112);
            this.txbCookie.Name = "txbCookie";
            this.txbCookie.Size = new System.Drawing.Size(336, 20);
            this.txbCookie.TabIndex = 0;
            // 
            // btnLoginFb
            // 
            this.btnLoginFb.Location = new System.Drawing.Point(599, 109);
            this.btnLoginFb.Name = "btnLoginFb";
            this.btnLoginFb.Size = new System.Drawing.Size(75, 50);
            this.btnLoginFb.TabIndex = 1;
            this.btnLoginFb.Text = "Đăng Nhập";
            this.btnLoginFb.UseVisualStyleBackColor = true;
            this.btnLoginFb.Click += new System.EventHandler(this.btnLoginFb_Click);
            // 
            // txbProfile
            // 
            this.txbProfile.Enabled = false;
            this.txbProfile.Location = new System.Drawing.Point(190, 243);
            this.txbProfile.Name = "txbProfile";
            this.txbProfile.Size = new System.Drawing.Size(336, 20);
            this.txbProfile.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Điền Cookie";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 244);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nơi Lưu";
            // 
            // txbProfileName
            // 
            this.txbProfileName.Location = new System.Drawing.Point(190, 186);
            this.txbProfileName.Name = "txbProfileName";
            this.txbProfileName.Size = new System.Drawing.Size(336, 20);
            this.txbProfileName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "Đặt Tên Profile";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(575, 233);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 30);
            this.button1.TabIndex = 7;
            this.button1.Text = "Chọn Nơi Lưu";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Flogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbProfileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbProfile);
            this.Controls.Add(this.btnLoginFb);
            this.Controls.Add(this.txbCookie);
            this.Name = "Flogin";
            this.Text = "Flogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbCookie;
        private System.Windows.Forms.Button btnLoginFb;
        private System.Windows.Forms.TextBox txbProfile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbProfileName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
    }
}