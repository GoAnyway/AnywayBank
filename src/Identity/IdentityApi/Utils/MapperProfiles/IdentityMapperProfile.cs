using System;
using AutoMapper;
using CommonData.Messages;
using Data.Commands;
using Data.Models.EntityModels;
using Data.Responses;
using Database.Entities;

namespace IdentityApi.Utils.MapperProfiles
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

            CreateMap<RegistrationCommand, UserModel>()
                .ForMember(_ => _.Username, opt => opt.MapFrom(s => s.Username))
                .ForMember(_ => _.Password, opt => opt.MapFrom(s => s.Password))
                .ForMember(_ => _.Email, opt => opt.MapFrom(s => s.Email))
                .ForMember(_ => _.RegistrationTime, opt => opt.MapFrom(s => DateTime.UtcNow));

            CreateMap<UserModel, UserRegisteredMessage>()
                .ForMember(_ => _.UserId, opt => opt.MapFrom(s => s.Id));

            CreateMap<UserModel, UserResponse>()
                .ForMember(_ => _.Username, opt => opt.MapFrom(s => s.Username));
        }
    }
}