using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhoenixMerch.DataAccess.Conrete.EntityFraneworkCore.Maps;
using PhoenixMerch.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;


namespace PhoenixMerch.DataAccess.Conrete.EntityFraneworkCore.Context
{
    public class PhoenixMerchContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=EMIR_PC\\SQLEXPRESS;database=corepersonel;Initial Catalog=PhoenixMerchDb ;Trusted_Connection=true;TrustServerCertificate=True");
			base.OnConfiguring(optionsBuilder);
		}
		
		protected override void OnModelCreating(ModelBuilder builder)
        {
			builder.Entity<Product>().Property(p => p.Price).HasConversion<double>();
			builder.Entity<ProductOrder>().Property(p => p.Price).HasConversion<double>();
			builder.Entity<ProductOrder>().Property(po => po.TotalPrice).HasConversion<double>();
			builder.Entity<ProductOrder>().HasKey(x => new { x.OrderId, x.ProductId });
			builder.ApplyConfiguration(new CustomerMap());
            builder.ApplyConfiguration(new ProductMap());
            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new OrderMap());
            base.OnModelCreating(builder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
	}
}
