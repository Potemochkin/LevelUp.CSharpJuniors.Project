using Microsoft.EntityFrameworkCore;
using StoreProject.Api.DAL.Configurations;
using StoreProject.Api.DAL.Entities;

namespace StoreProject.Api.DAL
{
    public sealed class ProductsDbContext : DbContext // Структура БД
    {
        public DbSet<ProductEntity>? Products { get; set; } //Тут наши таблицы Это таблица продектс
        public DbSet<UserEntity>? Users { get; set; }

        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options) 
        {         
          //  Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfiguration(new ProductEntityConfiguration());
        } 
    }
}
