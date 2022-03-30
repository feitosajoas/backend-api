using System;
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

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseMySql(
        //         @"server=localhost;user=root;password=root;database=sitedb;",
        //         new MySqlServerVersion(new Version(8, 0, 11))
        //     );
        // }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
        }
    }
}