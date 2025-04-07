using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrawFB
{
    public partial class FDetailShearchPost : Form
    {
        public FDetailShearchPost()
        {
            InitializeComponent();
            lblLinkPost.MaximumSize = new Size(panelLinkPost.Width - 10, 0);
            lblUserLink.MaximumSize = new Size(panelUserLink.Width - 10, 0);
            lblUserName.MaximumSize = new Size(panelUserName.Width - 10, 0);
            //lblContent.MaximumSize = new Size(panelConntent.Width - 10, 0);
            lblStatusPost.MaximumSize = new Size(panelstatuspost.Width - 10, 0);
        }
        public void SetData(
       string linkPost, string shareCount, string commentCount, string timePost,
       string UserName, string UserLink, string pageName, string pageLink,
       string originalContent, string content, string originalPostLink, string userNameOriginal, string originalTime, string trangthai)
        {
            lblLinkPost.Text = linkPost;
            lblShareCount.Text = shareCount;
            lblCommentCount.Text = commentCount;
            lblTimePost.Text = timePost;
            lblUserName.Text = UserName;
            lblUserLink.Text = UserLink;
            lblPageName.Text = pageName;
            lblPageLink.Text = pageLink;
           rTbContentOriginal.Text = originalContent;
            rTbContent.Text = content;
            lblOriginalLink.Text = originalPostLink;
            lblOriginalTime.Text = originalTime;
            lblTimePost.Text = timePost;
            lblStatusPost.Text = trangthai;
            lblOrinialName.Text = userNameOriginal;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
