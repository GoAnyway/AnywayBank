using System;

namespace Models.BaseEntityModels
{
    public abstract class BaseEntityModel : IEntityModel<Guid>
    {
        public Guid Id { get; set; }
    }
}