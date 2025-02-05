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
                List<Person> person = new List<Person>();
                person = Libary.Instance.GetShareOnePost(Driver, txblinkbv.Text);
                foreach (Person person2 in person)
                {
                    string linkfb = person2.LinkFb.ToString();
                    List<string> thongtincn = new List<string>();
                    if (linkfb != "")
                    {
                        thongtincn = Libary.Instance.thongtincanhan(Driver, linkfb + "/about");
                        foreach (string t in thongtincn)
                        {
                            MessageBox.Show("ab: "+t);
                        }
                    }
                }
                Driver.Quit();
            }
        }
    }
}
