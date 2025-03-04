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
           

        private void btnGet_Click(object sender, EventArgs e)
        {

            if (txbLinkPost.Text != "") 
            {
                ChromeOptions options = Libary.Instance.Options();
                ChromeDriver Driver = new ChromeDriver(options);
                Driver.Url = txbLinkPost.Text;
                string sumshare = "";
                string luotshare = "";
                List<PersonShare> personshare = new List<PersonShare>();
               // try
               // {
                    List<IWebElement> btnshare = new List<IWebElement>(Driver.FindElements(By.CssSelector("span[class = 'html-span xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x1hl2dhg x16tdsg8 x1vvkbs xkrqix3 x1sur9pj']")));
                    foreach (IWebElement btn in btnshare)
                    {
                        //Console.WriteLine(btn.Text);
                        sumshare = btn.Text;
                        if (sumshare.IndexOf("lượt chia sẻ") != -1)
                        {
                            btn.Click();
                            luotshare = btn.Text;
                        }
                    }
                    Libary.Instance.randomtime(6000, 10000);
                    if (luotshare != "")
                    {
                        txbSumShare.Text = luotshare;
                        int index = luotshare.IndexOf(" ");
                        luotshare = luotshare.Substring(0, index);
                        luotshare = Libary.Instance.xulyKshare(luotshare);
                    }
                    int a = Convert.ToInt32(luotshare);
                    if (a > 10) Libary.Instance.keoluotshare(Driver);
                IWebElement fullshare = Driver.FindElement(By.CssSelector("div[class = 'xb57i2i x1q594ok x5lxg6s xdt5ytf x6ikm8r x1ja2u2z x1pq812k x1rohswg xfk6m8 x1yqm8si xjx87ck x1l7klhg x1iyjqo2 xs83m0k x2lwn1j xx8ngbg xwo3gff x1oyok0e x1odjw0f x1e4zzel x1n2onr6 xq1qtft x78zum5 x179dxpb']"));
                List<IWebElement> listshare = new List<IWebElement>(fullshare.FindElements(By.CssSelector("a[class = 'x1i10hfl xjbqb8w x1ejq31n xd10rxx x1sy0etr x17r0tee x972fbf xcfux6l x1qhh985 xm0m39n x9f619 x1ypdohk xt0psk2 xe8uvvx xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x16tdsg8 x1hl2dhg xggy1nq x1a2a7pz x1heor9g xkrqix3 x1sur9pj x1s688f']")));
                foreach (IWebElement share in listshare)
                {
                    string link = share.GetAttribute("href");
                    string linkshare = Libary.Instance.rutgonlinkshare(link);
                    string linkfb = Libary.Instance.HrefToLinkFb(link);
                    string linkfbnew = "";
                    /*if (linkshare.IndexOf("/groups/") != -1)         
                    {
                        Driver.Url = linkshare;
                        string linkfbnew = "";
                        Libary.Instance.randomtime(4000, 6000);
                        List<IWebElement> sharegroups = new List<IWebElement>(Driver.FindElements(By.CssSelector("[class = 'x1i10hfl xjbqb8w x1ejq31n xd10rxx x1sy0etr x17r0tee x972fbf xcfux6l x1qhh985 xm0m39n x9f619 x1ypdohk xt0psk2 xe8uvvx xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x16tdsg8 x1hl2dhg xggy1nq x1a2a7pz xkrqix3 x1sur9pj xzsf02u x1s688f']")));
                        foreach (IWebElement sharegroup in sharegroups)
                        {
                            string Href = sharegroup.GetAttribute("href");
                            Console.WriteLine(Href);
                            if (Href.IndexOf("user/") != -1)
                            {
                                int index1 = Href.IndexOf("user/");
                                int index2 = Href.IndexOf("/?__");
                                if (index1 != -1 && index2 != -1)
                                {
                                    linkfbnew = Href.Substring(index1 + 5, index2 - index1 - 5);
                                }    
                            }    
                          
                        }
                        personshare.Add(new PersonShare(linkshare, linkfbnew));
                    }*/
                    if (linkshare.IndexOf("/user/") != -1)
                    {
                        int index1 = linkshare.IndexOf("user/");
                        if (index1 != -1)
                        {
                            linkfbnew = linkshare.Substring(index1 + 5, linkshare.Length - index1 - 5);
                        }
                    }
                    else personshare.Add(new PersonShare(linkshare, linkfb));
                }
                
                //}
                //catch { MessageBox.Show("Không thực hiện được tìm element btnshare"); }              
                int j = 1;
                foreach (PersonShare person2 in personshare)
                {
                    List<Person> person = new List<Person>();
                    string linkfb = person2.LinkFb.ToString();  
                    Console.WriteLine(linkfb);
                    string diachichiase = person2.DiachiShare.ToString();
                    if(linkfb != "")
                    {
                        
                        person = Libary.Instance.ThongtinPerson(Driver, linkfb);
                       foreach(Person per in person)
                        {
                            string songtai = per.NoiSong.ToString();
                            string dentu = per.DenTu.ToString();
                            dgvGetShareOnePost.Rows.Add(j++, diachichiase, linkfb, dentu, songtai);
                        }                           
                    }                             
                }
                Driver.Quit();
            }
            else { MessageBox.Show("Chưa nhập địa chỉ bài viết"); }
           
        }
    }
}
