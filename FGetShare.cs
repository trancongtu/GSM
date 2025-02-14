using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GSM.DAO;
using GSM.DTO;
using OpenQA.Selenium.Chrome;

namespace GSM
{
    public partial class FGetShare : Form
    {
        public FGetShare(string Linkbv)
        {
            InitializeComponent();
            txbLinkFb.Text = Linkbv;
            hienthongtinshare(Linkbv);
           
        }
        public void hienthongtinshare(string diachibv)
        {
            string profile = "D://CODE/Project/GSM/TCT";
            ChromeDriver driver = Libary.Instance.khoitao(profile);
            List<PersonShare> listpersonshare = new List<PersonShare>();
            listpersonshare = Libary.Instance.GetShareOnePost(driver,diachibv);
            int j = 1;
            foreach (PersonShare share in listpersonshare)
            {
                Person person = Libary.Instance.thongtinperson(driver, share.LinkFb);
                dataGridView1.Rows.Add(j++,share.DiachiShare.ToString(), person.LinkFb.ToString(), person.DisplayName.ToString(), person.Live.ToString(), person.From.ToString());
            }
        }
    }
}
