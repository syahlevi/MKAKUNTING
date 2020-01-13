using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AKUNTING
{
    public partial class zoomgambar : Form
    {
        public zoomgambar()
        {
            InitializeComponent();
        }

        public byte[] imagedata;
        public string path;

        public void a(string url)
        {
            string username = "amal";
            string password = "j4k4rt4";
            WebClient req = new WebClient();
            req.Credentials = new NetworkCredential(username, password);

            byte[] FData = req.DownloadData(url);
            string fString = System.Text.Encoding.UTF8.GetString(FData);
           pictureBox1.Image = ByteToImage(FData);

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

        private void zoomgambar_Load(object sender, EventArgs e)
        {
            try
            {
                a(path);
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
