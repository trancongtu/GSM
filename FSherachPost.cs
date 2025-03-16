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
                    Libary.Instance.randomtime(2000, 4000); ;
                   
                    while (postCount < 7)
                    {
                        driver.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
                        var posts = driver.FindElements(By.CssSelector("div[role='article']"));

                        foreach (var post in posts)
                        {
                            try
                            {
                                string linkbaiviet = "";
                                string linkshare = "";
                                string linkgoc = "";
                                string linkFb = "";
                                string nameFb = "";
                                string share = "";
                                string comment = "";
                                string tgdang = "";
                                string thoigianlinkgoc = "";
                                //lấy link post
                                // var postLinkElement = post.FindElement(By.CssSelector("a[class = 'x1i10hfl xjbqb8w x1ejq31n xd10rxx x1sy0etr x17r0tee x972fbf xcfux6l x1qhh985 xm0m39n x9f619 x1ypdohk xt0psk2 xe8uvvx xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x16tdsg8 x1hl2dhg xggy1nq x1a2a7pz x1heor9g xkrqix3 x1sur9pj x1s688f']"));
                                // string linkShare = postLinkElement.GetAttribute("href");
                                //lấy tên người đăng
                                var postinfor = post.FindElements(By.CssSelector("div[class='xu06os2 x1ok221b']"));
                                if (postinfor.Count >= 2)
                                {
                                    //Console.WriteLine("thấy element xu06os2 x1ok221b ");
                                    // lấy tên và link Fb
                                    var personpost = postinfor[0].FindElements(By.CssSelector("span[class='xjp7ctv'] > a"));
                                    if (personpost.Count >= 4)
                                    {
                                        Console.WriteLine("thấy 4 phần tử");
                                        // Nếu bài share, lấy phần tử thứ 4 (người đăng bài)
                                        linkFb = personpost[3].GetAttribute("href");
                                        nameFb = personpost[3].Text;
                                        // tgdang = 
                                    }
                                    else if (personpost.Count > 0)
                                    {
                                        Console.WriteLine("thấy 2 phần tử");
                                        // Nếu bài cá nhân, lấy phần tử cuối cùng
                                        linkFb = personpost.Last().GetAttribute("href");
                                        nameFb = personpost.Last().Text;
                                    }
                                    if(personpost.Count == 0)
                                    {
                                        Console.WriteLine("đã vào đến đây");
                                        var personpost2 = postinfor[0].FindElements(By.CssSelector("span[class='xjp7ctv']>span>span>a"));
                                        if(personpost2.Count >= 1)
                                        {
                                            Console.WriteLine("có tìm thấy");
                                            linkFb = personpost2[0].GetAttribute("href");
                                            nameFb = personpost2[0].Text;
                                        }    
                                    }
                                    Console.WriteLine("bai thu: " + postCount);
                                    Console.WriteLine("linkfb: " + linkFb);
                                    Console.WriteLine("tenfb: " + nameFb);
                                    // lấy thời gian, link bài viết
                                    var timepost = postinfor[1].FindElements(By.CssSelector("a[class = 'x1i10hfl xjbqb8w x1ejq31n xd10rxx x1sy0etr x17r0tee x972fbf xcfux6l x1qhh985 xm0m39n x9f619 x1ypdohk xt0psk2 xe8uvvx xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x16tdsg8 x1hl2dhg xggy1nq x1a2a7pz x1heor9g xkrqix3 x1sur9pj x1s688f']"));
                                    if (timepost.Count >= 2)
                                    {
                                        tgdang = timepost[0].Text;
                                        linkshare = timepost[0].GetAttribute("href");
                                        thoigianlinkgoc = timepost[1].Text;
                                        linkgoc = timepost[1].GetAttribute("href");
                                        Console.WriteLine("bai dang-----");
                                        Console.WriteLine("linkshare: " + linkshare);
                                        Console.WriteLine("tgdang: " + tgdang);
                                        Console.WriteLine("linkgoc: " + linkgoc);
                                        Console.WriteLine("tgdanggoc: " + thoigianlinkgoc);
                                    }
                                    else
                                    {
                                        tgdang = timepost.Last().Text;
                                        linkbaiviet = timepost.Last().GetAttribute("href");
                                        Console.WriteLine("linkbv: " + linkbaiviet);
                                        Console.WriteLine("tgdang: " + tgdang);
                                        Console.WriteLine("bai share-----");
                                    }
                                    // lấy nội dung                                   
                                     
                                    var contentpost = post.FindElements(By.CssSelector("span[class = 'x193iq5w xeuugli x13faqbe x1vvkbs x1xmvt09 x1lliihq x1s928wv xhkezso x1gmr53x x1cpjm7i x1fgarty x1943h6x xudqn12 x3x7a5m x6prxxf xvq8zen xo1l8bm xzsf02u x1yc453h']"));
                                    string fullcontent = "";
                                    foreach (var content in contentpost)
                                    {
                                        if (content.Text.IndexOf("Xem thêm") != -1)
                                        {
                                            try
                                            {
                                                // Tìm `div[role='button']` bên trong `span` đó
                                                var seeMoreButton = content.FindElement(By.CssSelector("div[role='button']"));

                                                // Click để mở rộng nội dung
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
                                    //Console.WriteLine("Nội dung bài viết: " + fullcontent);
                                    if (!string.IsNullOrEmpty(linkFb) && !uniquePosts.Contains(linkFb))
                                    {
                                        uniquePosts.Add(linkFb); // Thêm link bài viết vào danh sách đã lấy
                                      Console.WriteLine($"📌 Bài viết #{postCount + 1}:\n{fullcontent}");
                                        postCount++; // Tăng số lượng bài đã lấy
                                    }
                                    // lấy số bình luận

                                    var countcoment = post.FindElement(By.CssSelector(" span[class = 'html-span xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x1hl2dhg x16tdsg8 x1vvkbs xkrqix3 x1sur9pj']"));
                                    try
                                    {
                                        comment = countcoment.Text;
                                        Console.WriteLine(comment);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine("❌ Lỗi khi lấy số bình luận bài viết: " + ex.Message);
                                    }

                                    //if (linkFb != "") postCount++;
                                }
                                /* var personpost = post.FindElements(By.CssSelector("span[class='xjp7ctv'] > a"));

                                 if (personpost.Count >= 4)
                                 {
                                     // Nếu bài share, lấy phần tử thứ 4 (người đăng bài)
                                     linkFb = personpost[3].GetAttribute("href");
                                     nameFb = personpost[3].Text;
                                    // tgdang = 
                                 }
                                 else if (personpost.Count > 0)
                                 {
                                     // Nếu bài cá nhân, lấy phần tử cuối cùng
                                     linkFb = personpost.Last().GetAttribute("href");
                                     nameFb = personpost.Last().Text;
                                 }
                                // Console.WriteLine("linkshare: " + linkShare);
                                 //Console.WriteLine("linkfb: " + linkFb);
                                 //Console.WriteLine("tenfb: " + nameFb);
                                 var timepost = post.FindElements(By.CssSelector("div[class = 'xu06os2 x1ok221b']>span>div>span>span>span>a"));
                              if(timepost.Count >=2)
                                 {
                                     tgdang = timepost[0].Text;
                                     linkshare = timepost[0].GetAttribute("href");
                                     thoigianlinkgoc = timepost[1].Text;
                                     linkgoc = timepost[1].GetAttribute("href");
                                     Console.WriteLine("bai dang-----");
                                     Console.WriteLine("linkshare: " +linkshare);
                                     Console.WriteLine("tgdang: "+tgdang);
                                     Console.WriteLine("linkgoc: " +linkgoc);
                                     Console.WriteLine("tgdanggoc: " + thoigianlinkgoc);
                                 }
                                 if (personpost.Count > 0)
                                 {
                                     tgdang = timepost.Last().Text;
                                     linkbaiviet = timepost.Last().GetAttribute("href");
                                     Console.WriteLine("linkbv: " + linkbaiviet);
                                     Console.WriteLine("tgdang: " + tgdang);
                                     Console.WriteLine("bai share-----");
                                 }

                                 //lấy bài viết
                                 //span[class = 'x193iq5w xeuugli x13faqbe x1vvkbs x1xmvt09 x1lliihq x1s928wv xhkezso x1gmr53x x1cpjm7i x1fgarty x1943h6x xudqn12 x3x7a5m x6prxxf xvq8zen xo1l8bm xzsf02u x1yc453h']
                                 // var seeMoreButtons = post.FindElement(By.CssSelector("div[class = 'x1i10hfl xjbqb8w x1ejq31n xd10rxx x1sy0etr x17r0tee x972fbf xcfux6l x1qhh985 xm0m39n x9f619 x1ypdohk xt0psk2 xe8uvvx xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x16tdsg8 x1hl2dhg xggy1nq x1a2a7pz xkrqix3 x1sur9pj xzsf02u x1s688f'][role]"));                            
                                 // try { seeMoreButtons.Click(); Thread.Sleep(500); } catch { }

                                 /* var contentElements = post.FindElements(By.XPath(".//div[contains(@class, 'xdj266r') and contains(@class, 'x11i5rnm')]"));
                                  string fullPostText = "";

                                  foreach (var contentElement in contentElements)
                                  {
                                      fullPostText += contentElement.Text.Trim() + "\n";
                                  }
                                  if (!string.IsNullOrEmpty(fullPostText) && fullPostText.Length > 50 && !uniquePosts.Contains(fullPostText))
                                  {
                                      uniquePosts.Add(fullPostText);
                                      Console.WriteLine($"📌 Bài viết #{postCount + 1}:\n{fullPostText}");
                                      postCount++; // Tăng số lượng bài đã lấy
                                  }*/
                                /*var contentpost = post.FindElements(By.CssSelector("span[class = 'x193iq5w xeuugli x13faqbe x1vvkbs x1xmvt09 x1lliihq x1s928wv xhkezso x1gmr53x x1cpjm7i x1fgarty x1943h6x xudqn12 x3x7a5m x6prxxf xvq8zen xo1l8bm xzsf02u x1yc453h']"));
                                string fullcontent = "";
                                foreach (var content in contentpost)
                                {
                                    if (content.Text.IndexOf("Xem thêm") != -1)
                                    {
                                        try
                                        {
                                            // Tìm `div[role='button']` bên trong `span` đó
                                            var seeMoreButton = content.FindElement(By.CssSelector("div[role='button']"));

                                            // Click để mở rộng nội dung
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
                                //Console.WriteLine("Nội dung bài viết: " + fullcontent);
                                if (!string.IsNullOrEmpty(linkFb) && !uniquePosts.Contains(linkFb))
                                {
                                    uniquePosts.Add(linkFb); // Thêm link bài viết vào danh sách đã lấy
                                    //Console.WriteLine($"📌 Bài viết #{postCount + 1}:\n{fullcontent}");
                                    postCount++; // Tăng số lượng bài đã lấy
                                }
                                // lấy thời gian: 
                                                       
                                // lấy số bình luận
                               
                                var countcoment = post.FindElement(By.CssSelector(" span[class = 'html-span xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x1hl2dhg x16tdsg8 x1vvkbs xkrqix3 x1sur9pj']"));
                                try
                                {
                                    comment = countcoment.Text;
                                    //Console.WriteLine(comment);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("❌ Lỗi khi lấy dữ liệu bài viết: " + ex.Message);
                                }*/
                                

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("❌ Lỗi khi lấy dữ liệu bài viết: " + ex.Message);
                            }
                        }
                        driver.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");

                        lblStatus.Text = "✅ Hoàn thành!";
                }
                }

                MessageBox.Show("✅ Đã lấy xong 10 bài viết!");
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

