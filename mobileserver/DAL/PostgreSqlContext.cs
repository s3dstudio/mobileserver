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
        public DbSet<Users> Users { get; set; }
        public DbSet<FoodsCart> FoodsCart { get; set; }
        public DbSet<Notifications> Notifications { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Food>()
                .HasKey("idfood");
            builder.Entity<Users>()
                .HasKey("idUsers");
            builder.Entity<FoodsCart>()
                .HasKey("idCart");
            builder.Entity<Notifications>()
                .HasKey("idnotification");

        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
