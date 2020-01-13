using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using Npgsql;
using System.Globalization;

namespace AKUNTING
{
    public partial class costs : Form
    {
        public costs()
        {
            InitializeComponent();
        }

      
        public int jmlaset { get; set; }
        public string title { get; set; }
        public string id { get; set; }
        public void loaddata()
        {

            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            NpgsqlCommand ncom = new NpgsqlCommand();
            ncom.Connection = ncon;
            ncom.CommandType = CommandType.Text;
            ncom.CommandText = "select*from namespace2.account_costs ";
            DataSet ds = new DataSet();
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
            nda.Fill(ds, "akunting");
            gridaccounts.DataSource = ds;
            gridaccounts.DataMember = "akunting";
            gridaccounts.Columns["amount"].DefaultCellStyle.Format = "N2";

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

        private void costs_Load(object sender, EventArgs e)
        {
           
            DataGridViewLinkColumn lnk = new DataGridViewLinkColumn();
            DataGridViewLinkColumn lnk2 = new DataGridViewLinkColumn();
            gridaccounts.Columns.Add(lnk2);
            lnk2.Text = "Ubah Amount";
            lnk2.UseColumnTextForLinkValue = true;
            gridaccounts.Columns.Add(lnk);
            //lnk.HeaderText = "BUAT SURAT PEMBERITAHUAN";
            lnk.Text = "Rincian";

            lnk.UseColumnTextForLinkValue = true;
          
            counts();
            loaddata();
        }

        public void counts()
        {
            //int a = DateTime.Now.Year;
            //int m = DateTime.ParseExact("Oktober", "MMMM", CultureInfo.CurrentCulture).Month;
            //int tot = Convert.ToInt32(this.lbtotop.Text);
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            ncon.Open();
            //var sql = "select sum(amount)  from costs where extract(year from tanggal) ='" + dttanggal.Value.Year + "' and extract(month from tanggal) ='" + dttanggal.Value.Month + "'";

            var sql = "select sum(amount)  from namespace2.account_costs ";
            NpgsqlCommand ncom = new NpgsqlCommand(sql, ncon);
            NpgsqlDataReader dr = ncom.ExecuteReader();


            while (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    jmlaset = dr.GetInt32(0);
                    lbjmlstocks.Text = jmlaset.ToString("N0", new CultureInfo("en-US"));

                }
                else
                {

                    jmlaset = 0;

                    lbjmlstocks.Text = jmlaset.ToString("N0", new CultureInfo("en-US"));


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

        private void button1_Click(object sender, EventArgs e)
        {
            loaddata();
            counts();
        }

        private void gridaccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gridaccounts.Columns[1].Index && e.RowIndex >= 0)
            {
                title = "costs";
                id = gridaccounts.Rows[e.RowIndex].Cells[0].Value.ToString();
                rincian ri = new rincian();
                ri.title = title;
                ri.MdiParent = this.MdiParent;
                ri.Show();
            }
        }
    }
}
