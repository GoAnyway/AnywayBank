using Database.Entities.Core.Bank;
using Database.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace Database.DbContexts
{
    public sealed class BankDbContext : DbContext
    {
        public BankDbContext(DbContextOptions<BankDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<BankProfile> BankProfiles { get; set; }
    }
}