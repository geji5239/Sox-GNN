using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;

namespace SoxWeb.PasswordManager
{
    public class HashCalc
    {
        public string GetHashWithSalt(string data)
        {
            SHA256 sha = new SHA256CryptoServiceProvider();
            byte[] dataBytes = Encoding.ASCII.GetBytes(data);
            byte[] resultBytes = sha.ComputeHash(dataBytes);

            // return the hash string to the caller
            return Encoding.ASCII.GetString(resultBytes);
        }
    }
}