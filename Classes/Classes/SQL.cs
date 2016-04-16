/* Author: Juan Alexis Romero Mora
*
*Class for managing SQL Server
*Contains:
*- Method for connecting to database to database
*- Method for disconnecting from database
*- Method for query insert
*- Method for requesting all data from a table
*
*
*/


using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
			connectionString = "Persist Security Info=False;Integrated Security=False;Server=" + server + ";Database=" + database + ";User=" + user + ";Password=" + password + ";Encrypt=False;Connection Timeout=30;";
			Console.WriteLine ("Creado");
		}

        public bool conectar()
        {
			Console.WriteLine("Intentando conectar");
			bool res = false;
            try
            {

                SQLconn = new SqlConnection(connectionString);

                SQLconn.Open();
                res = true;
				Console.WriteLine("Conexion exitosa");
            }
			catch (Exception ex)
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

        public string insert(string table, ArrayList values)
        {
            String error = "";
            if (conectar())
            {
                query = "Insert into " + table + " values('";


                for (int i = 0; i < values.Count; i++)
                {
                    query += values[i].ToString();
                    if (i < values.Count - 1)
                        query += "','";
                    else
                        query += "');";
                }
				Console.WriteLine (query);
                SqlCommand cmd = new SqlCommand(query, SQLconn);
                try
                {
                    cmd.ExecuteNonQuery();
                    error ="";
                }
                catch (Exception ex)
                {
                    Console.WriteLine("error:\n" + ex);
					error = ex.ToString();
                }
                SQLconn.Close();
            }
            return error;
        }

		public ArrayList obtenerTodo(string table){
			ArrayList res = new ArrayList ();
            int index = 0;
			if (this.conectar ()) {
				query = "Select * from " + table;
				SqlCommand cmd = new SqlCommand (query, SQLconn);
				SqlDataReader reader = cmd.ExecuteReader ();
				while (reader.Read ()) {
                    string[] temp = new string[reader.FieldCount];
                    for(int i = 0; i < reader.FieldCount; i++)
                    {
                        temp[i] = reader[i].ToString();
                    } 
                    res.Add (temp);
 				}
				this.desconectar ();
			}
			return res;
		}

        public string baja(string col, string value,string table)
        {
            String error = "";
            query = "delete " + table + " where " + col + " = " + value+(";");
            if (this.conectar())
            {
                SqlCommand cmd = new SqlCommand(query, SQLconn);
                try
                {
                    cmd.ExecuteNonQuery();
                }catch(Exception e)
                {
                    error = e.ToString();
                }
                this.desconectar();
            }
            else
            {
                error = "No se pudo conectar con la base de datos";
            }
            return error;
        }

        public string update(ArrayList columns, ArrayList values,string conditionColumn,string conditionValue, string table)
        {
            string error = "";
            if (columns.Count == values.Count)
            {

                if (this.conectar())
                {
                    query = "update " + table + " set ";
                    for (int i = 0; i < columns.Count; i++)
                    {
                        query += columns[i].ToString() + "='" + values[i].ToString();
                        if (i < columns.Count - 1)
                            query += "',";
                    }
                    query += "'where " + conditionColumn + "='" + conditionValue + "';";
                    SqlCommand cmd = new SqlCommand(query, SQLconn);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        error = e.ToString();
                    }
                    this.desconectar();
                }
                else
                    error = "No se pudo conectar a la base de datos";

            }
            else
                error = "no coincide el numero de valores con el de columnas";
            
            return error;
        }
    }
}
