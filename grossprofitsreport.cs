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

namespace AKUNTING
{
    public partial class grossprofitsreport : Form
    {
        public grossprofitsreport()
        {
            InitializeComponent();
        }

        public int jmlearnings { get; set; }
        public int jmlcash { get; set; }
        public int totgross { get; set; }

        public void counts()
        {
            int m = DateTime.ParseExact(cbbulan.Text, "MMMM", CultureInfo.CurrentCulture).Month;
            //int tot = Convert.ToInt32(this.lbtotop.Text);
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            ncon.Open();
            //var sql = "select sum(amount)  from costs where extract(year from tanggal) ='" + dttanggal.Value.Year + "' and extract(month from tanggal) ='" + dttanggal.Value.Month + "'";

            var sql = "select sum(amount)  from namespace2.earnings where extract(year from tanggal) ='" + Convert.ToUInt32(this.cbtahun.Text )+ "' and extract(month from tanggal) ='" + m + "'";
            NpgsqlCommand ncom = new NpgsqlCommand(sql, ncon);
            NpgsqlDataReader dr = ncom.ExecuteReader();


            while (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {  jmlearnings = dr.GetInt32(0);
                    lbtotearn.Text = jmlearnings.ToString("N0", new CultureInfo("en-US"));


                }
                else
                {
                    lbtotearn.Text = 0.ToString();
                    jmlearnings = 0;
                }
            }

        }

        private void grossprofitsreport_Load(object sender, EventArgs e)
        {
            lbreportdate.Text = DateTime.Now.Date.ToString("dddd, dd-MM-yyyy");
            loadbind();
            loadbind2();
          
        }
        public void loadbind()
        {

            NpgsqlConnection nocn = new NpgsqlConnection(stringkoneksi.connection);
            nocn.Open();
            NpgsqlCommand ncom = new NpgsqlCommand("select distinct bulan from namespace2.configdate ", nocn);
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
            DataTable dt = new DataTable();
            nda.Fill(dt);
            //DataRow dr = dt.NewRow();
            //dr.ItemArray = new object[] { 0, "--Pilih Parent--" };
            //dt.Rows.InsertAt(dr, 0);
            cbbulan.ValueMember = "bulan";
            cbbulan.DisplayMember = "bulan";
            cbbulan.DataSource = dt;
        
            nocn.Close();
        }

        public void loadbind2()
        {

            NpgsqlConnection nocn = new NpgsqlConnection(stringkoneksi.connection);
            nocn.Open();
            NpgsqlCommand ncom = new NpgsqlCommand("select distinct tahun from namespace2.configdate ", nocn);
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
            DataTable dt = new DataTable();
            nda.Fill(dt);
            //DataRow dr = dt.NewRow();
            //dr.ItemArray = new object[] { 0, "--Pilih Parent--" };
            //dt.Rows.InsertAt(dr, 0);
            cbtahun.ValueMember = "tahun";
            cbtahun.DisplayMember = "tahun";
            cbtahun.DataSource = dt;

            nocn.Close();
        }

        public void cekcash()
        {
            int m = DateTime.ParseExact(cbbulan.Text, "MMMM", CultureInfo.CurrentCulture).Month;
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            ncon.Open();
            var sql = "select sum (amount) from namespace2.costs where extract(year from tanggal) ='" + Convert.ToInt32(this.cbtahun.Text) + "' and extract(month from tanggal) ='" + m + "'";
            NpgsqlCommand ncom = new NpgsqlCommand(sql, ncon);
            NpgsqlDataReader nred = ncom.ExecuteReader();
            while (nred.Read())
            {
                if (!nred.IsDBNull(0))
                { jmlcash = nred.GetInt32(0);
                    lbtotcost.Text = jmlcash.ToString("N0", new CultureInfo("en-US"));


                }
                else
                {
                    lbtotcost.Text = 0.ToString();
                    jmlcash = 0;
                }
            }
        }

        public void rumus()
        {
            totgross = jmlearnings - jmlcash;
            lbtotgross.Text = totgross.ToString();
            if (totgross<0)
            {
                lbket.Text = "PERUSAHAAN RUGI";
                lbket.ForeColor = Color.Red;
            }
            else if(totgross>0 && totgross<=jmlcash)
            {
                lbket.Text = "Batas Aman";
                lbket.ForeColor = Color.ForestGreen;
            }
            else if(totgross>jmlcash)
            {
                lbket.Text = "Balik Modal";
                lbket.ForeColor = Color.YellowGreen;
            }
        }

        public void loaddata()
        {


            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            NpgsqlCommand ncom = new NpgsqlCommand();
            ncom.Connection = ncon;
            ncom.CommandType = CommandType.Text;
            ncom.CommandText = "select*from namespace2.grossprofit where bulan='" + cbbulan.Text + "' and tahun='"+cbtahun.Text+"'"; 
            DataSet ds = new DataSet();
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
            nda.Fill(ds, "akunting");
            gridaccounts.DataSource = ds;
            gridaccounts.DataMember = "akunting";
            gridaccounts.Columns["earning"].DefaultCellStyle.Format = "N2";
            gridaccounts.Columns["costs"].DefaultCellStyle.Format = "N2";
            gridaccounts.Columns["grossprofit"].DefaultCellStyle.Format = "N2";

            aturdatagrid();



        }

        private void aturdatagrid()
        {
            try
            {
                //mengatur tampilan panjang kolom otomatis menyesuaikan panjang character string data cell
                for (int i = 0; i < gridaccounts.Columns.Count - 1; i++)
                {
                    gridaccounts.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                gridaccounts.Columns[gridaccounts.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                for (int i = 0; i < gridaccounts.Columns.Count; i++)
                {
                    int colw = gridaccounts.Columns[i].Width;
                    gridaccounts.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    gridaccounts.Columns[i].Width = colw;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void loadd()
        {

        }
        public void update()
        {
            NpgsqlConnection scon = new NpgsqlConnection(stringkoneksi.connection);

            string masukdata = "update namespace2.grossprofit set grossprofit=:grossprofit where bulan='" + cbbulan.Text + "'";

            NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);
            scom.Parameters.Add(new NpgsqlParameter("@grossprofit", Convert.ToDecimal(this.lbtotgross.Text)));


            scon.Open();
            scom.ExecuteNonQuery();

            scon.Close();
            
        }
        public void simpandata()
        {
            string months = DateTime.Now.ToString("MMMM");
            int m = DateTime.ParseExact(cbbulan.Text, "MMMM", CultureInfo.CurrentCulture).Month;
            NpgsqlConnection ncon2 = new NpgsqlConnection(stringkoneksi.connection);
            ncon2.Open();
            var sql = "select bulan from namespace2.grossprofit where bulan='" + months + "'";
            NpgsqlCommand ncom2 = new NpgsqlCommand(sql, ncon2);
            NpgsqlDataReader nred2 = ncom2.ExecuteReader();
            while (nred2.Read())
            {
                if (!nred2.IsDBNull(0))
                {
                    Update();
                    MessageBox.Show("DATA GROSS PROFIT BULAN INI SUDAH ADA TIDAK PERLU INSERT DOUBLE CUKUP UPDATE AMOUNT");

                }
                else
                {

                    try
                    { int a = 0;
                        NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
                        string masukdata = "insert into namespace2.GROSSPROFIT (grossprofitid,bulan,tahun,earning,costs,grossprofit,keterangan) values(@grossprofitid,@bulan,@tahun,@earning,@costs,@grossprofit,@keterangan)";
                        NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
                        ncom.Parameters.Add(new NpgsqlParameter("@grossprofitid", cbbulan.Text+cbtahun.Text+a++));
                        ncom.Parameters.Add(new NpgsqlParameter("@bulan", cbbulan.Text));
                        ncom.Parameters.Add(new NpgsqlParameter("@tahun", Convert.ToInt32(this.cbtahun.Text)));
                        ncom.Parameters.Add(new NpgsqlParameter("@earning", jmlearnings));
                        ncom.Parameters.Add(new NpgsqlParameter("@costs", jmlcash));
                        ncom.Parameters.Add(new NpgsqlParameter("@grossprofit", totgross));
                        ncom.Parameters.Add(new NpgsqlParameter("@keterangan", lbket.Text));
        

                        ncon.Open();
                        ncom.ExecuteNonQuery();
                        ncon.Close();
                        loaddata();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        { if (cbbulan.Text == "" || cbtahun.Text == "")
            {
                MessageBox.Show("Diisi Dong");
            }
            else
            {
                counts();
                cekcash();
                rumus();
                simpandata();
                update();
                loaddata();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string months = DateTime.Now.ToString("MMMM");
            MessageBox.Show(months);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            cetak2 c2 = new cetak2();
            c2.datereport = lbreportdate.Text;
            c2.monthprofit = cbbulan.Text;
            c2.year = Convert.ToInt32(this.cbtahun.Text);
            c2.earnings = jmlearnings;
            c2.cost = jmlcash;
            c2.grossprofit = totgross;
            c2.keterangan = lbket.Text;
            c2.MdiParent = this.MdiParent;
            c2.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            simpandata();
        }
    }
}
