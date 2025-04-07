namespace CrawFB
{
    partial class SetupShearchPost
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cBTime = new System.Windows.Forms.ComboBox();
            this.btnkeyword = new System.Windows.Forms.Button();
            this.btnCancer = new System.Windows.Forms.Button();
            this.chkFilterContent = new System.Windows.Forms.CheckBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.nudSoBai = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoBai)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Số Bài Lấy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Thời gian lấy";
            // 
            // cBTime
            // 
            this.cBTime.FormattingEnabled = true;
            this.cBTime.Items.AddRange(new object[] {
            "1 Ngày",
            "2 Ngày",
            "3 Ngày",
            "4 Ngày",
            "5 Ngày",
            "6 Ngày",
            "1 Tuần",
            "10 Ngày",
            "15 Ngày",
            "1 Tháng"});
            this.cBTime.Location = new System.Drawing.Point(201, 100);
            this.cBTime.Name = "cBTime";
            this.cBTime.Size = new System.Drawing.Size(293, 24);
            this.cBTime.TabIndex = 3;
            this.cBTime.SelectedIndexChanged += new System.EventHandler(this.cBTime_SelectedIndexChanged);
            // 
            // btnkeyword
            // 
            this.btnkeyword.Enabled = false;
            this.btnkeyword.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnkeyword.Location = new System.Drawing.Point(371, 199);
            this.btnkeyword.Name = "btnkeyword";
            this.btnkeyword.Size = new System.Drawing.Size(178, 46);
            this.btnkeyword.TabIndex = 4;
            this.btnkeyword.Text = "Keyword Filter";
            this.btnkeyword.UseVisualStyleBackColor = true;
            this.btnkeyword.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancer
            // 
            this.btnCancer.Location = new System.Drawing.Point(637, 116);
            this.btnCancer.Name = "btnCancer";
            this.btnCancer.Size = new System.Drawing.Size(72, 46);
            this.btnCancer.TabIndex = 5;
            this.btnCancer.Text = "Cancer";
            this.btnCancer.UseVisualStyleBackColor = true;
            // 
            // chkFilterContent
            // 
            this.chkFilterContent.AutoSize = true;
            this.chkFilterContent.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFilterContent.Location = new System.Drawing.Point(36, 208);
            this.chkFilterContent.Name = "chkFilterContent";
            this.chkFilterContent.Size = new System.Drawing.Size(285, 27);
            this.chkFilterContent.TabIndex = 6;
            this.chkFilterContent.Text = "Lọc nội dung trước khi tìm bài";
            this.chkFilterContent.UseVisualStyleBackColor = true;
            this.chkFilterContent.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(598, 47);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(142, 37);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Lưu Cập Nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // nudSoBai
            // 
            this.nudSoBai.Location = new System.Drawing.Point(201, 44);
            this.nudSoBai.Name = "nudSoBai";
            this.nudSoBai.Size = new System.Drawing.Size(293, 22);
            this.nudSoBai.TabIndex = 8;
            // 
            // SetupShearchPost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.nudSoBai);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.chkFilterContent);
            this.Controls.Add(this.btnCancer);
            this.Controls.Add(this.btnkeyword);
            this.Controls.Add(this.cBTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SetupShearchPost";
            this.Text = "SetupShearchPost";
            ((System.ComponentModel.ISupportInitialize)(this.nudSoBai)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cBTime;
        private System.Windows.Forms.Button btnkeyword;
        private System.Windows.Forms.Button btnCancer;
        private System.Windows.Forms.CheckBox chkFilterContent;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.NumericUpDown nudSoBai;
    }
}