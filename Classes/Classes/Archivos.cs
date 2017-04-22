/*
*Author: Juan Alexis Romero Mora
*
*Class for managing files
*
*Includes:
*-Method for reading text files
*-Method for converting an ArrayList to an array of Strings
*-Overloaded method for writing a text file
*   -With an array of strings as data souce
*   -With an ArrayList as data source.
*/


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Archivos
    {
        /*Reads a file and returns an array of Strings in which each position of the array is a row of the file.
          Receives as parameter the path to follow in which the file is located.*/
        /*Lee un archivo y devuelve un arreglo de Strings en el que cada posicion del arreglo es un renglon del archivo.
          Recive como parámetro la ruta en la que se encuentra el archivo. */
        public static String[] leerArchivo(String ruta)
        {
            try
            {
                int counter = 0;
                string line;
                ArrayList arreglo = new ArrayList();
                System.IO.StreamReader file = new System.IO.StreamReader(@ruta);
                while ((line = file.ReadLine()) != null)
                {
                    arreglo.Add(line + "\n");
                    counter++;
                }
                file.Close();
                return arrayListToArray(arreglo);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //Receives an array and converts it to a sring array.
        //Recibe un array list y lo convierte a arreglo de strings
        public static string[] arrayListToArray(ArrayList array)
        {
            string[] res = new string[array.Count];
            for (int i = 0; i < array.Count; i++)
               res[i] = array[i].ToString();
            return res;
        }

        /*Writes a text file.
          Receives as parameter a string of the path in which  the file will bw located (including the name of the file)
          and a String array in which each position of the array is a row of the file*/
        /*Escribe un archivo de texto.
         Recibe como parámetro un string con la ruta hacia el archivo(Incluyendo el nombre del archivo)
         y un arreglo de String en el que cada posición es un renglón del archivo*/
        public static void escribirArchivo(String rutaWrite, String[] cadena)
        {
            System.IO.File.WriteAllLines(rutaWrite, cadena);
        }

        /*Writes a text file.
          Receives as parameter a string of the path in which  the file will bw located (including the name of the file)
          and an ArrayList in which each position of the array is a row of the file*/
        /*Escribe un archivo de texto.
         Recibe como parámetro un string con la ruta hacia el archivo(Incluyendo el nombre del archivo)
         y un ArrayList en el que cada posición es un renglón del archivo*/
        public static void escribirArchivo(String rutaWrite, ArrayList cadena)
        {
            escribirArchivo(rutaWrite, arrayListToArray(cadena));
        }
    }
}
