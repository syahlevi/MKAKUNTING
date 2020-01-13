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
    public partial class insertstocks : Form
    {
        public insertstocks()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            a();
           
        }

        public void a()
        {
            string username = "amal";
            string password = "j4k4rt4";
            WebClient req = new WebClient();
            string url = "ftp://mk-cideng.ddns.net/tes%20prasetyo/2.PNG";
            req.Credentials = new NetworkCredential(username,password);
           
                byte[] FData = req.DownloadData(url);
                string fString = System.Text.Encoding.UTF8.GetString(FData);
            pictureBox1.Image = ByteToImage(FData);
          
        }

        public byte[] GetImgByte(string ftpFilePath)
        {
            ftpFilePath = "ftp://mk-cideng.ddns.net/tes%20prasetyo/2.PNG";
            string username = "amal";
            string password = "j4k4rt4";
            WebClient ftpClient = new WebClient();
            ftpClient.Credentials = new NetworkCredential(username, password);

            byte[] imageByte = ftpClient.DownloadData(ftpFilePath);
            return imageByte;
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

      
        }
}
