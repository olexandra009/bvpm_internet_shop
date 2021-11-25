using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DataShopEntityFramework.Entities
{
    public partial class ShopDBContext : DbContext
    {
        public ShopDBContext()
        {
        }

        public ShopDBContext(DbContextOptions<ShopDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("host=ec2-54-171-25-232.eu-west-1.compute.amazonaws.com;port=5432;database=d55h043t1abs2m;user id=yxijsspazmfiub; password=2ab4c65abc76feb2580b0f9a3bb615dc3f8292ecde944c9090d733bffa94f313;Pooling=true;SSLMode=Require; TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.HasIndex(e => e.Id, "category_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Description)
                    .HasColumnType("character varying")
                    .HasColumnName("description");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.HasIndex(e => e.Id, "orders_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

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
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("order_detail");

                entity.HasIndex(e => e.Id, "order_detail_id_order_detail_uindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('order_detail_id_order_detail_seq'::regclass)");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.IdOrder).HasColumnName("id_order");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.HasIndex(e => e.Id, "products_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

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
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.ToTable("reviews");

                entity.HasIndex(e => e.Id, "reviews_id_uindex")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");

                entity.Property(e => e.Stars).HasColumnName("stars");

                entity.Property(e => e.Text)
                    .HasColumnType("character varying")
                    .HasColumnName("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
