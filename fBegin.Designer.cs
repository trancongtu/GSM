namespace CrawFB
{
    partial class fBegin
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
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnOnePost = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupfast = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupTool = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.setup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnLoginNews = new DevExpress.XtraBars.BarButtonItem();
            this.btnProfile = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(37);
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.barSubItem1,
            this.btnOnePost,
            this.btnLoginNews,
            this.btnProfile});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ribbon.MaxItemId = 5;
            this.ribbon.Name = "ribbon";
            this.ribbon.OptionsMenuMinWidth = 412;
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(1051, 193);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "Từ 01 bài viết";
            this.barSubItem1.Id = 1;
            this.barSubItem1.Name = "barSubItem1";
            // 
            // btnOnePost
            // 
            this.btnOnePost.Caption = "Từ 01 bài viết";
            this.btnOnePost.Id = 2;
            this.btnOnePost.Name = "btnOnePost";
            this.btnOnePost.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnOnePost_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupfast,
            this.ribbonPageGroupTool,
            this.setup});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "GSM";
            // 
            // ribbonPageGroupfast
            // 
            this.ribbonPageGroupfast.Name = "ribbonPageGroupfast";
            this.ribbonPageGroupfast.Text = "Giám sát mạng nhanh";
            // 
            // ribbonPageGroupTool
            // 
            this.ribbonPageGroupTool.ItemLinks.Add(this.btnOnePost);
            this.ribbonPageGroupTool.Name = "ribbonPageGroupTool";
            this.ribbonPageGroupTool.Text = "THỐNG KÊ SHARE";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 498);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1051, 30);
            // 
            // setup
            // 
            this.setup.ItemLinks.Add(this.btnLoginNews);
            this.setup.ItemLinks.Add(this.btnProfile);
            this.setup.Name = "setup";
            this.setup.Text = "SETUP";
            // 
            // btnLoginNews
            // 
            this.btnLoginNews.Caption = "Đăng Nhập Mới";
            this.btnLoginNews.Id = 3;
            this.btnLoginNews.Name = "btnLoginNews";
            // 
            // btnProfile
            // 
            this.btnProfile.Caption = "Chọn Profile";
            this.btnProfile.Id = 4;
            this.btnProfile.Name = "btnProfile";
            // 
            // fBegin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 528);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "fBegin";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "fBegin";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupfast;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupTool;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btnOnePost;
        private DevExpress.XtraBars.BarButtonItem btnLoginNews;
        private DevExpress.XtraBars.BarButtonItem btnProfile;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup setup;
    }
}