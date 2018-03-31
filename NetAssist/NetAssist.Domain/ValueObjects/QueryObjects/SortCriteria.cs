using NetAssist.Validation;

namespace NetAssist.Domain
{
    public class SortCriteria : ValueObject<SortCriteria>
    {
        protected SortCriteria() { }

        public SortCriteria(string sortBy) : this (sortBy, SortDirectionOption.Ascending)
        {

        }

        public SortCriteria(string sortBy, string direction) : 
            this (sortBy, direction == SortDirectionOption.Descending.ToFriendlyName() || direction == "desc" ? SortDirectionOption.Descending : SortDirectionOption.Ascending)
        {

        }

        public SortCriteria(string sortBy, SortDirectionOption direction)
        {
            Guard.Begin().IsNotNull(sortBy, nameof(sortBy)).Check();

            SortBy = sortBy;
            Direction = direction;
        }

        public string SortBy { get; private set; }
        public SortDirectionOption Direction { get; private set; }
        public string DirectionAbbr => Direction == SortDirectionOption.Ascending ? "asc" : "desc";

        public string QuerySortOperation => Direction == SortDirectionOption.Ascending ? "OrderBy" : "OrderByDescending";

        public static SortCriteria Create(string sortByProperty) => new SortCriteria(sortByProperty);
        public static SortCriteria DefaultByName => new SortCriteria("Name");
        public static SortCriteria DefaultById => new SortCriteria("Id");
    }
}
