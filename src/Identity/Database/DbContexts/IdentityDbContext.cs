using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Database.DbContexts
{
    public sealed class IdentityDbContext : DbContext
    {
        public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
            : base(options) =>
            Database.Migrate();

        public DbSet<User> Users { get; set; }
    }
}
