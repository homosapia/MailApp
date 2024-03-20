using Microsoft.EntityFrameworkCore;
using PostalService.Models;

namespace PostalService.DataBase
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
        {
        }

        public DbSet<СompanyMember> Members { get; set; }
        public DbSet<Writing> Writings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
