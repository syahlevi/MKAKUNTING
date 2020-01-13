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
using OfficeExcel = Microsoft.Office.Interop.Excel;

using System.IO;
namespace AKUNTING
{
    public partial class assets : Form
    {
        public assets()
        {
            InitializeComponent();
        }
        DataSet ds1;

        public int jmlaset { get; set; }
        public string title { get; set; }
        public string id { get; set; }

        private void ExportDataSetToExcelpenerimabeasiswa(DataSet ds, string strPath)
        {
            int inHeaderLength = 3, inColumn = 0, inRow = 0;

            try
            {


                System.Reflection.Missing Default = System.Reflection.Missing.Value;
                //Create Excel File
                strPath += @"\Rekap Assets" + " " + DateTime.Now.ToString("dd MM yyyy") + ".xlsx";
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

                    excelWorkSheet.Cells[1, 1] = "Laporan Assets";

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


        private void assets_Load(object sender, EventArgs e)
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
            Console.Out.Write("dsfdsd");
        }

        public void counts()
        {
            //int a = DateTime.Now.Year;
            //int m = DateTime.ParseExact("Oktober", "MMMM", CultureInfo.CurrentCulture).Month;
            //int tot = Convert.ToInt32(this.lbtotop.Text);
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            ncon.Open();
            //var sql = "select sum(amount)  from costs where extract(year from tanggal) ='" + dttanggal.Value.Year + "' and extract(month from tanggal) ='" + dttanggal.Value.Month + "'";

            var sql = "select sum(amount)  from namespace2.account_assets";
            NpgsqlCommand ncom = new NpgsqlCommand(sql, ncon);
            NpgsqlDataReader dr = ncom.ExecuteReader();TaskSchedulerException TS;


            while (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    jmlaset= dr.GetInt32(0);
                    lbjmlstocks.Text = jmlaset.ToString("N0", new CultureInfo("en-US"));

                }
                else
                {

                    jmlaset= 0;

                    lbjmlstocks.Text = jmlaset.ToString("N0", new CultureInfo("en-US"));


                }
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

     

        public void loaddata()
        {

            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            NpgsqlCommand ncom = new NpgsqlCommand();
            ncom.Connection = ncon;
            ncom.CommandType = CommandType.Text;
            ncom.CommandText = "select *from namespace2.account_assets";
            DataSet ds = new DataSet();
            ds1 = new DataSet();
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
            nda.Fill(ds, "akunting");
            nda.Fill(ds1, "akunting");
            gridaccounts.DataSource = ds;
            gridaccounts.DataMember = "akunting";
            gridaccounts.Columns["amount"].DefaultCellStyle.Format = "N2";

            aturdatagrid();



        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            counts();
            loaddata();
        }

        private void gridaccounts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == gridaccounts.Columns[1].Index && e.RowIndex >= 0)
            {
                title = "assets";
                id = gridaccounts.Rows[e.RowIndex].Cells[0].Value.ToString();
                rincian ri = new rincian();
                ri.title = title;
                ri.MdiParent = this.MdiParent;
                ri.Show();
            }
            if(e.ColumnIndex==gridaccounts.Columns[0].Index&&e.RowIndex>=0)
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataSet ds = ds1;
            ExportDataSetToExcelpenerimabeasiswa(ds, Application.StartupPath);
        }
    }
}
