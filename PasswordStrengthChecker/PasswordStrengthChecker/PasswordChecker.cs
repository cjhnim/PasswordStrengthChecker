using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordStrengthChecker
{
    public class PasswordChecker
    {
        public bool IsAcceptablePassword(string password)
        {
            if (password.Length > 7 && 
                IsContainLetter(password) && 
                IsContainDigit(password))
            {
                return true;
            }

            return false;
        }

        private bool IsAcceptablePasswordForAdmin(string password)
        {
            if (password.Length >= 10 &&
                IsContainLetter(password) &&
                IsContainDigit(password))
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

        public bool IsAcceptablePasswordEx(string password, bool isAdmin)
        {
            if (!isAdmin)
                return IsAcceptablePassword(password);
            else
                return IsAcceptablePasswordForAdmin(password);
        }

    }
}
