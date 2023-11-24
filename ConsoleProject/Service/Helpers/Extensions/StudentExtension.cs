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
            string regPat= "^[+]{1}(?:[0-9\\-\\(\\)\\/\\.]\\s?){6, 15}[0-9]{1}$";

            if (number != null)
            {
                return Regex.IsMatch(number, regPat);
            }
            return false;
        }

    }
    
}
