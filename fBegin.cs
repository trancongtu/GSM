using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace CrawFB
{
    public partial class fBegin : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public fBegin()
        {
            InitializeComponent();
        }

        private void btnOnePost_ItemClick(object sender, ItemClickEventArgs e)
        {
            fGetShareonePost f = new fGetShareonePost();
            f.Show();
        }

        private void database_ItemClick(object sender, ItemClickEventArgs e)
        {
            FDatabasePerson f = new FDatabasePerson();
            f.ShowDialog();
        }
    }
}