using Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Service
{
    public class MD5Hasher : IPasswordHasher
    {
        public string ComputeHash(string password)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(data);
            }
        }
    }
}
