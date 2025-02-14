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

namespace GSM
{
    public partial class GetShareOnePost : Form
    {
        public GetShareOnePost()
        {
            InitializeComponent();
        }

        private void btnShearch_Click(object sender, EventArgs e)
        {
            string profile = "D://CODE/Project/GSM/ProfileTCT";
            Libary.Instance.khoitao(profile);
        }
    }
}
