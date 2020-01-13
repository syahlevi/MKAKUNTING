using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
namespace AKUNTING
{
    class stringkoneksi
    {
        public static string connection = @"User ID=postgres;Password=godofwar32;Host= 182.253.171.221;Port=5433;Database=database2;"; 

        public static NpgsqlConnection conn = new NpgsqlConnection(stringkoneksi.connection);
        public static NpgsqlCommand comm;
    }
}
