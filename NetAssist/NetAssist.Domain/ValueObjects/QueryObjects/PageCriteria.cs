using NetAssist.Validation;

namespace NetAssist.Domain
{
    public class PageCriteria : ValueObject<PageCriteria>
    {
        public PageCriteria(int size, int current)
        {
            Guard.Begin().IsGreaterThanZero(size, nameof(size)).IsGreaterThanZero(current, nameof(current)).Check();

            Size = size;
            Current = current;
        }

        public int Size { get; private set; }
        public int Current { get; private set; }

        public int Next => Current + 1;
        public int Prev => Current <= 1 ? 1 : Current - 1;
        public int CurrentIndex => (Current - 1);
        public int StartIndex => CurrentIndex * Size;
        public int EndIndex => StartIndex + Size;
        public int SizeAll => Current * Size;

        [SerializeIgnore]
        public static PageCriteria Default => new PageCriteria(25, 1);
    }
}
