using System;
using System.Security.Cryptography;
using System.Text;

namespace Kerberos
{
    class KerberosClient
    {
        public string username { get; set; }
        public string secret { get; }

        public KerberosClient(string username, string pwd) {
            this.username = username;
            using (SHA256 sha256Hash = SHA256.Create())
            {
                secret = GetHash(sha256Hash, pwd);
            }
        }

        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}