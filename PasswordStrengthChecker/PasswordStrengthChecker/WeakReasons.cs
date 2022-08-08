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
    }
}