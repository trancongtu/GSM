namespace CrawFB
{
    partial class fGetShareonePost
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txbLinkPost = new System.Windows.Forms.TextBox();
            this.dgvGetShareOnePost = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LinkShare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linkfb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdFb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.from = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.live = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thongtinkhac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.txbSumShare = new System.Windows.Forms.TextBox();
            this.btnGet = new System.Windows.Forms.Button();
            this.btnSavePerson = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGetShareOnePost)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Điền Link Bài Viết";
            // 
            // txbLinkPost
            // 
            this.txbLinkPost.Location = new System.Drawing.Point(276, 25);
            this.txbLinkPost.Name = "txbLinkPost";
            this.txbLinkPost.Size = new System.Drawing.Size(581, 22);
            this.txbLinkPost.TabIndex = 1;
            // 
            // dgvGetShareOnePost
            // 
            this.dgvGetShareOnePost.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Magenta;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGetShareOnePost.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvGetShareOnePost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGetShareOnePost.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.LinkShare,
            this.linkfb,
            this.IdFb,
            this.DisplayName,
            this.from,
            this.live,
            this.thongtinkhac});
            this.dgvGetShareOnePost.Location = new System.Drawing.Point(46, 149);
            this.dgvGetShareOnePost.Name = "dgvGetShareOnePost";
            this.dgvGetShareOnePost.RowHeadersWidth = 51;
            this.dgvGetShareOnePost.RowTemplate.Height = 24;
            this.dgvGetShareOnePost.Size = new System.Drawing.Size(1082, 447);
            this.dgvGetShareOnePost.TabIndex = 2;
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
            this.LinkShare.HeaderText = "Địa chỉ Share";
            this.LinkShare.MinimumWidth = 6;
            this.LinkShare.Name = "LinkShare";
            this.LinkShare.Width = 150;
            // 
            // linkfb
            // 
            this.linkfb.HeaderText = "Địa Chỉ FB Share";
            this.linkfb.MinimumWidth = 6;
            this.linkfb.Name = "linkfb";
            this.linkfb.Width = 125;
            // 
            // IdFb
            // 
            this.IdFb.HeaderText = "ID Facebook";
            this.IdFb.MinimumWidth = 6;
            this.IdFb.Name = "IdFb";
            this.IdFb.Width = 125;
            // 
            // DisplayName
            // 
            this.DisplayName.HeaderText = "Tên Fb";
            this.DisplayName.MinimumWidth = 6;
            this.DisplayName.Name = "DisplayName";
            this.DisplayName.Width = 150;
            // 
            // from
            // 
            this.from.HeaderText = "Đến Từ";
            this.from.MinimumWidth = 6;
            this.from.Name = "from";
            this.from.Width = 150;
            // 
            // live
            // 
            this.live.HeaderText = "Nơi ở";
            this.live.MinimumWidth = 6;
            this.live.Name = "live";
            this.live.Width = 150;
            // 
            // thongtinkhac
            // 
            this.thongtinkhac.HeaderText = "Thông tin khác";
            this.thongtinkhac.MinimumWidth = 6;
            this.thongtinkhac.Name = "thongtinkhac";
            this.thongtinkhac.Width = 125;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(42, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Số lượng Share thu được";
            // 
            // txbSumShare
            // 
            this.txbSumShare.Location = new System.Drawing.Point(276, 62);
            this.txbSumShare.Name = "txbSumShare";
            this.txbSumShare.Size = new System.Drawing.Size(581, 22);
            this.txbSumShare.TabIndex = 4;
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(922, 27);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(102, 57);
            this.btnGet.TabIndex = 5;
            this.btnGet.Text = "Thống KÊ";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnSavePerson
            // 
            this.btnSavePerson.Location = new System.Drawing.Point(1134, 149);
            this.btnSavePerson.Name = "btnSavePerson";
            this.btnSavePerson.Size = new System.Drawing.Size(77, 57);
            this.btnSavePerson.TabIndex = 6;
            this.btnSavePerson.Text = "Lưu Đối Tượng";
            this.btnSavePerson.UseVisualStyleBackColor = true;
            this.btnSavePerson.Click += new System.EventHandler(this.btnSavePerson_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbStatus.Location = new System.Drawing.Point(43, 111);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(208, 19);
            this.lbStatus.TabIndex = 7;
            this.lbStatus.Text = "Trạng Thái: Chờ hành động";
            // 
            // fGetShareonePost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 607);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.btnSavePerson);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.txbSumShare);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvGetShareOnePost);
            this.Controls.Add(this.txbLinkPost);
            this.Controls.Add(this.label1);
            this.Name = "fGetShareonePost";
            this.Text = "fGetShareonePost";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGetShareOnePost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbLinkPost;
        private System.Windows.Forms.DataGridView dgvGetShareOnePost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbSumShare;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnSavePerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn LinkShare;
        private System.Windows.Forms.DataGridViewTextBoxColumn linkfb;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdFb;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn from;
        private System.Windows.Forms.DataGridViewTextBoxColumn live;
        private System.Windows.Forms.DataGridViewTextBoxColumn thongtinkhac;
        private System.Windows.Forms.Label lbStatus;
    }
}