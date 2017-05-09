using System;

namespace NetAssist.Domain
{
    public class CommandDateOptional : ValueObject<CommandDateOptional>
    {
        protected CommandDateOptional() { }

        public CommandDateOptional(int userId) : this(userId, DateTime.UtcNow)
        {
        }

        public CommandDateOptional(int userId, DateTime date)
        {
            UserId = userId;
            Date = date;
        }

        public int? UserId { get; private set; }
        public DateTime? Date { get; private set; }

        public static CommandDateOptional Empty => new CommandDateOptional();
    }
}
