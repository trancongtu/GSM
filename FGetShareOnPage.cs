using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrawFB.DAO;
using CrawFB.DTO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace CrawFB
{
    public partial class FGetShareOnPage : Form
    {
        public FGetShareOnPage()
        {
            InitializeComponent();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            if (txbLinkPage.Text != "")               
            {   string linkpage = txbLinkPage.Text;
                int j = 1;
                int sobai = Convert.ToInt32(txbSoBai.Text);
                List<PersonShare> share = new List<PersonShare>();
                List<Person> people = new List<Person>();
                ChromeOptions options = Libary.Instance.Options();
                ChromeDriver Driver = new ChromeDriver(options);             
                Actions action = new Actions(Driver);
                share = Libary.Instance.GetShareOnePage(Driver, linkpage, sobai);
                foreach (PersonShare shareItem in share)
                {
                    string linkfb = shareItem.LinkFb.ToString();
                    if (PersonDAO.Instance.CheckCreatePerson(linkfb) == 0)
                    {
                        people = Libary.Instance.ThongtinPerson(Driver, linkfb);
                        foreach (Person per in people)
                        {
                            dgvGetShare.Rows.Add(j++, shareItem.DiachiShare.ToString(), linkfb, per.NoiSong.ToString(), per.DenTu.ToString());
                        }
                    } 
                    else
                    {
                        Person per = new Person();
                        per = PersonDAO.Instance.GetInforPerson("LinkFb",linkfb);
                        dgvGetShare.Rows.Add(j++, shareItem.DiachiShare.ToString(), linkfb, per.NoiSong.ToString(), per.DenTu.ToString());
                    }
                }
            }    
        }

        private void btnSavePerson_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvGetShare.RowCount; i++)
            {
                for (int j = 1; j < dgvGetShare.ColumnCount; j++)
                {
                    string giatri = "";
                    if(dgvGetShare.Rows[i].Cells[j].Value != null)
                    {
                        giatri = dgvGetShare.Rows[i].Cells[j].Value.ToString();
                    }
                    Console.WriteLine(giatri);
                }
            }
        }
    }
}
