using System;

namespace NetAssist.Validation
{
    [Serializable]
    public class ValidationGuardException : Exception
    {
        public ValidationGuardException() { }
        public ValidationGuardException(string message) : base(message) { }
        public ValidationGuardException(string message, Exception inner) : base(message, inner) { }
    }
}
