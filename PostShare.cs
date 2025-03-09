using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.DevTools.V130.Network;

namespace CrawFB.DTO
{
    public class PostShare
    {
        private string diachiShare;
        private string linkFb;
        private string tenFb;
        private string noiSong;
        private string denTu;
        private string hocVan;

        public PostShare(string diachishare, string linkfb, string tenfb, string dentu, string noisong,string hocvan) 
        { 
            this.DiachiShare = diachishare;
            this.LinkFb = linkfb;
            this.TenFb = tenfb;
            this.DenTu = dentu;
            this.NoiSong = noisong;
            this.HocVan = hocvan;
        }
      
        public PostShare() { }
        public string DiachiShare { get => diachiShare; set => diachiShare = value; }
        public string LinkFb { get => linkFb; set => linkFb = value; }
        public string TenFb { get => tenFb; set => tenFb = value; }
        public string NoiSong { get => noiSong; set => noiSong = value; }
        public string DenTu { get => denTu; set => denTu = value; }
        public string HocVan { get => hocVan; set => hocVan = value; }
    }
}
