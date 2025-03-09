using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawFB.DTO
{
    public class Person
    {
        private int id;
        private string linkFb;
        private string tenFb;
        private string noiSong;
        private string denTu;
        private string hocVan;
        private string idFbPerson;
        public Person(int id, string linkfb, string tenfb, string dentu, string noisong, string hocvan,string idfbperson)
        {
            this.Id = id;
            this.LinkFb = linkfb;
            this.TenFb = tenfb;
            this.DenTu = dentu;
            this.NoiSong = noisong;
            this.HocVan = hocvan;  
            this.IdFbPerson = idfbperson;
        }
        public Person(DataRow row)
        {
            this.Id = (int)row["ID"];
            this.TenFb = (string)row["TenFb"];
            this.LinkFb = (string)row["LinkFb"];
            this.NoiSong = (string)row["NoiSong"];
            this.DenTu = (string)row["DenTu"];
            this.HocVan = (string)row["HocVan"];
            this.IdFbPerson = (string)row["IdFbPerson"];
        }
        public Person() { }
        public string LinkFb { get => linkFb; set => linkFb = value; }
        public string TenFb { get => tenFb; set => tenFb = value; }
        public string NoiSong { get => noiSong; set => noiSong = value; }
        public string DenTu { get => denTu; set => denTu = value; }
        public string HocVan { get => hocVan; set => hocVan = value; }
        public int Id { get => id; set => id = value; }
        public string IdFbPerson { get => idFbPerson; set => idFbPerson = value; }
    }
}
