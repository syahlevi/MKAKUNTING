using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using Npgsql;

namespace AKUNTING
{
    public partial class stoppingretainedearning : Form
    {
        public stoppingretainedearning()
        {
            InitializeComponent();
        }

        private void stoppingretainedearning_Load(object sender, EventArgs e)
        {
            lbreportdate.Text = DateTime.Now.ToString("dddd, dd-MM-yyyy");
        }
    }
}
