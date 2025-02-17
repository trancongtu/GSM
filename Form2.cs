﻿using System;
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
using CrawFB.DTO;
using DevExpress.XtraEditors.Filtering.Templates;

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
            if (txblinkbv.Text != "")
            {
                ChromeOptions options = Libary.Instance.Options();
                ChromeDriver Driver = new ChromeDriver(options);
                Driver.Url = txblinkbv.Text;
                Libary.Instance.randomtime(6000, 10000);
                List<IWebElement> elementshare = new List<IWebElement>(Driver.FindElements(By.CssSelector("div[class = 'x9f619 x1ja2u2z x78zum5 x2lah0s x1n2onr6 x1qughib x1qjc9v5 xozqiw3 x1q0g3np xykv574 xbmpl8g x4cne27 xifccgj']>div:nth-of-type(3)>span>div>div")));
                foreach (IWebElement element in elementshare)
                {
                    IWebElement sumshare = element.FindElement(By.CssSelector("span[class = 'html-span xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x1hl2dhg x16tdsg8 x1vvkbs x1sur9pj xkrqix3']"));
                    Console.WriteLine(sumshare.Text);
                    IWebElement buttonshare = element.FindElement(By.CssSelector("div[class = 'x9f619 x1n2onr6 x1ja2u2z x78zum5 xdt5ytf x2lah0s x193iq5w xeuugli xg83lxy x1h0ha7o x10b6aqq x1yrsyyn']"));
                    buttonshare.Click();
                    Thread.Sleep(10000);
                   IWebElement element2 = Driver.FindElement(By.CssSelector("div[class = 'xb57i2i x1q594ok x5lxg6s xdt5ytf x6ikm8r x1ja2u2z x1pq812k x1rohswg xfk6m8 x1yqm8si xjx87ck x1l7klhg x1iyjqo2 xs83m0k x2lwn1j xx8ngbg xwo3gff x1oyok0e x1odjw0f x1e4zzel x1n2onr6 xq1qtft x78zum5 x179dxpb']"));
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
                }
                Driver.Quit();
            }
        }
    }
}
