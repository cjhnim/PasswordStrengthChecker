namespace PasswordStrengthChecker
{
    public enum WeakReasonType
    {
        Length,
        Alphabet,
        Digits,
        Special
    }

    public class WeakReasons
    {
        public WeakReasonType Type { get; set; }

        public override bool Equals(object obj)
        {
            return Type == ((WeakReasons)obj).Type;
        }

    }
}