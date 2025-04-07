using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using DevExpress.XtraEditors.Controls;
using System.Diagnostics;
using DevExpress.Data.TreeList;
using static CrawFB.SetupShearchPost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace CrawFB
{

    public partial class SetupShearchPost : Form
    {
        string projectFolder = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
        string dataFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
        string keywordFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "keywordsfilter.txt");
        private Dictionary<int, string> postDetails = new Dictionary<int, string>();

        // Khai báo delegate
        public delegate void SetupCompletedHandler(int numberOfPosts, string timePeriod, int filterMode);
        public SetupCompletedHandler setupCompletedHandler;
        public SetupShearchPost()
        {
            InitializeComponent();
            nudSoBai.Value = 10;
            if (cBTime.Items.Count > 0)
            {
                cBTime.SelectedItem = cBTime.Items[0]; // Chọn mặc định là 1 ngày
            }
            chkFilterContent.Checked = false; // Mặc định lọc sau

        }

        private void cBTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            cBTime.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (File.Exists(keywordFile))
            {
                Process.Start("notepad.exe", keywordFile);
            }
            else
            {
                CheckAndCreateKeywordFile();
            }
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
          btnkeyword.Enabled = true;          
        }
        private void CheckAndCreateKeywordFile()
        {
            // Tạo thư mục Data nếu chưa có
            if (!Directory.Exists(dataFolder))
            {
                Directory.CreateDirectory(dataFolder);
            }

            // Kiểm tra file keywords.txt
            if (!File.Exists(keywordFile))
            {
                File.WriteAllText(keywordFile, ""); // Tạo file rỗng
                MessageBox.Show("📂 Đã tạo file 'keywordsfilter.txt'. Hãy nhập từ khóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start("notepad.exe", keywordFile); // Mở Notepad
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int numberOfPosts = (int)nudSoBai.Value;
            string timePeriod = cBTime.SelectedItem.ToString();
            int filterMode = chkFilterContent.Checked ? 1 : 2;
            setupCompletedHandler?.Invoke(numberOfPosts, timePeriod, filterMode);
        }
    }
}
