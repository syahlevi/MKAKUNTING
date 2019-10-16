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

        public void simpanasset1()
        {
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            string masukdata = "insert into headcompany (idemployee,headname,jobtitle,gender,pass,email,phone) values(:idemployee,:headname,:jobtitle,:gender,:pass,:email,:phone)";
            NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
            ncom.Parameters.Add(new NpgsqlParameter("idemployee", Convert.ToInt32(this.txtidempl.Text)));
            ncom.Parameters.Add(new NpgsqlParameter("headname", txtheadname.Text));
            ncom.Parameters.Add(new NpgsqlParameter("jobtitle", txtjobtitle.Text));
            ncom.Parameters.Add(new NpgsqlParameter("gender", cbgender.Text));
            ncom.Parameters.Add(new NpgsqlParameter("pass", txtpass.Text));
            ncom.Parameters.Add(new NpgsqlParameter("email", txtemail.Text));
            ncom.Parameters.Add(new NpgsqlParameter("phone", Convert.ToDecimal(this.txtphone.Text)));



            ncon.Open();
            ncom.ExecuteNonQuery();
            ncon.Close();

        }

        public void simpanasset2()
        {
           
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            string masukdata = "insert into profilcompany (companyname,address,province,city,country,zipcode,phone,email,companystarts,idemployee) values(:companyname,:address,:province,:city,:country,:zipcode,:phone,:email,:companystarts,:idemployee)";
            NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
            ncom.Parameters.Add(new NpgsqlParameter("companyname", txtcompanyname.Text));
            ncom.Parameters.Add(new NpgsqlParameter("address", txtaddress.Text));
            ncom.Parameters.Add(new NpgsqlParameter("province", txtprovince.Text));
            ncom.Parameters.Add(new NpgsqlParameter("city", txtcity.Text));
            ncom.Parameters.Add(new NpgsqlParameter("country", txtnation.Text));
            ncom.Parameters.Add(new NpgsqlParameter("zipcode", Convert.ToDecimal(this.txtzipcode.Text)));
            ncom.Parameters.Add(new NpgsqlParameter("phone", Convert.ToDecimal(this.txtphonecomp.Text)));
            ncom.Parameters.Add(new NpgsqlParameter("email", txtemailcomp.Text));
            ncom.Parameters.Add(new NpgsqlParameter("companystarts", dtcomp.Value.Date));
            ncom.Parameters.Add(new NpgsqlParameter("idemployee", Convert.ToDecimal(this.txtidempl.Text)));


            ncon.Open();
            ncom.ExecuteNonQuery();
            ncon.Close();

            MessageBox.Show("Data Identitas Perusahaan Telah Berhasil Disimpan", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information);
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtaddress.Text==""||txtcity.Text==""||txtcompanyname.Text==""||txtemail.Text==""||txtemailcomp.Text==""||txtheadname.Text==""||txtidempl.Text==""||txtjobtitle.Text==""||txtnation.Text==""||txtpass.Text==""||txtphone.Text==""||txtphonecomp.Text==""||txtprovince.Text==""||txtzipcode.Text=="")
            {
                MessageBox.Show("Data Identitas Perusahaan Harus Diisi", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else

            {
                simpanasset1();
                simpanasset2();
            }
        }
    }
}
