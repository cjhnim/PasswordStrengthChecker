using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordStrengthChecker
{
    public class PasswordChecker
    {
        public bool IsAcceptablePassword(string password)
        {
            if (password.Length > 7 && IsContainLetterAndDigit(password))
            {
                return true;
            }

            return false;
        }


        private bool IsAcceptablePasswordForAdmin(string password)
        {
            if (password.Length >= 10 && IsContainLetterAndDigit(password) && IsContainSpecialChracters(password))
            {
                return true;
            }

            return false;
        }


        private bool IsContainDigit(string password)
        {
            foreach (var c in password)
            {
                if (char.IsDigit(c))
                    return true;
            }

            return false;
        }

        private bool IsContainLetter(string password)
        {
            foreach (var c in password)
            {
                if (char.IsLetter(c))
                    return true;
            }

            return false;
        }

        private bool IsContainSpecialChracters(string password)
        {
            foreach (var c in password)
            {
                if (!char.IsLetterOrDigit(c))
                    return true;
            }

            return false;
        }

        private bool IsContainLetterAndDigit(string password)
        {
            return IsContainLetter(password) && IsContainDigit(password);
        }

        public bool IsAcceptablePasswordEx(string password, bool isAdmin)
        {
            if (!isAdmin)
                return IsAcceptablePassword(password);
            else
                return IsAcceptablePasswordForAdmin(password);
        }

        public List<WeakReasons> GetLastReasons()
        {
            return new List<WeakReasons>();
        }
    }
}
