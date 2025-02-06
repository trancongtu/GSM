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
using CrawFB.DTO;

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
                IWebElement element = Driver.FindElement(By.LinkText("Bạn bè"));
                if (element != null)
                {
                    element.Click();
                }
                Libary.Instance.randomtime(5000, 10000);
                IWebElement element2 = Driver.FindElement(By.LinkText("Giới thiệu"));
                if (element2 != null)
                {
                    element2.Click();
                }
                Libary.Instance.randomtime(5000, 10000);
                IWebElement element3 = Driver.FindElement(By.LinkText("Ảnh"));
                if (element3 != null)
                {
                    element3.Click();
                }
                Libary.Instance.randomtime(5000, 10000);
                Driver.Quit();
            }
        }
    }
}
