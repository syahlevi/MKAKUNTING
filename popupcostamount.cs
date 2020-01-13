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
    public partial class popupcostamount : Form
    {
        public popupcostamount()
        {
            InitializeComponent();
        }
        public string id { get; set; }
        public string parentid { get; set; }
        public int totals { get; set; }
        public int total { get; set; }

        public void jumlahstock()
        {
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            ncon.Open();
            //var sql = "select sum(amount)  from costs where extract(year from tanggal) ='" + dttanggal.Value.Year + "' and extract(month from tanggal) ='" + dttanggal.Value.Month + "'";

            var sql = "select amount  from namespace2.amountupdatestocks";
            NpgsqlCommand ncom = new NpgsqlCommand(sql, ncon);
            NpgsqlDataReader dr = ncom.ExecuteReader();


            while (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    //jmlaset = dr.GetInt32(0);
                    total = dr.GetInt32(0);
                    lbjmlstock.Text = total.ToString();
                    //lbjmlstocks.Text = jmlaset.ToString("N0", new CultureInfo("en-US"));

                }
                else
                {
                    total = 0;
                    lbjmlstock.Text = total.ToString();

                    //jmlaset = 0;

                    //lbjmlstocks.Text = jmlaset.ToString("N0", new CultureInfo("en-US"));


                }
            }
        }

        private void popupcostamount_Load(object sender, EventArgs e)
        {
            txtpopid.Text = id;
            txtparentid.Text = parentid;
            jumlahstock();
        }
        public void updateamountearnings()
        {
            NpgsqlConnection scon = new NpgsqlConnection(stringkoneksi.connection);

            string masukdata = "update namespace2.earnings set amount=:amount where earningsid='" + txtpopid.Text + "'";

            NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);
            scom.Parameters.Add(new NpgsqlParameter("@amount", Convert.ToDecimal(this.txtamount.Text)));


            scon.Open();
            scom.ExecuteNonQuery();

            scon.Close();
            this.Hide();
            MessageBox.Show("Silahkan Isi Detail Earnings pada Menu Master ", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public void updateamountstocks2()
        {
            totals = Convert.ToInt32(this.txtamount.Text);
            int hitung = total + totals;

            NpgsqlConnection scon = new NpgsqlConnection(stringkoneksi.connection);

            string masukdata = "update namespace2.amountupdatestocks set amount=:amount";

            NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);
            scom.Parameters.Add(new NpgsqlParameter("@amount", Convert.ToDecimal(hitung)));


            scon.Open();
            scom.ExecuteNonQuery();

            scon.Close();
        }

        public void updateamountstocks()
        {
            NpgsqlConnection scon = new NpgsqlConnection(stringkoneksi.connection);

            string masukdata = "update namespace2.stocks set amount=:amount where stocksid='" + txtpopid.Text + "'";

            NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);
            scom.Parameters.Add(new NpgsqlParameter("@amount", Convert.ToDecimal(this.txtamount.Text)));


            scon.Open();
            scom.ExecuteNonQuery();

            scon.Close();
            this.Hide();
        }

        public void updateassets()
        {
            NpgsqlConnection scon = new NpgsqlConnection(stringkoneksi.connection);

            string masukdata = "update namespace2.assets set amount=:amount where assetsid='" + txtpopid.Text + "'";

            NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);
            scom.Parameters.Add(new NpgsqlParameter("@amount", Convert.ToDecimal(this.txtamount.Text)));


            scon.Open();
            scom.ExecuteNonQuery();

            scon.Close();
            this.Hide();
            MessageBox.Show("Silahkan Isi Detail Asset pada Menu Master ", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void updatekas()
        {
            totals = Convert.ToInt32(this.txtamount.Text);
            int hitung = total + totals;
            NpgsqlConnection scon = new NpgsqlConnection(stringkoneksi.connection);

            string masukdata = "update namespace2.assets set amount=:amount where assetsid=1001";

            NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);
            scom.Parameters.Add(new NpgsqlParameter("@amount", Convert.ToDecimal(hitung)));


            scon.Open();
            scom.ExecuteNonQuery();

            scon.Close();
        }

        public void updateamountdebts()
        {
            NpgsqlConnection scon = new NpgsqlConnection(stringkoneksi.connection);

            string masukdata = "update namespace2.debts set amount=:amount where debtsid='" + txtpopid.Text + "'";

            NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);
            scom.Parameters.Add(new NpgsqlParameter("@amount", Convert.ToDecimal(this.txtamount.Text)));


            scon.Open();
            scom.ExecuteNonQuery();

            scon.Close();
            this.Hide();
            MessageBox.Show("Silahkan Isi Detail Debts pada Menu Master ", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public void updatetopupamountcosts()
        {
            NpgsqlConnection scon = new NpgsqlConnection(stringkoneksi.connection);

            string masukdata = "update namespace2.costs set amount=:amount where costdid='" + txtpopid.Text + "'";

            NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);
            scom.Parameters.Add(new NpgsqlParameter("@amount", Convert.ToDecimal(this.txtamount.Text)));


            scon.Open();
            scom.ExecuteNonQuery();

            scon.Close();
            this.Hide();
            MessageBox.Show("Silahkan Isi Detail Costs pada Menu Master ", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtamount.Text == "")
            {
                MessageBox.Show("Tidak Boleh Kosong");
            }
            else
            {
                if(txtparentid.Text=="1000")
                {
                    updateassets();
                }
                else if(txtparentid.Text=="2000")
                {
                    updateamountdebts();
                }
                else if(txtparentid.Text=="3000")
                {
                    updateamountstocks();
                    updateamountstocks2();
                    updatekas();
                }
                else if(txtparentid.Text=="4000")
                {
                    updatetopupamountcosts();

                }
                else if(txtparentid.Text=="5000")
                {
                    updateamountearnings();
                }
            }
        }

        private void txtamount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
