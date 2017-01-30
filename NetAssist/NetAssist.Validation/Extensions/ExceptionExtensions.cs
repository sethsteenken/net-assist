using System;

namespace NetAssist.Validation
{
    public static class ExceptionExtensions
    {
        public static string GetFriendlyMessage(this Exception ex)
        {
            if (ex == null)
                return string.Empty;

            var trueException = ex.GetActualException();

            if (trueException is ValidationException)
                return (trueException as ValidationException).FriendlyMessage;
            else
                return trueException.Message;
        }
    }
}
