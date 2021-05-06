using AutoMapper;
using Database.Entities.Core.Bank;
using Models.InternalModels.EntityModels.Core;

namespace AnywayBank.Utils.MapperProfiles
{
    public class BankMapperProfile : Profile
    {
        public BankMapperProfile()
        {
            CreateMap<BankProfile, BankProfileModel>()
                .ForMember(_ => _.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(_ => _.BankAccounts, opt => opt.MapFrom(s => s.BankAccounts))
                .ForMember(_ => _.Person, opt => opt.MapFrom(s => s.Person));
            CreateMap<BankProfileModel, BankProfile>()
                .ForMember(_ => _.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(_ => _.BankAccounts, opt => opt.MapFrom(s => s.BankAccounts))
                .ForMember(_ => _.PersonId, opt =>
                {
                    opt.Condition(s => s.Person != null);
                    opt.MapFrom(s => s.Person.Id);
                })
                .ForMember(_ => _.Person, opt => opt.MapFrom(s => s.Person));

            CreateMap<BankAccount, BankAccountModel>()
                .ForMember(_ => _.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(_ => _.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(_ => _.Number, opt => opt.MapFrom(s => s.Number))
                .ForMember(_ => _.Balance, opt => opt.MapFrom(s => s.Balance))
                .ForMember(_ => _.OverdraftLimit, opt => opt.MapFrom(s => s.OverdraftLimit))
                .ForMember(_ => _.CreationTime, opt => opt.MapFrom(s => s.CreationTime))
                .ForMember(_ => _.EndTime, opt => opt.MapFrom(s => s.EndTime))
                .ForMember(_ => _.BankProfile, opt => opt.MapFrom(s => s.BankProfile));
            CreateMap<BankAccountModel, BankAccount>()
                .ForMember(_ => _.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(_ => _.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(_ => _.Number, opt => opt.MapFrom(s => s.Number))
                .ForMember(_ => _.Balance, opt => opt.MapFrom(s => s.Balance))
                .ForMember(_ => _.OverdraftLimit, opt => opt.MapFrom(s => s.OverdraftLimit))
                .ForMember(_ => _.CreationTime, opt => opt.MapFrom(s => s.CreationTime))
                .ForMember(_ => _.EndTime, opt => opt.MapFrom(s => s.EndTime))
                .ForMember(_ => _.BankProfileId, opt =>
                {
                    opt.Condition(s => s.BankProfile != null);
                    opt.MapFrom(s => s.BankProfile.Id);
                })
                .ForMember(_ => _.BankProfile, opt => opt.MapFrom(s => s.BankProfile));
        }
    }
}
