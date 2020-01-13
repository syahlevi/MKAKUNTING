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
    public partial class ConfigDate : Form
    {
        public ConfigDate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtbulan.Text==""|| txttahun.Text=="")
            {
                MessageBox.Show("Data Harus Diisi", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                simpan();
            }
        }

        public void simpan()
        {
           
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            string masukdata = "insert into namespace2.configdate values(@bulan,@tahun)";
            NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
            ncom.Parameters.Add(new NpgsqlParameter("@bulan", txtbulan.Text));
            ncom.Parameters.Add(new NpgsqlParameter("@tahun", Convert.ToInt32(this.txttahun.Text)));
    

            ncon.Open();
            ncom.ExecuteNonQuery();
            ncon.Close();

            MessageBox.Show("Data ConfigDate Berhasil Disimpan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loaddata();
        }

        private void ConfigDate_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        public void loaddata()
        {

            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            NpgsqlCommand ncom = new NpgsqlCommand();
            ncom.Connection = ncon;
            ncom.CommandType = CommandType.Text;
            ncom.CommandText = "select * from namespace2.configdate";
            DataSet ds = new DataSet();
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
            nda.Fill(ds, "dbakuntings");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "dbakuntings";
            aturdatagrid();




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
    }
}
