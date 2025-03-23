using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace CrawFB.DAO
{
    public class ShearchPostDAO
    {
        private static ShearchPostDAO instance;
        public static ShearchPostDAO Instance {
            get { if (instance == null) instance = new ShearchPostDAO(); return ShearchPostDAO.instance; }
            private set { ShearchPostDAO.instance = value; }
        }
        public string ExtractFbShortLink(string url)
        {
            // Kiểm tra nếu có ID
            var matchId = Regex.Match(url, @"id=(\d+)");
            if (matchId.Success)
            {
                return $"https://fb.com/{matchId.Groups[1].Value}";
            }

            // Nếu không có ID, lấy tên rút gọn
            var matchShortName = Regex.Match(url, @"facebook\.com/([^/?]+)");
            if (matchShortName.Success)
            {
                return $"https://fb.com/{matchShortName.Groups[1].Value}";
            }

            return "Invalid URL";
        }
        public string GetFullPostContent(IWebElement element)
        {
            string fullContent = "";
            try
            {
                // Tìm tất cả các thẻ span chứa nội dung bài viết
                var contentElements = element.FindElements(By.CssSelector("span[class = 'x193iq5w xeuugli x13faqbe x1vvkbs x1xmvt09 x1lliihq x1s928wv xhkezso x1gmr53x x1cpjm7i x1fgarty x1943h6x xudqn12 x3x7a5m x6prxxf xvq8zen xo1l8bm xzsf02u x1yc453h']"));

                foreach (var content in contentElements)
                {
                    if (content.Text.Contains("Xem thêm"))
                    {
                        try
                        {
                            // Tìm nút "Xem thêm" bên trong phần tử và click
                            var seeMoreButton = content.FindElement(By.CssSelector("div[role='button']"));
                            Thread.Sleep(1000);
                            seeMoreButton.Click();
                            Thread.Sleep(2000); // Chờ nội dung mở rộng
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Lỗi khi click 'Xem thêm': " + ex.Message);
                        }
                    }
                    fullContent += content.Text.Trim() + "\n";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy nội dung bài viết: " + ex.Message);
            }

            return fullContent.Trim();
        }
        public (string trangthai, string userName, string userLink) GetPostInfo(IWebElement postElement)
        {
            string trangthai = "Không xác định";
            string userName = string.Empty;
            string userLink = string.Empty;

            // Tìm user thông thường
            var userElement = postElement.FindElements(By.CssSelector("span[class='xjp7ctv'] > a"));
            if (userElement.Count > 0)
            {
                userName = userElement[0].Text.Trim();
                userLink = ShearchPostDAO.Instance.ExtractFbShortLink(userElement[0].GetAttribute("href"));
                trangthai = "Bài cá nhân, Page tự đăng";
            }
            else
            {
                // Tìm user ở bài đăng đặc biệt
                var specialpost = postElement.FindElements(By.CssSelector("span[class='xjp7ctv']>span>span>a"));
                if (specialpost.Count > 0)
                {
                    userName = specialpost[0].Text.Trim();
                    userLink = ShearchPostDAO.Instance.ExtractFbShortLink(specialpost[0].GetAttribute("href"));
                    trangthai = "Bài đăng đặc biệt";
                }
            }

            return (trangthai, userName, userLink);
        }
        public string ShortenFacebookPostLink(string originalLink)
        {
            try
            {
                // Tìm vị trí của "?__" để cắt bớt phần dư
                int index = originalLink.IndexOf("?__");
                if (index != -1)
                {
                    originalLink = originalLink.Substring(0, index);
                }

                // Chuyển domain về dạng rút gọn "https://fb.com/"
                originalLink = originalLink.Replace("https://www.facebook.com/", "https://fb.com/");

                return originalLink;
            }
            catch
            {
                return originalLink; // Trả về link gốc nếu có lỗi
            }
        }
    }
}
