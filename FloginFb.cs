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
    public partial class FloginFb : Form
    {
        public FloginFb()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cookie = txbCookie.Text;
            string profilename = txbProfileName.Text;
            if ((cookie == "") || (profilename == "") || (txbProfile.Text == ""))
            {
                MessageBox.Show("Chưa điền Cookie hoặc tên profile");
            }
            else
            {
                string ConvertToCookie = "";
                string temp1 = "";
                string temp2 = "";
                string[] cookie2 = cookie.Split(';');
                foreach (string ck in cookie2)
                {
                    if (ck.Contains("c_user")) { temp1 = ck; }
                    if (ck.Contains("xs=")) { temp2 = ck; }
                }
                if ((temp1 != "") && (temp2 != ""))
                {
                    ConvertToCookie = temp1 + "; " + temp2 + ";";
                }
                Console.WriteLine(ConvertToCookie);
                string script = "javascript:void(function(){ function setCookie(t) { var list = t.split('; '); console.log(list); for (var i = list.length - 1; i >= 0; i--) { var cname = list[i].split(' = ')[0]; var cvalue = list[i].split(' = ')[1]; var d = new Date(); d.setTime(d.getTime() + (7*24*60*60*1000)); var expires = '; domain =.facebook.com; expires = '+ d.toUTCString(); document.cookie = cname + ' = ' + cvalue + '; ' + expires; } } function hex2a(hex) { var str = ''; for (var i = 0; i < hex.length; i += 2) { var v = parseInt(hex.substr(i, 2), 16); if (v) str += String.fromCharCode(v); } return str; } setCookie('" + ConvertToCookie + "'); location.href = 'https://mbasic.facebook.com'; })()";
                string filePath = txbProfile.Text + "/" + txbProfileName.Text;
                ChromeOptions options = Libary.Instance.Options2(filePath);
                ChromeDriver driver = new ChromeDriver(options);
                driver.Url = "Https://Fb.com/";
                driver.ExecuteScript(script);
                Libary.Instance.randomtime(5000, 10000);
                try
                {
                    IWebElement elementlive = driver.FindElement(By.Id(":Rbadakl6illkqismipapd5aq:"));
                    if (elementlive.Enabled == true)
                    {
                        MessageBox.Show("đăng nhập thành công");
                        driver.Quit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();

            if (fd.ShowDialog() == DialogResult.OK)
            {
                txbProfile.Text = fd.SelectedPath.ToString();
            }
        }
    }
}
