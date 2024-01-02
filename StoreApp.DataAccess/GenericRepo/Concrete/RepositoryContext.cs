using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StoreApp.Entities.Models;
using System.Reflection;

namespace StoreApp.DataAccess.GenericRepo.Concrete
{
    public class RepositoryContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }


        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
/* 
            modelBuilder.Entity<Product>().HasData(
               new Product() { ProductId = 1, CategoryId=2,ImageUrl= "/images/1.jpg",ProductName = "Computer", Price = 254 },
                new Product() { ProductId = 2, CategoryId = 2,ImageUrl= "/images/2.jpg",ProductName = "Phone", Price = 85 },
                new Product() { ProductId = 3, CategoryId = 1, ImageUrl="/images/3.jpg",ProductName = "Keyword", Price = 97 },
                new Product() { ProductId = 4, CategoryId = 1,ImageUrl= "/images/4.jpg",ProductName = "Mouse", Price = 42 }

                );

            modelBuilder.Entity<Category>().HasData(
                new Category() { CategoryId = 1, CategoryName = "Oyuncak" },
                new Category() { CategoryId = 2, CategoryName = "Teknoloji" }
                )
;*/
            

            // modelBuilder.ApplyConfiguration(new ProductConfig());
            // modelBuilder.ApplyConfiguration(new CategoryConfig());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}