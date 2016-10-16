using System;

namespace NetAssist
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public class SerializeIgnoreAttribute : SerializeAttribute
    {
    }
}
