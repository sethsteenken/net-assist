﻿using System;

namespace NetAssist
{
    public static class TypeExtensions
    {
        public static bool HasDefaultConstructor(this Type type)
        {
            return type?.GetConstructor(Type.EmptyTypes) != null;
        }
    }
}
