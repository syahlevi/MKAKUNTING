using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Npgsql;
using System.Net;

namespace AKUNTING
{
    public partial class detailrincian : Form
    {
        public detailrincian()
        {
            InitializeComponent();
        }
        public string title { get; set; }
        public string amount { get; set; }
        public string id { get; set; }
        public string iddepan { get; set; }
        public string date { get; set; }
        public string documentno { get; set; }
        public string path { get; set; }
        public string pathhs { get; set; }
        public string stocksid1 { get; set; }
        public byte[] picture { get; set; }

        public string keterangan { get; set; }
        private void detailrincian_Load(object sender, EventArgs e)
        {
            txtaccountid.Text = id;
            iddepan = txtaccountid.Text.Substring(0, 1);
            if(iddepan=="3")
            {
                loadstocks();
            }
            if(iddepan=="2")
            {
                loaddebts();
            }
            if(iddepan=="1")
            {
                loadassets();
            }
            if(iddepan=="4")
            {
                loadcosts();
            }
            if(iddepan=="5")
            {
                loadearnings();

            }
        }

        public void loadearnings()
        {
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            ncon.Open();
            //var sql = "select sum(amount)  from costs where extract(year from tanggal) ='" + dttanggal.Value.Year + "' and extract(month from tanggal) ='" + dttanggal.Value.Month + "'";

            var sql = "select* from namespace2.earnings join namespace2.detailearnings on namespace2.earnings.earningsid= namespace2.detailearnings.earningsid where namespace2.earnings.earningsid= '" + txtaccountid.Text + "'";
            NpgsqlCommand ncom = new NpgsqlCommand(sql, ncon);
            NpgsqlDataReader dr = ncom.ExecuteReader();


            while (dr.Read())
            {
                txtamount.Text = dr.GetInt32(1).ToString();
                txttanggal.Text = dr.GetDate(2).ToString();
                txtdoc.Text = dr.GetString(3);
                txtketerangan.Text = dr.GetString(5);
                txtdate.Text = dr.GetDate(8).ToString();
                path = dr.GetString(6);
                pathhs = dr.GetString(9);
                a(pathhs);
                //var stream = new MemoryStream((picture)dr.GetByte(7));
                pbscan.Image = new Bitmap(path);
            }
            dr.Close();
            ncon.Close();
        }

        public void a(string url)
        {
            string username = "amal";
            string password = "j4k4rt4";
            WebClient req = new WebClient();
            req.Credentials = new NetworkCredential(username, password);

            byte[] FData = req.DownloadData(url);
            string fString = System.Text.Encoding.UTF8.GetString(FData);
            pbscan.Image = ByteToImage(FData);

        }

        //public byte[] GetImgByte(string ftpFilePath)
        //{
        //    ftpFilePath = "ftp://mk-cideng.ddns.net/tes%20prasetyo/2.PNG";
        //    string username = "amal";
        //    string password = "j4k4rt4";
        //    WebClient ftpClient = new WebClient();
        //    ftpClient.Credentials = new NetworkCredential(username, password);

        //    byte[] imageByte = ftpClient.DownloadData(ftpFilePath);
        //    return imageByte;
        //}

        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }


        public void loadcosts()
        {
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            ncon.Open();
            //var sql = "select sum(amount)  from costs where extract(year from tanggal) ='" + dttanggal.Value.Year + "' and extract(month from tanggal) ='" + dttanggal.Value.Month + "'";

            var sql = "select* from namespace2.costs join namespace2.DETAILCOSTS on namespace2.costs.costdid = namespace2.DETAILCOSTS.costdid where namespace2.costs.costdid= '" + txtaccountid.Text + "'";
            NpgsqlCommand ncom = new NpgsqlCommand(sql, ncon);
            NpgsqlDataReader dr = ncom.ExecuteReader();


            while (dr.Read())
            {
                txtamount.Text = dr.GetInt32(1).ToString();
                txttanggal.Text = dr.GetDate(2).ToString();
                txtdoc.Text = dr.GetString(3);
                txtketerangan.Text = dr.GetString(5);
                txtdate.Text = dr.GetDate(8).ToString();
                pathhs = dr.GetString(9);
                a(pathhs);
                path = dr.GetString(6);
                //var stream = new MemoryStream((picture)dr.GetByte(7));
            }
            dr.Close();
            ncon.Close();
        }

        public void loadassets()
        {
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            ncon.Open();
            //var sql = "select sum(amount)  from costs where extract(year from tanggal) ='" + dttanggal.Value.Year + "' and extract(month from tanggal) ='" + dttanggal.Value.Month + "'";

            var sql = "select* from namespace2.assets join namespace2.detailassets on namespace2.assets.assetsid= namespace2.detailassets.assetsid where namespace2.assets.assetsid= '" + txtaccountid.Text + "'";
            NpgsqlCommand ncom = new NpgsqlCommand(sql, ncon);
            NpgsqlDataReader dr = ncom.ExecuteReader();


            while (dr.Read())
            {
                txtamount.Text = dr.GetInt32(1).ToString();
                txttanggal.Text = dr.GetDate(2).ToString();
                txtdoc.Text = dr.GetString(3);
                txtketerangan.Text = dr.GetString(5);
                txtdate.Text = dr.GetDate(8).ToString();
                path = dr.GetString(6);
                pathhs = dr.GetString(9);
                a(pathhs);
                //var stream = new MemoryStream((picture)dr.GetByte(7));
                pbscan.Image = new Bitmap(path);
            }
            dr.Close();
            ncon.Close();
        }

        public void loaddebts()
        {
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            ncon.Open();
            //var sql = "select sum(amount)  from costs where extract(year from tanggal) ='" + dttanggal.Value.Year + "' and extract(month from tanggal) ='" + dttanggal.Value.Month + "'";

            var sql = "select* from namespace2.debts join namespace2.detaildebts on namespace2.debts.debtsid = namespace2.detailstocks.stocksid where namespace2.stocks.stocksid = '" + txtaccountid.Text + "'";
            NpgsqlCommand ncom = new NpgsqlCommand(sql, ncon);
            NpgsqlDataReader dr = ncom.ExecuteReader();


            while (dr.Read())
            {
                txtamount.Text = dr.GetInt32(1).ToString();
                txttanggal.Text = dr.GetDate(2).ToString();
                txtdoc.Text = dr.GetString(3);
                txtketerangan.Text = dr.GetString(5);
                txtdate.Text = dr.GetDate(8).ToString();
                path = dr.GetString(6);
                pathhs = dr.GetString(9);
                a(pathhs);
                //var stream = new MemoryStream((picture)dr.GetByte(7));
                pbscan.Image = new Bitmap(path);
            }
            dr.Close();
            ncon.Close();
        }

        public void loadstocks()
        {
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            ncon.Open();
            //var sql = "select sum(amount)  from costs where extract(year from tanggal) ='" + dttanggal.Value.Year + "' and extract(month from tanggal) ='" + dttanggal.Value.Month + "'";

            var sql = "select* from namespace2.stocks join namespace2.detailstocks on namespace2.stocks.stocksid = namespace2.detailstocks.stocksid where namespace2.stocks.stocksid = '" + txtaccountid.Text+"'";
            NpgsqlCommand ncom = new NpgsqlCommand(sql, ncon);
            NpgsqlDataReader dr = ncom.ExecuteReader();


            while (dr.Read())
            {
                txtamount.Text = dr.GetInt32(1).ToString();
                txttanggal.Text = dr.GetDate(2).ToString();
                txtdoc.Text = dr.GetString(3);
                txtketerangan.Text = dr.GetString(5);
                txtdate.Text = dr.GetDate(8).ToString();
                path = dr.GetString(6);
                pathhs = dr.GetString(9);
                a(pathhs);
                //var stream = new MemoryStream((picture)dr.GetByte(7));
                pbscan.Image = new Bitmap(path);
            }
            dr.Close();
            ncon.Close();
        }

        private void pbscan_Click(object sender, EventArgs e)
        {
            zoomgambar zg = new zoomgambar();
            zg.path = pathhs;
            zg.MdiParent = this.MdiParent;
            zg.Show();
        }
    }
}
