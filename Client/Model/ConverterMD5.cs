using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    class ConverterMD5
    {
       public ConverterMD5 () { }

        public string encodeMD5(String pass)
        {
            //encode pass from registerPanel
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(pass);
            byte[] hash = md5.ComputeHash(inputBytes);

            StringBuilder cryptoPass = new StringBuilder();

            for(int i=0; i<hash.Length; i++)
            {
                cryptoPass.Append(hash[i].ToString("X2"));
            }
            string resolve = cryptoPass.ToString();

            return resolve;
        }
    }
}
