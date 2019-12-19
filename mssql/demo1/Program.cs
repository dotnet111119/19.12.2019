using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSQL1
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlCommand cmd = new SqlCommand();

            cmd.Connection = new SqlConnection(
                ConfigurationManager.ConnectionStrings["companydb_local"].
                ConnectionString);
            cmd.Connection.Open();
            cmd.Connection.Close();
        }
    }
}
