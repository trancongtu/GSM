using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraPrinting.Native;
using DocumentFormat.OpenXml.Wordprocessing;
using System.IO;
using ClosedXML.Excel;
namespace CrawFB
{
    public partial class fAddPage : Form
    {
        private List<string> listPages = new List<string>();
        public fAddPage()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var lines = txbIdLink.Lines
            .Select(x => x.Trim())
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Distinct();
            int j = 1;
            foreach (var line in lines)
            {
                if (!listPages.Contains(line))
                {
                    listPages.Add(line);
                    dataGridViewPages.Rows.Add(j++,line); // Thêm vào DataGridView
                }
            }

            txbIdLink.Clear();
        }

        private void btnResult_Click(object sender, EventArgs e)
        {

            if (listPages.Count == 0)
            {
                MessageBox.Show("Chưa có địa chỉ nào để lưu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);
            string fileName = "DanhSachPage.xlsx";
            string filePath = Path.Combine(folderPath, fileName);

            try
            {
                // Mở workbook hiện có
                var workbook = new XLWorkbook(filePath);
                var worksheet = workbook.Worksheets.Worksheet("Sheet1");

                // Tìm dòng trống tiếp theo để bắt đầu thêm dữ liệu
                int nextRow = worksheet.LastRowUsed().RowNumber() + 1;

                // Thêm dữ liệu vào worksheet
                foreach (var page in listPages)
                {
                    worksheet.Cell(nextRow, 1).Value = nextRow - 1;  // STT
                    worksheet.Cell(nextRow, 2).Value = page;          // ID/Địa Chỉ Page
                    nextRow++;
                }

                // Lưu lại file
                workbook.Save();

                MessageBox.Show("Danh sách đã được lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            listPages.Clear();
            dataGridViewPages.Rows.Clear(); // Xóa hết dữ liệu trong DataGridView sau khi lưu
        }
    }
}
