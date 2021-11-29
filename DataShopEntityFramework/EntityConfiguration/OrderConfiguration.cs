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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> entity)
        {
            entity.ToTable("orders");

            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Address)
                .HasColumnType("character varying")
                .HasColumnName("address");

            entity.Property(e => e.ClientEmail)
                .HasColumnType("character varying")
                .HasColumnName("client_email");

            entity.Property(e => e.ClientName)
                .HasColumnType("character varying")
                .HasColumnName("client_name");

            entity.Property(e => e.ClientPhoneNum)
                .HasColumnType("character varying")
                .HasColumnName("client_phone_num");

            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");

            entity.HasMany(o => o.Details)
                .WithOne(p => p.Order)
                .HasForeignKey(p => p.IdOrder)
                .OnDelete(DeleteBehavior.Cascade).IsRequired(false);
        }
    }
}
