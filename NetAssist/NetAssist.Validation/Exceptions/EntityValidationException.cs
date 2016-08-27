using System;
using System.Collections.Generic;

namespace NetAssist.Validation
{
    [Serializable]
    public class EntityValidationException : ValidationException
    {
        public EntityValidationException(IReadOnlyList<EntityDataStoreValidationError> validationErrors) : this (validationErrors, null)
        {

        }

        public EntityValidationException(IReadOnlyList<EntityDataStoreValidationError> validationErrors, Exception innerException) : base(new BrokenRulesList(validationErrors), innerException)
        {

        }
    }
}
