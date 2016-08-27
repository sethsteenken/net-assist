using System;
using System.Collections.Generic;

namespace NetAssist.Validation
{
    public sealed class ValidationGuard
    {
        private List<Exception> exceptions;

        public ValidationGuard()
        {
            this.exceptions = new List<Exception>(1); // optimize for only having 1 exception
        }

        public IEnumerable<Exception> Exceptions
        {
            get { return this.exceptions; }
        }

        public ValidationGuard AddException(Exception ex)
        {
            lock (this.exceptions)
            {
                this.exceptions.Add(ex);
            }
            return this;
        }
    }
}
