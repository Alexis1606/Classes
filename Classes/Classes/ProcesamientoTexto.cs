using System;
using System.Collections;

namespace Classes
{
    class ProcesamientoTexto
    {
        ///<summary> 
		/// Recibe como prametro un string que representa un renglon y devuelve un arreglo de strings que en cada posición tiene una palabra del renglon
		/// </summary>
		public static string[] renglonAPalabras(String renglon, char token)
        {
            return renglon.Split(token);
        }
        ///<summary> Esta clase recibe como prametro un string que representa una palabre y devuelve un arreglo de caracteres que en cada posición tiene un caracter de la palabre
        /// </summary>
        public static char[] palabraACarateres(String palabra)
        {
            return palabra.ToCharArray();
        }
        /// <summary>
        /// Valida si la palabra existe existe en el texto dado.
        /// <para>El texto debe ser un arreglo de Strings en el que cada posición es un renglón del texto</para>
        /// </summary>
        public static bool existeTexto(string palabra, string[] texto)
        {/// <summary>
         /// Valida si la palabra existe existe en el texto dado.
         /// <para>El texto debe ser un arreglo de Strings en el que cada posición es un renglón del texto</para>
         /// </summary>
            if (posExiste(palabra, texto).Length == 0)
                return false;
            else
                return true;
        }
        ///<summary>
        /// Devuelve las posiciones en las que se encontraron la palabra dentro del renglon.
        /// </summary>
        private static int[] posRenglon(string palabra, string renglon)
        {
            ArrayList res = new ArrayList();


            for (int i = 0; i < renglon.Split().Length; i++)
            {
                if (palabra == renglon.Split()[i])
                    res.Add(i);
            }

            return arrayListToIntArray(res);
        }

        /// <summary>
        /// Devuelve una tabla con las posiciones donde se enconttó la palabra dentro del archivo.
        /// [renglon,columna] donde se encuentra la palabra.
        /// </summary>
        public static int[,] posExiste(string palabra, string[] texto)
        {
            ArrayList res = new ArrayList();
            for (int renglon = 0; renglon < texto.Length; renglon++)
            {
                for (int columna = 0; columna < posRenglon(palabra, texto[renglon]).Length; columna++)
                {
                    int[,] temp = new int[1, 2];
                    temp[0, 0] = renglon;
                    temp[0, 1] = posRenglon(palabra, texto[renglon])[columna];
                    res.Add(temp);
                }
            }

            return arrayListToBiIntArray(res);
        }
        /// <summary>
        /// Devuelve un arreglo identico al array list
        /// </summary>
        private static int[] arrayListToIntArray(ArrayList ar)
        {
            int[] temp = new int[ar.Count];
            for (int i = 0; i < ar.Count; i++)
            {
                temp[i] = Convert.ToInt32(ar[i].ToString());
            }
            return temp;
        }
        /// <summary>
        /// Devuelve un arreglo identico al array list
        /// </summary>

        private static int[,] arrayListToBiIntArray(ArrayList ar)
        {
            int[,] res = new int[ar.Count, 2];
            for (int i = 0; i < ar.Count; i++)
            {
                int[,] temp = (int[,])(ar[i]);
                res[i, 0] = temp[0, 0];
                res[i, 1] = temp[0, 1];
            }
            return res;
        }

        public static bool existe(string palabraAValidar, string[] diccionario)
        {
            int i = -1;
            bool v = false;
            do
            {
                i++;
                if (palabraAValidar == diccionario[i])
                {
                    v = true;
                }
            } while (palabraAValidar != diccionario[i] && i < diccionario.Length - 1);
            return v;
        }
    }
}
