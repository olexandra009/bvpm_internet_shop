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
    class OrderDetailConfiguration: IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> entity)
        {
            entity.ToTable("order_detail");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount").IsRequired();
            entity.Property(e => e.IdOrder).HasColumnName("id_order").IsRequired();
            entity.Property(e => e.IdProduct).HasColumnName("id_product").IsRequired();
        }
    }
}
