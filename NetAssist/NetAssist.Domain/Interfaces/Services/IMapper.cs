using System;

namespace NetAssist.Domain
{
    public interface IMapper
    {
        TDestination Map<TDestination>(object source);
        TDestination Map<TSource, TDestination>(TSource source);
        bool Exists<TSource, TDestination>();
        bool Exists(Type source, Type destination);
    }
}
