using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IPasswordHasher
    {
       string ComputeHash(string password);
    }
}
