using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using CrawFB.DAO;
namespace CrawFB
{
    public partial class FGroupsGSM : Form
    {
        public FGroupsGSM()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            string fileName = "DanhSachPage.xlsx";
            string filePath = Path.Combine(folderPath, fileName);
            if (!File.Exists(filePath))
            {
                string header = "STT, ID/Địa Chỉ Page";
                ExcellHelp.Instance.DesignExcelFile(header, filePath, "Sheet1");
            }
            else
            {
                // Mở form nhỏ để thêm ID/URL
                fAddPage form = new fAddPage();
                form.ShowDialog();
            }
        }
    }
}
