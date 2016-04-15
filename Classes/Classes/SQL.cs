/* Author: Juan Alexis Romero Mora
*
*Class for managing SQL Server
*Contains:
*- Method for connecting to database to database
*- Method for disconnecting from database
*- Method for query insert
*
*
*/


using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Classes
{
    public class SQL
    {
        public string connectionString;
        public string query;
        public SqlConnection SQLconn;

        public SQL()
        {
        }

        public SQL(string user, string password, string server, string database)
        {
            connectionString = "Server=" + server + ";Database=" + database + ";User=" + user + ";Password=" + password + ";Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }

        public bool conectar()
        {
            bool res = false;
            try
            {
                SQLconn = new SqlConnection(connectionString);
                SQLconn.Open();
                res = true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine("No se pudo establecer conexión con la lase de datos:\n" + ex);
            }
            return res;
        }

        public bool desconectar()
        {
            bool res = false;
            try
            {
                SQLconn.Close();
                res = true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:\n " + e);
            }
            return res;
        }

        public bool insert(string table, ArrayList values)
        {
            bool res = false;
            if (conectar())
            {
                query = "Insert into " + table + " values(";


                for (int i = 0; i < values.Count; i++)
                {
                    query += values[i].ToString();
                    if (i < values.Count - 1)
                        query += ",";
                    else
                        query += ");";
                }
                SqlCommand cmd = new SqlCommand(query, SQLconn);
                try
                {
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error:\n" + ex);
                }
                SQLconn.Close();
            }
            return res;
        }
    }
}
