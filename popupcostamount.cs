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
        private void popupcostamount_Load(object sender, EventArgs e)
        {
            txtpopid.Text = id;
            txtparentid.Text = parentid;
        }
        public void updateamountearnings()
        {
            NpgsqlConnection scon = new NpgsqlConnection(stringkoneksi.connection);

            string masukdata = "update earnings set amount=:amount where account_id='" + txtpopid.Text + "'";

            NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);
            scom.Parameters.Add(new NpgsqlParameter("@amount", Convert.ToDecimal(this.txtamount.Text)));


            scon.Open();
            scom.ExecuteNonQuery();

            scon.Close();
            this.Hide();
        }

        public void updateamountstocks()
        {
            NpgsqlConnection scon = new NpgsqlConnection(stringkoneksi.connection);

            string masukdata = "update stocks set amount=:amount where account_id='" + txtpopid.Text + "'";

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

            string masukdata = "update assets set amount=:amount where account_id='" + txtpopid.Text + "'";

            NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);
            scom.Parameters.Add(new NpgsqlParameter("@amount", Convert.ToDecimal(this.txtamount.Text)));


            scon.Open();
            scom.ExecuteNonQuery();

            scon.Close();
            this.Hide();
        }

        public void updateamountdebts()
        {
            NpgsqlConnection scon = new NpgsqlConnection(stringkoneksi.connection);

            string masukdata = "update debts set amount=:amount where account_id='" + txtpopid.Text + "'";

            NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);
            scom.Parameters.Add(new NpgsqlParameter("@amount", Convert.ToDecimal(this.txtamount.Text)));


            scon.Open();
            scom.ExecuteNonQuery();

            scon.Close();
            this.Hide();
        }

        public void updatetopupamountcosts()
        {
            NpgsqlConnection scon = new NpgsqlConnection(stringkoneksi.connection);

            string masukdata = "update costs set amount=:amount where account_id='" + txtpopid.Text + "'";

            NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);
            scom.Parameters.Add(new NpgsqlParameter("@amount", Convert.ToDecimal(this.txtamount.Text)));


            scon.Open();
            scom.ExecuteNonQuery();

            scon.Close();
            this.Hide();


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
