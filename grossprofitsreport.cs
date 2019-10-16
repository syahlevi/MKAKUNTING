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

            var sql = "select sum(amount)  from earnings where extract(year from tanggal) ='" + Convert.ToUInt32(this.cbtahun.Text )+ "' and extract(month from tanggal) ='" + m + "'";
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

        public void cekcash()
        {
            int m = DateTime.ParseExact(cbbulan.Text, "MMMM", CultureInfo.CurrentCulture).Month;
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            ncon.Open();
            var sql = "select sum (amount) from costs where extract(year from tanggal) ='" + Convert.ToInt32(this.cbtahun.Text) + "' and extract(month from tanggal) ='" + m + "'";
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
            ncom.CommandText = "select*from grossprofits where month='" + cbbulan.Text + "' and year='"+cbtahun.Text+"'"; 
            DataSet ds = new DataSet();
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
            nda.Fill(ds, "akunting");
            gridaccounts.DataSource = ds;
            gridaccounts.DataMember = "akunting";

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

            string masukdata = "update grossprofits set amount=:amount where month='" +cbbulan.Text + "'";

            NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);
            scom.Parameters.Add(new NpgsqlParameter("@amount", Convert.ToDecimal(this.lbtotgross.Text)));


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
            var sql = "select month from grossprofits where month='" + months + "'";
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
                    {
                        NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
                        string masukdata = "insert into GROSSPROFITS (year,month,amount) values(@year,@month,@amount)";
                        NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
                        ncom.Parameters.Add(new NpgsqlParameter("@year", decimal.Parse(this.cbtahun.Text)));
                        ncom.Parameters.Add(new NpgsqlParameter("@month", cbbulan.Text));


                        ncom.Parameters.Add(new NpgsqlParameter("@amount", decimal.Parse(lbtotgross.Text)));

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
    }
}
