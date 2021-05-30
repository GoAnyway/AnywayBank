using Data.Commands;
using Data.Models.EntityModels;
using Database.Entities;
using DataManager.Repositories;
using FluentValidation;
using Resources.IdentityCoreResources.Validators;

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
            RuleFor(_ => _.Password)
                .Equal(_ => _.PasswordConfirmation)
                .WithMessage(RegistrationCommandValidatorErrors.PasswordsMissmatch);

            RuleFor(_ => _.Username)
                .Must(IsUsernameUnique)
                .WithMessage(RegistrationCommandValidatorErrors.UsernameNotUnique);
        }

        private bool IsUsernameUnique(string username) =>
            !_userRepository.Any<UserModel>(_ => _.Username == username);
    }
}