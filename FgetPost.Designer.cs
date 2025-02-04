namespace CrawFB
{
    partial class FgetPost
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
            this.txbLink = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPost = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addresspost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datepost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnShreach = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txbAddressPost = new System.Windows.Forms.TextBox();
            this.btnGetShare = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPost)).BeginInit();
            this.SuspendLayout();
            // 
            // txbLink
            // 
            this.txbLink.Location = new System.Drawing.Point(287, 70);
            this.txbLink.Name = "txbLink";
            this.txbLink.Size = new System.Drawing.Size(438, 22);
            this.txbLink.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Điền Địa Chỉ Hội Nhóm";
            // 
            // dgvPost
            // 
            this.dgvPost.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvPost.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvPost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPost.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.addresspost,
            this.datepost,
            this.content});
            this.dgvPost.Location = new System.Drawing.Point(31, 149);
            this.dgvPost.Name = "dgvPost";
            this.dgvPost.RowHeadersWidth = 51;
            this.dgvPost.RowTemplate.Height = 24;
            this.dgvPost.Size = new System.Drawing.Size(787, 281);
            this.dgvPost.TabIndex = 2;
            this.dgvPost.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPost_CellClick);
            this.dgvPost.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPost_CellContentClick);
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.MinimumWidth = 6;
            this.STT.Name = "STT";
            this.STT.Width = 125;
            // 
            // addresspost
            // 
            this.addresspost.HeaderText = "Địa Chỉ Bài Viết";
            this.addresspost.MinimumWidth = 6;
            this.addresspost.Name = "addresspost";
            this.addresspost.Width = 150;
            // 
            // datepost
            // 
            this.datepost.HeaderText = "Thời Gian";
            this.datepost.MinimumWidth = 6;
            this.datepost.Name = "datepost";
            this.datepost.Width = 125;
            // 
            // content
            // 
            this.content.HeaderText = "Nội Dung";
            this.content.MinimumWidth = 6;
            this.content.Name = "content";
            this.content.Width = 150;
            // 
            // btnShreach
            // 
            this.btnShreach.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShreach.Location = new System.Drawing.Point(867, 149);
            this.btnShreach.Name = "btnShreach";
            this.btnShreach.Size = new System.Drawing.Size(75, 60);
            this.btnShreach.TabIndex = 3;
            this.btnShreach.Text = "Tìm";
            this.btnShreach.UseVisualStyleBackColor = true;
            this.btnShreach.Click += new System.EventHandler(this.btnShreach_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 472);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Địa chỉ bài viết";
            // 
            // txbAddressPost
            // 
            this.txbAddressPost.Location = new System.Drawing.Point(317, 455);
            this.txbAddressPost.Multiline = true;
            this.txbAddressPost.Name = "txbAddressPost";
            this.txbAddressPost.Size = new System.Drawing.Size(560, 63);
            this.txbAddressPost.TabIndex = 5;
            // 
            // btnGetShare
            // 
            this.btnGetShare.Location = new System.Drawing.Point(878, 262);
            this.btnGetShare.Name = "btnGetShare";
            this.btnGetShare.Size = new System.Drawing.Size(76, 73);
            this.btnGetShare.TabIndex = 6;
            this.btnGetShare.Text = "Lấy ID Share";
            this.btnGetShare.UseVisualStyleBackColor = true;
            this.btnGetShare.Click += new System.EventHandler(this.btnGetShare_Click);
            // 
            // FgetPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 530);
            this.Controls.Add(this.btnGetShare);
            this.Controls.Add(this.txbAddressPost);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnShreach);
            this.Controls.Add(this.dgvPost);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbLink);
            this.Name = "FgetPost";
            this.Text = "FgetPost";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPost)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbLink;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPost;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn addresspost;
        private System.Windows.Forms.DataGridViewTextBoxColumn datepost;
        private System.Windows.Forms.DataGridViewTextBoxColumn content;
        private System.Windows.Forms.Button btnShreach;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbAddressPost;
        private System.Windows.Forms.Button btnGetShare;
    }
}