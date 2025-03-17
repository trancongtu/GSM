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
                   
                    while (postCount < 7)
                    {
                        //driver.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
                        var posts = driver.FindElements(By.CssSelector("div[role='article']"));

                        foreach (var post in posts)
                        {
                            try
                            {
                                string linkbaiviet = "";// link bài tự đăng
                                string linkshare = "";// link share lại
                                string linkgoc = "";// link bài gốc
                                string linkFb = "";// link người đăng
                                string nameFb = "";// Tên người đăng
                                string share = "";
                                string comment = "";
                                string tgdang = "";// thời gian tự đăng
                                string thoigianlinkgoc = "";// thời gian bài gốc đăng đối với bài share lại
                                string fullcontent = "";
                                string linkchot = "";// link lưu post
                                string namepage = "";// tên page được đối tượng đăng
                                string linkpage = "";
                                int trangthai = -1;//reset trạng thái
                                int sodem = 1;
                                int indextime = -1;
                                int indexpost = -1;
                                //lấy thông tin bài đăng
                                var postinfor = post.FindElements(By.CssSelector("div[class='xu06os2 x1ok221b']"));
                                if (postinfor.Count < 2) continue;
                                else
                                {
                                    Console.WriteLine("--------------");
                                    if (postinfor.Count == 3) // đăng page, đăng cá nhân, share ảnh, video
                                    {
                                        
                                        Console.WriteLine(postinfor.Count);
                                        //Console.WriteLine("Bài Thứ: " + sodem++);
                                        // Thời gian đăng và xác định trạng thái//  
                                        // lấy thời gian, link bài viết
                                        var timepost = postinfor[1].FindElements(By.CssSelector("a[class = 'x1i10hfl xjbqb8w x1ejq31n xd10rxx x1sy0etr x17r0tee x972fbf xcfux6l x1qhh985 xm0m39n x9f619 x1ypdohk xt0psk2 xe8uvvx xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x16tdsg8 x1hl2dhg xggy1nq x1a2a7pz x1heor9g xkrqix3 x1sur9pj x1s688f']"));
                                        var personpost = postinfor[0].FindElements(By.CssSelector("span[class='xjp7ctv'] > a"));
                                        var pagepost = postinfor[1].FindElements(By.CssSelector("span[class = 'x193iq5w xeuugli x13faqbe x1vvkbs x1xmvt09 x1nxh6w3 x1sibtaa x1s688f xi81zsa']"));
                                        if (pagepost.Count > 0)// là bài đăng trên page
                                        {
                                            foreach (var page in pagepost)
                                            {
                                                // Console.WriteLine("Người đăng: "+page.Text.ToString());
                                                nameFb = page.Text;
                                                Console.WriteLine(nameFb);
                                                if (!nameFb.Contains("ẩn danh")) linkFb = page.GetAttribute("href");
                                                Console.WriteLine("Địa chỉ người đăng: " + linkFb);
                                            }
                                            foreach (var inforper in personpost)
                                            {
                                                Console.WriteLine("Đăng Trên PAge: " + inforper.Text.ToString());
                                                linkpage = inforper.GetAttribute("href");
                                                Console.WriteLine("Địa Chỉ PAge: " + linkpage);
                                                namepage = inforper.Text;
                                                // Console.WriteLine(namepage);
                                            }
                                        }
                                        else
                                        {                                          
                                            foreach (var inforper in personpost)
                                            {
                                                Console.WriteLine("Bài đăng thường với tên: " + inforper.Text.ToString());
                                                linkFb = inforper.GetAttribute("href");
                                                Console.WriteLine("Địa chỉ fb đăng: " + linkFb);
                                            }
                                        }
                                        foreach (var time in timepost)
                                        {
                                            Console.WriteLine("thoi gian dang: " + time.Text.ToString());
                                            tgdang = time.Text;
                                            linkbaiviet = time.GetAttribute("href");
                                            Console.WriteLine("địa chỉ bài viết: " + linkbaiviet);
                                        }
                                    }
                                    else
                                    {
                                        if (postinfor.Count == 6) // share lại page đủ 2 nội dung
                                        {
                                            var pagepost = postinfor[0].FindElements(By.CssSelector("span[class='xjp7ctv'] > a"));
                                            foreach (var inforpage in pagepost)
                                            {
                                                Console.WriteLine("Đăng Trên PAge: " + inforpage.Text.ToString());
                                                linkpage = inforpage.GetAttribute("href");
                                                Console.WriteLine("Địa Chỉ PAge: " + linkpage);
                                                namepage = inforpage.Text;
                                                // Console.WriteLine(namepage);
                                            }
                                            var personpost = postinfor[1].FindElements(By.CssSelector("span[class='xjp7ctv'] > a"));
                                            foreach (var inforper in personpost)
                                            {
                                                Console.WriteLine("Tài khoản đăng: " + inforper.Text.ToString());
                                                linkFb= inforper.GetAttribute("href");
                                                Console.WriteLine("Địa Chỉ fb: " + linkFb);
                                                nameFb = inforper.Text;
                                                // Console.WriteLine(namepage);
                                            }
                                            var timepost = postinfor[1].FindElements(By.CssSelector("a[class = 'x1i10hfl xjbqb8w x1ejq31n xd10rxx x1sy0etr x17r0tee x972fbf xcfux6l x1qhh985 xm0m39n x9f619 x1ypdohk xt0psk2 xe8uvvx xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x16tdsg8 x1hl2dhg xggy1nq x1a2a7pz x1heor9g xkrqix3 x1sur9pj x1s688f']"));
                                            foreach (var time in timepost)
                                            {
                                                Console.WriteLine("thoi gian dang: " + time.Text.ToString());
                                                tgdang = time.Text;
                                                linkbaiviet = time.GetAttribute("href");
                                                Console.WriteLine("địa chỉ bài viết: " + linkbaiviet);
                                            }
                                            var pagepost2 = postinfor[4].FindElements(By.CssSelector("span[class='xjp7ctv'] > a"));
                                            foreach (var inforpage in pagepost2)
                                            {
                                                Console.WriteLine("tên nơi đăng gốc: " + inforpage.Text.ToString());                                               
                                                Console.WriteLine("Địa Chỉ của nơi đăng: " + inforpage.GetAttribute("href").ToString());
                                                namepage = inforpage.Text;
                                                // Console.WriteLine(namepage);
                                            }
                                            var personpost2 = postinfor[5].FindElements(By.CssSelector("span[class='xjp7ctv'] > a"));
                                            foreach (var inforper in personpost2)
                                            {
                                                Console.WriteLine("Tài khoản đăng gốc: " + inforper.Text.ToString());
                                                //linkFb = inforper.GetAttribute("href");
                                                Console.WriteLine("Địa Chỉ fb: " + inforper.GetAttribute("href").ToString());
                                                //nameFb = inforper.Text;
                                                // Console.WriteLine(namepage);
                                            }
                                            var timepost2 = postinfor[5].FindElements(By.CssSelector("a[class = 'x1i10hfl xjbqb8w x1ejq31n xd10rxx x1sy0etr x17r0tee x972fbf xcfux6l x1qhh985 xm0m39n x9f619 x1ypdohk xt0psk2 xe8uvvx xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x16tdsg8 x1hl2dhg xggy1nq x1a2a7pz x1heor9g xkrqix3 x1sur9pj x1s688f']"));
                                            foreach (var timegoc in timepost2)
                                            {
                                                Console.WriteLine("thoi gian dang: " + timegoc.Text.ToString());
                                                //tgdang = time.Text;
                                                linkgoc = timegoc.GetAttribute("href");
                                                Console.WriteLine("địa chỉ bài viết gốc: " + linkgoc);
                                            }
                                        }    
                                    }
                               
                                    if (uniqueLinks.Add(linkbaiviet))
                                    {
                                        //Lấy nội dung bài viết
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
                                            Console.WriteLine("nôi dung bai viet: " +fullcontent);
                                            Console.WriteLine("------------------------");
                                        }
                                        // lấy số share
                                        var countshare = post.FindElement(By.CssSelector(" span[class = 'html-span xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x1hl2dhg x16tdsg8 x1vvkbs xkrqix3 x1sur9pj']"));
                                        try
                                        {
                                            share = countshare.Text;
                                            //share = Libary.Instance.tachsharepage(share);
                                        }
                                        catch (Exception ex)
                                        {
                                            Console.WriteLine("❌ Lỗi khi lấy số bình luận bài viết: " + ex.Message);
                                        }
                                        postCount++;
                                    }                                   
                                }                   
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("❌ Lỗi khi lấy dữ liệu bài viết: " + ex.Message);
                            }                         
                        }

                        if (postCount < 7)
                        {
                            driver.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
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

       
    }
}

