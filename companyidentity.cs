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
    public partial class companyidentity : Form
    {
        public companyidentity()
        {
            InitializeComponent();
        }
        public int industriid { get; set; }
    
       

        public void simpanasset2()
        {
           
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            string masukdata = "insert into profilcompany (sk_surat_no,companyname,address,province,city,nation,zipcode,phone,email,companystart,idemployee, name_of_type) values(:sk_surat_no,:companyname,:address,:province,:city,:nation,:zipcode,:phone,:email,:companystart,:idemployee,:name_of_type)";
            NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
            ncom.Parameters.Add(new NpgsqlParameter("sk_surat_no", txtsuratno.Text));

            ncom.Parameters.Add(new NpgsqlParameter("companyname", txtcompanyname.Text));
            ncom.Parameters.Add(new NpgsqlParameter("address", txtaddress.Text));
            ncom.Parameters.Add(new NpgsqlParameter("province", txtprovince.Text));
            ncom.Parameters.Add(new NpgsqlParameter("city", txtcity.Text));
            ncom.Parameters.Add(new NpgsqlParameter("nation", txtnation.Text));
            ncom.Parameters.Add(new NpgsqlParameter("zipcode", Convert.ToDecimal(this.txtzipcode.Text)));
            ncom.Parameters.Add(new NpgsqlParameter("phone", txtphonecomp.Text));
            ncom.Parameters.Add(new NpgsqlParameter("email", txtemailcomp.Text));
            ncom.Parameters.Add(new NpgsqlParameter("companystart", dtcomp.Value.Date));
            ncom.Parameters.Add(new NpgsqlParameter("idemployee", txtid.Text));
            ncom.Parameters.Add(new NpgsqlParameter("name_of_type", comboBox2.Text));


            ncon.Open();
            ncom.ExecuteNonQuery();
            ncon.Close();

            MessageBox.Show("Data Identitas Perusahaan Telah Berhasil Disimpan Silahkan Restart Accountant Software", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
            Form1 f = new Form1();
            f.Enabled = true;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtaddress.Text==""||txtcity.Text==""||txtcompanyname.Text==""||txtemailcomp.Text==""|| txtnation.Text==""||txtphonecomp.Text==""||txtprovince.Text==""||txtzipcode.Text=="")
            {
                MessageBox.Show("Data Identitas Perusahaan Harus Diisi", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else

            {
               
                simpanasset2();
            }
        }


        public void loaddir()
        {
            string rolesid = "5000";
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            ncon.Open();
            //var sql = "select sum(amount)  from costs where extract(year from tanggal) ='" + dttanggal.Value.Year + "' and extract(month from tanggal) ='" + dttanggal.Value.Month + "'";

            var sql = "select staffid, namastaff from staff where rolesid='" + rolesid + "'";
                NpgsqlCommand ncom = new NpgsqlCommand(sql, ncon);
            NpgsqlDataReader dr = ncom.ExecuteReader();


            while (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    txtdirekturname.Text = dr.GetString(1);
                    txtid.Text = dr.GetString(0);

                }
                else
                {

                    txtid.Text = "";
                    txtdirekturname.Text = "";


                }
            }
        }
        private void companyidentity_Load(object sender, EventArgs e)
        {
            loaddir();
            loadcb();
           
        }
        public void loadcb()
        {
            NpgsqlConnection nocn = new NpgsqlConnection(stringkoneksi.connection);
            nocn.Open();
            NpgsqlCommand ncom = new NpgsqlCommand("select nameofclass from namespace2.industriclassification", nocn);
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
            DataTable dt = new DataTable();
            nda.Fill(dt);
            //DataRow dr = dt.NewRow();
            //dr.ItemArray = new object[] { 0, "--Pilih Parent--" };
            //dt.Rows.InsertAt(dr, 0);
            cbindustriname.ValueMember = "nameofclass";
            cbindustriname.DisplayMember = "nameofclass";
            cbindustriname.DataSource = dt;

            nocn.Close();
        }

        public void cek2()
        {
            NpgsqlConnection nocn = new NpgsqlConnection(stringkoneksi.connection);
            nocn.Open();
            NpgsqlCommand ncom = new NpgsqlCommand("select name_of_type from namespace2.industri_bisnis  where nameofclass='" + cbindustriname.Text+"'", nocn);
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
            DataTable dt = new DataTable();
            nda.Fill(dt);
            //DataRow dr = dt.NewRow();
            //dr.ItemArray = new object[] { 0, "--Pilih Parent--" };
            //dt.Rows.InsertAt(dr, 0);
            comboBox2.ValueMember = "name_of_type";
            comboBox2.DisplayMember = "name_of_type";
            comboBox2.DataSource = dt;

            nocn.Close();
        }

       

        private void cbindustriname_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cek();
            cek2();
        }
    }
}
