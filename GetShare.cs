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
namespace CrawFB
{
    public partial class GetShare : Form
    {
        public GetShare()
        {
            InitializeComponent();
            //textBox1.Text = idbaiviet;
            getshare("https://www.facebook.com/TrenDuongPitch/posts/pfbid02F8uYhP8TdQJESztE1DkQe86zuZpwR8riV1AS1fNRAcfF1UJcs87R1nvZiqm3ZYBWl");
        }
        public void getshare(string idbaiviet)
        {
            ChromeOptions options = Libary.Instance.Options();
            ChromeDriver Driver = new ChromeDriver(options);
            Driver.Url = idbaiviet;
            Thread.Sleep(10000);
            Driver.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
            List<IWebElement> share = new List<IWebElement>(Driver.FindElements(By.XPath("//span[contains(@class,'x1vvkbs x1sur9pj xkrqix3')]")));
            if (share.Count > 0)
            {
                share[share.Count - 1].Click();
                Thread.Sleep(10000);
            }
            List<IWebElement> fullshare = new List<IWebElement>(Driver.FindElements(By.CssSelector("span.html-span xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x1hl2dhg x16tdsg8 x1vvkbs>a")));
            if (fullshare.Count > 0)
            {
                Console.WriteLine(fullshare);
            }
            /* IWebElement element2 = Driver.FindElement(By.XPath("//div[@class = 'xb57i2i x1q594ok x5lxg6s xdt5ytf x6ikm8r x1ja2u2z x1pq812k x1rohswg xfk6m8 x1yqm8si xjx87ck x1l7klhg x1iyjqo2 xs83m0k x2lwn1j xx8ngbg xwo3gff x1oyok0e x1odjw0f x1e4zzel x1n2onr6 xq1qtft x78zum5 x179dxpb']"));
             int last_count = 0;
             int new_count = 0;
             do
             {
                 Thread.Sleep(10000);
                 //last_count = Driver.FindElements(By.XPath("//div[@class = 'xb57i2i x1q594ok x5lxg6s xdt5ytf x6ikm8r x1ja2u2z x1pq812k x1rohswg xfk6m8 x1yqm8si xjx87ck x1l7klhg x1iyjqo2 xs83m0k x2lwn1j xx8ngbg xwo3gff x1oyok0e x1odjw0f x1e4zzel x1n2onr6 xq1qtft x78zum5 x179dxpb']")).Count();
                 last_count = Driver.FindElements(By.CssSelector("div[class ^= 'x1yztbdb']")).Count;
                 Console.WriteLine(last_count);
                 for (int i = 0; i < 6; i++)
                 {
                     element2.SendKeys(Keys.End);
                     element2.SendKeys(Keys.Up);
                     element2.SendKeys(Keys.Up);
                     element2.SendKeys(Keys.Up);
                     element2.SendKeys(Keys.Down);
                     element2.SendKeys(Keys.Down);
                     element2.SendKeys(Keys.Down);
                     Thread.Sleep(10000);
                 }
                 new_count = Driver.FindElements(By.CssSelector("div[class = 'x1yztbdb']")).Count;
                 Console.WriteLine(new_count);
             }
             while (last_count != new_count);
             List<IWebElement> fullshare = new List<IWebElement>(Driver.FindElements(By.CssSelector("div[class = 'x1yztbdb']")));
             foreach (IWebElement element in fullshare)
             {
                 IWebElement temp = element.FindElement(By.CssSelector("a[class ='x1i10hfl xjbqb8w x1ejq31n xd10rxx x1sy0etr x17r0tee x972fbf xcfux6l x1qhh985 xm0m39n x9f619 x1ypdohk xt0psk2 xe8uvvx xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x16tdsg8 x1hl2dhg xggy1nq x1a2a7pz x1heor9g x1sur9pj xkrqix3 x1s688f]"));
                 string link = temp.GetAttribute("href");
                 Console.WriteLine(link);
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
        
    }
}
