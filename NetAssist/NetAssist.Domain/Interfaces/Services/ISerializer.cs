using System;

namespace NetAssist.Domain
{
    public interface ISerializer
    {
        T Deserialize<T>(string serializedValue) where T : class;
        object Deserialize(string serializedValue, Type type);
        string Serialize(object value);
        string Serialize(object value, SerializePropertiesOption propertyAllowanceType);
    }
}
