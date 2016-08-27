namespace NetAssist.Validation
{
    public class EntityDataStoreValidationError : ValidationRule
    {        
        public EntityDataStoreValidationError(string entityType, string propertyName, string errorMessage) : base ($"{entityType}-{propertyName}", errorMessage)
        {
            EntityType = entityType;
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
        }

        public string EntityType { get; private set; }
        public string PropertyName { get; private set; }
        public string ErrorMessage { get; private set; }

        public override string Message => $"{PropertyName} is invalid. {ErrorMessage}";

        public override string ToString()
        {
            return $"Entity: {EntityType}. Invalid Property: {PropertyName}. Message: {ErrorMessage}";
        }
    }
}
