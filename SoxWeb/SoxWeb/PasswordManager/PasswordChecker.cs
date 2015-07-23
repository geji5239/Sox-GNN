using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoxWeb.PasswordManager
{
    public class PasswordChecker
    {
        HashCalc _hashCalc = new HashCalc();

        public string PasswordHash(string passwordString, out string salt)
        {
            salt = SaltGenerator.GetSalt();

            string finalString = passwordString + salt;

            return _hashCalc.GetHashWithSalt(finalString);
        }

        public string PasswordHash(string passwordString, string salt)
        {
            string finalString = passwordString + salt;

            return _hashCalc.GetHashWithSalt(finalString);
        }

        public bool IsPasswordValid(string passwordString, string salt, string passwordHash)
        {
            string finalString = passwordString + salt;

            return (passwordHash == _hashCalc.GetHashWithSalt(finalString));
        }
    }
}