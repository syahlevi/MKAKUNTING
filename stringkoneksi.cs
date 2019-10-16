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
        public static string connection = @"User ID=postgres;Password=godofwar32;Host=localhost;Port=5432;Database=akunting;";

        public static NpgsqlConnection conn = new NpgsqlConnection(stringkoneksi.connection);
        public static NpgsqlCommand comm;
    }
}
