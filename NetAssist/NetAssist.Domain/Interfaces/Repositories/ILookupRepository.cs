﻿using System.Collections.Generic;

namespace NetAssist.Domain
{
    public interface ILookupRepository<T> : IQueryRepository<T, int> where T : LookupEntity
    {
        IReadOnlyList<SelectItem> GetSelections();
        IReadOnlyList<TSelectType> GetSelections<TSelectType>() where TSelectType : SelectItem;
        T GetByName(string name);
    }
}
