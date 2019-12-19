using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM Employees";


            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

            List<Object> list = new List<object>();
            while (reader.Read() == true)
            {
                Console.WriteLine($" {reader["ID"]} {reader["NAME"]} {reader["AGE"]} {reader["ADDRESS"]} {reader["SALARY"]}");
                var e = new
                {
                    Id = reader["ID"],
                    firaName = reader["NAME"]
                };
                list.Add(e);
            }

            cmd.Connection.Close();
        }
    }
}
