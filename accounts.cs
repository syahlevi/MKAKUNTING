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
using  System.Globalization;


using OfficeExcel = Microsoft.Office.Interop.Excel;

using System.IO;

namespace AKUNTING
{
    public partial class accounts : Form
    {
        public accounts()
        {
            InitializeComponent();
        }
        DataSet ds1;

        public int conf { get; set; }
        public string codename { get; set; }

        private void ExportDataSetToExcelpenerimabeasiswa(DataSet ds, string strPath)
        {
            int inHeaderLength = 3, inColumn = 0, inRow = 0;

            try
            {


                System.Reflection.Missing Default = System.Reflection.Missing.Value;
                //Create Excel File
                strPath += @"\Rekap Account" + " "+ DateTime.Now.ToString("dd MM yyyy") + ".xlsx";
             OfficeExcel.Application excelApp = new OfficeExcel.Application();
                OfficeExcel.Workbook excelWorkBook = excelApp.Workbooks.Add(1);
                foreach (DataTable dtbl in ds.Tables)
                {
                    //buat excel worksheet
                    OfficeExcel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add(Default, excelWorkBook.Sheets[excelWorkBook.Sheets.Count], 1, Default);
                    excelWorkSheet.Name = dtbl.TableName;//Name worksheet

                    //tulis nama kolom
                    for (int i = 0; i < dtbl.Columns.Count; i++)
                        excelWorkSheet.Cells[inHeaderLength + 1, i + 1] = dtbl.Columns[i].ColumnName.ToUpper();

                    //isi baris
                    for (int m = 0; m < dtbl.Rows.Count; m++)
                    {
                        for (int n = 0; n < dtbl.Columns.Count; n++)
                        {
                            inColumn = n + 1;
                            inRow = inHeaderLength + 2 + m;
                            excelWorkSheet.Cells[inRow, inColumn] = dtbl.Rows[m].ItemArray[n].ToString();
                            if (m % 2 == 0)
                                excelWorkSheet.get_Range("A" + inRow.ToString(), "G" + inRow.ToString()).Interior.Color = System.Drawing.ColorTranslator.FromHtml("#FCE4D6");
                        }
                    }


                    OfficeExcel.Range cellRang2 = excelWorkSheet.get_Range("I1", "J3");
                    cellRang2.Merge(false);
                    float Left = (float)((double)cellRang2.Left);
                    float Top = (float)((double)cellRang2.Top);
                    const float ImageSize = 50;
                    //excelWorkSheet.Shapes.AddPicture("C:\\Users\\syahlevi93\\Documents\\proyek beasiswa\\Lambang_kab_peg_bintang.jpg", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, Left, Top, ImageSize, ImageSize);



                    //judul berkas

                    OfficeExcel.Range cellRang = excelWorkSheet.get_Range("A1", "G1");
                    cellRang.Merge(false);
                    cellRang.Interior.Color = System.Drawing.Color.White;
                    cellRang.Font.Color = System.Drawing.Color.Gray;
                    cellRang.HorizontalAlignment = OfficeExcel.XlHAlign.xlHAlignCenter;
                    cellRang.VerticalAlignment = OfficeExcel.XlVAlign.xlVAlignCenter;
                    cellRang.Font.Size = 15;

                    excelWorkSheet.Cells[1, 1] = "Laporan Account";

                    //OfficeExcel.Range cellRang12 = excelWorkSheet.get_Range("A2", "G2");
                    //cellRang12.Merge(false);
                    //cellRang12.Interior.Color = System.Drawing.Color.White;
                    //cellRang12.Font.Color = System.Drawing.Color.Gray;
                    //cellRang12.HorizontalAlignment = OfficeExcel.XlHAlign.xlHAlignCenter;
                    //cellRang12.VerticalAlignment = OfficeExcel.XlVAlign.xlVAlignCenter;
                    //cellRang12.Font.Size = 15;
                    //excelWorkSheet.Cells[2, 1] = "SURAT PEMBERITAHUAN PENERIMA BEASISWA UNTUK NIM" + " " + nim + " YANG DITERIMA BEASISWA PERIODE" + DateTime.Now.Year;

                    OfficeExcel.Range cellRang22 = excelWorkSheet.get_Range("A3", "G3");
                    cellRang22.Merge(false);
                    cellRang22.Interior.Color = System.Drawing.Color.White;
                    cellRang22.Font.Color = System.Drawing.Color.Gray;
                    cellRang22.HorizontalAlignment = OfficeExcel.XlHAlign.xlHAlignCenter;
                    cellRang22.VerticalAlignment = OfficeExcel.XlVAlign.xlVAlignCenter;
                    cellRang22.Font.Size = 13;

                    //excelWorkSheet.Cells[3, 1] = "Jl. Kukiding Oksibil";



                    //excelWorkSheet.Cells[12, 1] = " Pejabat Pelaksana";
                    //excelWorkSheet.Cells[14, 1] = " Jose Fino ";
                    //excelWorkSheet.Cells[15, 1] = " NIP/NIK. 3019220321";



                    //Style table column names
                    cellRang = excelWorkSheet.get_Range("A4", "G4");
                    cellRang.Font.Bold = true;
                    cellRang.Font.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.White);
                    cellRang.Interior.Color = System.Drawing.ColorTranslator.FromHtml("#ED7D31");
                    excelWorkSheet.get_Range("F4").EntireColumn.HorizontalAlignment = OfficeExcel.XlHAlign.xlHAlignRight;
                    //Formate price column
                    excelWorkSheet.get_Range("F5").EntireColumn.NumberFormat = "0.00";
                    //Auto fit columns
                    excelWorkSheet.Columns.AutoFit();
                }

                //Delete First Page
                excelApp.DisplayAlerts = false;
                Microsoft.Office.Interop.Excel.Worksheet lastWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelWorkBook.Worksheets[1];
                lastWorkSheet.Delete();
                excelApp.DisplayAlerts = true;

                //Set Defualt Page
                (excelWorkBook.Sheets[1] as OfficeExcel._Worksheet).Activate();

                excelWorkBook.SaveAs(strPath, Default, Default, Default, false, Default, OfficeExcel.XlSaveAsAccessMode.xlNoChange, Default, Default, Default, Default, Default);
                excelWorkBook.Close();
                excelApp.Quit();

                MessageBox.Show("Excel generated successfully \n As " + strPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void accounts_Load(object sender, EventArgs e)
        {
            DataGridViewLinkColumn lnk = new DataGridViewLinkColumn();
            gridaccounts.Columns.Add(lnk);
            lnk.Text = "Select";
            lnk.UseColumnTextForLinkValue = true;

            DataGridViewLinkColumn lnk2 = new DataGridViewLinkColumn();
            gridaccounts.Columns.Add(lnk2);
            lnk2.Text = "Delete";
            lnk2.UseColumnTextForLinkValue = true;

            //MessageBox.Show("Anda Harus Menginput Stocks Terlebih Dahulu Sebelum Mengisi Amount Account Yang Lain","Peringatan",  MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtnamaakun.Enabled = false;
            txtparentid.Enabled = false;
            loaddata();
        }

        public void simpanasset2()
        {
            decimal d = 0;
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            string masukdata = "insert into namespace2.assets (assetsid,amount,tanggal) values(:assetsid,:amount,:tanggal)";
            NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
            ncom.Parameters.Add(new NpgsqlParameter("assetsid", Convert.ToDecimal(this.txtakunid.Text)));
            ncom.Parameters.Add(new NpgsqlParameter("amount", d));
            ncom.Parameters.Add(new NpgsqlParameter("tanggal", dttanggal.Value.Date));

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
                pp.parentid = txtparentsid.Text;

            }
            pp.ShowDialog();
        }

        public void cekstocks()
        {
            NpgsqlConnection ncon2 = new NpgsqlConnection(stringkoneksi.connection);
            ncon2.Open();
            var sql = "select amount from namespace2.stocks";
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
        
        public void cekkode()
        {
            NpgsqlConnection ncon2 = new NpgsqlConnection(stringkoneksi.connection);
            ncon2.Open();
            var sql = "select id from namespace2.accounts where id=1001";
            NpgsqlCommand ncom2 = new NpgsqlCommand(sql, ncon2);
            NpgsqlDataReader nred2 = ncom2.ExecuteReader();
           if(nred2.Read())
            {
                simpanstocks();
            }
                 
                else
                {
                    simpanstocks();
                simpancash("Kas", 1001, 1000, 0);
                simpanassetcash(1001, 0, DateTime.Now.Date);
            }
                ncon2.Close();
            }
        
    



       

        public void simpanassetcash(int assetsid, int amount, DateTime tanggal)
        {
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            string masukdata = "insert into namespace2.assets (assetsid,amount,tanggal) values(:assetsid,:amount,:tanggal)";
            NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
            ncom.Parameters.Add(new NpgsqlParameter("assetsid", assetsid));
            ncom.Parameters.Add(new NpgsqlParameter("amount", amount));
            ncom.Parameters.Add(new NpgsqlParameter("tanggal", dttanggal.Value.Date));

            ncon.Open();
            ncom.ExecuteNonQuery();
            ncon.Close();
        }

        public void simpancash(string name, int id, int parent_id, int isparentaccount)
        {
            
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            string masukdata = "insert into namespace2.accounts (id,name,parent_id,isparentaccount) values(:id,:name,:parent_id,:isparentaccount)";
            NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
            ncom.Parameters.Add(new NpgsqlParameter("id", id));
            ncom.Parameters.Add(new NpgsqlParameter("name", name));
            ncom.Parameters.Add(new NpgsqlParameter("parent_id", parent_id));
            ncom.Parameters.Add(new NpgsqlParameter("isparentaccount", isparentaccount));

            ncon.Open();
            ncom.ExecuteNonQuery();
            ncon.Close();
            loaddata();
        }

        public void simpanstocks()
        {
            decimal d = 0;
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            string masukdata = "insert into namespace2.stocks (stocksid,amount,tanggal) values(:stocksid,:amount,:tanggal)";
            NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
            ncom.Parameters.Add(new NpgsqlParameter("stocksid", Convert.ToDecimal(this.txtakunid.Text)));
            ncom.Parameters.Add(new NpgsqlParameter("amount", d));
            ncom.Parameters.Add(new NpgsqlParameter("tanggal", dttanggal.Value.Date));

            ncon.Open();
            ncom.ExecuteNonQuery();
            ncon.Close();
            //simpancash("Kas", 1001, 1000, 0);
            //simpanassetcash(1001, 0, DateTime.Now.Date);
            popupcostamount pp = new popupcostamount();
            pp.id = txtakunid.Text;
            if (conf == 0)
            {
                pp.parentid = txtakunid.Text;
            }
            else if (conf == 1)
            {
                pp.parentid = txtparentsid.Text;

            }
            pp.ShowDialog();
        }

        public void simpancost()
        {
            DateTime ds = DateTime.Parse("12/03/1950");
            decimal d = 0;
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            string masukdata = "insert into namespace2.costs (costdid,amount,tanggal) values(:costdid,:amount,:tanggal)";
            NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
            ncom.Parameters.Add(new NpgsqlParameter("costdid", Convert.ToDecimal(this.txtakunid.Text)));
            ncom.Parameters.Add(new NpgsqlParameter("amount", d));
            ncom.Parameters.Add(new NpgsqlParameter("tanggal", dttanggal.Value.Date));

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
                pp.parentid = txtparentsid.Text;

            }
            pp.ShowDialog();
        }

        public void simpandebts()
        {
            DateTime ds = DateTime.Parse("12/03/1950");
            decimal d = 0;
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            string masukdata = "insert into namespace2.debts (debtsid,amount,tanggal) values(:debtsid,:amount,:tanggal)";
            NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
            ncom.Parameters.Add(new NpgsqlParameter("debtsid", Convert.ToDecimal(this.txtakunid.Text)));
            ncom.Parameters.Add(new NpgsqlParameter("amount", d));
            ncom.Parameters.Add(new NpgsqlParameter("tanggal", dttanggal.Value.Date));

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
                pp.parentid = txtparentsid.Text;

            }
            pp.ShowDialog();
        }


        public void simpanearnings()
        {
            DateTime ds = DateTime.Parse("12/03/1950");
            decimal d = 0;
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            string masukdata = "insert into namespace2.earnings (earningsid,amount,tanggal) values(:earningsid,:amount,:tanggal)";
            NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
            ncom.Parameters.Add(new NpgsqlParameter("earningsid", Convert.ToDecimal(this.txtakunid.Text)));
            ncom.Parameters.Add(new NpgsqlParameter("amount", d));
            ncom.Parameters.Add(new NpgsqlParameter("tanggal", dttanggal.Value.Date));

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
                pp.parentid = txtparentsid.Text;

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
                if (txtparentsid.Text == "1000" ||txtparentid.Text=="1000")
                {

                    simpanasset2();
                    codename = "KREDIT";

                }
                if (txtparentsid.Text== "2000" || txtparentid.Text == "2000")
                {
                    simpandebts();
                    codename = "KREDIT";

                }
                if (txtparentsid.Text == "3000" || txtparentid.Text == "3000")
                {
                    simpanstocks();
                    codename = "DEBIT";

                }
                if (txtparentsid.Text == "4000" || txtparentid.Text == "4000")
                {
                    simpancost();
                    codename = "KREDIT";

                }
                if (txtparentsid.Text == "5000" || txtparentid.Text == "5000")
                {
                    simpanearnings();
                    codename = "DEBIT";

                }
            }
        }

      
        public void simpandata()
        {
            try
            {
                NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
                string masukdata = "insert into namespace2.accounts values(@id,@name,@parent_id,@isparentaccount, @status)";
                NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
                ncom.Parameters.Add(new NpgsqlParameter("@id", Convert.ToDecimal(this.txtakunid.Text)));
                ncom.Parameters.Add(new NpgsqlParameter("@name", txtnamaakun.Text));
                if (conf == 1)
                {
                    ncom.Parameters.Add(new NpgsqlParameter("@parent_id", Convert.ToDecimal(txtparentsid.Text)));
                    ncom.Parameters.Add(new NpgsqlParameter("@status", "child"));


                }
                else if (conf == 0)
                {
                    ncom.Parameters.Add(new NpgsqlParameter("@status","parent"));

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
            ncom.CommandText = "select*from namespace2.accountsview2";
            DataSet ds = new DataSet();
            ds1 = new DataSet();
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
            nda.Fill(ds1, "akunting");
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
                MessageBox.Show("Data Perlu Diisi","Peringatan",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                if (conf == 0)
                {
                    //consumeapi();
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

            string masukdata = "update namespace2.accounts set name=:name where id='" + txtakunid.Text+ "'";

            NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);
            scom.Parameters.Add(new  NpgsqlParameter("name", txtnamaakun.Text));


            scon.Open();
            scom.ExecuteNonQuery();

            scon.Close();
            loaddata();
            txtnamaakun.Enabled = false;

        }

        public void simpanbukubesar()
        {
            DateTime ds = DateTime.Parse("12/03/1950");
            decimal d = 0;
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            string masukdata = "insert into namespace2.bukubesar(accountid,status) values(:accountid,:status)";
            NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
            ncom.Parameters.Add(new NpgsqlParameter("accountid", Convert.ToDecimal(this.txtakunid.Text)));
            ncom.Parameters.Add(new NpgsqlParameter("status", codename));

            ncon.Open();
            ncom.ExecuteNonQuery();
            ncon.Close();

        }

        public void counts()
        {
            int a = DateTime.Now.Year;
            int m = DateTime.ParseExact(DateTime.Now.Date.ToString("MMMM"), "MMMM", new System.Globalization.CultureInfo("id-ID")).Month;
            //int tot = Convert.ToInt32(this.lbtotop.Text);
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            ncon.Open();
            //var sql = "select sum(amount)  from costs where extract(year from tanggal) ='" + dttanggal.Value.Year + "' and extract(month from tanggal) ='" + dttanggal.Value.Month + "'";

            var sql = "select sum(amount)  from namespace2.stocks where extract(year from tanggal) ='" + a+ "' and extract(month from tanggal) ='" + m + "'";
            NpgsqlCommand ncom = new NpgsqlCommand(sql, ncon);
            NpgsqlDataReader dr = ncom.ExecuteReader();


            while (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                   int cost = dr.GetInt32(0);
                    MessageBox.Show("Jumlah Stocks Perusahaan Adalah :" + cost);
                    simpandata();
                    //consumeapi();
                    simpanasset();

                }
                else
                {
                   if(txtparentsid.Text == "3000")
                    {
                        //consumeapi();

                        simpandata();
                        cekkode();
                        //cekkode();

                    }
                   else
                    {
                        MessageBox.Show("Jumlah Stocks Perusahaan : 0, Anda Perlu Menambah Stocks Terlebih Dahulu ( Parent ID : 4000)");

                    }



                }
            }

        }

        public void deleteassets (int id)
        {
            NpgsqlConnection scon = new NpgsqlConnection(stringkoneksi.connection);

            string masukdata = "delete from namespace2.accounts  where id='" + id+ "'";

            NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);


            scon.Open();
            scom.ExecuteNonQuery();

            scon.Close();
            loaddata();
        }

        public void deleteaccount(int id)
        {
            NpgsqlConnection scon = new NpgsqlConnection(stringkoneksi.connection);

            string masukdata = "delete from namespace2.assets  where assetsid='" + id + "'";

            NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);


            scon.Open();
            scom.ExecuteNonQuery();

            scon.Close();
            loaddata();

        }


        public void deletecosts(int id)
        {
            NpgsqlConnection scon = new NpgsqlConnection(stringkoneksi.connection);

            string masukdata = "delete from namespace2.costs where costdid='" + id + "'";

            NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);


            scon.Open();
            scom.ExecuteNonQuery();

            scon.Close();
            loaddata();

        }

        public void deletestocks(int id)
        {

            NpgsqlConnection scon = new NpgsqlConnection(stringkoneksi.connection);

            string masukdata = "delete from namespace2.stocks  where stocksid='" + id + "'";

            NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);


            scon.Open();
            scom.ExecuteNonQuery();

            scon.Close();
            loaddata();
        }

        public void deleteearnings(int id)
        {

            NpgsqlConnection scon = new NpgsqlConnection(stringkoneksi.connection);

            string masukdata = "delete from namespace2.earnings where earningsid='" + id + "'";

            NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);


            scon.Open();
            scom.ExecuteNonQuery();

            scon.Close();
            loaddata();
        }

        public void deletedetailcosts(int id)
        {
            NpgsqlConnection scon = new NpgsqlConnection(stringkoneksi.connection);

            string masukdata = "delete from namespace2.detailcosts where costdid='" + id + "'";

            NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);


            scon.Open();
            scom.ExecuteNonQuery();

            scon.Close();
            loaddata();
        }

        public void deletedetailasset(int id)
        {
            NpgsqlConnection scon = new NpgsqlConnection(stringkoneksi.connection);

            string masukdata = "delete from namespace2.detailassets where assetsid='" + id + "'";

            NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);


            scon.Open();
            scom.ExecuteNonQuery();

            scon.Close();
            loaddata();
        }

        public void detaildebts(int id)
        {
            NpgsqlConnection scon = new NpgsqlConnection(stringkoneksi.connection);

            string masukdata = "delete from namespace2.detaildebts where debtsid='" + id + "'";

            NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);


            scon.Open();
            scom.ExecuteNonQuery();

            scon.Close();
            loaddata();
        }

        public void deletedetailearnings(int id)
        {
            NpgsqlConnection scon = new NpgsqlConnection(stringkoneksi.connection);

            string masukdata = "delete from namespace2.detailearnings where earningsid='" + id + "'";

            NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);


            scon.Open();
            scom.ExecuteNonQuery();

            scon.Close();
            loaddata();
        }

        public void deletedetailstocks (int id)
        {
            NpgsqlConnection scon = new NpgsqlConnection(stringkoneksi.connection);

            string masukdata = "delete from namespace2.detailstocks where stocksid='" + id + "'";

            NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);


            scon.Open();
            scom.ExecuteNonQuery();

            scon.Close();
            loaddata();
        }

        public void deletedebts(int id)
        {

            NpgsqlConnection scon = new NpgsqlConnection(stringkoneksi.connection);

            string masukdata = "delete from namespace2.debts where debtsid='" + id + "'";

            NpgsqlCommand scom = new NpgsqlCommand(masukdata, scon);


            scon.Open();
            scom.ExecuteNonQuery();

            scon.Close();
            loaddata();
        }

        private void gridaccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == gridaccounts.Columns[0].Index && e.RowIndex >= 0)
                {
                    txtakunid.Text = gridaccounts.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtnamaakun.Text = gridaccounts.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtakunid.ReadOnly = true;
                    txtnamaakun.Enabled = true;
                   
                }
                if(e.ColumnIndex==gridaccounts.Columns[1].Index && e.RowIndex >=0)
                {
                    txtakunid.Text = gridaccounts.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string huruf = txtakunid.Text.Substring(0, 1);

                    if (huruf=="1")
                    {
                        deletedetailasset(Convert.ToInt32(this.txtakunid.Text));

                        deleteaccount(Convert.ToInt32(this.txtakunid.Text));
                        deleteassets(Convert.ToInt32(this.txtakunid.Text));
                       

                    }
                    if(huruf=="2")
                    {
                        detaildebts(Convert.ToInt32(this.txtakunid.Text));

                        deletedebts(Convert.ToInt32(this.txtakunid.Text));

                        deleteassets(Convert.ToInt32(this.txtakunid.Text));
                    }
                    if (huruf=="3")
                    {
                        deletedetailstocks(Convert.ToInt32(this.txtakunid.Text));

                        deletestocks(Convert.ToInt32(this.txtakunid.Text));

                        deleteassets(Convert.ToInt32(this.txtakunid.Text));


                    }
                    if (huruf=="4")
                    {
                        deletedetailcosts(Convert.ToInt32(this.txtakunid.Text));

                        deletecosts(Convert.ToInt32(this.txtakunid.Text));

                        deleteassets(Convert.ToInt32(this.txtakunid.Text));


                    }
                    if (huruf=="5")
                    {
                        deletedetailearnings(Convert.ToInt32(this.txtakunid.Text));

                        deleteearnings(Convert.ToInt32(this.txtakunid.Text));

                        deleteassets(Convert.ToInt32(this.txtakunid.Text));


                    }
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

      

        public void konfig()
        {
            if(rdchildacc.Checked==true)
            {
                conf = 1;
                txtnamaakun.Enabled = true;
                string huruf = txtakunid.Text.Substring(0,1);
                int hu = Convert.ToInt32(huruf);
                int[] a;
                for (int i = 1; i <= hu; i++)
                {
                    if (i>=5)
                    {
                        MessageBox.Show("Saat Ini Kode Awal Parent Account hanya sampai 5", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    if (i >= 0 && i <= 5)
                    {
                        if (i == hu)
                        {
                            txtparentsid.Text = hu + "000";
                        }
                    }
                }
               
            }
            else if(rdparentacc.Checked==true)
            {
                conf = 0;
                txtnamaakun.Enabled = true;
                txtparentid.Text = txtakunid.Text;
              

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
          
            txtakunid.Text = "";
            txtakunid.ReadOnly = false;
            txtnamaakun.Text = "";
            txtparentid.Text = "";
            txtparentsid.Text = "";
            txtakunid.Enabled = true;
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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            gbdata.Dock = DockStyle.Fill;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            gbdata.Dock = DockStyle.None;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            loaddata();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Klik Pada Kolom ID untuk retrieve data pada Datagrid untuk keperluan Update", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            DataSet ds = ds1;
            ExportDataSetToExcelpenerimabeasiswa(ds, Application.StartupPath);

        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }
    }
}
