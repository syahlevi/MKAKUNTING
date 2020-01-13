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
using System.IO;
using System.Net;

namespace AKUNTING
{
    public partial class detailassets : Form
    {
        public detailassets()
        {
            InitializeComponent();
        }

        public string lokasi { get; set; }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Data.Dock = DockStyle.Fill;

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Data.Dock = DockStyle.None;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            loaddata();
        }

        private void pbscan_Click(object sender, EventArgs e)
        {
            if (txtpath.Text == "")
            {
                MessageBox.Show("Path Scan  DImasukin Dulu Dong", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    ;
            }
            else
            {
                zoomgambar zg = new zoomgambar();
                zg.path = this.txtpath.Text;
                zg.MdiParent = this.MdiParent;
                zg.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            try
            {
                if (DialogResult.OK == ofd.ShowDialog())
                {
                    pbscan.Image = new Bitmap(ofd.FileName);
                    lokasi = ofd.FileName;
                    txtpath.Text = ofd.FileName;
                    pbscan.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("File Yang dipilih Bukan File Gambar : (.jpg, .JPG, .png, .PNG) Atau File Gambar yang dipilih RUSAK", "KESALAHAN", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loaddata()
        {

            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            NpgsqlCommand ncom = new NpgsqlCommand();
            ncom.Connection = ncon;
            ncom.CommandType = CommandType.Text;
            ncom.CommandText = "select faktur_no, assetsid, keterangan,tanggalfaktur from namespace2.detailassets";
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

        public void simpan()
        {
            string path1 = @"ftp://mk-cideng.ddns.net/tes%20prasetyo/" + Path.GetFileName(lokasi);

            byte[] imagedata2 = readfile2(txtpath.Text);
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            string masukdata = "insert into namespace2.detailassets values(@faktur_no,@assetsid,@keterangan,@scanfakturpath,@scanfaktur,@tanggalfaktur,@pathftp)";
            NpgsqlCommand ncom = new NpgsqlCommand(masukdata, ncon);
            ncom.Parameters.Add(new NpgsqlParameter("@faktur_no", txtnofaktur.Text));
            ncom.Parameters.Add(new NpgsqlParameter("@assetsid", Convert.ToDecimal(this.txtaccountid.Text)));
            ncom.Parameters.Add(new NpgsqlParameter("@keterangan", rtketerangan.Text));
            ncom.Parameters.Add(new NpgsqlParameter("@scanfakturpath", (object)txtpath.Text));
            ncom.Parameters.Add(new NpgsqlParameter("@scanfaktur", (object)imagedata2));

            ncom.Parameters.Add(new NpgsqlParameter("@tanggalfaktur", dtfaktur.Value.Date));
            ncom.Parameters.Add(new NpgsqlParameter("@pathftp", (object)path1));

            ncon.Open();
            ncom.ExecuteNonQuery();
            ncon.Close();

            MessageBox.Show("Data Faktur Berhasil Disimpan", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loaddata();
            ftp2();

        }

        public void a()
        {
            string username = "amal";
            string password = "j4k4rt4";
            WebClient req = new WebClient();
            string url = "ftp://mk-cideng.ddns.net/tes%20prasetyo/nopicture1.jpg";
            req.Credentials = new NetworkCredential(username, password);

            byte[] FData = req.DownloadData(url);
            string fString = System.Text.Encoding.UTF8.GetString(FData);
            pbscan.Image = ByteToImage(FData);
            pbscan.SizeMode = PictureBoxSizeMode.StretchImage;

        }



        public static Bitmap ByteToImage(byte[] blob)
        {
            MemoryStream mStream = new MemoryStream();
            byte[] pData = blob;
            mStream.Write(pData, 0, Convert.ToInt32(pData.Length));
            Bitmap bm = new Bitmap(mStream, false);
            mStream.Dispose();
            return bm;
        }

        private void detailassets_Load(object sender, EventArgs e)
        {
            loaddata();
           // a();
        }

        byte[] readfile2(string spath2)
        {
            byte[] data = null;


            FileInfo fi = new FileInfo(spath2);
            long numbytes = fi.Length;

            FileStream fs = new FileStream(spath2, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            data = br.ReadBytes((int)numbytes);



            return data;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtaccountid.Text == "" || txtnofaktur.Text == "" || txtpath.Text == "")
            {
                MessageBox.Show("Data Harus Diisi", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                simpan();
            }
        }

        public void ftp1()
        {
            //FtpWebRequest request = (FtpWebRequest)WebRequest.Create("ftp://mk-cideng.ddns.net/tes%20prasetyo/");
            //request.Method = WebRequestMethods.Ftp.UploadFile;

            //// This example assumes the FTP site uses anonymous logon.
            //request.Credentials = new NetworkCredential("amal", "j4k4rt4");
            //request.KeepAlive = true;
            //request.UsePassive = false;
            //// Copy the contents of the file to the request stream.
            //StreamReader sourceStream = new StreamReader(txtpath.Text);
            //byte[] fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            //sourceStream.Close();
            //request.ContentLength = fileContents.Length;

            //Stream requestStream = request.GetRequestStream();
            //requestStream.Write(fileContents, 0, fileContents.Length);
            //requestStream.Close();

            //FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            //MessageBox.Show("Upload File Complete, status {0}", response.StatusDescription);

            ////Console.WriteLine("Upload File Complete, status {0}", response.StatusDescription);

            //response.Close();
        }

        public void ftp2()
        {
            if (txtpath.Text == null)
            {
                MessageBox.Show("Anda Harus Upload File Path", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string username = "amal";
                string password = "j4k4rt4";
                string nama = Path.GetFileName(txtpath.Text);

                try
                {
                    using (var client = new WebClient())
                    {
                        client.Credentials = new NetworkCredential(username, password);
                        client.UploadFile(@"ftp://mk-cideng.ddns.net/tes%20prasetyo/" + nama, WebRequestMethods.Ftp.UploadFile, lokasi);
                        MessageBox.Show("File Scan Uploaded", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("FTP Tidak Bisa Diakses", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }
      
    }
}
