using Data.Commands;
using Data.Models.EntityModels;
using Database.Entities;
using DataManager.Repositories;
using FluentValidation;

namespace IdentityCore.Validators
{
    public class RegistrationCommandValidator : AbstractValidator<RegistrationCommand>
    {
        private readonly IIdentityRepository<User> _userRepository;

        public RegistrationCommandValidator(IIdentityRepository<User> userRepository)
        {
            _userRepository = userRepository;
            InitializeValidationRules();
        }

        private void InitializeValidationRules()
        {
            RuleFor(_ => _.Username)
                .Must(IsUsernameUnique)
                .WithMessage("Person with same Username already exists!");
        }

        private bool IsUsernameUnique(string username) =>
            !_userRepository.Any<UserModel>(_ => _.Username == username);
    }
}