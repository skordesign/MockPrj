using Microsoft.EntityFrameworkCore;
using MockPrj.Models;

namespace MockPrj.Data
{
    public class SIMSDbContext:DbContext
    {
        public SIMSDbContext(DbContextOptions<SIMSDbContext> options) : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        //add more table - dbset
        public DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            
        }
    }
}
