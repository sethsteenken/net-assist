using NetAssist.Validation;

namespace NetAssist.Domain
{
    public class ResultListFilter : ValueObject<ResultListFilter>
    {
        public ResultListFilter(int page, int pageSize, string sortProperty) : this (page, pageSize, sortProperty, SortDirectionOption.Ascending.ToFriendlyName())
        {

        }

        public ResultListFilter(int page, int pageSize, string sortProperty, string sortDirection) : this (new PageCriteria(pageSize, page), new SortCriteria(sortProperty, sortDirection))
        {
      
        }

        public ResultListFilter(PageCriteria paging, SortCriteria sorting)
        {
            Guard.Begin().IsNotNull(paging, nameof(paging)).IsNotNull(sorting, nameof(sorting)).Check();
            Paging = paging;
            Sorting = sorting;
        }

        public PageCriteria Paging { get; private set; }
        public SortCriteria Sorting { get; private set; }

        public static ResultListFilter Default => new ResultListFilter(PageCriteria.Default, SortCriteria.DefaultByName);
        public static ResultListFilter None => null;
    }
}
