using Microsoft.EntityFrameworkCore;
using Site.Domain.Entities;
using Site.Infra.Mappings;

namespace Site.Infra.Context
{
    public class SiteContext : DbContext
    {
        public SiteContext()
        { }
        public SiteContext(DbContextOptions<SiteContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
        }
    }
}