using System;
using System.Collections.Generic;
using System.Text;

namespace NetAssist.Domain
{
    public abstract class SettingsBase : ISettings
    {
        private readonly IValueParser _parser;

        public SettingsBase(IValueParser parser)
        {
            _parser = parser;
        }

        protected IValueParser Parser => _parser;

        public virtual string Get(string key)
        {
            return Get(key, required: true);
        }

        public virtual string Get(string key, bool required)
        {
            return Get<string>(key, required);
        }

        public virtual string Get(string key, string defaultValue)
        {
            var value = Get(key, required: false);
            if (string.IsNullOrWhiteSpace(value))
                return defaultValue;
            return value;
        }

        public virtual T Get<T>(string key)
        {
            return Get<T>(key, required: true);
        }

        public virtual T Get<T>(string key, bool required)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentNullException(nameof(key));

            if (!TryGetBaseValue(key, out string value))
            {
                if (required)
                    throw new AppSettingNotFoundException(key);
                else
                    return default(T);
            }

            return _parser.Parse<T>(value);
        }

        public virtual T Get<T>(string key, T defaultValue)
        {
            if (!TryGetBaseValue(key, out string value))
                return defaultValue;

            return _parser.Parse<T>(value);
        }

        protected abstract bool TryGetBaseValue(string key, out string value);
    }
}
