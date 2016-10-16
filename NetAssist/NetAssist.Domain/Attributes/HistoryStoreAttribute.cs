using System;

namespace NetAssist.Domain
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    public class HistoryStoreAttribute : SerializeAttribute
    {
    }
}
