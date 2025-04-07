namespace CrawFB
{
    partial class FSherachPost
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
            this.btnShearch = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnOpenKeywords = new System.Windows.Forms.Button();
            this.txtFullPost = new System.Windows.Forms.TextBox();
            this.txblinkbv = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbnoidunggoc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelbinding = new System.Windows.Forms.Panel();
            this.panelmenu = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.paneldata = new System.Windows.Forms.Panel();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noidung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nguoidang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkfb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.posttime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkbaiviet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagelink = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orgishare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeogri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noidunggoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tengoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Linkgoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.share = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ghichu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelbinding.SuspendLayout();
            this.panelmenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.paneldata.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnShearch
            // 
            this.btnShearch.Location = new System.Drawing.Point(868, 9);
            this.btnShearch.Name = "btnShearch";
            this.btnShearch.Size = new System.Drawing.Size(80, 52);
            this.btnShearch.TabIndex = 0;
            this.btnShearch.Text = "Tìm Kiếm";
            this.btnShearch.UseVisualStyleBackColor = true;
            this.btnShearch.Click += new System.EventHandler(this.btnShearch_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(17, 20);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(67, 16);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Trạng thái";
            // 
            // btnOpenKeywords
            // 
            this.btnOpenKeywords.Location = new System.Drawing.Point(970, 4);
            this.btnOpenKeywords.Name = "btnOpenKeywords";
            this.btnOpenKeywords.Size = new System.Drawing.Size(99, 62);
            this.btnOpenKeywords.TabIndex = 3;
            this.btnOpenKeywords.Text = "📝 Mở keywords.txt";
            this.btnOpenKeywords.UseVisualStyleBackColor = true;
            this.btnOpenKeywords.Click += new System.EventHandler(this.btnOpenKeywords_Click);
            // 
            // txtFullPost
            // 
            this.txtFullPost.Location = new System.Drawing.Point(82, 21);
            this.txtFullPost.Multiline = true;
            this.txtFullPost.Name = "txtFullPost";
            this.txtFullPost.Size = new System.Drawing.Size(1454, 101);
            this.txtFullPost.TabIndex = 4;
            // 
            // txblinkbv
            // 
            this.txblinkbv.Location = new System.Drawing.Point(82, 128);
            this.txblinkbv.Name = "txblinkbv";
            this.txblinkbv.Size = new System.Drawing.Size(1454, 22);
            this.txblinkbv.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nội dung";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Địa Chỉ";
            // 
            // txbnoidunggoc
            // 
            this.txbnoidunggoc.Location = new System.Drawing.Point(82, 172);
            this.txbnoidunggoc.Multiline = true;
            this.txbnoidunggoc.Name = "txbnoidunggoc";
            this.txbnoidunggoc.Size = new System.Drawing.Size(1460, 65);
            this.txbnoidunggoc.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Nội dung bài gốc (nếu có)";
            // 
            // panelbinding
            // 
            this.panelbinding.Controls.Add(this.label3);
            this.panelbinding.Controls.Add(this.txbnoidunggoc);
            this.panelbinding.Controls.Add(this.label2);
            this.panelbinding.Controls.Add(this.label1);
            this.panelbinding.Controls.Add(this.txtFullPost);
            this.panelbinding.Controls.Add(this.txblinkbv);
            this.panelbinding.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelbinding.Location = new System.Drawing.Point(0, 427);
            this.panelbinding.Name = "panelbinding";
            this.panelbinding.Size = new System.Drawing.Size(1535, 237);
            this.panelbinding.TabIndex = 11;
            // 
            // panelmenu
            // 
            this.panelmenu.Controls.Add(this.btnOpenKeywords);
            this.panelmenu.Controls.Add(this.lblStatus);
            this.panelmenu.Controls.Add(this.btnShearch);
            this.panelmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelmenu.Location = new System.Drawing.Point(0, 0);
            this.panelmenu.Name = "panelmenu";
            this.panelmenu.Size = new System.Drawing.Size(1535, 77);
            this.panelmenu.TabIndex = 12;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.noidung,
            this.nguoidang,
            this.linkfb,
            this.posttime,
            this.linkbaiviet,
            this.pagename,
            this.pagelink,
            this.orgishare,
            this.timeogri,
            this.noidunggoc,
            this.tengoc,
            this.Linkgoc,
            this.share,
            this.comment,
            this.ghichu});
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1524, 308);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.Resize += new System.EventHandler(this.dataGridView1_Resize);
            // 
            // paneldata
            // 
            this.paneldata.Controls.Add(this.dataGridView1);
            this.paneldata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paneldata.Location = new System.Drawing.Point(0, 77);
            this.paneldata.Name = "paneldata";
            this.paneldata.Size = new System.Drawing.Size(1535, 350);
            this.paneldata.TabIndex = 13;
            this.paneldata.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
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
            // 
            // nguoidang
            // 
            this.nguoidang.HeaderText = "Người Đăng/Share";
            this.nguoidang.MinimumWidth = 6;
            this.nguoidang.Name = "nguoidang";
            this.nguoidang.Width = 101;
            // 
            // linkfb
            // 
            this.linkfb.HeaderText = "Địa Chỉ Fb người đăng/share";
            this.linkfb.MinimumWidth = 6;
            this.linkfb.Name = "linkfb";
            // 
            // posttime
            // 
            this.posttime.HeaderText = "Thời gian đăng/share";
            this.posttime.MinimumWidth = 6;
            this.posttime.Name = "posttime";
            this.posttime.Width = 101;
            // 
            // linkbaiviet
            // 
            this.linkbaiviet.HeaderText = "Địa Chỉ Bài Viết";
            this.linkbaiviet.MinimumWidth = 6;
            this.linkbaiviet.Name = "linkbaiviet";
            // 
            // pagename
            // 
            this.pagename.HeaderText = "Page được đăng/share";
            this.pagename.MinimumWidth = 6;
            this.pagename.Name = "pagename";
            this.pagename.Width = 101;
            // 
            // pagelink
            // 
            this.pagelink.HeaderText = "Địa chỉ Page";
            this.pagelink.MinimumWidth = 6;
            this.pagelink.Name = "pagelink";
            this.pagelink.Width = 101;
            // 
            // orgishare
            // 
            this.orgishare.HeaderText = "Link Nguồn Share (nếu có)";
            this.orgishare.MinimumWidth = 6;
            this.orgishare.Name = "orgishare";
            // 
            // timeogri
            // 
            this.timeogri.HeaderText = "thời gian bài gốc (nếu có)";
            this.timeogri.MinimumWidth = 6;
            this.timeogri.Name = "timeogri";
            this.timeogri.Width = 101;
            // 
            // noidunggoc
            // 
            this.noidunggoc.HeaderText = "Nội Dung bài gốc";
            this.noidunggoc.MinimumWidth = 6;
            this.noidunggoc.Name = "noidunggoc";
            // 
            // tengoc
            // 
            this.tengoc.HeaderText = "Tên FB đăng gốc";
            this.tengoc.MinimumWidth = 6;
            this.tengoc.Name = "tengoc";
            this.tengoc.Width = 101;
            // 
            // Linkgoc
            // 
            this.Linkgoc.HeaderText = "Địa chỉ Fb Gốc";
            this.Linkgoc.MinimumWidth = 6;
            this.Linkgoc.Name = "Linkgoc";
            // 
            // share
            // 
            this.share.HeaderText = "Lượng Share";
            this.share.MinimumWidth = 6;
            this.share.Name = "share";
            this.share.Width = 50;
            // 
            // comment
            // 
            this.comment.HeaderText = "Số Bình Luận";
            this.comment.MinimumWidth = 6;
            this.comment.Name = "comment";
            this.comment.Width = 50;
            // 
            // ghichu
            // 
            this.ghichu.HeaderText = "Ghi chú";
            this.ghichu.MinimumWidth = 6;
            this.ghichu.Name = "ghichu";
            this.ghichu.Width = 101;
            // 
            // FSherachPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1535, 664);
            this.Controls.Add(this.paneldata);
            this.Controls.Add(this.panelmenu);
            this.Controls.Add(this.panelbinding);
            this.Name = "FSherachPost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FSherachPost";
            this.Resize += new System.EventHandler(this.FSherachPost_Resize);
            this.panelbinding.ResumeLayout(false);
            this.panelbinding.PerformLayout();
            this.panelmenu.ResumeLayout(false);
            this.panelmenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.paneldata.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShearch;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnOpenKeywords;
        private System.Windows.Forms.TextBox txtFullPost;
        private System.Windows.Forms.TextBox txblinkbv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbnoidunggoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelbinding;
        private System.Windows.Forms.Panel panelmenu;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel paneldata;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn noidung;
        private System.Windows.Forms.DataGridViewTextBoxColumn nguoidang;
        private System.Windows.Forms.DataGridViewTextBoxColumn linkfb;
        private System.Windows.Forms.DataGridViewTextBoxColumn posttime;
        private System.Windows.Forms.DataGridViewTextBoxColumn linkbaiviet;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagename;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagelink;
        private System.Windows.Forms.DataGridViewTextBoxColumn orgishare;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeogri;
        private System.Windows.Forms.DataGridViewTextBoxColumn noidunggoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn tengoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linkgoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn share;
        private System.Windows.Forms.DataGridViewTextBoxColumn comment;
        private System.Windows.Forms.DataGridViewTextBoxColumn ghichu;
    }
}