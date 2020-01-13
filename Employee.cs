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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            loaddata();
            loadcb();
            groupBox1.Enabled = false;
            txtcreatedon.Text = DateTime.Now.Date.ToString("dd-MM-yyyy");
            txtcreatedby.Text = "ADMIN";

            cbrolename.SelectedValue = "";
        }

        public void loadcb()
        {
            NpgsqlConnection nocn = new NpgsqlConnection(stringkoneksi.connection);
            nocn.Open();
            NpgsqlCommand ncom = new NpgsqlCommand("select rolenames from namespace2.roles", nocn);
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
            DataTable dt = new DataTable();
            nda.Fill(dt);
            //DataRow dr = dt.NewRow();
            //dr.ItemArray = new object[] { 0, "--Pilih Parent--" };
            //dt.Rows.InsertAt(dr, 0);
            cbrolename.ValueMember = "rolenames";
            cbrolename.DisplayMember = "rolenames";
            cbrolename.DataSource = dt;
          
            nocn.Close();
        }

        public void loaddata()
        {

            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            NpgsqlCommand ncom = new NpgsqlCommand();
            ncom.Connection = ncon;
            ncom.CommandType = CommandType.Text;
            ncom.CommandText = "select * from namespace2.staffviews";
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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            gbdata.Dock = DockStyle.Fill;
            gbdata.BringToFront();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            gbdata.Dock = DockStyle.None;
            gbdata.SendToBack();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            loaddata();
        }

        public void getcb()
        {
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            ncon.Open();
            //var sql = "select sum(amount)  from costs where extract(year from tanggal) ='" + dttanggal.Value.Year + "' and extract(month from tanggal) ='" + dttanggal.Value.Month + "'";

            var sql = "select rolesid from namespace2.roles where rolenames='" + cbrolename.Text+"'";
            NpgsqlCommand ncom = new NpgsqlCommand(sql, ncon);
            NpgsqlDataReader dr = ncom.ExecuteReader();


            while (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    txtrolesid.Text = dr.GetString(0);

                }
                else
                {

                    txtrolesid.Text = "";


                }
            }
        }

        public void simpanstaff()
        { DateTime dd = DateTime.Now.Date;
            try
            {
                NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
                string masukdata = "insert into namespace2.staff values(@staffid,@namastaff,@passwords,@createdby,@createdon,@rolesid)";
                NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
                ncom.Parameters.Add(new NpgsqlParameter("@staffid", txtstaffid.Text));
                ncom.Parameters.Add(new NpgsqlParameter("@namastaff", txtstaffnamastaff.Text));
                ncom.Parameters.Add(new NpgsqlParameter("@passwords", txtpassword.Text));
                ncom.Parameters.Add(new NpgsqlParameter("@createdby", txtcreatedby.Text));
                ncom.Parameters.Add(new NpgsqlParameter("@createdon", dd));
                ncom.Parameters.Add(new NpgsqlParameter("@rolesid", txtrolesid.Text));


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

        public void simpanheadcomp()
        {
            
            try
            {
                NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
                string masukdata = "insert into namespace2.headcompany values(@idemployee,@staffid,@email,@kontak)";
                NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
                ncom.Parameters.Add(new NpgsqlParameter("@idemployee", txtstaffid.Text));
                ncom.Parameters.Add(new NpgsqlParameter("@staffid", txtstaffid.Text));
                ncom.Parameters.Add(new NpgsqlParameter("@email", txtemail.Text));
                ncom.Parameters.Add(new NpgsqlParameter("@kontak", txtphone.Text));
           

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

        private void button2_Click(object sender, EventArgs e)
        {
            if (cbrolename.Text == "Direktur")
            {
                groupBox1.Enabled = true;

            }
            else
            {
                groupBox1.Enabled = false;
            }
            getcb();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cbrolename.Text=="Direktur")
            {
                if(txtemail.Text==""||txtpassword.Text==""||txtphone.Text==""||txtrolesid.Text==""||txtstaffid.Text==""||txtstaffnamastaff.Text=="")
                {
                    MessageBox.Show("Data Harus Diisi", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    simpanstaff();
                    simpanheadcomp();
                   
                }
            }
            else
            {
                if ( txtpassword.Text == "" || txtrolesid.Text == "" || txtstaffid.Text == "" || txtstaffnamastaff.Text == "")
                {
                    MessageBox.Show("Data Harus Diisi", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    simpanstaff();
                }
            }
        }
    }
}
