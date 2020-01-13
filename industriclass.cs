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
    public partial class industriclass : Form
    {
        public industriclass()
        {
            InitializeComponent();
        }

        public void load()
        {
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            NpgsqlCommand ncom = new NpgsqlCommand();
            ncom.Connection = ncon;
            ncom.CommandType = CommandType.Text;
            ncom.CommandText = "select *from namespace2.industri_bisnis";
            DataSet ds = new DataSet();
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
            nda.Fill(ds, "akunting");
            dgbisnis.DataSource = ds;
            dgbisnis.DataMember = "akunting";
            aturdatagrid();
        }


        public void simpanbisnis()
        {
            try
            {
                NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
                string masukdata = "insert into namespace2.typeofbusines values(@typeofbusines_id,@industri_id,@name_of_type)";
                NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
                ncom.Parameters.Add(new NpgsqlParameter("@typeofbusines_id", Convert.ToInt32(this.txtbisnisid.Text)));
                ncom.Parameters.Add(new NpgsqlParameter("@industri_id", Convert.ToInt32(this.txtidindustri.Text)));
                ncom.Parameters.Add(new NpgsqlParameter("@name_of_type", this.txtnamebisnis.Text));

                ncon.Open();
                ncom.ExecuteNonQuery();
                ncon.Close();
                load();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void simpanindustri()
        {
            try
            {
                NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
                string masukdata = "insert into namespace2.industriclassification values(@industri_id,@nameofclass)";
                NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
                ncom.Parameters.Add(new NpgsqlParameter("@industri_id", Convert.ToInt32(this.txtindustriid.Text)));
                ncom.Parameters.Add(new NpgsqlParameter("@nameofclass", this.txtname.Text));
               
                ncon.Open();
                ncom.ExecuteNonQuery();
                ncon.Close();
                load();
                loadcb();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void btnsimpanindustri_Click(object sender, EventArgs e)
        {
            if(txtindustriid.Text==""||txtname.Text=="")
            {
                MessageBox.Show("Data Harus Diisi", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                simpanindustri();
            }
        }

        private void btnsimpanbisns_Click(object sender, EventArgs e)
        {
            if(txtbisnisid.Text==""||txtidindustri.Text==""||txtnamebisnis.Text=="")
            {
                MessageBox.Show("Data Harus Diisi", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                simpanbisnis();
            }
        }

        private void aturdatagrid()
        {
            try
            {
                //mengatur tampilan panjang kolom otomatis menyesuaikan panjang character string data cell
                for (int i = 0; i < dgbisnis.Columns.Count - 1; i++)
                {
                    dgbisnis.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                dgbisnis.Columns[dgbisnis.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                for (int i = 0; i < dgbisnis.Columns.Count; i++)
                {
                    int colw = dgbisnis.Columns[i].Width;
                    dgbisnis.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dgbisnis.Columns[i].Width = colw;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void industriclass_Load(object sender, EventArgs e)
        {
            load();
            loadcb();
        }

        public void cek()
        {
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            ncon.Open();
            //var sql = "select sum(amount)  from costs where extract(year from tanggal) ='" + dttanggal.Value.Year + "' and extract(month from tanggal) ='" + dttanggal.Value.Month + "'";

            var sql = "select industri_id  from namespace2.industriclassification where nameofclass ='" + cbindustriname.Text+"'";
            NpgsqlCommand ncom = new NpgsqlCommand(sql, ncon);
            NpgsqlDataReader dr = ncom.ExecuteReader();


            while (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                   txtidindustri.Text = dr.GetInt32(0).ToString();

                }
                else
                {

                    txtidindustri.Text = "";


                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cbindustriname.Text=="")
            {
                MessageBox.Show("Adna harus set nama industri", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                cek();


            }
        }
    }
}
