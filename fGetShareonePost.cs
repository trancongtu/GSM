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
using DevExpress.XtraEditors.Filtering.Templates;
using CrawFB.DAO;
using OpenQA.Selenium.DevTools.V130.Debugger;

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
                 try
                {
                List<IWebElement> btnshare = new List<IWebElement>(Driver.FindElements(By.CssSelector("span[class = 'html-span xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x1hl2dhg x16tdsg8 x1vvkbs xkrqix3 x1sur9pj']")));
                foreach (IWebElement btn in btnshare)
                {
                    //Console.WriteLine(btn.Text);
                    sumshare = btn.Text;
                    if ((sumshare.IndexOf("lượt chia sẻ") != -1) || (sumshare.IndexOf("shares") != -1))
                    {
                        btn.Click();
                        luotshare = btn.Text;
                    }
                }
                }
                catch { MessageBox.Show("không tìm được Element button Share");
                    
                }
                Libary.Instance.randomtime(6000, 10000);
                if (luotshare != "")
                {
                    txbSumShare.Text = luotshare;
                    int index = luotshare.IndexOf(" ");
                    luotshare = luotshare.Substring(0, index);
                    //Console.WriteLine(luotshare);
                    luotshare = Libary.Instance.xulyKshare(luotshare);
                }
                int a = Convert.ToInt32(luotshare);
                if (a > 10) Libary.Instance.keoluotshare(Driver);

                Libary.Instance.randomtime(4000, 6000);
                List<IWebElement> listshare = new List<IWebElement>(Driver.FindElements(By.CssSelector("div[class = 'xb57i2i x1q594ok x5lxg6s xdt5ytf x6ikm8r x1ja2u2z x1pq812k x1rohswg xfk6m8 x1yqm8si xjx87ck x1l7klhg x1iyjqo2 xs83m0k x2lwn1j xx8ngbg xwo3gff x1oyok0e x1odjw0f x1e4zzel x1n2onr6 xq1qtft x78zum5 x179dxpb']>div>div>div>div>div>div>div>div>div>div:nth-of-type(2)>div")));
                foreach (IWebElement share in listshare)
                {
                    IWebElement share1 = share.FindElement(By.CssSelector("a[class = 'x1i10hfl xjbqb8w x1ejq31n xd10rxx x1sy0etr x17r0tee x972fbf xcfux6l x1qhh985 xm0m39n x9f619 x1ypdohk xt0psk2 xe8uvvx xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x16tdsg8 x1hl2dhg xggy1nq x1a2a7pz x1heor9g xkrqix3 x1sur9pj x1s688f']"));
                    if (share1 != null)
                    {
                        string link = share1.GetAttribute("href");                      
                        string linkshare = Libary.Instance.rutgonlinkshare(link);                      
                        string linkfb = Libary.Instance.HrefToLinkFb(link);
                        string idfb = Libary.Instance.HrefToIdFb(link);
                        if (linkfb.IndexOf("/groups/") != -1)
                        {
                            string linkfbnew = "";
                            string idfb2 = "";
                            string linkfb2 = "";
                            IWebElement share2 = share.FindElement(By.CssSelector("a[class = 'x1i10hfl xjbqb8w x1ejq31n xd10rxx x1sy0etr x17r0tee x972fbf xcfux6l x1qhh985 xm0m39n x9f619 x1ypdohk xt0psk2 xe8uvvx xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x16tdsg8 x1hl2dhg xggy1nq x1a2a7pz xkrqix3 x1sur9pj xzsf02u x1s688f']"));
                            linkfbnew = share2.GetAttribute("href");
                            idfb2 = Libary.Instance.HrefShareGroupsToIdFb(linkfbnew);
                            linkfb2 = "Https://Fb.com/" + idfb2;
                            personshare.Add(new PersonShare(linkshare, linkfb2, idfb2));
                        }
                        else personshare.Add(new PersonShare(linkshare, linkfb,idfb));

                    }
                }
                int j = 1;
                foreach (PersonShare person2 in personshare)
                {
                    List<Person> person = new List<Person>();
                    string linkfb = person2.LinkFb.ToString();
                    string diachichiase = person2.DiachiShare.ToString();
                    string idfb = person2.IdFb.ToString();
                    if (linkfb != "")
                    {

                        person = Libary.Instance.ThongtinPerson(Driver, linkfb);
                        foreach (Person per in person)
                        {
                            string songtai = per.NoiSong.ToString();
                            string dentu = per.DenTu.ToString();
                            string tenfb = per.TenFb.ToString();
                            string thongtinkhac = per.HocVan.ToString();
                            dgvGetShareOnePost.Rows.Add(j++, diachichiase, linkfb, idfb, tenfb, dentu, songtai);
                        }
                    }
                }
                    Driver.Quit();
            }
            else { MessageBox.Show("Chưa nhập địa chỉ bài viết"); }
           
        }

        private void btnSavePerson_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvGetShareOnePost.Rows)
            {
                if (!row.IsNewRow)
                {
                    string linkfb = "";
                    if (row.Cells["linkfb"].Value.ToString() != null) linkfb = row.Cells["linkfb"].Value.ToString();
                    string idfb = "";
                    if (row.Cells["IdFb"].Value.ToString() != null) idfb = row.Cells["IdFb"].Value.ToString();
                    string tenfb = "";
                    if (row.Cells["DisplayName"].Value.ToString() != null) idfb = row.Cells["DisplayName"].Value.ToString();
                    string noisong = "";
                    if (row.Cells["from"].Value.ToString() != null) noisong = row.Cells["from"].Value.ToString();
                    string dentu = "";
                    if (row.Cells["live"].Value.ToString() != null) dentu= row.Cells["live"].Value.ToString();
                    string hocvan = "";
                    if (row.Cells["thongtinkhac"].Value.ToString() != null) hocvan = row.Cells["thongtinkhac"].Value.ToString();
                    if (PersonDAO.Instance.ShearchPerson("LinkFb", linkfb) == false)
                    {
                        string query = "INSERT INTO Person(TenFb, LinkFb, IdFbPerson, NoiSong, DenTu, HocVan) VALUES (N'" + tenfb + "', N'" + linkfb + "', N'" + idfb + "', N'" + noisong + "', N'" + dentu + "', N'" + hocvan + "')";
                        DataProvider.Instance.ExecuteQuery(query);
                        MessageBox.Show("luu doi tuong thanh cong");
                    }
                }    
                    
            }
        }
    }
}
