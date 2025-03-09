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
using DevExpress.ReportServer.ServiceModel.DataContracts;

namespace CrawFB
{
    public partial class FDatabasePerson : Form
    {
        public FDatabasePerson()
        {
            InitializeComponent();
            hiendoituong();
        }
        void hiendoituong()
        {          
            List<Person> ListPerson = PersonDAO.Instance.LoadPerson();
            int i = 1;
            foreach (Person item in ListPerson)
            {                                                  
                dataGridView1.Rows.Add(i++, item.LinkFb.ToString(), item.TenFb.ToString(), item.IdFbPerson.ToString(), item.NoiSong.ToString(), item.DenTu.ToString(), item.HocVan.ToString());
            }
        }
    }
}
