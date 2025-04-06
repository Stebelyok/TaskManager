using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace TaskManager.Utils
{
    public static class PasswordEncoder
    {
        private const int WorkFactor = 12;

        public static string Encode(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool Verify(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
