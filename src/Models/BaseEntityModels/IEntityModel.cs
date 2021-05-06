using System;

namespace Models.BaseEntityModels
{
    public interface IEntityModel<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}