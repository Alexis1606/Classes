using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Collections;

namespace Classes
{
    class DataBase
    {
        public string serverType;
        public string connectionString;
        public string query;
        public SQL databaseSQL;

        public DataBase(string serverType, string user, string password, string server, string database)
        {
            this.serverType = serverType;
            #region SQL
            if (serverType == "SQL")
            {
                databaseSQL = new SQL(user, password, server, database);
            }
            #endregion

            #region MySQL
            else if (serverType == "MySQL")
            {
                connectionString = "datasource=" + server + ";port=3306;username=" + user + ";password=" + password;
            }
            #endregion
        }

        public bool conectar()
        {
            bool res = false;
            #region SQL SERVER
            if (serverType == "SQL")
            {
                if (databaseSQL.conectar())
                    res = true;
            }
            #endregion

            #region MySql
            else if (serverType == "MySQL")
            {
                try
                {
                    MySqlConnection MySQLconn = new MySqlConnection(connectionString);
                    MySQLconn.Open();
                    res = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("No se pudo establecer conexión con la lase de datos:\n" + ex);
                }
            }
            #endregion

            #region error de servertype
            else
            {
                Console.WriteLine("Server type no válido\n Servidores válidos: SQL, MySQL");
            }
            #endregion
            return res;

        }
        public bool insert(string table, ArrayList values)
        {
            bool res = false;
            if (conectar())
            {

                #region SQL
                if (serverType == "SQL")
                {
                    databaseSQL.insert(table, values);
                }

                #endregion
                #region MySQL
                if (serverType == "MySQL")
                {
                    try
                    {

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("error:\n" + ex);
                    }
                }
                #endregion

            }
            return res;
        }

        public bool desconectar()
        {
            bool res = false;
            #region SQL SERVER
            if (serverType == "SQL")
            {
                databaseSQL.desconectar();
                res = true;
            }
            #endregion

            #region MySql
            else if (serverType == "MySQL")
            {

            }
            #endregion

            #region error de servertype
            else
            {
                Console.WriteLine("Server type no válido\n Servidores válidos: SQL, MySQL");
            }
            #endregion
            return res;
        }
    }
}
