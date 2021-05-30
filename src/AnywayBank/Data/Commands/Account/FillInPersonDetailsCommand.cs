using System;
using System.ComponentModel.DataAnnotations;
using Data.BaseRequests;
using Data.Models.EntityModels.Core;

namespace Data.Commands.Account
{
    public class FillInPersonDetailsCommand : IAnywayBankRequest<PersonModel>
    {
        public Guid PersonId { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        public DateTime Birthday { get; set; }
    }
}