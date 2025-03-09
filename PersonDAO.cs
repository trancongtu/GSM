using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrawFB.DTO;

namespace CrawFB.DAO
{
    public class PersonDAO
    {
        private static PersonDAO instance;

        public static PersonDAO Instance
        {
            get { if (instance == null) instance = new PersonDAO(); return PersonDAO.instance; }
            private set { PersonDAO.instance = value; }
        }
        public List<Person> LoadPerson()
        {
            List<Person> listPerson = new List<Person>();
            string query = "select * from Person";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow dtr in data.Rows)
            {
                Person per = new Person(dtr);
                listPerson.Add(per);
            }
            return listPerson;
        }
        public void CreatPersonSimple(string DisplayName, string AddressPerson, string IdFbPerson, string Noisong, string dentu, string hocvan)
        {
            string str = "INSERT INTO dbo.Person(TenFb, LinkFb, IdFbPerson, NoiSong, DenTu, HocVan) VALUES (N'" + DisplayName + "', N'" + AddressPerson + "', N'" + IdFbPerson + "',N'" + Noisong + "', N'" + dentu + "', N'" + hocvan + "')";
            DataProvider.Instance.ExecuteQuery(str);
        }
        public int CheckCreatePerson(string linkfb)
        {
            int i = 0;
            string sql = "Select * from Person where LinkFb = N'" + linkfb + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(sql);
            if (data.Rows.Count > 0) i = 1;
            else i = 0;
            return i;
        }
        public Person GetInforPerson(string cot, string giatri)
        {
            string query = "select * from Person where " + cot + " = N'" + giatri + "'";
            Person per = new Person();
            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(query);
                foreach (DataRow dtr in data.Rows)
                {
                    per = new Person(dtr);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return per;
        }
        public bool ShearchPerson(string cot, string giatri)
        {
            string query = "select * from Person where " + cot + " = N'" + giatri + "'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            if (data.Rows.Count > 0)
                return true;
            else return false;
        }
       
    }
}
