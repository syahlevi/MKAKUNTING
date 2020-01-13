using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices;
using System.Globalization;
using System.IO;
namespace AKUNTING
{
    public partial class cetak2 : Form
    {
        public cetak2()
        {
            InitializeComponent();
        }
        public string datereport { get; set; }
        public string monthprofit { get; set; }
        public int year { get; set; }
        public int earnings { get; set; }
        public int cost { get; set; }
        public int grossprofit { get; set; }
        public string keterangan { get; set; }

        private void cetak2_Load(object sender, EventArgs e)
        {
            ReportDocument rd = new ReportDocument();
            string[] s = { "\\bin" };
            string filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + "\\CrystalReport1.rpt";
            string patt = Application.StartupPath + "~\\CrystalReport1.rpt";
            string path22 = Application.StartupPath.Split(s, StringSplitOptions.None)[0] + "\\Debug\\CrystalReport1.rpt";
            string paths = @"C:\Users\Acer\Documents\Visual Studio 2015\Projects\AKUNTING VERSI 1.0\AKUNTING\bin\Debug\CrystalReport1.rpt";
            string path2 = "~/Debug/CrystalReport1.rpt";
            rd.Load("CrystalReport2.rpt");
          
            //string.Format(cultureInfo, "{0:n}", totoperasional));
            rd.SetParameterValue("datereports", datereport);
            rd.SetParameterValue("monthprofit", monthprofit);
            rd.SetParameterValue("yearprofit",year);
            rd.SetParameterValue("totalearnings", earnings.ToString("N0", new CultureInfo("en-US")));
            rd.SetParameterValue("totalcost", cost.ToString("N0", new CultureInfo("en-US")));
            rd.SetParameterValue("totalgrossprofits", grossprofit.ToString("N0",new CultureInfo("en-US")));
            rd.SetParameterValue("keterangan", keterangan);


            crystalReportViewer1.ReportSource = rd;

            crystalReportViewer1.Refresh();

        }
    }
}
