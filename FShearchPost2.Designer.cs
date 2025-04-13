namespace CrawFB
{
    partial class FShearchPost2
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
            this.panelmenu = new System.Windows.Forms.Panel();
            this.btnsetup = new System.Windows.Forms.Button();
            this.btnOpenKeywords = new System.Windows.Forms.Button();
            this.btnShearch = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.paneldata = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panelbinding = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txblinkbv = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbnoidunggoc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFullPost = new System.Windows.Forms.TextBox();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noidung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diachibv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timepost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countshare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countcomment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stattus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diemtieucuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelmenu.SuspendLayout();
            this.paneldata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panelbinding.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelmenu
            // 
            this.panelmenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelmenu.Controls.Add(this.btnsetup);
            this.panelmenu.Controls.Add(this.btnOpenKeywords);
            this.panelmenu.Controls.Add(this.btnShearch);
            this.panelmenu.Controls.Add(this.lblStatus);
            this.panelmenu.Location = new System.Drawing.Point(12, 3);
            this.panelmenu.Name = "panelmenu";
            this.panelmenu.Size = new System.Drawing.Size(1362, 94);
            this.panelmenu.TabIndex = 0;
            // 
            // btnsetup
            // 
            this.btnsetup.Location = new System.Drawing.Point(867, 34);
            this.btnsetup.Name = "btnsetup";
            this.btnsetup.Size = new System.Drawing.Size(112, 35);
            this.btnsetup.TabIndex = 3;
            this.btnsetup.Text = "Setup";
            this.btnsetup.UseVisualStyleBackColor = true;
            this.btnsetup.Click += new System.EventHandler(this.btnsetup_Click);
            // 
            // btnOpenKeywords
            // 
            this.btnOpenKeywords.Location = new System.Drawing.Point(722, 34);
            this.btnOpenKeywords.Name = "btnOpenKeywords";
            this.btnOpenKeywords.Size = new System.Drawing.Size(112, 35);
            this.btnOpenKeywords.TabIndex = 2;
            this.btnOpenKeywords.Text = "Mở Keyword";
            this.btnOpenKeywords.UseVisualStyleBackColor = true;
            this.btnOpenKeywords.Click += new System.EventHandler(this.btnOpenKeywords_Click);
            // 
            // btnShearch
            // 
            this.btnShearch.Location = new System.Drawing.Point(581, 34);
            this.btnShearch.Name = "btnShearch";
            this.btnShearch.Size = new System.Drawing.Size(112, 35);
            this.btnShearch.TabIndex = 1;
            this.btnShearch.Text = "Tìm Kiếm";
            this.btnShearch.UseVisualStyleBackColor = true;
            this.btnShearch.Click += new System.EventHandler(this.btnShearch_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(18, 23);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(140, 23);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Chờ Hành động";
            // 
            // paneldata
            // 
            this.paneldata.Controls.Add(this.dataGridView1);
            this.paneldata.Location = new System.Drawing.Point(3, 106);
            this.paneldata.Name = "paneldata";
            this.paneldata.Size = new System.Drawing.Size(1389, 313);
            this.paneldata.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.noidung,
            this.diachibv,
            this.timepost,
            this.countshare,
            this.countcomment,
            this.stattus,
            this.diemtieucuc});
            this.dataGridView1.Location = new System.Drawing.Point(9, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1362, 310);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // panelbinding
            // 
            this.panelbinding.Controls.Add(this.label3);
            this.panelbinding.Controls.Add(this.txblinkbv);
            this.panelbinding.Controls.Add(this.label2);
            this.panelbinding.Controls.Add(this.txbnoidunggoc);
            this.panelbinding.Controls.Add(this.label1);
            this.panelbinding.Controls.Add(this.txtFullPost);
            this.panelbinding.Location = new System.Drawing.Point(4, 425);
            this.panelbinding.Name = "panelbinding";
            this.panelbinding.Size = new System.Drawing.Size(1370, 244);
            this.panelbinding.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Địa chỉ bài viết";
            // 
            // txblinkbv
            // 
            this.txblinkbv.Location = new System.Drawing.Point(221, 197);
            this.txblinkbv.Multiline = true;
            this.txblinkbv.Name = "txblinkbv";
            this.txblinkbv.Size = new System.Drawing.Size(1057, 34);
            this.txblinkbv.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(905, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "Nội dung Gốc (nếu có)";
            // 
            // txbnoidunggoc
            // 
            this.txbnoidunggoc.Location = new System.Drawing.Point(695, 36);
            this.txbnoidunggoc.Multiline = true;
            this.txbnoidunggoc.Name = "txbnoidunggoc";
            this.txbnoidunggoc.Size = new System.Drawing.Size(583, 150);
            this.txbnoidunggoc.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(202, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nội dung Chi Tiết";
            // 
            // txtFullPost
            // 
            this.txtFullPost.Location = new System.Drawing.Point(31, 36);
            this.txtFullPost.Multiline = true;
            this.txtFullPost.Name = "txtFullPost";
            this.txtFullPost.Size = new System.Drawing.Size(583, 150);
            this.txtFullPost.TabIndex = 0;
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 6;
            this.STT.Name = "STT";
            this.STT.Width = 50;
            // 
            // noidung
            // 
            this.noidung.HeaderText = "Nội Dung";
            this.noidung.MinimumWidth = 6;
            this.noidung.Name = "noidung";
            this.noidung.Width = 200;
            // 
            // diachibv
            // 
            this.diachibv.HeaderText = "Địa Chỉ Bài viết";
            this.diachibv.MinimumWidth = 6;
            this.diachibv.Name = "diachibv";
            this.diachibv.Width = 200;
            // 
            // timepost
            // 
            this.timepost.HeaderText = "thời gian đăng";
            this.timepost.MinimumWidth = 6;
            this.timepost.Name = "timepost";
            this.timepost.Width = 125;
            // 
            // countshare
            // 
            this.countshare.HeaderText = "Lượng Share";
            this.countshare.MinimumWidth = 6;
            this.countshare.Name = "countshare";
            this.countshare.Width = 80;
            // 
            // countcomment
            // 
            this.countcomment.HeaderText = "Lượng bình luận";
            this.countcomment.MinimumWidth = 6;
            this.countcomment.Name = "countcomment";
            this.countcomment.Width = 80;
            // 
            // stattus
            // 
            this.stattus.HeaderText = "Trạng Thái";
            this.stattus.MinimumWidth = 6;
            this.stattus.Name = "stattus";
            this.stattus.Width = 125;
            // 
            // diemtieucuc
            // 
            this.diemtieucuc.HeaderText = "Điểm tiêu cực";
            this.diemtieucuc.MinimumWidth = 6;
            this.diemtieucuc.Name = "diemtieucuc";
            this.diemtieucuc.Width = 50;
            // 
            // FShearchPost2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1404, 700);
            this.Controls.Add(this.panelbinding);
            this.Controls.Add(this.paneldata);
            this.Controls.Add(this.panelmenu);
            this.Name = "FShearchPost2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FShearchPost2";
            this.panelmenu.ResumeLayout(false);
            this.panelmenu.PerformLayout();
            this.paneldata.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panelbinding.ResumeLayout(false);
            this.panelbinding.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelmenu;
        private System.Windows.Forms.Panel paneldata;
        private System.Windows.Forms.Panel panelbinding;
        private System.Windows.Forms.Button btnOpenKeywords;
        private System.Windows.Forms.Button btnShearch;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbnoidunggoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFullPost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txblinkbv;
        private System.Windows.Forms.Button btnsetup;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn noidung;
        private System.Windows.Forms.DataGridViewTextBoxColumn diachibv;
        private System.Windows.Forms.DataGridViewTextBoxColumn timepost;
        private System.Windows.Forms.DataGridViewTextBoxColumn countshare;
        private System.Windows.Forms.DataGridViewTextBoxColumn countcomment;
        private System.Windows.Forms.DataGridViewTextBoxColumn stattus;
        private System.Windows.Forms.DataGridViewTextBoxColumn diemtieucuc;
    }
}