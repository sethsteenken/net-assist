using NetAssist.Validation;

namespace NetAssist.Domain
{
    public class QueryResult<T>
    {
        protected QueryResult() { }

        protected QueryResult(bool succeeded) : this(succeeded, succeeded ? "Success" : "Failed")
        {

        }

        protected QueryResult(bool succeeded, string message)
        {
            Succeeded = succeeded;
            Message = message;
        }

        public QueryResult(bool succeeded, T data) : this(succeeded, data, succeeded ? "Success" : "Failed")
        {

        }

        public QueryResult(bool succeeded, T data, string message)
        {
            Data = data;
            Succeeded = succeeded;
            Message = message;
        }

        public QueryResult(BrokenRulesList brokenRules)
        {
            Succeeded = brokenRules.Count == 0;
            BrokenRules = brokenRules ?? new BrokenRulesList();
            Message = Succeeded ? "Success" : string.IsNullOrWhiteSpace(BrokenRules.Message) ? "Failed" : BrokenRules.Message;
        }

        public bool Succeeded { get; protected set; }
        public string Message { get; protected set; }
        public T Data { get; protected set; }
        public bool DataWasFound { get; protected set; } = true;

        public BrokenRulesList BrokenRules { get; protected set; } = new BrokenRulesList();

        public static QueryResult<T> NotFound() => new QueryResult<T>(false) { DataWasFound = false };
        public static QueryResult<T> NotFound(string message) => new QueryResult<T>(false, message) { DataWasFound = false };
        public static QueryResult<T> Success(T data) => new QueryResult<T>(true, data);
        public static QueryResult<T> Fail(BrokenRulesList brokenRules) => new QueryResult<T>(brokenRules);
        public static QueryResult<T> Fail(ValidationRule rule) => new QueryResult<T>(new BrokenRulesList(rule));
    }
}
