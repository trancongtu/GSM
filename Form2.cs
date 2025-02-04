using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Threading;
using Keys = OpenQA.Selenium.Keys;
using DevExpress.Utils;

namespace CrawFB
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();


            string linkfb = "https://www.facebook.com/tiengnoitudotaynguyen?__cft__[0]=AZXP3ubVhTWNujqbaJwugfaxv84K2bObAHYjZTnkjiUBgZ7tf_-jjtu184AFMEs6Bjvz-AhdcDMMi84gfeGzbzU7IeFr__s4P8zFWiFriGA1fCStUUs2sU7ezd0OwGK11xgTFQt529rnS8M6Mg3snmx30GLHyvmxrPKMhFuD1VPBsw&__tn__=-UC%2CP-R!%3Av-R";
            string linkrutgon = Libary.Instance.xulylinkperson(linkfb);
            Console.WriteLine(linkrutgon);
            
        }
            

    }
}
