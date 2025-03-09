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
using OpenQA.Selenium.Interactions;
using System.IO;
using System.Threading;
using Keys = OpenQA.Selenium.Keys;
using DevExpress.Utils;
using CrawFB.DTO;
using DevExpress.XtraEditors.Filtering.Templates;
using DevExpress.XtraEditors.Design;
using static System.Windows.Forms.LinkLabel;

namespace CrawFB
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Person> person = new List<Person>();
            List<PersonShare> share = new List<PersonShare>();
            if (txblinkbv.Text != "")
            {
                ChromeOptions options = Libary.Instance.Options();
                ChromeDriver Driver = new ChromeDriver(options);
                // IWebDriver driver = new ChromeDriver();
                Actions action = new Actions(Driver);
                Driver.Url = txblinkbv.Text;
                int soluong = 10; int dem = 1;
                Libary.Instance.randomtime(6000, 10000);
                while (dem < soluong)
                {

                    List<IWebElement> elementshare = new List<IWebElement>(Driver.FindElements(By.CssSelector("div[class = 'x9f619 x1ja2u2z x78zum5 x2lah0s x1n2onr6 x1qughib x1qjc9v5 xozqiw3 x1q0g3np xykv574 xbmpl8g x4cne27 xifccgj']>div:nth-of-type(3)>span>div>div")));
                    foreach (IWebElement element in elementshare)
                    {
                        IWebElement sumshare = element.FindElement(By.CssSelector("span[class = 'html-span xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x1hl2dhg x16tdsg8 x1vvkbs x1sur9pj xkrqix3']"));
                        Console.WriteLine("tổng share: " + sumshare.Text);
                        int SumShare = Convert.ToInt32(sumshare.Text);
                        IWebElement buttonshare = element.FindElement(By.CssSelector("div[class = 'x9f619 x1n2onr6 x1ja2u2z x78zum5 xdt5ytf x2lah0s x193iq5w xeuugli xg83lxy x1h0ha7o x10b6aqq x1yrsyyn']"));
                        action.MoveToElement(buttonshare).Build().Perform();
                        action.Click(buttonshare).Build().Perform();
                        //buttonshare.Click();
                        Thread.Sleep(10000);
                        if (SumShare > 10)
                        {
                            IWebElement element2 = Driver.FindElement(By.CssSelector("div[class = 'xb57i2i x1q594ok x5lxg6s xdt5ytf x6ikm8r x1ja2u2z x1pq812k x1rohswg xfk6m8 x1yqm8si xjx87ck x1l7klhg x1iyjqo2 xs83m0k x2lwn1j xx8ngbg xwo3gff x1oyok0e x1odjw0f x1e4zzel x1n2onr6 xq1qtft x78zum5 x179dxpb']"));
                            int last_count = 0;
                            int new_count = 0;
                            do
                            {
                                Libary.Instance.randomtime(6000, 10000);
                                //last_count = Driver.FindElements(By.XPath("//div[@class = 'xb57i2i x1q594ok x5lxg6s xdt5ytf x6ikm8r x1ja2u2z x1pq812k x1rohswg xfk6m8 x1yqm8si xjx87ck x1l7klhg x1iyjqo2 xs83m0k x2lwn1j xx8ngbg xwo3gff x1oyok0e x1odjw0f x1e4zzel x1n2onr6 xq1qtft x78zum5 x179dxpb']")).Count();
                                last_count = Driver.FindElements(By.CssSelector("div[class = 'x1yztbdb']")).Count();
                                Console.WriteLine("count cuối: " + last_count);

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
                                Console.WriteLine("count cu", +new_count);
                            }
                            while (last_count != new_count);
                        }

                        List<IWebElement> fullshare = new List<IWebElement>(Driver.FindElements(By.CssSelector("div[class ^= 'x1yztbdb']>div>div>div>div>div>div>div>div>div>span>div>h3>span>span>a")));
                        foreach (IWebElement element3 in fullshare)
                        {
                            string diachi = element3.GetAttribute("href");
                            string diachishare = Libary.Instance.rutgonlinkshare(diachi);
                            string linkfb = Libary.Instance.xulylinkperson(diachi);
                            Console.WriteLine(linkfb);
                        }
                        IWebElement buttonclose = Driver.FindElement(By.CssSelector("div[class = 'x1i10hfl xjqpnuy xa49m3k xqeqjp1 x2hbi6w x13fuv20 xu3j5b3 x1q0q8m5 x26u7qi x1ypdohk xdl72j9 x2lah0s xe8uvvx xdj266r x11i5rnm xat24cr x1mh8g0r x2lwn1j xeuugli x16tdsg8 x1hl2dhg xggy1nq x1ja2u2z x1t137rt x1q0g3np x87ps6o x1lku1pv x1a2a7pz x6s0dn4 xzolkzo x12go9s9 x1rnf11y xprq8jg x972fbf xcfux6l x1qhh985 xm0m39n x9f619 x78zum5 xl56j7k xexx8yu x4uap5 x18d9i69 xkhd6sd x1n2onr6 xc9qbxq x14qfxbe x1qhmfi1']"));
                        buttonclose.Click();
                        dem++;
                        Console.WriteLine(dem);
                    }
                    Driver.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
                    Thread.Sleep(10000);
                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /* ChromeOptions options = Libary.Instance.Options();
             ChromeDriver Driver = new ChromeDriver(options);
             Driver.Url = txblinkbv.Text;
             Libary.Instance.randomtime(6000, 10000);
             Random ran = new Random();
             int tam = ran.Next(2, 5);
             Console.WriteLine(tam);
             List<IWebElement> fullshare = new List<IWebElement>(Driver.FindElements(By.CssSelector("a[class = 'x1i10hfl xe8uvvx xggy1nq x1o1ewxj x3x9cwd x1e5q0jg x13rtm0m x87ps6o x1lku1pv x1a2a7pz xjyslct xjbqb8w x18o3ruo x13fuv20 xu3j5b3 x1q0q8m5 x26u7qi x972fbf xcfux6l x1qhh985 xm0m39n x9f619 x1heor9g x1ypdohk xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x1n2onr6 x16tdsg8 x1hl2dhg x1vjfegm x3nfvp2 xrbpyxo x1itg65n x16dsc37']")));

             if (tam < fullshare.Count)
             {
                 fullshare[tam].Click();
                 Libary.Instance.randomtime(3000, 5000);
             }
             fullshare[1].Click();
            string linkshare = "";
            string idfb = "";
            string linkfb = "";
           string link = txblinkbv.Text;
            int i = link.IndexOf("&id=");
            int j = link.IndexOf("&__");
            int k = link.IndexOf("?__");
            int t = link.IndexOf("/posts/");
            if (( i != -1 )&&(j != -1 ))
            {
                linkshare = link.Substring(0, j);
                idfb = link.Substring(i+4,j-i-4);
                linkfb = "https://Fb.com/" + idfb;
            }
            if ((k != -1)&&(t != -1)) 
            {
                linkshare = link.Substring(0, k);
                linkfb = link.Substring(0,t);
            }
            Console.WriteLine(linkshare);
            Console.WriteLine(linkfb);
            Console.WriteLine(idfb);*/
            ChromeOptions options = Libary.Instance.Options();
            ChromeDriver Driver = new ChromeDriver(options);
            Actions action = new Actions(Driver);
            Driver.Url = txblinkbv.Text;
           Libary.Instance.randomtime(6000, 10000);
            List<IWebElement> elementshare = new List<IWebElement>(Driver.FindElements(By.CssSelector("div[class = 'x9f619 x1ja2u2z x78zum5 x2lah0s x1n2onr6 x1qughib x1qjc9v5 xozqiw3 x1q0g3np xykv574 xbmpl8g x4cne27 xifccgj']>div:nth-of-type(3)>span>div>div")));
            foreach (IWebElement element in elementshare)
            {
                IWebElement sumshare = element.FindElement(By.CssSelector("span[class = 'html-span xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x1hl2dhg x16tdsg8 x1vvkbs xkrqix3 x1sur9pj']"));
                //Console.WriteLine("tổng share: " + sumshare.Text);
                int SumShare = Convert.ToInt32(sumshare.Text);
                IWebElement buttonshare = element.FindElement(By.CssSelector("div[class = 'x9f619 x1n2onr6 x1ja2u2z x78zum5 xdt5ytf x2lah0s x193iq5w xeuugli xg83lxy x1h0ha7o x10b6aqq x1yrsyyn']"));
                action.MoveToElement(buttonshare).Build().Perform();
                action.Click(buttonshare).Build().Perform();
                //buttonshare.Click();
                Libary.Instance.randomtime(3000, 7000);
                if (SumShare > 10)
                {
                    IWebElement element2 = Driver.FindElement(By.CssSelector("div[class = 'xb57i2i x1q594ok x5lxg6s xdt5ytf x6ikm8r x1ja2u2z x1pq812k x1rohswg xfk6m8 x1yqm8si xjx87ck x1l7klhg x1iyjqo2 xs83m0k x2lwn1j xx8ngbg xwo3gff x1oyok0e x1odjw0f x1e4zzel x1n2onr6 xq1qtft x78zum5 x179dxpb']"));
                    int last_count = 0;
                    int new_count = 0;
                    do
                    {
                        Libary.Instance.randomtime(6000, 10000);
                        //last_count = Driver.FindElements(By.XPath("//div[@class = 'xb57i2i x1q594ok x5lxg6s xdt5ytf x6ikm8r x1ja2u2z x1pq812k x1rohswg xfk6m8 x1yqm8si xjx87ck x1l7klhg x1iyjqo2 xs83m0k x2lwn1j xx8ngbg xwo3gff x1oyok0e x1odjw0f x1e4zzel x1n2onr6 xq1qtft x78zum5 x179dxpb']")).Count();
                        last_count = Driver.FindElements(By.CssSelector("div[class = 'x1yztbdb']")).Count();
                        //Console.WriteLine("count cuối: " + last_count);

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
                        //Console.WriteLine("count cu", +new_count);
                    }
                    while (last_count != new_count);
                }
                List<IWebElement> fullshare = new List<IWebElement>(Driver.FindElements(By.CssSelector("div[class ^= 'x1yztbdb']>div>div>div>div>div>div>div:nth-of-type(2)>div>div:nth-of-type(2)>span:nth-of-type(1)>div>span>span>span>a")));
                foreach (IWebElement element3 in fullshare)
                {
                    string link = element3.GetAttribute("href");
                    Console.WriteLine(link);
                    MessageBox.Show(link);
                }
                    IWebElement buttonclose = Driver.FindElement(By.CssSelector("div[class = 'x1i10hfl xjqpnuy xa49m3k xqeqjp1 x2hbi6w x13fuv20 xu3j5b3 x1q0q8m5 x26u7qi x1ypdohk xdl72j9 x2lah0s xe8uvvx xdj266r x11i5rnm xat24cr x1mh8g0r x2lwn1j xeuugli x16tdsg8 x1hl2dhg xggy1nq x1ja2u2z x1t137rt x1q0g3np x87ps6o x1lku1pv x1a2a7pz x6s0dn4 xzolkzo x12go9s9 x1rnf11y xprq8jg x972fbf xcfux6l x1qhh985 xm0m39n x9f619 x78zum5 xl56j7k xexx8yu x4uap5 x18d9i69 xkhd6sd x1n2onr6 xc9qbxq x14qfxbe x1qhmfi1']"));
                buttonclose.Click();
                
            }
            Driver.Quit();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<PersonShare> personshare = new List<PersonShare>();
            ChromeOptions options = Libary.Instance.Options();
            ChromeDriver Driver = new ChromeDriver(options);
            Actions action = new Actions(Driver);
            string sumshare = "";
            Driver.Url = txblinkbv.Text;
            Libary.Instance.randomtime(6000, 10000);
            List<IWebElement> temp = new List<IWebElement>(Driver.FindElements(By.CssSelector("span[class = 'html-span xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x1hl2dhg x16tdsg8 x1vvkbs xkrqix3 x1sur9pj']"))); // css lượt chia sẻ
            foreach (IWebElement clickshare in temp)
            {
                int t = clickshare.Text.IndexOf("lượt chia sẻ");
                if (t != -1)
                {
                   
                    int index = clickshare.Text.IndexOf(" ");
                    sumshare = clickshare.Text.Substring(0, index);
                    clickshare.Click();
                }

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
                Console.WriteLine(diachi);
               // string diachishare = Libary.Instance.xululinkshare(diachi);
               // string linkfb = Libary.Instance.xulylinkperson(diachi);
               // personshare.Add(new PersonShare(diachishare, linkfb));
            }
            //return personshare;
           // foreach (PersonShare personShare in personshare)
           // {
             //   Console.WriteLine(personShare.DiachiShare.ToString());
             //   Console.WriteLine(personShare.LinkFb.ToString());
           // }
           //Driver.Quit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string chuoi = txblinkbv.Text;
            ChromeOptions options = Libary.Instance.Options();
            ChromeDriver Driver = new ChromeDriver(options);
            Driver.Url = chuoi;           
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
                if ((sumshare.IndexOf("lượt chia sẻ") != -1) || (sumshare.IndexOf("shares") != -1))
                {
                    btn.Click();
                    luotshare = btn.Text;
                }
            }
            Libary.Instance.randomtime(6000, 10000);
            if (luotshare != "")
            {
                //txbSumShare.Text = luotshare;
                int index = luotshare.IndexOf(" ");
                luotshare = luotshare.Substring(0, index);
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
                    Console.WriteLine("link: "+link);
                    string linkshare = Libary.Instance.rutgonlinkshare(link);
                    Console.WriteLine("linkshare: " + linkshare);
                    string linkfb = Libary.Instance.HrefToLinkFb(link);
                    Console.WriteLine("linkfb: " + linkfb);
                    if (linkfb.IndexOf("/groups/") != -1)
                    {
                        string linkfbnew = "";
                        IWebElement share2 = share.FindElement(By.CssSelector("a[class = 'x1i10hfl xjbqb8w x1ejq31n xd10rxx x1sy0etr x17r0tee x972fbf xcfux6l x1qhh985 xm0m39n x9f619 x1ypdohk xt0psk2 xe8uvvx xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x16tdsg8 x1hl2dhg xggy1nq x1a2a7pz xkrqix3 x1sur9pj xzsf02u x1s688f']"));
                        linkfbnew = share2.GetAttribute("href");
                        linkfbnew = Libary.Instance.HrefShareGroupsToIdFb(linkfbnew);
                        Console.WriteLine(linkfbnew);
                    }
                    
                }
            }
          Driver.Quit();
        }
    }
}
