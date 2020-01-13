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
    public partial class Cetak3 : Form
    {
        public Cetak3()
        {
            InitializeComponent();
        }

        public string keterangan { get; set; }
        public int gross { get; set; }
        public int net { get; set; }
        public int interest { get; set; }
        public int amortization { get; set; }
        public int depreciation { get; set; }
        public int tax { get; set; }
        public string month { get; set; }
        public int year { get; set; }
        public string date { get; set; }

        private void Cetak3_Load(object sender, EventArgs e)
        {
            ReportDocument rd = new ReportDocument();
            string[] s = { "\\bin" };
            string filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory) + "\\CrystalReport1.rpt";
            string patt = Application.StartupPath + "~\\CrystalReport1.rpt";
            string path22 = Application.StartupPath.Split(s, StringSplitOptions.None)[0] + "\\Debug\\CrystalReport1.rpt";
            string paths = @"C:\Users\Acer\Documents\Visual Studio 2015\Projects\AKUNTING VERSI 1.0\AKUNTING\bin\Debug\CrystalReport1.rpt";
            string path2 = "~/Debug/CrystalReport1.rpt";
            rd.Load("CrystalReport3.rpt");

            //string.Format(cultureInfo, "{0:n}", totoperasional));
            rd.SetParameterValue("tanggalreport", date);

            rd.SetParameterValue("monthprofit", month);
            rd.SetParameterValue("yearprofit", year);
            rd.SetParameterValue("keterangan", keterangan);
            rd.SetParameterValue("totalgross", gross.ToString("N0", new CultureInfo("en-US")));
            rd.SetParameterValue("totalnett", net.ToString("N0", new CultureInfo("en-US")));
            rd.SetParameterValue("interest", interest.ToString("N0", new CultureInfo("en-US")));
            rd.SetParameterValue("amortization", amortization.ToString("N0", new CultureInfo("en-US")));
            rd.SetParameterValue("depreciation", depreciation.ToString("N0", new CultureInfo("en-US")));
            rd.SetParameterValue("tax", tax.ToString("N0", new CultureInfo("en-US")));



            crystalReportViewer1.ReportSource = rd;

            crystalReportViewer1.Refresh();

        }
    }
}
