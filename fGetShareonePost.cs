using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Threading;
using Keys = OpenQA.Selenium.Keys;
using DevExpress.Utils;
using DevExpress.Utils.DPI;
using CrawFB.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CrawFB
{
    public partial class fGetShareonePost : Form
    {
        public fGetShareonePost()
        {
            InitializeComponent();
           
        }
            public void GetShare(string idbaiviet)
        {
            ChromeOptions options = Libary.Instance.Options();
            ChromeDriver Driver = new ChromeDriver(options);
            Driver.Url = idbaiviet;
            Libary.Instance.randomtime(6000, 10000);
            Driver.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            List<IWebElement> share = new List<IWebElement>(Driver.FindElements(By.XPath("//span[contains(@class,'x1vvkbs x1sur9pj xkrqix3')]")));
            if (share.Count > 0)
            {
                share[share.Count - 1].Click();
                Thread.Sleep(10000);
            }
            //List<IWebElement> fullshare = new List<IWebElement>(Driver.FindElements(By.CssSelector("span.html-span xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x1hl2dhg x16tdsg8 x1vvkbs>a")));
            //if (fullshare.Count > 0)
            //{
              
            //}
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
            txbSumShare.Text = new_count.ToString();
            List<PostShare> danhsachshare = new List<PostShare>();
            //int j = 0;
            List<IWebElement> fullshare = new List<IWebElement>(Driver.FindElements(By.CssSelector("div[class ^= 'x1yztbdb']>div>div>div>div>div>div>div:nth-child(2)>div>div:nth-child(2)>span:nth-child(1)>div>span:nth-child(1)>span>span>a")));
            foreach (IWebElement element in fullshare)
            {
                string diachichiase = element.GetAttribute("href");
                diachichiase = Libary.Instance.rutgonlinkshare(diachichiase);
                string linkfb = Libary.Instance.xululinkshare(diachichiase);
                Console.WriteLine(linkfb);
               // danhsachshare.Add(new PostShare(diachichiase, linkfb,"","",""));
             
            }    
            /*foreach (PostShare postShare in danhsachshare)
            {
                string linkfb = postShare.LinkFb;
                Console.WriteLine(linkfb);
                string diachishare = postShare.DiachiShare;
                List<string> thongtincn = new List<string>();
                thongtincn = Libary.Instance.thongtincanhan(Driver, linkfb + "/about");
                string songtai = "";
                string dentu = "";
                if (thongtincn.Count > 0)
                {
                    foreach (string t in thongtincn)
                    {
                        if (string.Compare(t, "sống tại") == 0) { songtai = t; }
                        if (string.Compare(t, "đến từ") == 0) { dentu = t; }
                    }
                }
                dgvGetShareOnePost.Rows.Add(j++, diachishare, linkfb, songtai, dentu);
            }    
                /*List<IWebElement> fullshare = new List<IWebElement>(Driver.FindElements(By.CssSelector("div[class = 'x1yztbdb']")));
                
                 foreach (IWebElement element in fullshare)
                  {
                     //IWebElement temp = element.FindElement(By.CssSelector("a[class ='x1i10hfl xjbqb8w x1ejq31n xd10rxx x1sy0etr x17r0tee x972fbf xcfux6l x1qhh985 xm0m39n x9f619 x1ypdohk xt0psk2 xe8uvvx xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x16tdsg8 x1hl2dhg xggy1nq x1a2a7pz x1heor9g x1sur9pj xkrqix3 x1s688f]"));
                     IWebElement temp = element.FindElement(By.CssSelector("a[class*='x1sur9pj xkrqix3 x1s688f']"));
                     string link = temp.GetAttribute("href");
                     Console.WriteLine(link);
                      dgvGetShareOnePost.Rows.Add(j++, link);
                  }
                  /*List<IWebElement> linkshare = new List<IWebElement>(Driver.FindElements(By.XPath("//div[@class = 'xb57i2i x1q594ok x5lxg6s xdt5ytf x6ikm8r x1ja2u2z x1pq812k x1rohswg xfk6m8 x1yqm8si xjx87ck x1l7klhg x1iyjqo2 xs83m0k x2lwn1j xx8ngbg xwo3gff x1oyok0e x1odjw0f x1e4zzel x1n2onr6 xq1qtft x78zum5 x179dxpb']//a")));
                  if (linkshare.Count > 0)
                  {
                      foreach (IWebElement element in linkshare)
                      {
                          string link = element.GetAttribute("href");
                          Console.WriteLine(link);

                      }
                  }
                  */
                Driver.Quit();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {

            if (txbLinkPost.Text != "") 
            {
                ChromeOptions options = Libary.Instance.Options();
                ChromeDriver Driver = new ChromeDriver(options);
                List<Person> person = new List<Person>();
                person = Libary.Instance.GetShareOnePost(Driver, txbLinkPost.Text);
                int j = 1;
                foreach (Person person2 in person)
                {
                    string linkfb = person2.LinkFb.ToString();       
                    string diachichiase = person2.DiachiShare.ToString();
                    List<string> thongtincn = new List<string>();
                    if(linkfb != "")
                    {
                        string songtai = "";
                        string dentu = "";
                        thongtincn = Libary.Instance.thongtincanhan(Driver, linkfb);
                        if(thongtincn.Count > 0)
                        {
                            for (int i = 0; i < thongtincn.Count; i++)
                            {
                               
                                if (thongtincn[i] == "songtai")
                                {
                                    songtai = thongtincn[i + 1];                                   
                                }
                                if (thongtincn[i] == "dentu")
                                {
                                    dentu = thongtincn[i + 1];                                   
                                }
                               
                            }                          
                        }
                        dgvGetShareOnePost.Rows.Add(j++, diachichiase, linkfb, dentu, songtai);

                    }                             
                }
                Driver.Quit();
            }
            else { MessageBox.Show("Chưa nhập địa chỉ bài viết"); }
           
        }
    }
}
