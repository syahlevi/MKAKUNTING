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

namespace AKUNTING
{
    public partial class nettprofitss : Form
    {
        public nettprofitss()
        {
            InitializeComponent();
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

  


        private void nettprofitss_Load(object sender, EventArgs e)
        {
            txtyear.Text = DateTime.Now.Date.ToString("yyyy");
            txtmonth.Text = DateTime.Now.Date.ToString("MMMM");
            loaddata();
        }
        int angka = 0;


        public void simpandata()
        {
            try
            {
                NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
                string masukdata = "insert into nettprofits (year,month,amount) values(:year,:month,:amount)";
                NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
                ncom.Parameters.Add(new NpgsqlParameter("year", Convert.ToDecimal(this.txtyear.Text)));
                ncom.Parameters.Add(new NpgsqlParameter("month", txtmonth.Text));
                ncom.Parameters.Add(new NpgsqlParameter("amount", Convert.ToDecimal(angka)));

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

        public void loaddata()
        {

            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            NpgsqlCommand ncom = new NpgsqlCommand();
            ncom.Connection = ncon;
            ncom.CommandType = CommandType.Text;
            ncom.CommandText = "select*from nettprofits";
            DataSet ds = new DataSet();
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
            nda.Fill(ds, "akunting");
            gridaccounts.DataSource = ds;
            gridaccounts.DataMember = "akunting";
            aturdatagrid();




        }

        private void button1_Click(object sender, EventArgs e)
        {
            simpandata();
        }

        private void txtyear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
