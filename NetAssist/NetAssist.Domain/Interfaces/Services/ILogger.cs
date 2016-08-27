using System;

namespace NetAssist.Domain
{
    public interface ILogger
    {
        Guid Error(Exception ex);
        void Error(string message);
        void Info(string message);
    }
}
