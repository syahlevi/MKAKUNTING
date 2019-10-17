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

namespace AKUNTING
{
    public partial class cetak : Form
    {
        public cetak()
        {
            
            InitializeComponent();
        }

        public string keterangan { get; set; }
        public int selisih { get; set; }
        public int totoperasional { get; set; }
        public int totcash { get; set; }
        public int totstocks { get; set; }
        public string printreport { get; set; }

    

        private void cetak_Load(object sender, EventArgs e)
        {
            //CultureInfo cultureInfo = new CultureInfo("id-ID");


            ReportDocument rd = new ReportDocument();
            string paths = @"C:\Users\Acer\Documents\Visual Studio 2015\Projects\AKUNTING\CrystalReport1.rpt";
            rd.Load(paths);
            //string.Format(cultureInfo, "{0:n}", totoperasional));
            rd.SetParameterValue("reportdate", printreport);
            rd.SetParameterValue("totaloperational", totoperasional.ToString("N0", new CultureInfo("en-US")));
            rd.SetParameterValue("totalcash", totcash.ToString("N0", new CultureInfo("en-US")));
            rd.SetParameterValue("totalstocks", totstocks.ToString("N0", new CultureInfo("en-US")));
            rd.SetParameterValue("sisastocks", selisih.ToString("N0", new CultureInfo("en-US")));
            rd.SetParameterValue("keterangan", keterangan);
            rd.SetParameterValue("printreportdate", DateTime.Now.ToString("dddd, dd-MMMM-yyyy"));


            crystalReportViewer1.ReportSource = rd;

            crystalReportViewer1.Refresh();

            

        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
