using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Npgsql;

namespace AKUNTING
{
    public partial class rincian : Form
    {
        public rincian()
        {
            InitializeComponent();
        }

     
        public int jmlaset { get; set; }
        public string title { get; set; }
        public string id { get; set; }
        public string date { get; set; }
        public string amount { get; set; }
        public string documentno { get; set; }
        public string stocksid1 { get; set; }
        public string keterangan { get; set; }
        public byte[] picture { get; set; }

        private void rincian_Load(object sender, EventArgs e)
        {
            lbtitle.Text = title;
            id = id;
            DataGridViewLinkColumn lnk = new DataGridViewLinkColumn();
            gridaccounts.Columns.Add(lnk);
            //lnk.HeaderText = "BUAT SURAT PEMBERITAHUAN";
            lnk.Text = "Detail";

            lnk.UseColumnTextForLinkValue = true;
            if (title=="costs")
            {
                loaddetailcosts();
            }
            if(title=="debts")
            {
                loaddetaildebts();
            }
            if(title=="assets")
            {
                loaddetailassets();
            }
            if(title=="earnings")
            {
                loaddetailearnings();
            }
            if(title=="Stocks")
            {
                loaddetailstocks();
            }
           
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
                    if (gridaccounts.Columns[i] is DataGridViewImageColumn)
                    {
                        ((DataGridViewImageColumn)gridaccounts.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        public void loaddetailstocks()
        {
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            NpgsqlCommand ncom = new NpgsqlCommand();
            ncom.Connection = ncon;
            ncom.CommandType = CommandType.Text;
            ncom.CommandText = "select*from namespace2.stocks join namespace2.detailstocks on namespace2.stocks.stocksid=namespace2.detailstocks.stocksid";
            DataSet ds = new DataSet();
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
            nda.Fill(ds, "akunting");
            gridaccounts.DataSource = ds;
            gridaccounts.DataMember = "akunting";
            aturdatagrid();

        }

        public void loaddetailcosts()
        {
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            NpgsqlCommand ncom = new NpgsqlCommand();
            ncom.Connection = ncon;
            ncom.CommandType = CommandType.Text;
            ncom.CommandText = "select*from namespace2.costs join namespace2.detailcosts on namespace2.costs.costdid=namespace2.detailcosts.costdid";
            DataSet ds = new DataSet();
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
            nda.Fill(ds, "akunting");
            gridaccounts.DataSource = ds;
            gridaccounts.DataMember = "akunting";
            aturdatagrid();

        }


        public void loaddetaildebts()
        {
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            NpgsqlCommand ncom = new NpgsqlCommand();
            ncom.Connection = ncon;
            ncom.CommandType = CommandType.Text;
            ncom.CommandText = "select*from namespace2.debts join namespace2.detaildebts on namespace2.debts.debtsid=namespace2.detaildebts.debtsid";
            DataSet ds = new DataSet();
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
            nda.Fill(ds, "akunting");
            gridaccounts.DataSource = ds;
            gridaccounts.DataMember = "akunting";
            aturdatagrid();

        }


        public void loaddetailassets()
        {
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            NpgsqlCommand ncom = new NpgsqlCommand();
            ncom.Connection = ncon;
            ncom.CommandType = CommandType.Text;
            ncom.CommandText = "select*from namespace2.assets join namespace2.detailassets on namespace2.assets.assetsid=namespace2.detailassets.assetsid";
            DataSet ds = new DataSet();
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
            nda.Fill(ds, "akunting");
            gridaccounts.DataSource = ds;
            gridaccounts.DataMember = "akunting";
            aturdatagrid();

        }


        public void loaddetailearnings()
        {
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            NpgsqlCommand ncom = new NpgsqlCommand();
            ncom.Connection = ncon;
            ncom.CommandType = CommandType.Text;
            ncom.CommandText = "select*from namespace2.earnings join namespace2.detailearnings on namespace2.earnings.earningsid=namespace2.detailearnings.earningsid";
            DataSet ds = new DataSet();
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
            nda.Fill(ds, "akunting");
            gridaccounts.DataSource = ds;
            gridaccounts.DataMember = "akunting";
            aturdatagrid();

        }

        private void gridaccounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gridaccounts.Columns[0].Index && e.RowIndex >= 0)
            {
               
                id = gridaccounts.Rows[e.RowIndex].Cells[1].Value.ToString();
                amount= gridaccounts.Rows[e.RowIndex].Cells[2].Value.ToString();
                date= gridaccounts.Rows[e.RowIndex].Cells[3].Value.ToString();
                documentno = gridaccounts.Rows[e.RowIndex].Cells[4].Value.ToString();
                stocksid1 = gridaccounts.Rows[e.RowIndex].Cells[5].Value.ToString();
                keterangan= gridaccounts.Rows[e.RowIndex].Cells[6].Value.ToString();
                picture = (byte[])gridaccounts.Rows[e.RowIndex].Cells[8].Value;
                detailrincian ri = new detailrincian();
                ri.id = id;
                ri.amount = amount;
                ri.date = date;
                ri.documentno = documentno;
                ri.stocksid1 = stocksid1;
                ri.keterangan = keterangan;
                ri.MdiParent = this.MdiParent;
                ri.Show();
            }
        }
    }
}
