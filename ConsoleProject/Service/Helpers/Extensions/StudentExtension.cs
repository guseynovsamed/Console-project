using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Service.Helpers.Extensions
{
    public static class StudentExtension
    {
        public static bool CheckPhone(this string number)
        {
            string regPat = (@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}");

            if (number != null)
            {
                return Regex.IsMatch(number, regPat);
            }
            return false;
        }

    }
    
}
