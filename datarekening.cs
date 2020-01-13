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
    public partial class datarekening : Form
    {
        public datarekening()
        {
            InitializeComponent();
        }

         public void simpan()
        {
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            string masukdata = "insert into namespace2.rekeningbank (norekening,kodebank,namabank,sk_surat_no) values(:norekening,:kodebank,:namabank,:sk_surat_no)";
            NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
            ncom.Parameters.Add(new NpgsqlParameter("norekening", txtrekening.Text));
            ncom.Parameters.Add(new NpgsqlParameter("kodebank", Convert.ToInt32(this.cbkodebank.Text)));
            ncom.Parameters.Add(new NpgsqlParameter("namabank", txtnamabank.Text));
            ncom.Parameters.Add(new NpgsqlParameter("sk_surat_no", txtsk.Text));
            
            ncon.Open();
            ncom.ExecuteNonQuery();
            ncon.Close();

            MessageBox.Show("Data Identitas Perusahaan Telah Berhasil Disimpan", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information);
            load();
        }
        private void aturdatagrid()
        {
            try
            {
                //mengatur tampilan panjang kolom otomatis menyesuaikan panjang character string data cell
                for (int i = 0; i < dataGridView1.Columns.Count - 1; i++)
                {
                    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    int colw = dataGridView1.Columns[i].Width;
                    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    dataGridView1.Columns[i].Width = colw;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void load()
        {
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            NpgsqlCommand ncom = new NpgsqlCommand();
            ncom.Connection = ncon;
            ncom.CommandType = CommandType.Text;
            ncom.CommandText = "select*from namespace2.rekeningbank";
            DataSet ds = new DataSet();
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
            nda.Fill(ds, "akunting");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "akunting";

            aturdatagrid();

        }

        public void delete()
        {
            NpgsqlConnection scon = new NpgsqlConnection(stringkoneksi.connection);

            string masukdata = "delete from namespace2.rekeningbank where norekening=:norekening";

            NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);
            scom.Parameters.Add(new NpgsqlParameter("norekening", txtrekening.Text));


            scon.Open();
            scom.ExecuteNonQuery();

            scon.Close();
            load();
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtnamabank.Text == "" || cbkodebank.Text == ""||txtrekening.Text=="")
            {
                MessageBox.Show("Harus Diisi", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else

            {
                simpan();
            }
        }

        public void loadcb()
        {
            NpgsqlConnection nocn = new NpgsqlConnection(stringkoneksi.connection);
            nocn.Open();
            NpgsqlCommand ncom = new NpgsqlCommand("select code from namespace2.bank", nocn);
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
            DataTable dt = new DataTable();
            nda.Fill(dt);
            //DataRow dr = dt.NewRow();
            //dr.ItemArray = new object[] { 0, "--Pilih Parent--" };
            //dt.Rows.InsertAt(dr, 0);
            cbkodebank.ValueMember = "code";
            cbkodebank.DisplayMember = "code";
            cbkodebank.DataSource = dt;

            nocn.Close();
        }

        private void datarekening_Load(object sender, EventArgs e)
        {
            load();
            loadcb();
            ceksk();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataGridView1.Columns[0].Index && e.RowIndex >= 0)
                {
                    //txtbca.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtrekening.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                   

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtnamabank.Text == "" || cbkodebank.Text == "" || txtrekening.Text == "")
            {
                MessageBox.Show("Isi Data yang akan dihapus", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                delete();
            }
        }

        public void ceksk()
        {
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            ncon.Open();
            //var sql = "select sum(amount)  from costs where extract(year from tanggal) ='" + dttanggal.Value.Year + "' and extract(month from tanggal) ='" + dttanggal.Value.Month + "'";

            var sql = "select sk_surat_no from namespace2.profilcompany";
            NpgsqlCommand ncom = new NpgsqlCommand(sql, ncon);
            NpgsqlDataReader dr = ncom.ExecuteReader();


            while (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    txtsk.Text = dr.GetString(0);
                }

                else
                {
                    txtnamabank.Text = "";

                }
            }
        }

        public void ceek()
        {
            //int tot = Convert.ToInt32(this.lbtotop.Text);
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            ncon.Open();
            //var sql = "select sum(amount)  from costs where extract(year from tanggal) ='" + dttanggal.Value.Year + "' and extract(month from tanggal) ='" + dttanggal.Value.Month + "'";

            var sql = "select * from namespace2.bank where code='" + cbkodebank.Text+"'";
            NpgsqlCommand ncom = new NpgsqlCommand(sql, ncon);
            NpgsqlDataReader dr = ncom.ExecuteReader();


            while (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    txtnamabank.Text = dr.GetString(0);
                }

                else
                {
                    txtnamabank.Text = "";

                }
            }
        }

        private void cbkodebank_SelectedIndexChanged(object sender, EventArgs e)
        {
            ceek();
        }
    }
}
