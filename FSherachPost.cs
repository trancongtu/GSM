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
                    
                    while (postCount < 5)
                    {
                        var posts = driver.FindElements(By.CssSelector("div[role='article']"));

                        foreach (var post in posts)
                        {
                            try
                            {
                                var seeMoreButtons = post.FindElements(By.XPath("//div[@role='button'][span[contains(text(), 'Xem thêm')]]"));
                                foreach (var btn in seeMoreButtons)
                                {
                                    try { btn.Click(); Thread.Sleep(500); } catch { }
                                }
                                var contentElements = post.FindElements(By.XPath(".//div[contains(@class, 'xdj266r') and contains(@class, 'x11i5rnm')]"));
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
                                }

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

