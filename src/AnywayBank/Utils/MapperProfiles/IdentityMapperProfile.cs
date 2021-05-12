using System;
using AutoMapper;
using Data.Commands.Identity;
using Data.Models.InternalModels.EntityModels.Identity;
using Database.Entities.Identity;

namespace AnywayBank.Utils.MapperProfiles
{
    public class IdentityMapperProfile : Profile
    {
        public IdentityMapperProfile()
        {
            CreateMap<User, UserModel>()
                .ForMember(_ => _.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(_ => _.Username, opt => opt.MapFrom(s => s.Username))
                .ForMember(_ => _.Password, opt => opt.MapFrom(s => s.Password))
                .ForMember(_ => _.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(_ => _.RegistrationTime, opt => opt.MapFrom(s => s.RegistrationTime));
            CreateMap<UserModel, User>()
                .ForMember(_ => _.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(_ => _.Username, opt => opt.MapFrom(s => s.Username))
                .ForMember(_ => _.Password, opt => opt.MapFrom(s => s.Password))
                .ForMember(_ => _.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(_ => _.RegistrationTime, opt => opt.MapFrom(s => s.RegistrationTime));

            CreateMap<Person, PersonModel>()
                .ForMember(_ => _.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(_ => _.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(_ => _.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(_ => _.Birthday, opt => opt.MapFrom(s => s.Birthday))
                .ForMember(_ => _.User, opt => opt.MapFrom(s => s.User))
                .ForMember(_ => _.BankProfile, opt => opt.MapFrom(s => s.BankProfile));
            CreateMap<PersonModel, Person>()
                .ForMember(_ => _.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(_ => _.FirstName, opt => opt.MapFrom(s => s.FirstName))
                .ForMember(_ => _.LastName, opt => opt.MapFrom(s => s.LastName))
                .ForMember(_ => _.Birthday, opt => opt.MapFrom(s => s.Birthday))
                .ForMember(_ => _.User, opt => opt.MapFrom(s => s.User))
                .ForMember(_ => _.BankProfile, opt => opt.MapFrom(s => s.BankProfile));

            CreateMap<RegistrationCommand, UserModel>()
                .ForMember(_ => _.Username, opt => opt.MapFrom(s => s.Username))
                .ForMember(_ => _.Password, opt => opt.MapFrom(s => s.Password))
                .ForMember(_ => _.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(_ => _.RegistrationTime, opt => opt.MapFrom(s => DateTime.UtcNow));
        }
    }
}