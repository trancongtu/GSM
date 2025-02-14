namespace GSM
{
    partial class fPostOnePage
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
            this.components = new System.ComponentModel.Container();
            this.txbLinkPage = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbCountPost = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnShearch = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.STT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LinkPost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimePost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Content = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountShare = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGetShare = new System.Windows.Forms.Button();
            this.txbComment = new System.Windows.Forms.TextBox();
            this.txbShare = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txbContent = new System.Windows.Forms.TextBox();
            this.txbLinkPost = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txbTimePost = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbLinkPage
            // 
            this.txbLinkPage.Location = new System.Drawing.Point(175, 133);
            this.txbLinkPage.Name = "txbLinkPage";
            this.txbLinkPage.Size = new System.Drawing.Size(525, 20);
            this.txbLinkPage.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(30, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Link Page";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(30, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "Số Lượng Bài Lấy";
            // 
            // txbCountPost
            // 
            this.txbCountPost.Location = new System.Drawing.Point(175, 185);
            this.txbCountPost.Name = "txbCountPost";
            this.txbCountPost.Size = new System.Drawing.Size(525, 20);
            this.txbCountPost.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(30, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Thời Gian Lấy";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(175, 236);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(525, 21);
            this.comboBox1.TabIndex = 6;
            // 
            // btnShearch
            // 
            this.btnShearch.Location = new System.Drawing.Point(706, 137);
            this.btnShearch.Name = "btnShearch";
            this.btnShearch.Size = new System.Drawing.Size(75, 43);
            this.btnShearch.TabIndex = 7;
            this.btnShearch.Text = "Thống Kê";
            this.btnShearch.UseVisualStyleBackColor = true;
            this.btnShearch.Click += new System.EventHandler(this.btnShearch_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.STT,
            this.LinkPost,
            this.TimePost,
            this.Content,
            this.CountShare,
            this.CountComment});
            this.dataGridView1.Location = new System.Drawing.Point(34, 305);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(743, 273);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // STT
            // 
            this.STT.HeaderText = "STT";
            this.STT.Name = "STT";
            this.STT.Width = 50;
            // 
            // LinkPost
            // 
            this.LinkPost.HeaderText = "Địa Chỉ Bài Viết";
            this.LinkPost.Name = "LinkPost";
            this.LinkPost.Width = 150;
            // 
            // TimePost
            // 
            this.TimePost.HeaderText = "Thời Gian";
            this.TimePost.Name = "TimePost";
            // 
            // Content
            // 
            this.Content.HeaderText = "Nội Dung";
            this.Content.Name = "Content";
            this.Content.Width = 200;
            // 
            // CountShare
            // 
            this.CountShare.HeaderText = "Số Lượng Share";
            this.CountShare.Name = "CountShare";
            // 
            // CountComment
            // 
            this.CountComment.HeaderText = "Số Lượng Bình Luận";
            this.CountComment.Name = "CountComment";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGetShare);
            this.panel1.Controls.Add(this.txbComment);
            this.panel1.Controls.Add(this.txbShare);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txbContent);
            this.panel1.Controls.Add(this.txbLinkPost);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txbTimePost);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(793, 290);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(387, 288);
            this.panel1.TabIndex = 9;
            // 
            // btnGetShare
            // 
            this.btnGetShare.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetShare.ForeColor = System.Drawing.Color.Red;
            this.btnGetShare.Location = new System.Drawing.Point(60, 2);
            this.btnGetShare.Name = "btnGetShare";
            this.btnGetShare.Size = new System.Drawing.Size(269, 34);
            this.btnGetShare.TabIndex = 10;
            this.btnGetShare.Text = "Thống Kê Share";
            this.btnGetShare.UseVisualStyleBackColor = true;
            this.btnGetShare.Click += new System.EventHandler(this.btnGetShare_Click);
            // 
            // txbComment
            // 
            this.txbComment.Location = new System.Drawing.Point(279, 256);
            this.txbComment.Name = "txbComment";
            this.txbComment.Size = new System.Drawing.Size(99, 20);
            this.txbComment.TabIndex = 19;
            // 
            // txbShare
            // 
            this.txbShare.Location = new System.Drawing.Point(80, 256);
            this.txbShare.Name = "txbShare";
            this.txbShare.Size = new System.Drawing.Size(99, 20);
            this.txbShare.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label8.Location = new System.Drawing.Point(203, 257);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 19);
            this.label8.TabIndex = 17;
            this.label8.Text = "Comment";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(26, 257);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 19);
            this.label7.TabIndex = 16;
            this.label7.Text = "Share";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(65, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 19);
            this.label6.TabIndex = 15;
            this.label6.Text = "Nội Dung";
            // 
            // txbContent
            // 
            this.txbContent.Location = new System.Drawing.Point(6, 164);
            this.txbContent.Multiline = true;
            this.txbContent.Name = "txbContent";
            this.txbContent.Size = new System.Drawing.Size(378, 75);
            this.txbContent.TabIndex = 14;
            // 
            // txbLinkPost
            // 
            this.txbLinkPost.Location = new System.Drawing.Point(3, 70);
            this.txbLinkPost.Name = "txbLinkPost";
            this.txbLinkPost.Size = new System.Drawing.Size(375, 20);
            this.txbLinkPost.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(65, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 19);
            this.label5.TabIndex = 12;
            this.label5.Text = "Thời Gian";
            // 
            // txbTimePost
            // 
            this.txbTimePost.Location = new System.Drawing.Point(3, 118);
            this.txbTimePost.Name = "txbTimePost";
            this.txbTimePost.Size = new System.Drawing.Size(378, 20);
            this.txbTimePost.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(65, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "Link Bài Viết";
            // 
            // fPostOnePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 590);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnShearch);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbCountPost);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbLinkPage);
            this.Name = "fPostOnePage";
            this.Text = "fPostOnePage";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbLinkPage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbCountPost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnShearch;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn STT;
        private System.Windows.Forms.DataGridViewTextBoxColumn LinkPost;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimePost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Content;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountShare;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountComment;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbLinkPost;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txbTimePost;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txbContent;
        private System.Windows.Forms.Button btnGetShare;
        private System.Windows.Forms.TextBox txbComment;
        private System.Windows.Forms.TextBox txbShare;
    }
}