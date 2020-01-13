using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Globalization;
using System.Data;
using System.Net;
using System.Diagnostics;

namespace AKUNTING
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void cekkoneksi()
        {

            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            try
            {
                ncon.Open();
                MessageBox.Show("Koneksi Berhasil", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lbinfo.Text = "Koneksi OK";
                lbinfo.ForeColor = Color.Green;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lbinfo.Text = ex.Message;
                lbinfo.ForeColor = Color.Red;
            }
            ncon.Close();
        }

        private void cekKoneksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cekkoneksi();
        }

        private void accountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            accounts ac = new accounts();
            ac.MdiParent = this;
            ac.Show();
        }

      

        private void operationalCostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            operationalcostreport opc = new operationalcostreport();
            opc.MdiParent = this;
            opc.Show();
        }

      

        public void countss()
        {

            //int tot = Convert.ToInt32(this.lbtotop.Text);
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            ncon.Open();
            //var sql = "select sum(amount)  from costs where extract(year from tanggal) ='" + dttanggal.Value.Year + "' and extract(month from tanggal) ='" + dttanggal.Value.Month + "'";

            var sql = "select *from namespace2.profilcompany join namespace2.headcompany on namespace2.profilcompany.idemployee=namespace2.headcompany.idemployee";
            NpgsqlCommand ncom = new NpgsqlCommand(sql, ncon);
            NpgsqlDataReader dr = ncom.ExecuteReader();


            while (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {


                    //txtcompanyid.Text = dr.GetInt32(0).ToString();
                    lbnamecompany.Text = dr.GetString(1);

                    //txtaddress.Text = dr.GetString(2);
                    //txtprovince.Text = dr.GetString(3);
                    //txtcity.Text = dr.GetString(4);
                    //txtnation.Text = dr.GetString(5);
                    //txtzipcode.Text = dr.GetInt32(6).ToString();
                    //txtphonecomp.Text = dr.GetInt32(7).ToString();
                    //txtemailcomp.Text = dr.GetString(8);
                    //txtdatestart.Text = dr.GetDate(9).ToString();
                    //txtidempl.Text = dr.GetString(10);
                    //txtheadname.Text = dr.GetString(11);
                    //txtjobtitle.Text = dr.GetString(12);
                    //txtgender.Text = dr.GetString(13);
                    //txtpass.Text = dr.GetString(14);
                    //txtemail.Text = dr.GetString(15);
                    //txtphone.Text = dr.GetString(16);

                }
                else
                {


                    MessageBox.Show("Anda Belum Mengisi Data Perusahaan", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
        }

        public void counts()
        {

            int a = DateTime.Now.Year;
            //int m = DateTime.ParseExact(DateTime.Now.ToString("MMMM"), "MMMM", new System.Globalization.CultureInfo("id-ID")).Month;
            //int tot = Convert.ToInt32(this.lbtotop.Text);
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            ncon.Open();
            //var sql = "select sum(amount)  from costs where extract(year from tanggal) ='" + dttanggal.Value.Year + "' and extract(month from tanggal) ='" + dttanggal.Value.Month + "'";

            var sql = "select sum(zipcode)  from namespace2.profilcompany";
            NpgsqlCommand ncom = new NpgsqlCommand(sql, ncon);
            NpgsqlDataReader dr = ncom.ExecuteReader();


            while (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {

                    countss();

                }
                else
                {


                    Welcomescreen ws = new Welcomescreen();
                    ws.StartPosition = FormStartPosition.CenterScreen;

                    ws.Show();
                    this.Enabled = false;


                }
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            counts();
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            lbdatess.Text = DateTime.Now.ToString("dddd, dd-MM-yyyy");
            cekkoneksi();
        }

        private void costToolStripMenuItem_Click(object sender, EventArgs e)
        {

            costs cs = new costs();
            cs.MdiParent = this;
            cs.Show();
        }

        private void stocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stocks st = new stocks();
            st.MdiParent = this;
            st.Show();
        }

        private void debtsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            debts db = new debts();
            db.MdiParent = this;
            db.Show();
        }

        private void assetsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            assets ass = new assets();
            ass.MdiParent = this;
            ass.Show();
        }

        private void grossProfitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grossprofits gp = new grossprofits();
            gp.MdiParent = this;
            gp.Show();
        }

        private void netProfitsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            nettprofitss npp = new nettprofitss();
            npp.MdiParent = this;
            npp.Show();
        }

        private void earningsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            earnings es = new earnings();
            es.MdiParent = this;
            es.Show();
        }

        //public void cekstocks()
        //{
        //    int m = DateTime.Now.Month;
        //    int ms = DateTime.Now.Year;
        //    NpgsqlConnection ncon2 = new NpgsqlConnection(stringkoneksi.connection);
        //    ncon2.Open();
        //    var sql = "select amount from stocks ";
        //    NpgsqlCommand ncom2 = new NpgsqlCommand(sql, ncon2);
        //    NpgsqlDataReader nred2 = ncom2.ExecuteReader();
        //    while (nred2.Read())
        //    {
        //        //MessageBox.Show(sql)
        //        if (!nred2.IsDBNull(0))
        //        {
                   
        //                accounts ac = new accounts();
        //                ac.MdiParent = this;
        //                ac.Show();
                   
                
        //            //simpanstocks();
        //            //simpandata();
        //            //simpanasset();

        //        }
        //        else
        //        {
        //            MessageBox.Show("Anda Harus Mengisi Stocks Bulan Ini Terlebih Dahulu");
        //            insertstocks iss = new insertstocks();
        //            iss.MdiParent = this;
        //            iss.Show();

        //        }
        //    }
        //}

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            accounts ac = new accounts();
            ac.MdiParent = this;
            ac.Show();




        }

        private void grossProfitsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            grossprofitsreport grp = new grossprofitsreport();
            grp.MdiParent = this;
            grp.Show();
        }

        private void nettProfitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NettProfitreport npr = new NettProfitreport();
            npr.MdiParent = this;
            npr.Show();
        }

        private void stoppingRetainedEarningsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            stoppingretainedearning sre = new stoppingretainedearning();
            sre.MdiParent = this;
            sre.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            counts();
        }

        private void companyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            identitascompany idc = new identitascompany();
            idc.MdiParent = this;
            idc.Show();
        }

        private void rekeningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            datarekening dr = new datarekening();
            dr.MdiParent = this;
            dr.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            panduan p = new panduan();
            p.MdiParent = this;
            p.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void arrangeIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form[] children = this.MdiChildren;
            for (int i = 0; i < children.Length; i++)
            {
                children[i].Close();
            }
        }

        private void detailCostsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            detailcost dc = new detailcost();
            dc.MdiParent = this;
            dc.Show();
        }

        private void detailStocksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            detailstocks ds = new detailstocks();
            ds.MdiParent = this;
            ds.Show();
        }

        private void crystalReportRuntimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://downloads.businessobjects.com/akdlm/cr4vs2010/CRforVS_13_0_5.exe");
            Process.Start(sInfo);
        }

        private void oDBC32BITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"psqlodbc_11_01_0000.zip");

        }

        private void konfigurasiODBCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            konfigurasiodbc ko = new konfigurasiodbc();
            ko.MdiParent = this;
            ko.Show();
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            detailcost dc = new detailcost();
            dc.MdiParent = this;
            dc.Show();
        }

        private void detailsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            detailstocks ds = new detailstocks();
            ds.MdiParent = this;
            ds.Show();
        }

        private void detailsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DetailDebts dd = new DetailDebts();
            dd.MdiParent = this;
            dd.Show();
        }

        private void detailsToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            detailearnings de = new detailearnings();
            de.MdiParent = this;
            de.Show();
        }

        private void detailsToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            detailassets da = new detailassets();
            da.MdiParent = this;
            da.Show();
        }

      

        private void employeeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Employee em = new Employee();
            em.MdiParent = this;
            em.Show();
        }

        private void rolesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ROLEScs rl = new ROLEScs();
            rl.MdiParent = this;
            rl.Show();
        }

        private void industriClassificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            industriclass ic = new industriclass();
            ic.MdiParent = this;
            ic.Show();
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
            Environment.Exit(0);
        }

        private void configDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigDate cd = new ConfigDate();
            cd.MdiParent = this;
            cd.Show();
        }
    }
}
