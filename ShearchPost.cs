using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace CrawFB.DTO
{
    public class ShearchPost
    {
        private string commentCount;
        private string originalContent;
        private string statusPost;
        private string userNameOriginal;
        private int diemtieucuc;
        public ShearchPost(string postername, string posterlink, string timepost, string linkpost, string content, string originaltime, string originalpostlink, string userNameOriginal ,string originalcontent , string pagename, string pagelink, string sharecount, string commentcount, string status, int diemtieucuc)
        {
            this.PosterName = postername;
            this.PosterLink = posterlink; 
            this.LinkPost = linkpost;
            this.TimePost = timepost;
            this.PageLink = pagelink;
            this.OriginalPostLink = originalpostlink;
            this.Content = content;
            this.OriginalTime = originaltime;
            this.PageName = pagename;
            this.PageLink = pagelink;
            this.CommentCount = commentcount;
            this.ShareCount = sharecount;
            this.originalContent = originalcontent;
            this.StatusPost = status;
            this.UserNameOriginal = userNameOriginal;
            this.Diemtieucuc = diemtieucuc;
                
        }      
        public string PosterName { get; set; } // Người đăng bài (có thể là người share)
        public string PosterLink { get; set; } // Link Facebook của người đăng
        public string PageName { get; set; } // Tên page nếu là bài từ page
        public string PageLink { get; set; } // Link của page nếu có
        public string TimePost { get; set; } // Thời gian bài đăng, share (nếu có)
        public string LinkPost { get; set; } // Link bài đăng, share (nếu có)
        public string OriginalTime { get; set; } // Thời gian bài gốc (nếu có)
        public string OriginalPostLink { get; set; } // Link bài gốc (nếu có)
        public string Content { get; set; } // Nội dung bài viết
        public string ShareCount { get; set; } // Số lượt chia sẻ
        
        public string OriginalContent { get => originalContent; set => originalContent = value; }
        public string StatusPost { get => statusPost; set => statusPost = value; }
        public string CommentCount { get => commentCount; set => commentCount = value; }
        public string UserNameOriginal { get => userNameOriginal; set => userNameOriginal = value; }
        public int Diemtieucuc { get => diemtieucuc; set => diemtieucuc = value; }
    }
}
