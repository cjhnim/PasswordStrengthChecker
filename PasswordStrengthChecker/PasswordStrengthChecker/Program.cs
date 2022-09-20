using System;

namespace PasswordStrengthChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            PasswordChecker checker = new PasswordChecker();
            Console.WriteLine(checker.IsAcceptablePassword("ABCDEFGHKJ"));
            Console.WriteLine(checker.IsAcceptablePassword("ABCDEFGHKJ1"));
            Console.WriteLine(checker.IsAcceptablePassword("KJ1"));
            Console.WriteLine(checker.IsAcceptablePassword("123"));
            Console.WriteLine(checker.IsAcceptablePassword("1234567"));
            Console.WriteLine(checker.IsAcceptablePassword("1234567A"));
        }
    }
}
