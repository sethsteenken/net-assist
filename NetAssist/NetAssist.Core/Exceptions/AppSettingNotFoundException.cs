using System;

namespace NetAssist
{
    [Serializable]
    public class AppSettingNotFoundException : Exception
    {
        public AppSettingNotFoundException() { }
        public AppSettingNotFoundException(string key) : base(string.Format("The constant setting key \"{0}\" was not found.", key)) { }
        public AppSettingNotFoundException(string key, Exception inner) : base(string.Format("The constant setting key \"{0}\" was not found.", key), inner) { }
        protected AppSettingNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        { }
    }
}
