using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class MSSql
    {
        public static string FirstDataFromTable(DataTable dt)
        {
            string res;
            DataRow dr = dt.Rows[0];
            res = dr[0].ToString();
            return res;
        }
        public static DataTable ExecuteStoredProcedure(string ConnectionString, string stored, Parameter[] parameters)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand com = new SqlCommand(stored);
            for (int i = 0; i < parameters.Length; i++)
            {
                string name = parameters[i].name;
                object value = parameters[i].value;
                com.Parameters.Add(new SqlParameter(name, value));
            }
            com.CommandType = CommandType.StoredProcedure;
            com.Connection = con;
            DataTable dt = new DataTable();
            con.Open();
            dt.Load(com.ExecuteReader());
            con.Close();
            return dt;
        }
        public static string FirstDataFromTable(string ConnectionString, string stored, Parameter[] parameters)
        {
            DataTable dt = ExecuteStoredProcedure(ConnectionString, stored, parameters);
            return FirstDataFromTable(dt);
        }
    }
}
