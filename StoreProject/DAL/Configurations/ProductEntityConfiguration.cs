using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreProject.Api.DAL.Entities;
using System.Reflection.Emit;

namespace StoreProject.Api.DAL.Configurations
{
    public sealed class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()       // Not null
                .HasColumnType("nvarchar")
                .HasMaxLength(300);

            builder.Property(e => e.Description)
                .HasColumnType("nvarchar")
                .HasMaxLength(500);

            builder.Property(e => e.CategoryId)
                .IsRequired()
                .HasColumnType("uniqueidentifier");

            builder.HasIndex(e => e.CategoryId); // для добавления индекса. Если индекс более одного поля то это (e => () => new {e.CategoryId})
        }
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(500);

            builder.Property(e => e.IsAdmin)
               .HasColumnType("bit");

        }
    }
}
