namespace CrawFB
{
    partial class FDatabasePerson
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LinkFb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenFb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdFbPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SongTai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DenTu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HocVan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.LinkFb,
            this.TenFb,
            this.IdFbPerson,
            this.SongTai,
            this.DenTu,
            this.HocVan});
            this.dataGridView1.Location = new System.Drawing.Point(12, 92);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(911, 394);
            this.dataGridView1.TabIndex = 0;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 6;
            this.STT.Name = "STT";
            this.STT.Width = 75;
            // 
            // LinkFb
            // 
            this.LinkFb.HeaderText = "Địa Chỉ FB";
            this.LinkFb.MinimumWidth = 6;
            this.LinkFb.Name = "LinkFb";
            this.LinkFb.Width = 125;
            // 
            // TenFb
            // 
            this.TenFb.HeaderText = "Tên FB";
            this.TenFb.MinimumWidth = 6;
            this.TenFb.Name = "TenFb";
            this.TenFb.Width = 125;
            // 
            // IdFbPerson
            // 
            this.IdFbPerson.HeaderText = "ID FB";
            this.IdFbPerson.MinimumWidth = 6;
            this.IdFbPerson.Name = "IdFbPerson";
            this.IdFbPerson.Width = 125;
            // 
            // SongTai
            // 
            this.SongTai.HeaderText = "Sống Tại";
            this.SongTai.MinimumWidth = 6;
            this.SongTai.Name = "SongTai";
            this.SongTai.Width = 125;
            // 
            // DenTu
            // 
            this.DenTu.HeaderText = "Đến Từ";
            this.DenTu.MinimumWidth = 6;
            this.DenTu.Name = "DenTu";
            this.DenTu.Width = 125;
            // 
            // HocVan
            // 
            this.HocVan.HeaderText = "Học Vấn";
            this.HocVan.MinimumWidth = 6;
            this.HocVan.Name = "HocVan";
            this.HocVan.Width = 125;
            // 
            // FDatabasePerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1013, 549);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FDatabasePerson";
            this.Text = "FDatabasePerson";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn LinkFb;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenFb;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdFbPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn SongTai;
        private System.Windows.Forms.DataGridViewTextBoxColumn DenTu;
        private System.Windows.Forms.DataGridViewTextBoxColumn HocVan;
    }
}