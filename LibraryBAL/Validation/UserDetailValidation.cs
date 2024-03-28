using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibraryBAL.Validation
{
    internal class UserDetailValidation
    {
        public static bool IsValidEmailFormat(string email)
        {

            return Regex.IsMatch(email, "^[a-z0-9][A-Z-a-z0-9._]+@([-a-z0-9]+.)+[a-z]{2,5}$");
        }
        public static bool IsPhoneNumberFormat(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"\d[0-9]{9}$");
        }

    }
}
