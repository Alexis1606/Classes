using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
/*
 * Class containing several utilities 
 * 
 *  - encrypt with sha512 algorithym
 * 
 */
namespace Classes
{
    class Utilities
    {
        public static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = SHA512.Create();  //or use SHA1.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }
        public static string encrypt(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));
            return sb.ToString();
        }
    }
}
