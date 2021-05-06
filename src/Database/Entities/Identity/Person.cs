﻿using System;
using Database.BaseEntities;

namespace Database.Entities.Identity
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }

        public virtual User User { get; set; }
    }
}