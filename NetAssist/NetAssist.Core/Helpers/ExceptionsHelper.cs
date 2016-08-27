using System;

namespace NetAssist
{
    public class ExceptionsHelper
    {
        public static string GetTrueMessage(Exception ex)
        {
            return GetActualException(ex).Message;
        }

        private static Exception GetActualException(Exception ex)
        {
            if (ex.InnerException != null)
                return GetActualException(ex.InnerException);
            else
                return ex;
        }
    }
}
