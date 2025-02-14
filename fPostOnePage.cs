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
    public partial class fPostOnePage : Form
    {
        public fPostOnePage()
        {
            InitializeComponent();
        }

        private void btnShearch_Click(object sender, EventArgs e)
        {
            string soluong = txbCountPost.Text;
            string linkbv = txbLinkPage.Text;
            string profile = "D://CODE/Project/GSM/TCT";
           
            ChromeDriver driver = Libary.Instance.khoitao(profile);
            List<Post> post = new List<Post>();
            post = Libary.Instance.GetPostOnePage(driver, linkbv, "", soluong, post);         
            int j = 1;
            foreach (Post post2 in post)
            {              
                dataGridView1.Rows.Add(j++, post2.DiaChi.ToString(), post2.ThoiGian.ToString(), post2.NoiDung.ToString(),post2.ChiaSe.ToString(), post2.BinhLuan.ToString()) ;
            }
            driver.Quit();
          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ( e.RowIndex >= 0)
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dataGridView1.Rows[e.RowIndex];
                txbLinkPost.Text = row.Cells["LinkPost"].Value.ToString();
                txbTimePost.Text = row.Cells["TimePost"].Value.ToString();
                txbContent.Text = row.Cells["Content"].Value.ToString();
                txbShare.Text = row.Cells["CountShare"].Value.ToString(); 
                txbComment.Text = row.Cells["CountComment"].Value.ToString();
            }
            
        }

        private void btnGetShare_Click(object sender, EventArgs e)
        {
            FGetShare f = new FGetShare(txbLinkPost.Text);
            f.ShowDialog();
        }
    }
}
