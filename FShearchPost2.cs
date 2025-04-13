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
using CrawFB.DAO;
using static CrawFB.DAO.ShearchPostDAO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;
using static CrawFB.SetupShearchPost;

namespace CrawFB
{
    public partial class FShearchPost2 : Form
    {
        string projectFolder = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
        string dataFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        string keywordFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "keywords.txt");
        string blacklistfile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "keywordsfilter.txt");
        private Dictionary<int, string> postDetails = new Dictionary<int, string>(); // ✅ Khai báo biến toàn cục
        private int sobai = 10;
        private string thoigian = "1 ngày";
        private int locbai = 2;
        public SetupCompletedHandler SetupCompleted;
        public FShearchPost2()
        {
            InitializeComponent();
            CheckAndCreateKeywordFile();
            AddButtonColumn();
            LoadSettings();
            this.Size = new Size(1100, 600);
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
        public void LoadSettings()
        {
            string configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"Config", "config.txt");
            if (File.Exists(configFilePath))
            {
                try
                {
                    var configData = File.ReadAllLines(configFilePath);

                    if (configData.Length >= 3)
                    {
                        sobai = int.Parse(configData[0]);
                        thoigian = configData[1];
                        locbai = int.Parse(configData[2]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi đọc cấu hình: " + ex.Message);
                }
            }

        }
        private void SaveSettings(int sobai, string thoigian, int locbai)
        {
            // Lưu lại cấu hình vào file config.txt
            string configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", "config.txt");

            try
            {
                File.WriteAllLines(configFilePath, new string[] {
                sobai.ToString(),
                thoigian,
                locbai.ToString()
            });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu cấu hình: " + ex.Message);
            }
        }
        private void SetupForm_SetupCompleted(int sobai, string thoigian, int locbai)
        {
            // Nhận giá trị mới từ form setup và cập nhật
            this.sobai = sobai;
            this.thoigian = thoigian;
            this.locbai = locbai;
            // Lưu lại cấu hình mới vào file
            SaveSettings(sobai, thoigian, locbai);
        }
        private void AddButtonColumn()
        {
            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.Name = "DetailButton";
            btnColumn.HeaderText = "Hành động";
            btnColumn.Text = "Xem chi tiết";
            btnColumn.UseColumnTextForButtonValue = true; // QUAN TRỌNG: Hiển thị text trên button

            dataGridView1.Columns.Add(btnColumn);
        }
        private void btnShearch_Click(object sender, EventArgs e)
        {
            MessageBox.Show("so bai:" +sobai.ToString());
            lblStatus.Text = "🔍 Đang đọc từ khóa...";
            HashSet<string> uniqueLinks = new HashSet<string>();
            List<ShearchPost> listpost = new List<ShearchPost>();
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
            int j = 1;
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
                    searchBox.SendKeys(OpenQA.Selenium.Keys.Control + "a");
                    searchBox.SendKeys(OpenQA.Selenium.Keys.Backspace);
                    searchBox.SendKeys($"\"{keyword}\"");
                    searchBox.SendKeys(OpenQA.Selenium.Keys.Enter);
                    Thread.Sleep(5000);
              

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
                    
                    while (postCount < sobai)
                    {
                        var posts = driver.FindElements(By.CssSelector("div[role='article']"));

                        foreach (var post in posts)
                        {
                            try
                            {
                                string linkbaiviet = "";// link bài tự đăng                                                        
                                string shareCount = "N/A"; string commentCount = "N/A";
                                string trangthai = "N/A";//reset trạng thái
                                string userName = "N/A", userLink = "N/A";
                                string pageName = "", pageLink = "", noidunggoc = "";
                                string fullcontent = ""; string usernameoriginal = "N/A"; string linkoriginal = "N/A";
                                //lấy thông tin bài đăng
                                Console.WriteLine("------bat dau--------");
                                var postinfor = post.FindElements(By.CssSelector("div[class='xu06os2 x1ok221b']"));
                                Console.WriteLine("phần tử postinfor: " + postinfor.Count);
                              List<string> timeList = new List<string>(); // danh sách giờ
                               List<string> linkList = new List<string>(); //danh sách link
                                try
                                {
                                    if (postinfor.Count > 0)
                                    {
                                        (timeList, linkList) = ShearchPostDAO.Instance.ExtractTimeAndLinks(postinfor); // Gọi hàm và nhận tuple
                                    }
                                }
                                catch (ArgumentOutOfRangeException ex)
                                {
                                    Console.WriteLine("❌ Lỗi goi ham ExtractTimeAndLinks: " + ex.Message);
                                    Console.WriteLine("StackTrace: " + ex.StackTrace); // In ra vị trí lỗi
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("❌ Lỗi khác: " + ex.Message);
                                    Console.WriteLine("StackTrace: " + ex.StackTrace); // In ra vị trí lỗi
                                }
                                Console.WriteLine("ket qua timelist la "+timeList.Count);                             
                                Console.WriteLine("ket qua linklist la " + linkList.Count);                                                           
                                string shareTime = "", originalTime = "", sharePostLink = "", originalPostLink = "";               
                                try
                                {
                                    if(timeList.Count > 0 && linkList.Count > 0)
                                    {
                                        var postTypeResult = ShearchPostDAO.Instance.PostTypeDetector(timeList, linkList);// xử lý link và thời gian
                                        Console.WriteLine("✅ PostTypeDetector OK");                                      
                                        Console.WriteLine("🕒 Share time: " + postTypeResult.ShareTime);
                                        Console.WriteLine("🔗 Link bài viết: " + postTypeResult.LinkBaiViet);

                                        // Nếu cần, gán vào biến toàn cục
                                        linkbaiviet = postTypeResult.LinkBaiViet;
                                        shareTime = postTypeResult.ShareTime;
                                        originalTime = postTypeResult.OriginalTime;
                                        sharePostLink = postTypeResult.SharePostLink;
                                        originalPostLink = postTypeResult.OriginalPostLink;
                                    }                                        
                                    // dùng result
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("❌ Lỗi khi gọi PostTypeDetector: " + ex.Message);
                                }
                               
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
                                    switch(timeList.Count)
                                    {
                                        case 0:
                                            if (postinfor.Count == 0) // timlist, linklist =0 thì kiểm tra bài video
                                            {
                                               // trangthai = "bài đăng có video";
                                                Console.WriteLine("bài video");
                                                try { (shareTime, linkbaiviet, trangthai) = ShearchPostDAO.Instance.HandleVideoPost(post); }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine("❌ Lỗi khi gọi HandleVideoPost: " + ex.Message);
                                                }
                                            }
                                            break;
                                        case 1:
                                            if (postinfor.Count == 3) // có nội dung
                                            {
                                                //Console.WriteLine("bài đăng có nội dung");
                                                // kiểm tra có phải bài cá nhân đăng page
                                                var pagePost = postinfor[1].FindElements(By.CssSelector("span[class='xjp7ctv'] > a")); // kiểm tra có phải đăng page
                                                if (pagePost.Count > 0)
                                                {

                                                    // Console.WriteLine("Người đăng: "+page.Text.ToString());
                                                   // Console.WriteLine("bài đăng có nội dung và cá nhân đăng page");
                                                    userName = pagePost[0].Text;
                                                    Console.WriteLine(userName);
                                                    if (!userName.Contains("ẩn danh")) userLink = pagePost[0].GetAttribute("href");
                                                    Console.WriteLine("Địa chỉ người đăng: " + userLink);

                                                    foreach (var inforper in userElement)
                                                    {
                                                        Console.WriteLine("Đăng Trên PAge: " + inforper.Text.ToString());
                                                        pageLink = inforper.GetAttribute("href");
                                                        Console.WriteLine("Địa Chỉ PAge: " + pageLink);
                                                        pageName = inforper.Text;
                                                    }
                                                    trangthai = "Cá nhân Đăng Page";
                                                }
                                                else
                                                {
                                                    //-------------------------------------------// kiểm tra bài đăng cá nhân
                                                    if (userElement.Count > 0)
                                                    {
                                                        try { (trangthai, userName, userLink) = ShearchPostDAO.Instance.GetPostInfo(postinfor[0]); }
                                                        catch (Exception ex)
                                                        {
                                                            Console.WriteLine("❌ Lỗi khi gọi GetPostInfo: " + ex.Message);
                                                        }                                                      
                                                    }
                                                    else
                                                    {
                                                        var specialpost = postinfor[0].FindElements(By.CssSelector("span[class='xjp7ctv']>span>span>a"));

                                                        if (specialpost.Count > 0)
                                                        {
                                                            try { (trangthai, userName, userLink) = ShearchPostDAO.Instance.GetPostInfo(postinfor[0]); }
                                                            catch (Exception ex)
                                                            {
                                                                Console.WriteLine("❌ Lỗi khi gọi GetPostInfo: " + ex.Message);
                                                            }                                                            
                                                        }

                                                    }
                                                }

                                                // lấy nội dung chung
                                                
                                                var contentpost = postinfor[2].FindElements(By.CssSelector("span[class = 'x193iq5w xeuugli x13faqbe x1vvkbs x1xmvt09 x1lliihq x1s928wv xhkezso x1gmr53x x1cpjm7i x1fgarty x1943h6x xudqn12 x3x7a5m x6prxxf xvq8zen xo1l8bm xzsf02u x1yc453h']"));

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
                                                var pagePost = postinfor[1].FindElements(By.CssSelector("span[class='xjp7ctv'] > a")); // kiểm tra có phải đăng page
                                                if (pagePost.Count > 0)
                                                {

                                                    // Console.WriteLine("Người đăng: "+page.Text.ToString());
                                                    // Console.WriteLine("bài đăng có nội dung và cá nhân đăng page");
                                                    userName = pagePost[0].Text;
                                                    Console.WriteLine(userName);
                                                    if (!userName.Contains("ẩn danh")) userLink = pagePost[0].GetAttribute("href");
                                                    Console.WriteLine("Địa chỉ người đăng: " + userLink);

                                                    foreach (var inforper in userElement)
                                                    {
                                                        Console.WriteLine("Đăng Trên PAge: " + inforper.Text.ToString());
                                                        pageLink = inforper.GetAttribute("href");
                                                        Console.WriteLine("Địa Chỉ PAge: " + pageLink);
                                                        pageName = inforper.Text;
                                                    }
                                                    trangthai = "Cá nhân Đăng Page nen mau";
                                                }
                                                else
                                                {
                                                    (trangthai, userName, userLink) = ShearchPostDAO.Instance.GetPostInfo(postinfor[0]);                                               
                                                    trangthai = "bài đăng ca nhan nền màu";
                                                }
                                                // string backgroundContent = "";
                                                var bgContentElements = post.FindElements(By.CssSelector("div[class='xdj266r x11i5rnm xat24cr x1mh8g0r x1vvkbs']"));
                                                if (bgContentElements.Count > 0)
                                                {
                                                    // MessageBox.Show("vao den mau0");
                                                    foreach (var cont in bgContentElements)
                                                    {
                                                        fullcontent += cont.Text.Trim();
                                                    }
                                                }
                                                // fullcontent = backgroundContent;

                                            }
                                            if (postinfor.Count == 5)
                                            {
                                                Console.WriteLine("vào đến postinfor = 5");
                                                (trangthai, userName, userLink) = ShearchPostDAO.Instance.GetPostInfo(postinfor[0]);
                                                var contentpost = postinfor[2].FindElements(By.CssSelector("span[class = 'x193iq5w xeuugli x13faqbe x1vvkbs x1xmvt09 x1lliihq x1s928wv xhkezso x1gmr53x x1cpjm7i x1fgarty x1943h6x xudqn12 x3x7a5m x6prxxf xvq8zen xo1l8bm xzsf02u x1yc453h']"));

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
                                                    trangthai = "bài tự đăng có gắn link ngoài";
                                                }
                                            }
                                            break;
                                        case 2:
                                            if (postinfor.Count == 6) // một bài đăng page một bài khác và bài share lại bài người khácc
                                            {
                                                Console.WriteLine("vào đến postinfor = 6");
                                                noidunggoc = string.Empty;
                                                // kiểm tra bài đăng page
                                                var pagePost = postinfor[1].FindElements(By.CssSelector("span[class = 'x193iq5w xeuugli x13faqbe x1vvkbs x1xmvt09 x1nxh6w3 x1sibtaa x1s688f xi81zsa']")); // kiểm tra có phải đăng page
                                                if (pagePost.Count > 0) // là bài đăng page 
                                                {
                                                    Console.WriteLine("vào đến postinfor = 6 va bai dang page");
                                                    foreach (var page in pagePost)
                                                    {
                                                        userName = page.Text;
                                                        Console.WriteLine(userName);
                                                        if (!userName.Contains("ẩn danh")) userLink = page.GetAttribute("href");
                                                    }
                                                    foreach (var inforper in userElement)
                                                    {
                                                        pageLink = inforper.GetAttribute("href");
                                                        pageLink = ShearchPostDAO.Instance.ShortenFacebookPostLink(pageLink);
                                                        pageName = inforper.Text;
                                                    }

                                                }
                                                else // không phải thì là share lại
                                                {
                                                    Console.WriteLine("vào đến postinfor = 6 va bai share lai");
                                                    var userpost = postinfor[0].FindElements(By.CssSelector("span[class='xjp7ctv'] > a"));
                                                    if (userpost.Count > 0)
                                                    {
                                                        userName = userpost[0].Text.Trim();
                                                        userLink = userpost[0].GetAttribute("href");
                                                        userLink = ShearchPostDAO.Instance.ExtractFbShortLink(userLink);
                                                    }
                                                    trangthai = "bài share lại bài cá nhân, page";
                                                }
                                                // lấy người đăng gốc
                                                var userElement1 = postinfor[3].FindElements(By.CssSelector("span[class='xjp7ctv'] > a"));
                                                if (userElement1.Count > 0)
                                                {
                                                    usernameoriginal = userElement1[0].Text.Trim();
                                                    linkoriginal = userElement1[0].GetAttribute("href");
                                                }
                                                else
                                                {
                                                    var userElement2 = postinfor[3].FindElements(By.CssSelector("span[class='xjp7ctv']>span>span>a"));

                                                    if (userElement2.Count > 0)
                                                    {
                                                        usernameoriginal = userElement2[0].Text.Trim();
                                                        linkoriginal = userElement2[0].GetAttribute("href");
                                                        linkoriginal = ShearchPostDAO.Instance.ExtractFbShortLink(linkoriginal);
                                                        //trangthai = "Bài đăng đặc biệt";
                                                    }
                                                }

                                                var contentpost = postinfor[2].FindElements(By.CssSelector("span[class = 'x193iq5w xeuugli x13faqbe x1vvkbs x1xmvt09 x1lliihq x1s928wv xhkezso x1gmr53x x1cpjm7i x1fgarty x1943h6x xudqn12 x3x7a5m x6prxxf xvq8zen xo1l8bm xzsf02u x1yc453h']"));

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
                                                noidunggoc = ShearchPostDAO.Instance.GetFullPostContent(postinfor[5]);
                                            }
                                            else if (postinfor.Count == 5)
                                            {
                                                var indexuser = post.FindElements(By.CssSelector("span[class='xjp7ctv'] > a"));
                                                if (indexuser.Count == 6)
                                                {
                                                    trangthai = "đăng lên page một bài của người khác";
                                                    userName = indexuser[4].Text;
                                                    pageName = indexuser[4].Text;

                                                    var fullcontent2 = postinfor[2];
                                                    fullcontent = ShearchPostDAO.Instance.GetFullPostContent(fullcontent2);

                                                    var userElement1 = postinfor[3].FindElements(By.CssSelector("span[class='xjp7ctv'] > a"));
                                                    if (userElement1.Count > 0)
                                                    {
                                                        usernameoriginal = userElement1[0].Text.Trim();
                                                        linkoriginal = userElement1[0].GetAttribute("href");
                                                        linkoriginal = ShearchPostDAO.Instance.ExtractFbShortLink(linkoriginal);
                                                    }
                                                    else
                                                    {
                                                        var userElement2 = postinfor[3].FindElements(By.CssSelector("span[class='xjp7ctv']>span>span>a"));

                                                        if (userElement2.Count > 0)
                                                        {
                                                            usernameoriginal = userElement2[0].Text.Trim();
                                                            linkoriginal = userElement2[0].GetAttribute("href");
                                                            linkoriginal = ShearchPostDAO.Instance.ExtractFbShortLink(linkoriginal);
                                                            //trangthai = "Bài đăng đặc biệt";
                                                        }
                                                    }
                                                }


                                            }
                                        break;
                                    }
                                    // phần chung
                                    try
                                    {
                                        var sharecoment = post.FindElements(By.CssSelector("div[class='x9f619 x1n2onr6 x1ja2u2z x78zum5 xdt5ytf x2lah0s x193iq5w xeuugli xsyo7zv x16hj40l x10b6aqq x1yrsyyn']"));
                                        foreach (var sharet in sharecoment)
                                        {
                                           
                                            string textContent = sharet.Text;
                                            if (textContent.Contains("bình luận") == true)
                                            {
                                                commentCount = textContent;
                                            }
                                            else shareCount = textContent;
                                        }
                                        Console.WriteLine($"Số bình luận: {commentCount}, Số chia sẻ: {shareCount}");
                                    }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine("❌ Lỗi khi lấy số lượt chia sẻ: " + ex.Message);
                                                }
                        }
                                List<string> tuKhoaTieuCuc = File.ReadAllLines(blacklistfile)
                                 .Select(x => x.Trim().ToLower())
                                 .Where(x => !string.IsNullOrEmpty(x))
                                 .ToList();
                                int diemtieucuc = 0;
                                string noiDungLower = fullcontent.ToLower();
                                foreach (var tu in tuKhoaTieuCuc)
                                {
                                    if (noiDungLower.Contains(tu))
                                    {
                                        diemtieucuc++;
                                    }
                                }
                                listpost.Add(new ShearchPost(userName, userLink, shareTime, linkbaiviet, fullcontent, originalTime, originalPostLink, usernameoriginal, noidunggoc, pageName, pageLink, shareCount, commentCount,trangthai, diemtieucuc));
                                postCount++;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("❌ Lỗi khi lấy dữ liệu bài viết: " + ex.Message);
                            }
                        }

                        if (postCount < sobai)
                        {
                            Console.WriteLine("⬇️ Đang cuộn xuống để lấy thêm bài viết...");
                            driver.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
                            Thread.Sleep(2000);
                        }
                    }
                    lblStatus.Text = "Lấy Xong Bài Viết từ khóa: " + keyword;
                }

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
            }
            finally
            {
                driver.Quit();
            }
            var listTieuCuc = listpost
            .Where(p => p.Diemtieucuc > 0)
             .OrderByDescending(p => p.Diemtieucuc)
            .ToList();
            Console.WriteLine(" so phan tu listpot :" +listpost.Count);
            Console.WriteLine(" so phan tu listieucuc :" + listTieuCuc.Count);
            foreach (ShearchPost post in listTieuCuc)
            {
                // Ví dụ hiển thị: Content, LinkPost, TimePost, ShareCount, CommentCount1
                int rowIndex = dataGridView1.Rows.Add(j++, post.Content, post.LinkPost, post.TimePost, post.ShareCount, post.CommentCount, post.StatusPost, post.Diemtieucuc);

                // Lưu đối tượng post vào thuộc tính Tag của dòng
                dataGridView1.Rows[rowIndex].Tag = post;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtFullPost.Text = row.Cells["noidung"].Value?.ToString();
                txblinkbv.Text = row.Cells["diachibv"].Value?.ToString();
            
                if (dataGridView1.Columns[e.ColumnIndex].Name == "DetailButton" && e.RowIndex >= 0)
                {
                    ShearchPost selectedPost = dataGridView1.Rows[e.RowIndex].Tag as ShearchPost;
                    if (selectedPost != null)
                    {
                        // Nếu cần so sánh LinkPost với đối tượng trong List (ví dụ: nếu có nhiều kết quả trùng nhau)
                        // Bạn có thể dùng LINQ như sau:
                        // ShearchPost postDetail = listPost.FirstOrDefault(p => p.LinkPost == selectedPost.LinkPost);

                        // Nếu đã tìm thấy, truyền dữ liệu sang form chi tiết

                        FDetailShearchPost detailForm = new FDetailShearchPost();

                        // Ví dụ: truyền dữ liệu thông qua phương thức SetData
                        detailForm.SetData(
                           selectedPost.LinkPost,         // link bài đăng
                            selectedPost.ShareCount,         // share count
                             selectedPost.CommentCount,      // comment count
                             selectedPost.TimePost,           // thời gian đăng (có thể dùng làm trạng thái nếu cần)
                             selectedPost.PosterName,         // tên người đăng
                            selectedPost.PosterLink,         // link người đăng
                            selectedPost.PageName,           // tên page
                             selectedPost.PageLink,           // link page
                            selectedPost.OriginalContent,    // nội dung gốc
                             selectedPost.Content,            // full content
                             selectedPost.OriginalPostLink,
                             selectedPost.UserNameOriginal,// link bài gốc
                             selectedPost.OriginalTime,
                             selectedPost.StatusPost
                            );        // thời gian bài gốc


                        detailForm.ShowDialog();
                    }
                }
            }
        }

        private void btnsetup_Click(object sender, EventArgs e)
        {
            SetupShearchPost setupForm = new SetupShearchPost();
            setupForm.setupCompletedHandler += SetupForm_SetupCompleted;
            setupForm.ShowDialog(); // Mở cửa sổ cài đặt dưới dạng modal
        }
    }
}
