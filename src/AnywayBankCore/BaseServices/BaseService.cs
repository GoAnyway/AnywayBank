using AutoMapper;
using DataManager.UnitsOfWork.AnywayBankUnitsOfWork;

namespace AnywayBankCore.BaseServices
{
    public abstract class BaseService : BaseService<IAnywayBankUnitOfWork>
    {
        protected BaseService(IAnywayBankUnitOfWork unitOfWork, IMapper mapper) 
            : base(unitOfWork, mapper)
        {
        }
    }

    public abstract class BaseService<TUnitOfWork>
    {
        protected readonly TUnitOfWork UnitOfWork;
        protected readonly IMapper Mapper;

        protected BaseService(TUnitOfWork unitOfWork, IMapper mapper)
        {
            UnitOfWork = unitOfWork;
            Mapper = mapper;
        }
    }
}