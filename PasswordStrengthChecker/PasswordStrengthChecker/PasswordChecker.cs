using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordStrengthChecker
{
    public class PasswordChecker
    {
        public bool IsAcceptablePassword(string password)
        {
            if (password.Length > 7 && IsContainLetter(password))
            {
                return true;
            }

            return false;
        }

        private bool IsContainLetter(string password)
        {
            bool isContainLetter = false;
            foreach (var c in password)
            {
                if (char.IsLetter(c))
                    isContainLetter = true;

            }

            return isContainLetter;
        }
    }
}
