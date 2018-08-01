using System;
using System.Security.Cryptography;
using System.Text;
using TourToto.DataTypes.Interfaces;

namespace TourToto.Tools
{
    internal class PasswordBase64 : IPassword
    {
        public string EncodePassword(string password)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] inArray = HashAlgorithm.Create("SHA1").ComputeHash(bytes);
            return Convert.ToBase64String(inArray);
        }
    }
}