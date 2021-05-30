using AutoMapper;
using Data.Models.EntityModels.Core;
using Database.Entities.Core.Bank;

namespace AnywayBankApi.Utils.MapperProfiles
{
    public class BankMapperProfile : Profile
    {
        public BankMapperProfile()
        {
            CreateMap<BankProfile, BankProfileModel>()
                .ForMember(_ => _.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(_ => _.BankAccounts, opt => opt.MapFrom(s => s.BankAccounts));
            CreateMap<BankProfileModel, BankProfile>()
                .ForMember(_ => _.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(_ => _.BankAccounts, opt => opt.MapFrom(s => s.BankAccounts));

            CreateMap<BankAccount, BankAccountModel>()
                .ForMember(_ => _.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(_ => _.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(_ => _.Number, opt => opt.MapFrom(s => s.Number))
                .ForMember(_ => _.Balance, opt => opt.MapFrom(s => s.Balance))
                .ForMember(_ => _.OverdraftLimit, opt => opt.MapFrom(s => s.OverdraftLimit))
                .ForMember(_ => _.CreationTime, opt => opt.MapFrom(s => s.CreationTime))
                .ForMember(_ => _.EndTime, opt => opt.MapFrom(s => s.EndTime));
            CreateMap<BankAccountModel, BankAccount>()
                .ForMember(_ => _.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(_ => _.Type, opt => opt.MapFrom(s => s.Type))
                .ForMember(_ => _.Number, opt => opt.MapFrom(s => s.Number))
                .ForMember(_ => _.Balance, opt => opt.MapFrom(s => s.Balance))
                .ForMember(_ => _.OverdraftLimit, opt => opt.MapFrom(s => s.OverdraftLimit))
                .ForMember(_ => _.CreationTime, opt => opt.MapFrom(s => s.CreationTime))
                .ForMember(_ => _.EndTime, opt => opt.MapFrom(s => s.EndTime));
        }
    }
}