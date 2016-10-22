using System;

namespace NetAssist.Domain
{
    public class CommandDate : CommandDate<int>
    {
        protected CommandDate() { }
        public CommandDate(int user) : base (user) { }
        public CommandDate(int user, DateTime date) : base (user, date) {  }
    }

    public class CommandDate<T> : ValueObject<CommandDate<T>>
    {
        protected CommandDate() { }

        public CommandDate(T user) : this (user, DateTime.UtcNow)
        {

        }

        public CommandDate(T user, DateTime date)
        {
            User = user;
            Date = date;
        }

        public T User { get; private set; }
        public DateTime Date { get; private set; }
    }
}
