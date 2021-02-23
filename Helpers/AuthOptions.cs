using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Helpers
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer"; // publisher
        public const string AUDIENCE = "MyAuthClient"; // consumer
        const string KEY = "mysupersecret_secretkey!123";   // key
        public const int LIFETIME = 1; // in min
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
