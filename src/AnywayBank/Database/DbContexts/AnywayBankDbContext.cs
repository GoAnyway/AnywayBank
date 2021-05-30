using Database.Entities.Core;
using Database.Entities.Core.Bank;
using Microsoft.EntityFrameworkCore;

namespace Database.DbContexts
{
    public sealed class AnywayBankDbContext : DbContext
    {
        public AnywayBankDbContext(DbContextOptions<AnywayBankDbContext> options)
            : base(options) =>
            Database.EnsureCreated();

        public DbSet<Person> Persons { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<BankProfile> BankProfiles { get; set; }
    }
}