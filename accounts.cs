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
    public partial class accounts : Form
    {
        public accounts()
        {
            InitializeComponent();
        }

        public  int conf { get; set; }
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

        private void accounts_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Anda Harus Menginput Stocks Terlebih Dahulu Sebelum Mengisi Amount Account Yang Lain","Peringatan",  MessageBoxButtons.OK, MessageBoxIcon.Information);
            cbparent.Enabled = false;
            txtnamaakun.Enabled = false;
            txtparentid.Enabled = false;
            loaddata();
        }

        public void simpanasset2()
        {
            decimal d = 0;
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            string masukdata = "insert into assets (account_id,amount,tanggal) values(:account_id,:amount,:tanggal)";
            NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
            ncom.Parameters.Add(new NpgsqlParameter("account_id", Convert.ToDecimal(this.txtakunid.Text)));
            ncom.Parameters.Add(new NpgsqlParameter("amount", d));
            ncom.Parameters.Add(new NpgsqlParameter("tanggal", DateTime.Now.Date));

            ncon.Open();
            ncom.ExecuteNonQuery();
            ncon.Close();
            popupcostamount pp = new popupcostamount();
            pp.id = txtakunid.Text;
            if (conf == 0)
            {
                pp.parentid = txtakunid.Text;
            }
            else if (conf == 1)
            {
                pp.parentid = cbparent.Text;

            }
            pp.ShowDialog();
        }

        public void cekstocks()
        {
            NpgsqlConnection ncon2 = new NpgsqlConnection(stringkoneksi.connection);
            ncon2.Open();
            var sql = "select amount from stocks";
            NpgsqlCommand ncom2 = new NpgsqlCommand(sql, ncon2);
            NpgsqlDataReader nred2 = ncom2.ExecuteReader();
            while (nred2.Read())
            {
                if (!nred2.IsDBNull(0))
                {
                    int a = nred2.GetInt32(0);
                    txtakunid.Text = a.ToString();
                    txtakunid.Text = "4000";
                    MessageBox.Show("4000");

                }
                else
                {

                    int aa = nred2.GetInt32(0);
                    txtakunid.Text = "4000";
                    MessageBox.Show("4000");

                }
                ncon2.Close();
            }
        }
        

        public void simpanstocks()
        {
            decimal d = 0;
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            string masukdata = "insert into stocks (account_id,amount,tanggal) values(:account_id,:amount,:tanggal)";
            NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
            ncom.Parameters.Add(new NpgsqlParameter("account_id", Convert.ToDecimal(this.txtakunid.Text)));
            ncom.Parameters.Add(new NpgsqlParameter("amount", d));
            ncom.Parameters.Add(new NpgsqlParameter("tanggal", DateTime.Now.Date));

            ncon.Open();
            ncom.ExecuteNonQuery();
            ncon.Close();
            popupcostamount pp = new popupcostamount();
            pp.id = txtakunid.Text;
            if (conf == 0)
            {
                pp.parentid = txtakunid.Text;
            }
            else if (conf == 1)
            {
                pp.parentid = cbparent.Text;

            }
            pp.ShowDialog();
        }

        public void simpancost()
        {
            DateTime ds = DateTime.Parse("12/03/1950");
            decimal d = 0;
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            string masukdata = "insert into costs (account_id,amount,tanggal) values(:account_id,:amount,:tanggal)";
            NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
            ncom.Parameters.Add(new NpgsqlParameter("account_id", Convert.ToDecimal(this.txtakunid.Text)));
            ncom.Parameters.Add(new NpgsqlParameter("amount", d));
            ncom.Parameters.Add(new NpgsqlParameter("tanggal",DateTime.Now.Date));

            ncon.Open();
            ncom.ExecuteNonQuery();
            ncon.Close();

            popupcostamount pp = new popupcostamount();
            pp.id = txtakunid.Text;
            if(conf==0)
            {
                pp.parentid = txtakunid.Text;
            }
            else if(conf==1)
            {
                pp.parentid = cbparent.Text;

            }
            pp.ShowDialog();
        }

        public void simpandebts()
        {
            DateTime ds = DateTime.Parse("12/03/1950");
            decimal d = 0;
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            string masukdata = "insert into debts (account_id,amount,tanggal) values(:account_id,:amount,:tanggal)";
            NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
            ncom.Parameters.Add(new NpgsqlParameter("account_id", Convert.ToDecimal(this.txtakunid.Text)));
            ncom.Parameters.Add(new NpgsqlParameter("amount", d));
            ncom.Parameters.Add(new NpgsqlParameter("tanggal", DateTime.Now.Date));

            ncon.Open();
            ncom.ExecuteNonQuery();
            ncon.Close();
            popupcostamount pp = new popupcostamount();
            pp.id = txtakunid.Text;
            if (conf == 0)
            {
                pp.parentid = txtakunid.Text;
            }
            else if (conf == 1)
            {
                pp.parentid = cbparent.Text;

            }
            pp.ShowDialog();
        }


        public void simpanearnings()
        {
            DateTime ds = DateTime.Parse("12/03/1950");
            decimal d = 0;
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            string masukdata = "insert into earnings (account_id,amount,tanggal) values(:account_id,:amount,:tanggal)";
            NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
            ncom.Parameters.Add(new NpgsqlParameter("account_id", Convert.ToDecimal(this.txtakunid.Text)));
            ncom.Parameters.Add(new NpgsqlParameter("amount", d));
            ncom.Parameters.Add(new NpgsqlParameter("tanggal", DateTime.Now.Date));

            ncon.Open();
            ncom.ExecuteNonQuery();
            ncon.Close();
            popupcostamount pp = new popupcostamount();
            pp.id = txtakunid.Text;
            if (conf == 0)
            {
                pp.parentid = txtakunid.Text;
            }
            else if (conf == 1)
            {
                pp.parentid = cbparent.Text;

            }
            pp.ShowDialog();
        }




        public void simpanasset()
        {
            if (txtakunid.Text == "" && conf == -1)
            {
                MessageBox.Show("Diisi Dong");
            }
            else
            {
                if (cbparent.Text == "1000" ||txtparentid.Text=="1000")
                {

                    simpanasset2();
                }
                if (cbparent.Text == "2000" || txtparentid.Text == "2000")
                {
                    simpandebts();
                }
                if (cbparent.Text == "3000" || txtparentid.Text == "3000")
                {
                    simpanstocks();
                }
                if (cbparent.Text == "4000" || txtparentid.Text == "4000")
                {
                    simpancost();
                }
                if(cbparent.Text=="5000" || txtparentid.Text == "5000")
                {
                    simpanearnings();

                }
            }
        }

        public void simpandata()
        {
            try
            {
                NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
                string masukdata = "insert into accounts values(@id,@name,@parent_id,@isparentaccount)";
                NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
                ncom.Parameters.Add(new NpgsqlParameter("@id", Convert.ToDecimal(this.txtakunid.Text)));
                ncom.Parameters.Add(new NpgsqlParameter("@name", txtnamaakun.Text));
                if(conf==1)
                {
                    ncom.Parameters.Add(new NpgsqlParameter("@parent_id", Convert.ToDecimal(cbparent.Text)));

                }
                else if(conf==0)
                {
                    ncom.Parameters.Add(new NpgsqlParameter("@parent_id", Convert.ToDecimal(this.txtparentid.Text)));

                }
                ncom.Parameters.Add(new NpgsqlParameter("@isparentaccount", conf));

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
            ncom.CommandText = "select*from accounts order by id asc";
            DataSet ds = new DataSet();
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
            nda.Fill(ds, "akunting");
            gridaccounts.DataSource = ds;
            gridaccounts.DataMember = "akunting";
            aturdatagrid();
         

           

        }

        public void loadtopupamountcost()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtakunid.Text == "" || conf == -1)
            {
                MessageBox.Show("Diisi Dong");
            }
            else
            {
                if (conf == 0)
                {
                    simpandata();
                }
                if (conf == 1)
                {
                    counts();
                    //simpanasset();
                }
              
                //simpanstocks();
                //if(conf==0)
                //{
                //    simpandata();
                //}
                //if (conf==1)
                //{
                //    simpanasset();
                //}
               
              

            }
        }
        public void update()
        {
             NpgsqlConnection scon = new NpgsqlConnection(stringkoneksi.connection);

            string masukdata = "update accounts set name=:name where id='" + txtakunid.Text+ "'";

            NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);
            scom.Parameters.Add(new  NpgsqlParameter("name", txtnamaakun.Text));


            scon.Open();
            scom.ExecuteNonQuery();

            scon.Close();
            loaddata();


        }

        public void counts()
        {
            int a = DateTime.Now.Year;
            int m = DateTime.ParseExact("Oktober", "MMMM", CultureInfo.CurrentCulture).Month;
            //int tot = Convert.ToInt32(this.lbtotop.Text);
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            ncon.Open();
            //var sql = "select sum(amount)  from costs where extract(year from tanggal) ='" + dttanggal.Value.Year + "' and extract(month from tanggal) ='" + dttanggal.Value.Month + "'";

            var sql = "select sum(amount)  from stocks where extract(year from tanggal) ='" + a+ "' and extract(month from tanggal) ='" + m + "'";
            NpgsqlCommand ncom = new NpgsqlCommand(sql, ncon);
            NpgsqlDataReader dr = ncom.ExecuteReader();


            while (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                   int cost = dr.GetInt32(0);
                    MessageBox.Show("Jumlah Stocks Perusahaan Adalah :" + cost);
                    simpandata();
                    simpanasset();

                }
                else
                {
                   if(cbparent.Text=="3000")
                    {
                        simpandata();
                        simpanstocks();
                    }
                   else
                    {
                        MessageBox.Show("Jumlah Stocks Perusahaan : 0, Anda Perlu Menambah Stocks Terlebih Dahulu ( Parent ID : 4000)");

                    }



                }
            }

        }

        private void gridaccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == gridaccounts.Columns[0].Index && e.RowIndex >= 0)
                {
                    txtakunid.Text = gridaccounts.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtnamaakun.Text = gridaccounts.Rows[e.RowIndex].Cells[1].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //public void updatetopupamountcosts()
        //{
        //    NpgsqlConnection scon = new NpgsqlConnection(stringkoneksi.connection);

        //    string masukdata = "update costs set amount=:amount where id='" + txtakunid.Text + "'";

        //    NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);
        //    scom.Parameters.Add(new NpgsqlParameter("name", txtnamaakun.Text));


        //    scon.Open();
        //    scom.ExecuteNonQuery();

        //    scon.Close();
        //    loaddata();


        //}


        private void button2_Click(object sender, EventArgs e)
        {
            if(txtnamaakun.Text=="" || txtakunid.Text=="")
            {
                MessageBox.Show("Anda Harus Klik Datagrid Terlebih Dahulu Untuk Retrieve Data");
            }
            else
            {
                update();
            }
        }

        public void loadbind()
        {
            cbparent.Enabled = true;
            NpgsqlConnection nocn = new NpgsqlConnection(stringkoneksi.connection);
            nocn.Open();
            NpgsqlCommand ncom = new NpgsqlCommand("select id from accounts where isparentaccount=0", nocn);
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
            DataTable dt = new DataTable();
            nda.Fill(dt);
            //DataRow dr = dt.NewRow();
            //dr.ItemArray = new object[] { 0, "--Pilih Parent--" };
            //dt.Rows.InsertAt(dr, 0);
            cbparent.ValueMember = "id";
            cbparent.DisplayMember = "id";
            cbparent.DataSource = dt;
            nocn.Close();
        }

        public void konfig()
        {
            if(rdchildacc.Checked==true)
            {
                conf = 1;
                txtnamaakun.Enabled = true;
                loadbind();
            }
            else if(rdparentacc.Checked==true)
            {
                conf = 0;
                txtnamaakun.Enabled = true;
                txtparentid.Text = txtakunid.Text;
                cbparent.Enabled = false ;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtakunid.Text == "" && rdchildacc.Checked == false && rdparentacc.Checked == false)
            {
                MessageBox.Show("Harus diisi dong");
            }
            else
            {
                konfig();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conf = -1;
            cbparent.Enabled = false;
            txtakunid.Text = "";
            txtparentid.Text = "";
            txtnamaakun.Enabled = false;
            txtparentid.Enabled = false;
        }

        private void txtakunid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            counts();
        }

        private void rdparentacc_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
