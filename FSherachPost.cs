using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using DevExpress.Utils;
using static System.Windows.Forms.LinkLabel;
using System.Net.Http;
using static DevExpress.Data.Filtering.Helpers.SubExprHelper;
using CrawFB.DTO;
using System.Text.RegularExpressions;
using DevExpress.XtraPrinting.Shape;
using DevExpress.XtraPrinting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace CrawFB
{
    public partial class FSherachPost : Form
    {
        string projectFolder = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
        string dataFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        string keywordFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "keywords.txt");
        private Dictionary<int, string> postDetails = new Dictionary<int, string>(); // ✅ Khai báo biến toàn cục
        public FSherachPost()
        {
            InitializeComponent();
            CheckAndCreateKeywordFile();
        }
        private void CheckAndCreateKeywordFile()
        {
            // Tạo thư mục Data nếu chưa có
            if (!Directory.Exists(dataFolder))
            {
                Directory.CreateDirectory(dataFolder);
            }

            // Kiểm tra file keywords.txt
            if (!File.Exists(keywordFile))
            {
                File.WriteAllText(keywordFile, ""); // Tạo file rỗng
                MessageBox.Show("📂 Đã tạo file 'keywords.txt'. Hãy nhập từ khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start("notepad.exe", keywordFile); // Mở Notepad
            }
        }


        private void btnShearch_Click(object sender, EventArgs e)
        {
         
            lblStatus.Text = "🔍 Đang đọc từ khóa...";
            HashSet<string> uniqueLinks = new HashSet<string>();
            List<ShearchPost> listshearchpost = new List<ShearchPost>();
            // Đọc từ khóa từ file
            if (!File.Exists(keywordFile))
            {
                MessageBox.Show("❌ Không tìm thấy file keywords.txt!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> keywords = new List<string>(File.ReadAllLines(keywordFile));
            if (keywords.Count == 0)
            {
                MessageBox.Show("❌ File keywords.txt trống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Process.Start("notepad.exe", keywordFile); // Mở lại Notepad nếu trống
                return;
            }

            lblStatus.Text = "✅ Đã tải " + keywords.Count + " từ khóa.";

            // Cấu hình Selenium WebDriver
            ChromeOptions options = Libary.Instance.Options();
            ChromeDriver driver = new ChromeDriver(options);

            try
            {
                driver.Navigate().GoToUrl("https://www.facebook.com/");
                Thread.Sleep(3000);
                string pageSource = driver.PageSource;

                if (pageSource.Contains("Đăng nhập") || pageSource.Contains("Log in"))
                {
                    Console.WriteLine("⚠ Profile chưa đăng nhập! Kiểm tra lại đường dẫn profile.");
                }
                else
                {
                    Console.WriteLine("✅ Đã đăng nhập Facebook thành công.");
                }
                foreach (string keyword in keywords)
                {
                   
                    lblStatus.Text = $"🔄 Đang tìm '{keyword}'...";

                    IWebElement searchBox = driver.FindElement(By.XPath("//input[@type='search']"));
                    searchBox.SendKeys(keyword);
                    searchBox.SendKeys(OpenQA.Selenium.Keys.Enter);
                    Thread.Sleep(5000);
                    //int maxPosts = 10; // Lấy tối đa 10 bài viết

                    List<string> uniquePosts = new List<string>();
                    int postCount = 0;
                    var btnposts = driver.FindElements(By.CssSelector("span[class = 'x193iq5w xeuugli x13faqbe x1vvkbs x1xmvt09 x6prxxf xvq8zen xk50ysn xzsf02u']"));
                    foreach (var btnpost in btnposts)
                    {                        
                        if (btnpost.Text == "Bài viết") btnpost.Click();
                    }
                    Thread.Sleep(10000);
                    var baivietu = driver.FindElement(By.CssSelector("input[aria-label = 'Bài viết từ']"));
                    if (baivietu != null) { baivietu.Click(); }
                    Libary.Instance.randomtime(2000, 4000);
                    var moinguoi = driver.FindElement(By.CssSelector("li[id = 'Mọi người']"));
                    if (moinguoi != null) { moinguoi.Click(); }
                    Libary.Instance.randomtime(2000, 4000);
                    var thoigian = driver.FindElement(By.CssSelector("input[aria-label = 'Bài viết gần đây']"));
                    if (thoigian != null) { thoigian.Click(); }
                    Libary.Instance.randomtime(6000, 10000); ;
                    int j = 1;
                    while (postCount < 7)
                    {
                        //driver.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
                        var posts = driver.FindElements(By.CssSelector("div[role='article']"));
                       
                        foreach (var post in posts)
                        {
                            try
                            {
                                string linkbaiviet = "";// link bài tự đăng                                                        
                               string linkpage = ""; string shareCount = "N/A";
                                string trangthai = "N/A";//reset trạng thái
                                string userName = "N/A", userLink = "N/A";
                                string pageName = "", pageLink = "";                              
                                string fullcontent = "";
                                //lấy thông tin bài đăng
                                Console.WriteLine("------bat dau--------");
                                var postinfor = post.FindElements(By.CssSelector("div[class='xu06os2 x1ok221b']"));
                                Console.WriteLine("phần tử postinfor: " + postinfor.Count);
                                List<string> timeList = new List<string>(); // danh sách giờ
                                List<string> linkList = new List<string>(); //danh sách link                                                                                                                                                  
                                        foreach (var temp in postinfor)
                                        {
                                            string textContent = temp.Text.Trim();
                                            if (!string.IsNullOrEmpty(textContent) && Regex.IsMatch(textContent, @"(\d+\s*(giờ|phút|ngày|hôm qua|Tháng))", RegexOptions.IgnoreCase))
                                            {
                                                timeList.Add(textContent);

                                                var hrefElement = temp.FindElements(By.CssSelector("a[class*='x1i10hfl']")); // Lấy href
                                                if (hrefElement.Count > 0) linkList.Add(hrefElement[0].GetAttribute("href"));
                                                else linkList.Add(""); // Nếu không có link, thêm chuỗi rỗng
                                            }
                                        }
                                    string shareTime = "", originalTime = "", sharePostLink = "", originalPostLink = "";
                                    if (timeList.Count == 1)
                                    {
                                        // 🔸 Bài tự đăng
                                        originalTime = timeList[0];
                                        originalPostLink = linkList[0];
                                        linkbaiviet = originalPostLink;
                                    }
                                    else if (timeList.Count == 2)
                                    {
                                        // 🔹 Bài share
                                        shareTime = timeList[0];
                                        originalTime = timeList[1];
                                        sharePostLink = linkList[0];
                                        originalPostLink = linkList[1];
                                    linkbaiviet = sharePostLink;
                                }
                                    Console.WriteLine("thời gian 1:" + originalTime);
                                    Console.WriteLine("thời gian 2:" + shareTime);
                                    // 🛑 Kiểm tra trùng lặp bài viết                                                                 
                                    if (!uniqueLinks.Add(linkbaiviet))
                                    {
                                        Console.WriteLine("❌ Bỏ qua bài viết trùng: ");
                                        continue;
                                    }
                                    else //Nếu chưa có mới tiếp tục làm
                                    {
                                        //phần tử đầu tiên luôn là người đăng hoặc share lại
                                    
                                        var userElement = postinfor[0].FindElements(By.CssSelector("span[class='xjp7ctv'] > a"));
                                        if (timeList.Count == 1)
                                        {
                                            var pagePost = postinfor[1].FindElements(By.CssSelector("span[class='x193iq5w xeuugli']")); // kiểm tra có phải đăng page
                                            if (pagePost.Count > 0)
                                            {
                                                foreach (var page in pagePost)
                                                {
                                                    // Console.WriteLine("Người đăng: "+page.Text.ToString());
                                                    userName = page.Text;
                                                    Console.WriteLine(userName);
                                                    if (!userName.Contains("ẩn danh")) userLink = page.GetAttribute("href");
                                                    Console.WriteLine("Địa chỉ người đăng: " + userLink);
                                                }
                                                foreach (var inforper in userElement)
                                                {
                                                    Console.WriteLine("Đăng Trên PAge: " + inforper.Text.ToString());
                                                    pageLink = inforper.GetAttribute("href");
                                                    Console.WriteLine("Địa Chỉ PAge: " + linkpage);
                                                    pageName = inforper.Text;
                                                    // Console.WriteLine(namepage);
                                                }
                                            trangthai = "Cá nhân Đăng Page";
                                            }
                                            // 🔸 Bài tự đăng
                                            if (userElement.Count > 0)
                                            {
                                                userName = userElement[0].Text.Trim();
                                                userLink = userElement[0].GetAttribute("href");
                                            trangthai = "Bài cá nhân, Page tự đăng";
                                            }
                                            Console.WriteLine("bài tự đăng: " + userName + " link:" + userLink);
                                            if (postinfor.Count == 0)
                                            {
                                            trangthai = "bài đăng có video";
                                                Console.WriteLine("bài video");
                                                var videopost = post.FindElements(By.CssSelector("a[class ='x1i10hfl xjbqb8w x1ejq31n xd10rxx x1sy0etr x17r0tee x972fbf xcfux6l x1qhh985 xm0m39n x9f619 x1ypdohk xt0psk2 xe8uvvx xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x16tdsg8 x1hl2dhg xggy1nq x1a2a7pz x1heor9g xkrqix3 x1sur9pj x1s688f']"));
                                                if (videopost.Count > 0)
                                                {
                                                    foreach (var v in videopost)
                                                    {
                                                        Console.WriteLine(v.Text.ToString());
                                                        Console.WriteLine(v.GetAttribute("href").ToString());
                                                    }
                                                }
                                                var timevideopost = post.FindElements(By.CssSelector("span[class = 'html-span xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x1hl2dhg x16tdsg8 x1vvkbs x4k7w5x x1h91t0o x1h9r5lt x1jfb8zj xv2umb2 x1beo9mf xaigb6o x12ejxvf x3igimt xarpa2k xedcshv x1lytzrv x1t2pt76 x7ja8zs x1qrby5j']"));
                                                if (timevideopost.Count > 0)
                                                {
                                                    foreach (var t in timevideopost)
                                                    {
                                                        Console.WriteLine(t.Text.ToString());
                                                        // Console.WriteLine(t.GetAttribute("href").ToString());
                                                    }
                                                }
                                            }
                                            if (postinfor.Count == 3) // có nội dung
                                            {
                                            trangthai = "bài đăng bình thường";
                                                try
                                                {
                                                    var countShareElement = post.FindElement(By.CssSelector("span[class='html-span xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x1hl2dhg x16tdsg8 x1vvkbs xkrqix3 x1sur9pj']"));
                                                    shareCount = countShareElement.Text.Trim();
                                                }
                                                catch (NoSuchElementException)
                                                {
                                                    shareCount = "N/A"; // Không có số lượt chia sẻ
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine("❌ Lỗi khi lấy số lượt chia sẻ: " + ex.Message);
                                                }
                                                var contentpost = post.FindElements(By.CssSelector("span[class = 'x193iq5w xeuugli x13faqbe x1vvkbs x1xmvt09 x1lliihq x1s928wv xhkezso x1gmr53x x1cpjm7i x1fgarty x1943h6x xudqn12 x3x7a5m x6prxxf xvq8zen xo1l8bm xzsf02u x1yc453h']"));

                                                foreach (var content in contentpost)
                                                {
                                                    if (content.Text.IndexOf("Xem thêm") != -1)
                                                    {
                                                        try
                                                        {
                                                            // Tìm `div[role='button']` bên trong `span` đó
                                                            var seeMoreButton = content.FindElement(By.CssSelector("div[role='button']"));
                                                            // Click để mở rộng nội dung
                                                            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", seeMoreButton);
                                                            Thread.Sleep(1000); // Đợi 1s trước khi click
                                                            seeMoreButton.Click();
                                                            Thread.Sleep(2000); // Chờ nội dung mở rộng
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            Console.WriteLine("Lỗi khi click 'Xem thêm': " + ex.Message);
                                                        }
                                                    }
                                                    fullcontent += content.Text.Trim() + "\n";
                                                }
                                                Console.WriteLine("nôi dung bai viet: " + fullcontent);
                                            }
                                            if (postinfor.Count == 2) // kiểm tra xem có chữ nền ảnh
                                            {
                                                string backgroundContent = "";
                                                var bgContentElements = post.FindElements(By.CssSelector("div[class='xdj266r x11i5rnm']"));
                                                if (bgContentElements.Count > 0)
                                                {
                                                    backgroundContent = bgContentElements[0].Text.Trim();
                                                }
                                            fullcontent = backgroundContent;
                                            trangthai = "bài đăng nền màu";
                                        }
                                        }
                                        else if (timeList.Count == 2)
                                        {
                                        if (userElement.Count > 0)
                                        {
                                            userName = userElement[0].Text.Trim();
                                            userLink = userElement[0].GetAttribute("href");
                                        }
                                        Console.WriteLine("bài share lại: " + userName + " link:" + userLink);
                                        if (postinfor.Count == 6) // share lại page đủ 2 nội dung
                                            {
                                            trangthai = "bài share lại bài cá nhân, page";
                                            var contentpost = post.FindElements(By.CssSelector("span[class = 'x193iq5w xeuugli x13faqbe x1vvkbs x1xmvt09 x1lliihq x1s928wv xhkezso x1gmr53x x1cpjm7i x1fgarty x1943h6x xudqn12 x3x7a5m x6prxxf xvq8zen xo1l8bm xzsf02u x1yc453h']"));

                                                foreach (var content in contentpost)
                                                {
                                                    if (content.Text.IndexOf("Xem thêm") != -1)
                                                    {
                                                        try
                                                        {
                                                            // Tìm `div[role='button']` bên trong `span` đó
                                                            var seeMoreButton = content.FindElement(By.CssSelector("div[role='button']"));
                                                            // Click để mở rộng nội dung
                                                            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", seeMoreButton);
                                                            Thread.Sleep(1000); // Đợi 1s trước khi click
                                                            seeMoreButton.Click();
                                                            Thread.Sleep(2000); // Chờ nội dung mở rộng
                                                        }
                                                        catch (Exception ex)
                                                        {
                                                            Console.WriteLine("Lỗi khi click 'Xem thêm': " + ex.Message);
                                                        }
                                                    }
                                                    fullcontent += content.Text.Trim() + "\n";
                                                }
                                                Console.WriteLine("nôi dung bai viet: " + fullcontent);
                                            }
                                        }
                                        else if (postinfor.Count == 5)
                                    {
                                        var indexuser = post.FindElements(By.CssSelector("span[class='xjp7ctv'] > a"));
                                        if (indexuser.Count == 6)
                                        {
                                            trangthai = "đăng lên page một bài của người khác";
                                            userName = indexuser[4].Text;
                                            pageName = indexuser[4].Text;
                                        }    
                                    }    
                                   


                                    }
                                //listshearchpost.Add(new ShearchPost(userName, userLink, shareTime, linkbaiviet, originalTime, originalPostLink, fullcontent, pageName, pageLink, shareCount, ""));
                                dataGridView1.Rows.Add(j++, fullcontent, userName, userLink, shareTime, linkbaiviet, pageName, pageLink, originalPostLink, originalTime, shareCount, trangthai);
                                    postCount++;                           
                                
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("❌ Lỗi khi lấy dữ liệu bài viết: " + ex.Message);
                            }                         
                        }

                        if (postCount < 7)
                        {
                            Console.WriteLine("⬇️ Đang cuộn xuống để lấy thêm bài viết...");
                            driver.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
                            Thread.Sleep(2000);
                        }                      
                    }
                }

                MessageBox.Show("✅ Đã lấy xong bài viết!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                driver.Quit();
            }
        }

        private void btnOpenKeywords_Click(object sender, EventArgs e)
        {
            if (File.Exists(keywordFile))
            {
                Process.Start("notepad.exe", keywordFile);
            }
            else
            {
                MessageBox.Show("❌ File keywords.txt chưa tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex > 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
               txtFullPost.Text = row.Cells["noidung"].Value?.ToString();
            }    
        }
    }
}

