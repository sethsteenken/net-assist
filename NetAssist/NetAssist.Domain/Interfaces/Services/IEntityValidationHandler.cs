using NetAssist.Validation;
using System;
using System.Collections.Generic;

namespace NetAssist.Domain
{
    public interface IEntityValidationHandler
    {
        bool IsInvalidEntity(Exception ex);
        IList<EntityDataStoreValidationError> GetEntityValidationErrors(Exception ex);
        string BuildFriendlyValidationErrors(IList<EntityDataStoreValidationError> errors);
    }
}
