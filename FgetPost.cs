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
namespace CrawFB
{
    public partial class FgetPost : Form
    {
        public FgetPost()
        {
            InitializeComponent();
            
            
        }

        private void btnShreach_Click(object sender, EventArgs e)
        {
            string adrressGroups;
            if (txbLink != null)
            {
                adrressGroups = txbLink.Text;
                ChromeOptions options = Libary.Instance.Options();
                ChromeDriver Driver = new ChromeDriver(options);
                if (Driver != null)
                {
                    if (MessageBox.Show("Nạp thành công, bắt đầu lấy bài viết", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Driver.Url = adrressGroups;
                        Driver.Navigate();
                        Thread.Sleep(10000);                       
                       // List<IWebElement> elements = null;
                        int i = 0;
                        while (i < 10)
                        {
                            Driver.ExecuteScript("window.scrollTo(0, document.body.scrollHeight)");
                            Thread.Sleep(10000);
                            /*elements = new List<IWebElement>(Driver.FindElements(By.XPath("//a[contains(@href, '/posts/')]")));
                            foreach (IWebElement element in elements)
                            {
                                string idpost = element.GetAttribute("href");
                                int index = idpost.IndexOf("comment_id");
                                if (index == -1)
                                {
                                    int index2 = idpost.IndexOf("?");
                                    if (index2 != -1)
                                    {
                                        idpost = idpost.Substring(0, index2);
                                        idpost = idpost.Replace("https://www.facebook.com/", "https://Fb.com/");
                                       
                                    }
                                    string thoigian = element.GetAttribute("aria-label");
                                    dgvPost.Rows.Add(i++, idpost, thoigian, "");
                                }
                            }*/
                            List<IWebElement> fullpost = new List<IWebElement>(Driver.FindElements(By.CssSelector("div[data-pagelet*='TimelineFeedUnit']")));
                        Console.WriteLine(fullpost.Count);
                    
                            foreach (IWebElement element in fullpost)
                            {
                            IWebElement temp = element.FindElement(By.CssSelector("a[class*='x1sur9pj xkrqix3 x1s688f']"));
                            string idpost = temp.GetAttribute("href");
                            int index2 = idpost.IndexOf("?");
                            if (index2 != -1)
                            {
                                idpost = idpost.Substring(0, index2);
                                idpost = idpost.Replace("https://www.facebook.com/", "https://Fb.com/");
                            }
                                string thoigian = temp.GetAttribute("aria-label");
                                string contents = "";


                                List<IWebElement> content = new List<IWebElement>(element.FindElements(By.CssSelector("div[class*='x11i5rnm xat24cr']")));
                                    foreach (IWebElement noidung in content)
                                {
                                    contents += noidung.Text;
                                }


                                    dgvPost.Rows.Add(i++, idpost, thoigian, contents);
                            }
                            
                           
                            /*IWebElement element = Driver.FindElement(By.CssSelector("div[data-pagelet*='TimelineFeedUnit']"));
                            IWebElement temp = element.FindElement(By.CssSelector("a[class*='x1sur9pj xkrqix3 x1s688f']"));
                              
                                    string idpost = temp.GetAttribute("href");
                                    int index2 = idpost.IndexOf("?");
                                    if (index2 != -1)
                                    {
                                        idpost = idpost.Substring(0, index2);
                                        idpost = idpost.Replace("https://www.facebook.com/", "https://Fb.com/");
                                    }
                                    string thoigian = temp.GetAttribute("aria-label");
                                   
                            */
                                
                           // }







                        }
                        Driver.Quit();

                    }  
                }
                else { MessageBox.Show("lỗi"); }

            }
        }

        private void dgvPost_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvPost_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvPost.Rows[e.RowIndex];
                txbAddressPost.Text = Convert.ToString(row.Cells["addresspost"].Value);
            }
        }

        private void btnGetShare_Click(object sender, EventArgs e)
        {
            //GetShare f = new GetShare(txbAddressPost.Text);
        }
    }
}
