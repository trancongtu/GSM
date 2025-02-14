namespace GSM
{
    partial class GetShareOnePost
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
            this.txbLinkPost = new System.Windows.Forms.TextBox();
            this.btnShearch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txbLinkPost
            // 
            this.txbLinkPost.Location = new System.Drawing.Point(228, 137);
            this.txbLinkPost.Name = "txbLinkPost";
            this.txbLinkPost.Size = new System.Drawing.Size(569, 20);
            this.txbLinkPost.TabIndex = 0;
            // 
            // btnShearch
            // 
            this.btnShearch.Location = new System.Drawing.Point(891, 118);
            this.btnShearch.Name = "btnShearch";
            this.btnShearch.Size = new System.Drawing.Size(75, 56);
            this.btnShearch.TabIndex = 1;
            this.btnShearch.Text = "Thống Kê";
            this.btnShearch.UseVisualStyleBackColor = true;
            this.btnShearch.Click += new System.EventHandler(this.btnShearch_Click);
            // 
            // GetShareOnePost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 587);
            this.Controls.Add(this.btnShearch);
            this.Controls.Add(this.txbLinkPost);
            this.Name = "GetShareOnePost";
            this.Text = "GetShareOnePost";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txbLinkPost;
        private System.Windows.Forms.Button btnShearch;
    }
}