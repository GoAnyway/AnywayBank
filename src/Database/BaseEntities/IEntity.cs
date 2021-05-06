using System;

namespace Database.BaseEntities
{
    public interface IEntity<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}