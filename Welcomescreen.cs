using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AKUNTING
{
    public partial class Welcomescreen : Form
    {
        public Welcomescreen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            companyidentity ci = new companyidentity();
            ci.StartPosition = FormStartPosition.CenterScreen;
            ci.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("It's Still Being Developed", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
