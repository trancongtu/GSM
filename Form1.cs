using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using OpenQA.Selenium.DevTools.V130.Page;

namespace CrawFB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            ChromeOptions options = Libary.Instance.Options();
            ChromeDriver Driver = new ChromeDriver(options);
            if (Driver != null)
            {
                MessageBox.Show("Nạp Profile thành công");
                Driver.Url = "https://Facebook.com";
                Driver.Navigate();
                Thread.Sleep(10000);
                Driver.Url = "https://www.facebook.com/vu.luc.312318";
                Driver.Navigate();
                Thread.Sleep(10000);
                List<IWebElement> element = new List<IWebElement>();
                element = Libary.Instance.CheckAcoount(Driver);
                string filepath = "infor.txt";
                File.WriteAllText(filepath, element[0].Text.ToString() + "\n");
                for (int i = 1; i < 10; i++)
                {
                    Console.OutputEncoding = Encoding.Unicode;
                    Console.InputEncoding = Encoding.Unicode;
                    //Console.WriteLine(element[i].Text.ToString());                    
                   File.AppendAllText(filepath, element[i].Text.ToString()+"\n");                   
                }    
                //MessageBox.Show(element.Text);
                Driver.Quit();
            }  
            else { MessageBox.Show("lỗi"); }         
        }
    }
}
