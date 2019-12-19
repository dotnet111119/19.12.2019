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
        class Emplopyee
        {
            public int ID { get; set; }
            public int Age { get; set; }
            public string Name { get; set; }
            public string Address { get; set;  }
            public double Salary { get; set; }
        }
        static void Main(string[] args)
        {

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["companydb_local"].ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("SELECT_ALL_EMPLOYEES", conn);

                cmd.Connection.Open();

                cmd.CommandType = CommandType.StoredProcedure;


                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.Default);

                List<Emplopyee> list = new List<Emplopyee>();
                while (reader.Read() == true)
                {
                    Console.WriteLine($" {reader["ID"]} {reader["NAME"]} {reader["AGE"]} {reader["ADDRESS"]} {reader["SALARY"]}");
                    var e = new Emplopyee
                    {
                        ID = Convert.ToInt32(reader["ID"]),
                        Name = reader["NAME"].ToString(),
                        Age = Convert.ToInt32(reader["AGE"]),
                        Address = reader["ADDRESS"].ToString(),
                        Salary = Convert.ToDouble(reader["SALARY"]),
                    };
                    list.Add(e);
                }
            }

            //cmd.Connection.Close();
        }
    }
}
