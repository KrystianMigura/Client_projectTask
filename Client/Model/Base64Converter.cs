using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    public class Base64Converter
    {
       public Base64Converter () { }

        public string encodeBase64string(String value)
        {
            var bytesString = System.Text.Encoding.UTF8.GetBytes(value);
            string str = System.Convert.ToBase64String(bytesString);
            return str;
        }

        public string decodeBase64string(String value)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(value);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
           
        }
    }
}
