using System;
using System.ComponentModel.DataAnnotations.Schema;
using Database.BaseEntities;

namespace Database.Entities.Identity
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationTime { get; set; }

        [ForeignKey(nameof(Person))] public Guid? PersonId { get; set; }
        public Person Person { get; set; }
    }
}