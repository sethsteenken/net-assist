namespace NetAssist.Domain
{
    public enum SerializePropertiesOption
    {
        All, //all properties
        ExcludeIgnored, //all properties by those set to be ignored
        OnlyIncluded, //only properties set to be included,
        OnlyIncludedExplicit //only included properties, designed to be explicitly targeted
    }
}
