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
            {
                bool isContainLetter = false;
                foreach(var c in password)
                {
                    if (char.IsLetter(c))
                        isContainLetter = true;

                }

                if(isContainLetter)
                    return true;
            }

            return false;
        }
    }
}
