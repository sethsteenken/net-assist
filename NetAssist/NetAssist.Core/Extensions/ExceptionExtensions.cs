using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetAssist
{
    public static class ExceptionExtensions
    {        
        public static Exception GetActualException(this Exception ex)
        {
            if (ex == null)
                return null;

            if (ex.InnerException != null)
                return GetActualException(ex.InnerException);
            else
                return ex;
        }
    }
}
