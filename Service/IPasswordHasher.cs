using System;
using System.Security.Cryptography;
using System.Text;

namespace Service
{
    public interface IPasswordHasher
    {
        string ComputeHash(string password);
    }
}
