using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Helpers.Extensions
{
    public static class UserExtension
    {
        public static bool EmailCheck(this string email)
        {
            if (email.Contains("@") is false)
            {
                ConsoleColor.Red.WriteConsole("Email format is wrong");
                return false;
            }
            return true;
        }
    }
}
