using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawFB.DTO
{
    public class PersonShare
    {
        private string diachiShare;
        private string linkFb;
        private string idFb;
        public PersonShare(string diachishare, string linkfb, string idfb)
        {
            this.DiachiShare = diachishare;
            this.LinkFb = linkfb;
            this.IdFb = idfb;
        }
        public PersonShare() { }
        public string DiachiShare { get => diachiShare; set => diachiShare = value; }
        public string LinkFb { get => linkFb; set => linkFb = value; }
        public string IdFb { get => idFb; set => idFb = value; }
    }
}
