using System;

namespace NetAssist.Domain
{
    public class CommandDate : CommandDate<int> { }

    public class CommandDate<T> : ValueObject<CommandDate<T>>
    {
        protected CommandDate() { }

        public CommandDate(T userId) : this (userId, DateTime.UtcNow)
        {

        }

        public CommandDate(T userId, DateTime date)
        {
            UserId = userId;
            Date = date;
        }

        public T UserId { get; private set; }
        public DateTime Date { get; private set; }
    }
}
