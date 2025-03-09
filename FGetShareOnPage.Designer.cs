namespace CrawFB
{
    partial class FGetShareOnPage
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txbSoBai = new System.Windows.Forms.TextBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txbLinkPage = new System.Windows.Forms.TextBox();
            this.dgvGetShare = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LinkShare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LinkFb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Live = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.From = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnGet = new System.Windows.Forms.Button();
            this.btnSavePerson = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGetShare)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txbSoBai);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txbLinkPage);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1030, 103);
            this.panel1.TabIndex = 0;
            // 
            // txbSoBai
            // 
            this.txbSoBai.Location = new System.Drawing.Point(700, 59);
            this.txbSoBai.Name = "txbSoBai";
            this.txbSoBai.Size = new System.Drawing.Size(201, 22);
            this.txbSoBai.TabIndex = 4;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.radioButton2.Location = new System.Drawing.Point(553, 61);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(118, 23);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Theo Số Bài";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(67, 61);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(121, 20);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Theo Thời Gian";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(50, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Địa Chỉ Page";
            // 
            // txbLinkPage
            // 
            this.txbLinkPage.Location = new System.Drawing.Point(250, 16);
            this.txbLinkPage.Name = "txbLinkPage";
            this.txbLinkPage.Size = new System.Drawing.Size(651, 22);
            this.txbLinkPage.TabIndex = 0;
            // 
            // dgvGetShare
            // 
            this.dgvGetShare.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvGetShare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGetShare.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.LinkShare,
            this.LinkFb,
            this.DisplayName,
            this.Live,
            this.From});
            this.dgvGetShare.Location = new System.Drawing.Point(12, 121);
            this.dgvGetShare.Name = "dgvGetShare";
            this.dgvGetShare.RowHeadersWidth = 51;
            this.dgvGetShare.RowTemplate.Height = 24;
            this.dgvGetShare.Size = new System.Drawing.Size(1030, 372);
            this.dgvGetShare.TabIndex = 1;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 6;
            this.STT.Name = "STT";
            this.STT.Width = 50;
            // 
            // LinkShare
            // 
            this.LinkShare.HeaderText = "Địa Chỉ Share";
            this.LinkShare.MinimumWidth = 6;
            this.LinkShare.Name = "LinkShare";
            this.LinkShare.Width = 200;
            // 
            // LinkFb
            // 
            this.LinkFb.HeaderText = "Địa Chỉ FB ";
            this.LinkFb.MinimumWidth = 6;
            this.LinkFb.Name = "LinkFb";
            this.LinkFb.Width = 200;
            // 
            // DisplayName
            // 
            this.DisplayName.HeaderText = "Tên FB";
            this.DisplayName.MinimumWidth = 6;
            this.DisplayName.Name = "DisplayName";
            this.DisplayName.Width = 125;
            // 
            // Live
            // 
            this.Live.HeaderText = "Sống Tại";
            this.Live.MinimumWidth = 6;
            this.Live.Name = "Live";
            this.Live.Width = 200;
            // 
            // From
            // 
            this.From.HeaderText = "Đến Từ";
            this.From.MinimumWidth = 6;
            this.From.Name = "From";
            this.From.Width = 200;
            // 
            // btnGet
            // 
            this.btnGet.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGet.ForeColor = System.Drawing.Color.Red;
            this.btnGet.Location = new System.Drawing.Point(1057, 14);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(78, 82);
            this.btnGet.TabIndex = 2;
            this.btnGet.Text = "Thống Kê";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnSavePerson
            // 
            this.btnSavePerson.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavePerson.ForeColor = System.Drawing.Color.Red;
            this.btnSavePerson.Location = new System.Drawing.Point(1057, 121);
            this.btnSavePerson.Name = "btnSavePerson";
            this.btnSavePerson.Size = new System.Drawing.Size(78, 82);
            this.btnSavePerson.TabIndex = 3;
            this.btnSavePerson.Text = "Lưu Đối Tượng";
            this.btnSavePerson.UseVisualStyleBackColor = true;
            this.btnSavePerson.Click += new System.EventHandler(this.btnSavePerson_Click);
            // 
            // FGetShareOnPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1159, 586);
            this.Controls.Add(this.btnSavePerson);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.dgvGetShare);
            this.Controls.Add(this.panel1);
            this.Name = "FGetShareOnPage";
            this.Text = "FGetShareOnPage";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGetShare)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbLinkPage;
        private System.Windows.Forms.TextBox txbSoBai;
        private System.Windows.Forms.DataGridView dgvGetShare;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn LinkShare;
        private System.Windows.Forms.DataGridViewTextBoxColumn LinkFb;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Live;
        private System.Windows.Forms.DataGridViewTextBoxColumn From;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnSavePerson;
    }
}