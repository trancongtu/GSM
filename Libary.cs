using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CrawFB.DTO;
using DevExpress.Data.Helpers;
using DevExpress.Data.NetCompatibility.Extensions;
using DevExpress.Skins;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V130.Page;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace CrawFB
{
    public class Libary
    {
        private static Libary instance;
        public Libary() { }

        public static Libary Instance
        {
            get { if (instance == null) instance = new Libary(); return Libary.instance; }
            private set { Libary.instance = value; }
        }

        public ChromeOptions Options()
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArgument("user-data-dir=C:/User/trant/PycharmProject/PythonProject/ProfileChromeGSM");
            //option.AddArgument("--headless"); //chay ngam hay k
            option.AddArgument("--disable-infobars");
            option.AddArgument("start-maximized");
            option.AddArgument("--disable-extensions");
            // Pass the argument 1 to allow and 2 to block
            return option;
        }
        public ChromeDriver khoitao(string profile)
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArguments("user-data-dir=" + profile);
            option.AddArgument("--disable-infobars");
            option.AddArgument("start-maximized");
            option.AddArgument("--disable-extensions");

            //option.AddArgument("--headless"); //chạy ngầm
            ChromeDriver driver = new ChromeDriver(option);
            return driver;
        }
        public ChromeOptions Options2(string profile)
        {
            ChromeOptions option = new ChromeOptions();
            option.AddArguments("user-data-dir=" + profile);
            option.AddArgument("--disable-infobars");
            option.AddArgument("start-maximized");
            option.AddArgument("--disable-extensions");
            //option.AddArgument("--headless"); //chạy ngầm
            return option;
        }
         public List<Post> GetPostOnePage(ChromeDriver Driver, string linkpost, string time, string soluong)
 {
     List<Post> post = new List<Post>();
     if ((Driver != null) && (linkpost != ""))
         Driver.Url = linkpost;
         Driver.Navigate();
     
     {
         int i = 0;
         if (soluong != "")
         {
             int sl = Convert.ToInt32(soluong);
             while(i<sl)
             {
                 Driver.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
                 randomtime(5000, 10000);
                 //WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
                 List<IWebElement> fullpost = new List<IWebElement>(Driver.FindElements(By.CssSelector("div[data-pagelet*='TimelineFeedUnit']")));
                 foreach (IWebElement element in fullpost)
                 {
                     IWebElement temp = element.FindElement(By.CssSelector("a[class*='x1sur9pj xkrqix3 x1s688f']"));
                     string idpost = temp.GetAttribute("href");
                     idpost = rutgonlinkshare(idpost);
                     string thoigian = temp.GetAttribute("aria-label");
                     string contents = "";  
                     List<IWebElement> noidung =new List<IWebElement>(element.FindElements(By.CssSelector("div[class = 'xu06os2 x1ok221b']>span")));
                     foreach (IWebElement content in noidung) // lấy nội dung bài viết
                     {
                         contents = content.Text;
                     }
                     List<IWebElement> noidunganh = new List<IWebElement>(element.FindElements(By.CssSelector("div[class = 'x6s0dn4 x78zum5 xdt5ytf x5yr21d xl56j7k x10l6tqk x17qophe x13vifvy xh8yej3']>div>div")));
                     if (noidunganh != null) // lấy chữ viết trong các bài có mầu
                     {
                         foreach (IWebElement nda in noidunganh)
                         {
                             contents += nda.Text;
                         }    
                     }                        
                     List<IWebElement> tuongtac = new List<IWebElement>(element.FindElements(By.CssSelector("div[class = 'x9f619 x1n2onr6 x1ja2u2z x78zum5 xdt5ytf x2lah0s x193iq5w xeuugli xsyo7zv x16hj40l x10b6aqq x1yrsyyn']")));
                     string binhluan = ""; int bl = 0; int cs = 0;
                     string chiase = "";
                     foreach (IWebElement temp2 in tuongtac)
                     {
                         if (temp2.Text.IndexOf("bình luận")  != -1) 
                         {   binhluan = temp2.Text;
                             int index = binhluan.IndexOf(" ");                 
                             binhluan = binhluan.Substring(0,index);
                             bl = Convert.ToInt32(binhluan);
                         }
                         if (temp2.Text.IndexOf("chia sẻ") != -1) 
                         { 
                             chiase  = temp2.Text;
                             chiase = chiase.Substring(0,chiase.IndexOf(" "));
                             cs = Convert.ToInt32(chiase);
                         }
                     }
                     //string binhluan = comment.Text;

                     //Console.WriteLine(idpost + " " + thoigian + " " + contents + "" +binhluan + "_" +chiase);
                     //IWebElement temp = element.FindElement(By.CssSelector("div[class='xdj266r x11i5rnm xat24cr x1mh8g0r x1vvkbs x126k92a']"));
                     // string content2 = temp.Text;
                     //Console.WriteLine(content2);
                     
                     
                     post.Add(new Post(idpost, contents, thoigian, cs,bl));
                     i++;
                 }

             }
         }
     }
     return post;
 }
        public List<IWebElement> CheckAcoount(ChromeDriver driver)
        {
            List<IWebElement> element = null;
            List<IWebElement> infor = new List<IWebElement>(driver.FindElements(By.XPath("//div[@class = 'x9f619 x1n2onr6 x1ja2u2z x78zum5 xdt5ytf x193iq5w xeuugli x1r8uery x1iyjqo2 xs83m0k xsyo7zv x16hj40l x10b6aqq x1yrsyyn']//span"))); 
            if (infor != null)
            {
                element = infor;
            }
            return element;
        }
        public List<Person> GetShareOnePost(ChromeDriver Driver, string linkpost)
        {
            List<Person> person = new List<Person>();
            Driver.Url = linkpost;
            string sumshare = "";
            Libary.Instance.randomtime(6000, 10000);
            Driver.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            List<IWebElement> temp = new List<IWebElement>(Driver.FindElements(By.CssSelector("span[class = 'html-span xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x1hl2dhg x16tdsg8 x1vvkbs x1sur9pj xkrqix3']")));
            sumshare = temp[temp.Count - 1].Text;
            if (sumshare != "")
            {
                int index = sumshare.IndexOf(" ");
                sumshare = sumshare.Substring(0, index);
            }
            List<IWebElement> share = new List<IWebElement>(Driver.FindElements(By.XPath("//span[contains(@class,'x1vvkbs x1sur9pj xkrqix3')]")));
            if (share.Count > 0)
            {
                share[share.Count - 1].Click();
                Thread.Sleep(10000);
            }
            int a = Convert.ToInt32(sumshare);
            if (a > 10)
            {
                IWebElement element2 = Driver.FindElement(By.XPath("//div[@class = 'xb57i2i x1q594ok x5lxg6s xdt5ytf x6ikm8r x1ja2u2z x1pq812k x1rohswg xfk6m8 x1yqm8si xjx87ck x1l7klhg x1iyjqo2 xs83m0k x2lwn1j xx8ngbg xwo3gff x1oyok0e x1odjw0f x1e4zzel x1n2onr6 xq1qtft x78zum5 x179dxpb']"));
                int last_count = 0;
                int new_count = 0;
                do
                {
                    Libary.Instance.randomtime(6000, 10000);
                    //last_count = Driver.FindElements(By.XPath("//div[@class = 'xb57i2i x1q594ok x5lxg6s xdt5ytf x6ikm8r x1ja2u2z x1pq812k x1rohswg xfk6m8 x1yqm8si xjx87ck x1l7klhg x1iyjqo2 xs83m0k x2lwn1j xx8ngbg xwo3gff x1oyok0e x1odjw0f x1e4zzel x1n2onr6 xq1qtft x78zum5 x179dxpb']")).Count();
                    last_count = Driver.FindElements(By.CssSelector("div[class = 'x1yztbdb']")).Count();
                    Console.WriteLine(last_count);

                    for (int i = 0; i < 2; i++)
                    {
                        element2.SendKeys(Keys.End);
                        element2.SendKeys(Keys.Up);
                        element2.SendKeys(Keys.Up);
                        element2.SendKeys(Keys.Up);
                        element2.SendKeys(Keys.Down);
                        element2.SendKeys(Keys.Down);
                        element2.SendKeys(Keys.Down);
                        Libary.Instance.randomtime(6000, 10000);
                    }

                    new_count = Driver.FindElements(By.CssSelector("div[class = 'x1yztbdb']")).Count();
                    Console.WriteLine(new_count);
                }
                while (last_count != new_count);
            }
            List<IWebElement> fullshare = new List<IWebElement>(Driver.FindElements(By.CssSelector("div[class ^= 'x1yztbdb']>div>div>div>div>div>div>div>div>div>span>div>h3>span>span>a")));
            foreach (IWebElement element in fullshare)
            {
                string diachi = element.GetAttribute("href"); 
                string diachishare = Libary.instance.rutgonlinkshare(diachi);
                string linkfb = Libary.Instance.xulylinkperson(diachi);                
                person.Add(new Person(diachishare,linkfb, "", "", "", ""));
            }
            return person;
        }
        public string SumShare(ChromeDriver Driver, string linkbaiviet)
        {
            string sumshare = "";
            Driver.Url = linkbaiviet;
            Libary.Instance.randomtime(6000, 10000);
            Driver.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            List<IWebElement> temp = new List<IWebElement>(Driver.FindElements(By.CssSelector("span[class = 'html-span xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x1hl2dhg x16tdsg8 x1vvkbs x1sur9pj xkrqix3']")));
            sumshare = temp[temp.Count - 1].Text;
            if(sumshare != "")
            {
                int index = sumshare.IndexOf(" ");
                sumshare = sumshare.Substring(0, index);
            }
            return sumshare;
        }
        public List<string> thongtincanhan(ChromeDriver Driver, string link)
        {
            //string thongtinsongtai, thongtindentu = "";
            Driver.Url = link;
            randomtime(5000, 10000);
            Random random = new Random();
            int ran = random.Next(1, 4);
            randomAction(Driver, ran);
            List<string> thongtin = new List<string>();
            List<IWebElement> element = new List<IWebElement>(Driver.FindElements(By.CssSelector("div[class = 'xzsf02u x6prxxf xvq8zen x126k92a']>span")));
            randomtime(5000, 10000);
            if (element != null)
            {
                foreach (IWebElement element2 in element)
                {
                    string temp1 = element2.Text;                                 
                   if(temp1.Contains("Sống") == true)
                    {
                        thongtin.Add("songtai");
                        int index = temp1.IndexOf("\n");
                        temp1 = temp1.Substring(index, temp1.Length - index);
                        thongtin.Add(temp1);                      
                    }    
                    if(temp1.Contains("Đến") == true)
                    {                       
                        thongtin.Add("dentu");
                        int index = temp1.IndexOf("Đến từ");
                        temp1 = temp1.Substring(index + 6, temp1.Length - index-6);
                        thongtin.Add(temp1);
                    }  
                  
                }               
            }
            else { thongtin.Add("");}
            return thongtin;
        }
        public string xululinkshare(string link)
        {
            string ketqua = "";
            int i = link.IndexOf("&id");          
            int j = link.IndexOf("&__");           
            if (i != -1 && j != -1)
            {
                link = link.Substring(i + 4, j - i - 4);
                ketqua = "https://Fb.com/" + link;

            }           
            else
            {
                int index2 = link.IndexOf("/posts/");
                if (index2 != -1)
                {
                    link = link.Substring(0, index2);
                    ketqua = link.Replace("https://www.facebook.com/", "https://Fb.com/");
                }
            }    
            return ketqua;
        }
            public string xulylinkperson(string link)
            {
            string ketqua = "";
            int i = link.IndexOf("id=");           
            int j = link.IndexOf("&__");
            if (i != -1 && j != -1)
            {
                link = link.Substring(i + 3, j - i - 3);
                ketqua = "https://Fb.com/" + link;

            }
            else
            {
                int index2 = link.IndexOf("?__");
                if (index2 != -1)
                {
                    link = link.Substring(0, index2);
                    ketqua = link.Replace("https://www.facebook.com/", "https://Fb.com/");
                }
            }
            return ketqua;
        }
        public string rutgonlinkshare(string link)
        {
            string ketqua = "";

            int index2 = link.IndexOf("?");
            if (index2 != -1)
            {
                link = link.Substring(0, index2);
                ketqua = link.Replace("https://www.facebook.com/", "https://Fb.com/");
            }
            return ketqua;

        }
        public void randomtime (int time1,  int time2)
        {
            Random random = new Random();
            int time = random.Next(time1, time2);         
            Thread.Sleep(time);
        }
        public void randomAction(ChromeDriver Driver, int t)
        {
            if (t == 1)
            {
                IWebElement element = Driver.FindElement(By.LinkText("Bạn bè"));
                if (element != null)
                {
                    element.Click();
                }
                Libary.Instance.randomtime(5000, 10000);
            }
            if (t == 2)
            {
                IWebElement element = Driver.FindElement(By.LinkText("Ảnh"));
                if (element != null)
                {
                    element.Click();
                }
                Libary.Instance.randomtime(5000, 10000);
            }
            if (t == 3)
            {
                IWebElement element = Driver.FindElement(By.LinkText("Video"));
                if (element != null)
                {
                    element.Click();
                }
                Libary.Instance.randomtime(5000, 10000);
            }
            if (t == 4)
            {
                IWebElement element = Driver.FindElement(By.LinkText("Check in"));
                if (element != null)
                {
                    element.Click();
                }
                Libary.Instance.randomtime(5000, 10000);
            }

            IWebElement element2 = Driver.FindElement(By.LinkText("Giới thiệu"));
            if (element2 != null)
            {
                element2.Click();
            }
            Libary.Instance.randomtime(5000, 10000);
        }

    }
}
