using System;

namespace NetAssist.Domain
{
    public interface ISerializer
    {
        T Deserialize<T>(string serializedValue) where T : class;
        object Deserialize(string serializedValue, Type type);
        string Serialize(object value);
        string SerializeOnly(object value, params SerializeAttribute[] onlyAttributes);
        string SerializeAllBut(object value, params SerializeAttribute[] ignoreAttributes);
    }
}
