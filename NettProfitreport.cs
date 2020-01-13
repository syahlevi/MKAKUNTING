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
    public partial class NettProfitreport : Form
    {
        public NettProfitreport()
        {
            InitializeComponent();
        }

        public int grossprofit { get; set; }
        public int interest { get; set; }
        public int tax { get; set; }
        public int amortization { get; set; }
        public int depreciation { get; set; }
        public int netprofit { get; set; }

        public void update()
        {
            NpgsqlConnection scon = new NpgsqlConnection(stringkoneksi.connection);

            string masukdata = "update namespace2.nettprofit set totalnet=:totalnet where bulan='" + cbbulan.Text + "'";

            NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);
            scom.Parameters.Add(new NpgsqlParameter("@totalnet", Convert.ToDecimal(netprofit)));


            scon.Open();
            scom.ExecuteNonQuery();

            scon.Close();
            loaddata();

        }
        public void simpandata()
        {
            string months = DateTime.Now.ToString("MMMM");
            int m = DateTime.ParseExact(cbbulan.Text, "MMMM", CultureInfo.CurrentCulture).Month;
            NpgsqlConnection ncon2 = new NpgsqlConnection(stringkoneksi.connection);
            ncon2.Open();
            var sql = "select bulan from namespace2.nettprofit where bulan='" + months + "'";
            NpgsqlCommand ncom2 = new NpgsqlCommand(sql, ncon2);
            NpgsqlDataReader nred2 = ncom2.ExecuteReader();
            while (nred2.Read())
            {
                if (!nred2.IsDBNull(0))
                {
                    update();
                    MessageBox.Show("DATA GROSS PROFIT BULAN INI SUDAH ADA TIDAK PERLU INSERT DOUBLE CUKUP UPDATE AMOUNT");

                }
                else
                {

                    try
                    {
                        int a = 0;
                        NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
                        string masukdata = "insert into namespace2.nettprofit(nettprofitid,bulan,tahun,totalgross,totalnet,interest,amortization,depreciation,tax,keterangan) values(:nettprofitid,:bulan,:tahun,:totalgross,:totalnet,:interest,:amortization,:depreciation,:tax,:keterangan)";
                        NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
                        ncom.Parameters.Add(new NpgsqlParameter("nettprofitid", cbbulan.Text+cbtahun.Text+a++));
                        ncom.Parameters.Add(new NpgsqlParameter("bulan", cbbulan.Text));
                        ncom.Parameters.Add(new NpgsqlParameter("tahun", Convert.ToInt32(this.cbtahun.Text)));
                        ncom.Parameters.Add(new NpgsqlParameter("totalgross", grossprofit));
                        ncom.Parameters.Add(new NpgsqlParameter("totalnet", netprofit));
                        ncom.Parameters.Add(new NpgsqlParameter("interest",  Convert.ToInt32(this.txtinterest.Text)));
                        ncom.Parameters.Add(new NpgsqlParameter("amortization", Convert.ToInt32(this.txtamortization.Text)));
                        ncom.Parameters.Add(new NpgsqlParameter("depreciation", Convert.ToInt32(this.txtdepreciation.Text)));
                        ncom.Parameters.Add(new NpgsqlParameter("tax", Convert.ToInt32(this.txttax.Text)));
                        ncom.Parameters.Add(new NpgsqlParameter("keterangan", lbket.Text));


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

        public void rumus()
        {
            tax = Convert.ToInt32(this.txttax.Text);
            interest = Convert.ToInt32(this.txtinterest.Text);
            amortization = Convert.ToInt32(this.txtamortization.Text);
            depreciation = Convert.ToInt32(this.txtdepreciation.Text);
            netprofit = grossprofit - (interest + tax + amortization + depreciation);
            lbnetprofit.Text = netprofit.ToString("N0", new CultureInfo("en-US"));
            if (netprofit < 0)
            {
                lbket.Text = "Perusahaan Rugi";
                lbket.ForeColor = Color.Red;
            }
            else if (netprofit > 0 || netprofit <= grossprofit)
            {
                lbket.Text = "Nett Profit Normal";
                lbket.ForeColor = Color.ForestGreen;
            }
            else if (netprofit > grossprofit)

            {
                lbket.Text = "Balik Modal";
                lbket.ForeColor = Color.YellowGreen;
            }

        }

        public void loadbind()
        {

            NpgsqlConnection nocn = new NpgsqlConnection(stringkoneksi.connection);
            nocn.Open();
            NpgsqlCommand ncom = new NpgsqlCommand("select bulan,tahun from namespace2.configdate", nocn);
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
            DataTable dt = new DataTable();
            nda.Fill(dt);
            //DataRow dr = dt.NewRow();
            //dr.ItemArray = new object[] { 0, "--Pilih Parent--" };
            //dt.Rows.InsertAt(dr, 0);
            cbbulan.ValueMember = "bulan";
            cbbulan.DisplayMember = "bulan";
            cbbulan.DataSource = dt;
            cbtahun.ValueMember = "tahun";
            cbtahun.DisplayMember = "tahun";
            cbtahun.DataSource = dt;
            nocn.Close();
        }

        private void NettProfitreport_Load(object sender, EventArgs e)
        {
            tax = 0;
            txttax.Text = tax.ToString();
            interest = 0;
            amortization = 0;
            depreciation = 0;
            netprofit = 0;
            txtamortization.Text = amortization.ToString();
            txtdepreciation.Text = depreciation.ToString();
            txtinterest.Text = interest.ToString();
            lbnetprofit.Text = netprofit.ToString();
            lbreportdate.Text = DateTime.Now.Date.ToString("dddd, dd-MM-yyyy");
            loadbind();
            

        }

        public void loaddata()
        {


            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            NpgsqlCommand ncom = new NpgsqlCommand();
            ncom.Connection = ncon;
            ncom.CommandType = CommandType.Text;
            ncom.CommandText = "select*from namespace2.nettprofit where bulan='" + cbbulan.Text + "' and tahun='" + cbtahun.Text + "'";
            DataSet ds = new DataSet();
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
            nda.Fill(ds, "akunting");
            gridaccounts.DataSource = ds;
            gridaccounts.DataMember = "akunting";
            gridaccounts.Columns["totalgross"].DefaultCellStyle.Format = "N2";
            gridaccounts.Columns["totalnet"].DefaultCellStyle.Format = "N2";
            gridaccounts.Columns["interest"].DefaultCellStyle.Format = "N2";
            gridaccounts.Columns["amortization"].DefaultCellStyle.Format = "N2";
            gridaccounts.Columns["depreciation"].DefaultCellStyle.Format = "N2";
            gridaccounts.Columns["tax"].DefaultCellStyle.Format = "N2";


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

        public void counts()
        {
            int m = DateTime.ParseExact(cbbulan.Text, "MMMM", CultureInfo.CurrentCulture).Month;
            //int tot = Convert.ToInt32(this.lbtotop.Text);
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            ncon.Open();
            //var sql = "select sum(amount)  from costs where extract(year from tanggal) ='" + dttanggal.Value.Year + "' and extract(month from tanggal) ='" + dttanggal.Value.Month + "'";

            var sql = "select grossprofit from namespace2.grossprofit where bulan='" + cbbulan.Text + "' and tahun='" + cbtahun.Text + "'";
                NpgsqlCommand ncom = new NpgsqlCommand(sql, ncon);
            NpgsqlDataReader dr = ncom.ExecuteReader();


            while (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    grossprofit = dr.GetInt32(0);
                    lbtotgross.Text = grossprofit.ToString("N0", new CultureInfo("en-US"));


                }
                else
                {
                    MessageBox.Show("Anda Perlu Melakukan Kalkulasi Gross Report Di Menu Report -> Gross Profit Report");
                    lbtotgross.Text = 0.ToString();
                    grossprofit = 0;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cbbulan.Text==""||cbtahun.Text=="")
            {
                MessageBox.Show("Kosong Oy");

            }
            else
            {
                loaddata();
                counts();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            rumus();
            simpandata();
        }

        private void txtinterest_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtamortization_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtdepreciation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            update();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Cetak3 c3 = new Cetak3();
            c3.date = lbreportdate.Text;
            c3.month = cbbulan.Text;
            c3.year = Convert.ToInt32(this.cbtahun.Text);
            c3.gross = grossprofit;
            c3.net = netprofit;
            c3.interest = Convert.ToInt32(this.txtinterest.Text);
            c3.amortization = Convert.ToInt32(this.txtamortization.Text);
            c3.depreciation = Convert.ToInt32(this.txtdepreciation.Text);
            c3.tax = Convert.ToInt32(this.txttax.Text);
            c3.keterangan = lbket.Text;
            c3.MdiParent = this.MdiParent;
            c3.Show();
        }
    }
}
