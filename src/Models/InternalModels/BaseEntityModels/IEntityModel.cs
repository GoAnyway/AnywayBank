﻿using System;

namespace Models.InternalModels.BaseEntityModels
{
    public interface IEntityModel<TKey>
        where TKey : struct, IEquatable<TKey>
    {
        TKey Id { get; set; }
    }
}