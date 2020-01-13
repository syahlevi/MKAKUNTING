using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AKUNTING
{
    public partial class konfigurasiodbc : Form
    {
        public konfigurasiodbc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string command = "mailto:tossasyahlevi03[at]gmail.com?subject=Password ODBC Crystal Report";
            Process.Start(command);
        }

       
    }
}
