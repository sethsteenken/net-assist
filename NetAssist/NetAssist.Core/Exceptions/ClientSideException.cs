using System;

namespace NetAssist
{
    [Serializable]
    public class ClientSideException : Exception
    {
        public ClientSideException() { }
        public ClientSideException(string message) : base(message) { }
        public ClientSideException(string message, Exception inner) : base(message, inner) { }
        protected ClientSideException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        { }
    }
}
