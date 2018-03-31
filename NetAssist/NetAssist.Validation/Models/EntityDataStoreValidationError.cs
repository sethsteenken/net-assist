using NetAssist.Validation.Models;

namespace NetAssist.Validation
{
    public class EntityDataStoreValidationError : PropertyValidationRule
    {        
        public EntityDataStoreValidationError(string entityType, string propertyName, string errorMessage) : base (propertyName, errorMessage)
        {
            EntityType = entityType;
            ErrorMessage = errorMessage;
        }

        public string EntityType { get; private set; }
        public string PropertyName => Name;
        public string ErrorMessage { get; private set; }

        public override string Message => $"{PropertyName} is invalid. {ErrorMessage}";

        public override string ToString()
        {
            return $"Entity: {EntityType}. Invalid Property: {PropertyName}. Message: {ErrorMessage}";
        }
    }
}
