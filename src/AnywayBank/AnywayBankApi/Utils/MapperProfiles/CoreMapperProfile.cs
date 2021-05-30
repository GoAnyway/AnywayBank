using AutoMapper;
using Data.Commands.Account;
using Data.Models.EntityModels.Core;
using Database.Entities.Core;

namespace AnywayBankApi.Utils.MapperProfiles
{
    public class CoreMapperProfile : Profile
    {
        public CoreMapperProfile()
        {
            CreateMap<Person, PersonModel>()
                .ForMember(_ => _.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(_ => _.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(_ => _.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(_ => _.Birthday, opt => opt.MapFrom(s => s.Birthday))
                .ForMember(_ => _.BankProfile, opt => opt.MapFrom(s => s.BankProfile));
            CreateMap<PersonModel, Person>()
                .ForMember(_ => _.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(_ => _.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(_ => _.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(_ => _.Birthday, opt => opt.MapFrom(s => s.Birthday))
                .ForMember(_ => _.BankProfile, opt => opt.MapFrom(s => s.BankProfile));

            CreateMap<FillInPersonDetailsCommand, PersonModel>()
                .ForMember(_ => _.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(_ => _.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(_ => _.Birthday, opt => opt.MapFrom(s => s.Birthday));

            CreateMap<CreatePersonCommand, PersonModel>()
                .ForMember(_ => _.Id, opt => opt.MapFrom(s => s.Message.UserId));
        }
    }
}