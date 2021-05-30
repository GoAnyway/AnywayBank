using AutoMapper;
using CommonData.UtilModels.ErrorModels;
using CommonDatabase.BaseEntities;
using CommonDataManager.BaseRepositories;
using Database.DbContexts;

namespace DataManager.Repositories
{
    public class IdentityRepository<TEntity> : BaseRepository<TEntity, IdentityDbContext, DefaultErrorModel>,
        IIdentityRepository<TEntity>
        where TEntity : BaseEntity
    {
        public IdentityRepository(IdentityDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}