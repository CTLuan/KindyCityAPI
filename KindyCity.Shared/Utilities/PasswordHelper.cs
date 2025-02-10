using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KindyCity.Shared.Utilities
{
    public static class PasswordHelper
    {

        public static string HashPasswordWithSalt(string password, string passwordSalt)
        {
            return BCrypt.Net.BCrypt.HashPassword(password + passwordSalt);
        }

        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static string GenerateSalt(int workFactor = 12)
        {
            return BCrypt.Net.BCrypt.GenerateSalt(workFactor);
        }

        public static bool VerifyPassword(string password, string salt, string passwordHash)
        {
            var passwordEnter = password + salt;

            return BCrypt.Net.BCrypt.Verify(passwordEnter, passwordHash);
        }

    }
}
