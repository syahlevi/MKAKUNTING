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
using NpgsqlTypes;
namespace AKUNTING
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public void operation_consume_storedprocedure()
        {
            string connstring = "";
            string result = "COOBA2";
            double d = 3002;

            string commandss = "CALL updateaccounts2('" + result + "','" + d + "')";
            NpgsqlConnection conn = new NpgsqlConnection(stringkoneksi.connection);

            NpgsqlCommand ncom = new NpgsqlCommand();
            ncom.Connection = conn;

            ncom.CommandType = CommandType.Text;
            ncom.CommandText = commandss;


         
            conn.Open();
            ncom.ExecuteNonQuery();
            conn.Close();
        }

       
    }
}
