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
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using System.Globalization;

namespace AKUNTING
{
    public partial class operationalcostreport : Form
    {
        public operationalcostreport()
        {
            InitializeComponent();
        }

        public int stocks { get; set; }
        public int cost { get; set; }
        public int selisih { get; set; }
        public int cash { get; set; }
        public int cekselisih { get; set; }

        public int cekamount { get; set; }

      

        public void loaddata()
        {
            int m = DateTime.ParseExact(cbbulan.Text, "MMMM", CultureInfo.CurrentCulture).Month;


            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            NpgsqlCommand ncom = new NpgsqlCommand();
            ncom.Connection = ncon;
            ncom.CommandType = CommandType.Text;
            ncom.CommandText = "select*from costs where extract(year from tanggal) ='"+ Convert.ToInt32(this.cbtahun.Text)+ "' and extract(month from tanggal) ='" + m+ "'";
            DataSet ds = new DataSet();
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
            nda.Fill(ds, "akunting");
            dgreport.DataSource = ds;
            dgreport.DataMember = "akunting";

            aturdatagrid();



        }

        public void countstock()
        {
            int m = DateTime.ParseExact(cbbulan.Text, "MMMM", CultureInfo.CurrentCulture).Month;

            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            ncon.Open();
            var sql = "select sum(amount)  from stocks where extract(year from tanggal) ='" + Convert.ToInt32(this.cbtahun.Text) + "' and extract(month from tanggal) ='" + m + "'";
            NpgsqlCommand ncom = new NpgsqlCommand(sql, ncon);
            NpgsqlDataReader dr = ncom.ExecuteReader();


            while (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {  stocks = dr.GetInt32(0);
                    lbtotstocks.Text = stocks.ToString("N0", new CultureInfo("en-US"));


                }
                else
                {
                    lbtotstocks.Text = 0.ToString();
                    stocks = 0;
                }
            }

        }

        public void cekcash()
        {
            int m = DateTime.ParseExact(cbbulan.Text, "MMMM", CultureInfo.CurrentCulture).Month;
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            ncon.Open();
            var sql = "select sum (amount) from assets where extract(year from tanggal) ='" + Convert.ToInt32(this.cbtahun.Text) + "' and extract(month from tanggal) ='" + m + "'"; 
            NpgsqlCommand ncom = new NpgsqlCommand(sql, ncon);
            NpgsqlDataReader nred = ncom.ExecuteReader();
            while(nred.Read())
            {
                if(!nred.IsDBNull(0))
                {  cash = nred.GetInt32(0);
                    lbtotcash.Text = cash.ToString("N0", new CultureInfo("en-US"));


                }
                else
                {
                    lbtotcash.Text = 0.ToString();
                    cash = 0;
                }
            }
        }
    

        public void counts()
        {
           int  m= DateTime.ParseExact(cbbulan.Text, "MMMM", CultureInfo.CurrentCulture).Month;
            //int tot = Convert.ToInt32(this.lbtotop.Text);
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            ncon.Open();
            //var sql = "select sum(amount)  from costs where extract(year from tanggal) ='" + dttanggal.Value.Year + "' and extract(month from tanggal) ='" + dttanggal.Value.Month + "'";

            var sql = "select sum(amount)  from costs where extract(year from tanggal) ='" + cbtahun.Text + "' and extract(month from tanggal) ='" + m + "'";
            NpgsqlCommand ncom = new NpgsqlCommand(sql,ncon);
            NpgsqlDataReader dr = ncom.ExecuteReader();

          
            while(dr.Read())
            {
                if (!dr.IsDBNull(0))
                { cost = dr.GetInt32(0);
                    lbtotop.Text = cost.ToString("N0", new CultureInfo("en-US"));


                }
                else
                {
                    lbtotop.Text = 0.ToString();
                    cost = 0;
                }
            }

        }

        public void cari()
        {

        }


        public void cekupdatestocks()
        {
            //int tot = Convert.ToInt32(this.lbtotop.Text);
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            ncon.Open();
            //var sql = "select sum(amount)  from costs where extract(year from tanggal) ='" + dttanggal.Value.Year + "' and extract(month from tanggal) ='" + dttanggal.Value.Month + "'";

            var sql = "select amount  from amountupdatestocks ";
            NpgsqlCommand ncom = new NpgsqlCommand(sql, ncon);
            NpgsqlDataReader dr = ncom.ExecuteReader();


            while (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    update();
                  


                }
                else
                {
                    MessageBox.Show("Stocks Amount");
                    insertamount();
                }
            }
        }

   

        public void insertamount()
        {
           
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            string masukdata = "insert into amountupdatestocks (amount) values(:amount)";
            NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
            ncom.Parameters.Add(new NpgsqlParameter("amount", selisih));

            ncon.Open();
            ncom.ExecuteNonQuery();
            ncon.Close();
          
        }

        public void update()
        {
            int m = DateTime.ParseExact(DateTime.Now.Month.ToString(), "mm", CultureInfo.CurrentCulture).Month;

            NpgsqlConnection scon = new NpgsqlConnection(stringkoneksi.connection);

            string masukdata = "update amountupdatestocks set amount=:amount";

            NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);
            scom.Parameters.Add(new NpgsqlParameter("@amount", Convert.ToDecimal(selisih)));


            scon.Open();
            scom.ExecuteNonQuery();

            scon.Close();
            loaddata();
            MessageBox.Show("Data Stocks Bulan :" +" " + DateTime.Now.Month.ToString("MMMM") + "Telah Terupdate", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loaddata();
            counts();
            countstock();
            cekcash();
          
           
         
            //lbreportdate.Text = dttanggal.Value.Month.ToString() + dttanggal.Value.Year.ToString();
            lbreportdate.Text = cbbulan.Text + cbtahun.Text;

            selisih = stocks - cost;

            lbselisih.Text = selisih.ToString("N0", new CultureInfo("en-US"));
            cekselisih = selisih + cost;

            if (selisih == 0)
            {
                lbket.Text = "-";
            }
            else
            {

                if (cekselisih == stocks )
                {
                    lbket.Text = "PERHITUNGAN SESUAI";
                    lbket.ForeColor = Color.YellowGreen;
                }
                if (cekselisih < stocks )
                {
                    lbket.Text = "Selisih Aman";
                    lbket.ForeColor = Color.Green;
                }
                if (cekselisih > stocks )
                {
                    lbket.Text = "PERHITUNGAN TIDAK SESUAI";
                    lbket.ForeColor = Color.Red;
                }
                cekupdatestocks();
            }
        }
        public void loadbind()
        {
           
            NpgsqlConnection nocn = new NpgsqlConnection(stringkoneksi.connection);
            nocn.Open();
            NpgsqlCommand ncom = new NpgsqlCommand("select month,year from grossprofits ", nocn);
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
            DataTable dt = new DataTable();
            nda.Fill(dt);
            //DataRow dr = dt.NewRow();
            //dr.ItemArray = new object[] { 0, "--Pilih Parent--" };
            //dt.Rows.InsertAt(dr, 0);
            cbbulan.ValueMember = "month";
            cbbulan.DisplayMember = "month";
            cbbulan.DataSource = dt;
            cbtahun.ValueMember = "year";
            cbtahun.DisplayMember = "year";
            cbtahun.DataSource = dt;
            nocn.Close();
        }


        private void operationalcostreport_Load(object sender, EventArgs e)
        {
            loadbind();
            lbreportprint.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");
        }

        private void aturdatagrid()
        {
            try
            {
                //mengatur tampilan panjang kolom otomatis menyesuaikan panjang character string data cell
                for (int i = 0; i < dgreport.Columns.Count - 1; i++)
                {
                    dgreport.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                dgreport.Columns[dgreport.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                for (int i = 0; i < dgreport.Columns.Count; i++)
                {
                    int colw = dgreport.Columns[i].Width;
                    dgreport.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgreport.Columns[i].Width = colw;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loaddata();
            counts();
            countstock();
            cekcash();
          
        }

        private void dttanggal_ValueChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            cetak c = new cetak();
            c.keterangan = lbket.Text;
            c.selisih = selisih;
            c.totoperasional = cost;
            c.totcash = cash;
            c.totstocks = stocks;
            c.printreport = lbreportprint.Text;
            
            c.MdiParent = this.MdiParent;
            c.Show();
        }

        private void cbbulan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
