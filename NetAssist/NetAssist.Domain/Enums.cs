namespace NetAssist.Domain
{
    public enum CommandTypeOption
    {
        Added = 1,
        Updated = 2,
        Removed = 3
    }

    public enum SerializePropertiesOption
    {
        All, //all properties
        ExcludeIgnored, //all properties by those set to be ignored
        OnlyIncluded, //only properties set to be included,
        OnlyIncludedExplicit //only included properties, designed to be explicitly targeted
    }

    public enum SortDirectionOption
    {
        Ascending,
        Descending
    }
}
