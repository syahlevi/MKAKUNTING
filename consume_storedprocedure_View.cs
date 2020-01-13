using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AKUNTING
{
    class consume_storedprocedure_View
    {
        public void operation_consume_storedprocedure()
        {
            string nama = "COOBA2";
            double index = 3002;

            string commandss = "CALL updateaccounts2('" + nama+ "','" + index + "')";
            NpgsqlConnection conn = new NpgsqlConnection(stringkoneksi.connection);

            NpgsqlCommand ncom = new NpgsqlCommand();
            ncom.Connection = conn;

            ncom.CommandType = CommandType.Text;
            ncom.CommandText = commandss;



            conn.Open();
            ncom.ExecuteNonQuery();
            conn.Close();
        }

        public void operation_consume_view()
        {
            NpgsqlConnection ncon = new NpgsqlConnection(stringkoneksi.connection);
            NpgsqlCommand ncom = new NpgsqlCommand();
            ncom.Connection = ncon;
            ncom.CommandType = CommandType.Text;

            ncom.CommandText = "select name from account_assets";
            DataSet ds = new DataSet();
            NpgsqlDataAdapter nda = new NpgsqlDataAdapter(ncom);
            nda.Fill(ds, "dbakuntings");
            //dataGridView1.DataSource = ds;
            //dataGridView1.DataMember = "dbakuntings";
        }
    }
}
