using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace Classes
{
    public class MySQL
    {
        public string server;
        public string user;
        public string password;

        public MySQL(string server, string user, string password)
        {
            this.server = server;
            this.user = user;
            this.password = password;
        }

        public void insert(string database, string table, string valuesFile)
        {
            try
            {
                string[] archivo = Archivos.leerArchivo(valuesFile);
                string MyConnection2 = "datasource=" + this.server + ";port=3306;username=" + this.user + ";password=" + this.password;
                //Console.WriteLine("COnection string: "+MyConnection2);
                for (int i = 0; i < archivo.Length; i++)
                {
                    string query = "insert into " + database + "." + table + " values('";
                    string[] values = ProcesamientoTexto.renglonAPalabras(archivo[i], '|');
                    for (int j = 0; j < values.Length; j++)
                    {
                        query += values[j] + "'";
                        if (j < values.Length - 1)
                            query += ", '";
                        else
                            query += ");";

                    }
                    //Console.WriteLine("Query: "+query);
                    MySqlConnection conexion = new MySqlConnection(MyConnection2);
                    MySqlCommand comando = new MySqlCommand(query, conexion);
                    //Console.WriteLine("Comando aceptado");
                    MySqlDataReader MyReader2;
                    //Console.WriteLine("Reader creado");
                    conexion.Open();
                    //Console.WriteLine("COnexion abierta");
                    try
                    {
                        MyReader2 = comando.ExecuteReader();
                        Console.WriteLine("\n' " + query + " ' ejecutado exitosamente");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("\nExcepción " + e + " en query: " + query);
                    }
                    conexion.Close();
                    //Console.WriteLine("Conexion cerrada");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + e);
                //Console.ReadLine ();
            }

        }
    }
}
