using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordStrengthChecker
{
    public class PasswordChecker
    {
        public bool IsAcceptablePassword(string password)
        {
            if (password.Length > 7)
                return true;

            return false;
        }
    }
}
