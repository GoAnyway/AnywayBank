using AutoMapper;
using CommonData.UtilModels.ErrorModels;
using CommonDatabase.BaseEntities;
using CommonDataManager.BaseRepositories;
using Database.DbContexts;

namespace DataManager.Repositories
{
    public class AnywayBankRepository<TEntity> : BaseRepository<TEntity, AnywayBankDbContext, DefaultErrorModel>,
        IAnywayBankRepository<TEntity>
        where TEntity : BaseEntity
    {
        public AnywayBankRepository(AnywayBankDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}