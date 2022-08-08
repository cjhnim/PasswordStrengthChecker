﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordStrengthChecker
{
    public class PasswordChecker
    {
        private List<WeakReasons> reasons;

        public PasswordChecker()
        {
            reasons = new List<WeakReasons>();
        }

        public bool IsAcceptablePassword(string password)
        {
            if (CheckLength(password,8) && IsContainLetterAndDigit(password))
            {
                return true;
            }

            return false;
        }


        private bool IsAcceptablePasswordForAdmin(string password)
        {
            if (CheckLength(password,10) && IsContainLetterAndDigit(password) && IsContainSpecialChracters(password))
            {
                return true;
            }

            return false;
        }

        private bool CheckLength(string password, int strongLength)
        {
            if (password.Length >= strongLength)
                return true;

            reasons.Add(new WeakReasons { Type = WeakReasons.TYPE_LENGTH });

            return false;
        }

        private bool IsContainDigit(string password)
        {
            foreach (var c in password)
            {
                if (char.IsDigit(c))
                    return true;
            }

            reasons.Add(new WeakReasons { Type = WeakReasons.TYPE_DIGITS });

            return false;
        }

        private bool IsContainLetter(string password)
        {
            foreach (var c in password)
            {
                if (char.IsLetter(c))
                    return true;
            }

            reasons.Add(new WeakReasons { Type = WeakReasons.TYPE_ALPHABET});
            return false;
        }

        private bool IsContainSpecialChracters(string password)
        {
            foreach (var c in password)
            {
                if (!char.IsLetterOrDigit(c))
                    return true;
            }

            reasons.Add(new WeakReasons { Type = WeakReasons.TYPE_SPECIAL });

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
            return reasons;
        }
    }
}
