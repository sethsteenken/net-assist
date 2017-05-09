using System;

namespace NetAssist.Domain
{
    public class CommandDate : CommandDate<int>
    {
        protected CommandDate() { }
        public CommandDate(int userId) : base (userId) { }
        public CommandDate(int userId, DateTime date) : base (userId, date) {  }

        public static CommandDate Empty => new CommandDate();
    }

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
