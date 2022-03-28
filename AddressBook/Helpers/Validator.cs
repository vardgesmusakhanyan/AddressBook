using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AddressBook.Helpers
{
    public static class Validator
    {
        public static bool IsPhoneNumber(string input)
        {
            Regex reg = new Regex("^[0-9]{9}$");
            return reg.IsMatch(input);
        }

        public static bool IsEmailAddress(string input)
        {
            Regex reg = new Regex(@"\S+@\S+.\S+");
            return reg.IsMatch(input);
        }
    }
}
