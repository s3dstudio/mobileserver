using Microsoft.EntityFrameworkCore;
using mobileserver.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mobileserver.DAL
{
    public class PostgreSqlContext : DbContext
    {
        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : base(options)
        {
        }

        public DbSet<Food> Food { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Food>()
                .HasKey("idfood");

        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
