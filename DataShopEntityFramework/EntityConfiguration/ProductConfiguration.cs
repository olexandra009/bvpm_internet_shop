using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataShopEntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataShopEntityFramework.EntityConfiguration
{
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.ToTable("products");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Amount).HasColumnName("amount");

            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");

            entity.Property(e => e.IdCategory).HasColumnName("id_category");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("character varying")
                .HasColumnName("name");

            entity.Property(e => e.Photo)
                .HasColumnType("character varying")
                .HasColumnName("photo");

            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasMany(o => o.Reviews)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.IdProduct)
                .OnDelete(DeleteBehavior.Cascade).IsRequired(false);

            entity.HasMany(o => o.Orders)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.IdProduct)
                .OnDelete(DeleteBehavior.Cascade).IsRequired(false);
        }
    }
}
