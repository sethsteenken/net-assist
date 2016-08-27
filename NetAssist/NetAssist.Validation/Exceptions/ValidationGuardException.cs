using System;

namespace NetAssist.Validation
{
    [Serializable]
    public class ValidationGuardException : Exception
    {
        public ValidationGuardException() { }
        public ValidationGuardException(string message) : base(message) { }
        public ValidationGuardException(string message, Exception inner) : base(message, inner) { }
        protected ValidationGuardException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
