using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using Npgsql;

namespace AKUNTING
{
    public partial class identitascompany : Form
    {
        public identitascompany()
        {
            InitializeComponent();
        }

        private void identitascompany_Load(object sender, EventArgs e)
        {
            counts();
        }

        public void counts()
        {
          
            //int tot = Convert.ToInt32(this.lbtotop.Text);
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            ncon.Open();
            //var sql = "select sum(amount)  from costs where extract(year from tanggal) ='" + dttanggal.Value.Year + "' and extract(month from tanggal) ='" + dttanggal.Value.Month + "'";

            var sql = "select *from profilcompany join headcompany on profilcompany.idemployee=headcompany.idemployee";
            NpgsqlCommand ncom = new NpgsqlCommand(sql, ncon);
            NpgsqlDataReader dr = ncom.ExecuteReader();


            while (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {


                    txtcompanyid.Text = dr.GetInt32(0).ToString();
                    txtcompanyname.Text = dr.GetString(1);
                    txtaddress.Text = dr.GetString(2);
                    txtprovince.Text = dr.GetString(3);
                    txtcity.Text = dr.GetString(4);
                    txtnation.Text = dr.GetString(5);
                    txtzipcode.Text = dr.GetInt32(6).ToString();
                    txtphonecomp.Text = dr.GetInt32(7).ToString();
                    txtemailcomp.Text = dr.GetString(8);
                    txtdatestart.Text = dr.GetDate(9).ToString();
                    txtidempl.Text = dr.GetString(10);
                    txtheadname.Text = dr.GetString(11);
                    txtjobtitle.Text = dr.GetString(12);
                    txtgender.Text = dr.GetString(13);
                    txtpass.Text = dr.GetString(14);
                    txtemail.Text = dr.GetString(15);
                    txtphone.Text = dr.GetString(16);

                }
                else
                {


                    MessageBox.Show("Anda Belum Mengisi Data Perusahaan","Peringatan",MessageBoxButtons.OK,MessageBoxIcon.Warning);

                }
            }

        }
    }
}
