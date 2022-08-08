namespace PasswordStrengthChecker
{
    public class WeakReasons
    {
        public static readonly int TYPE_LENGTH = 1;
        public static readonly int TYPE_ALPHABET = 2;
        public static readonly int TYPE_DIGITS = 3;
        public static readonly int TYPE_SPECIAL = 4;

        public int Type { get; set; }
    }
}