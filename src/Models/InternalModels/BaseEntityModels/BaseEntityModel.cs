using System;

namespace Models.InternalModels.BaseEntityModels
{
    public abstract class BaseEntityModel : IEntityModel<Guid>
    {
        public Guid Id { get; set; }
    }
}