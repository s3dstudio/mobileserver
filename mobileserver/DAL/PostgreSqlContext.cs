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
        public DbSet<foodscart> foodscart { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<AllBills> AllBills { get; set; }
        public DbSet<FoodsCartDetail> FoodsCartDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Food>()
                .HasKey("idfood");
            builder.Entity<Users>()
                .HasKey("idUsers");
            builder.Entity<foodscart>()
                .HasKey("idcart");
            builder.Entity<Notifications>()
                .HasKey("idnotification");
            builder.Entity<AllBills>()
                .HasKey("idCart");
            builder.Entity<FoodsCartDetail>()
                .HasKey("idfcdetail");

        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }
    }
}
