using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Service.Common
{
    public static  class HelperService
    {
        public static string GeneratePassowrd(this string password, byte[] salt)
        {

            string passwordHash = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password!,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

            return passwordHash;
        }


        public static  byte[]  GenrateSalt()
        {
           return  RandomNumberGenerator.GetBytes(128 / 8);
        }
    }
}
