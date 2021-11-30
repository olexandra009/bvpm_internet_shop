﻿// <auto-generated />
using System;
using DataShopEntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataShopEntityFramework.Migrations
{
    [DbContext(typeof(ShopDBContext))]
    partial class ShopDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("DataShopEntityFramework.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("character varying")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("category");
                });

            modelBuilder.Entity("DataShopEntityFramework.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("character varying")
                        .HasColumnName("address");

                    b.Property<string>("ClientEmail")
                        .HasColumnType("character varying")
                        .HasColumnName("client_email");

                    b.Property<string>("ClientName")
                        .HasColumnType("character varying")
                        .HasColumnName("client_name");

                    b.Property<string>("ClientPhoneNum")
                        .HasColumnType("character varying")
                        .HasColumnName("client_phone_num");

                    b.Property<double>("Cost")
                        .HasColumnType("double precision")
                        .HasColumnName("cost");

                    b.Property<string>("Description")
                        .HasColumnType("character varying")
                        .HasColumnName("description");

                    b.HasKey("Id");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("DataShopEntityFramework.Entities.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("double precision")
                        .HasColumnName("amount");

                    b.Property<int>("IdOrder")
                        .HasColumnType("integer")
                        .HasColumnName("id_order");

                    b.Property<int>("IdProduct")
                        .HasColumnType("integer")
                        .HasColumnName("id_product");

                    b.HasKey("Id");

                    b.HasIndex("IdOrder");

                    b.HasIndex("IdProduct");

                    b.ToTable("order_detail");
                });

            modelBuilder.Entity("DataShopEntityFramework.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double?>("Amount")
                        .HasColumnType("double precision")
                        .HasColumnName("amount");

                    b.Property<string>("Description")
                        .HasColumnType("character varying")
                        .HasColumnName("description");

                    b.Property<int>("IdCategory")
                        .HasColumnType("integer")
                        .HasColumnName("id_category");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("name");

                    b.Property<string>("Photo")
                        .HasColumnType("character varying")
                        .HasColumnName("photo");

                    b.Property<double?>("Price")
                        .HasColumnType("double precision")
                        .HasColumnName("price");

                    b.HasKey("Id");

                    b.HasIndex("IdCategory");

                    b.ToTable("products");
                });

            modelBuilder.Entity("DataShopEntityFramework.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("IdProduct")
                        .HasColumnType("integer")
                        .HasColumnName("id_product");

                    b.Property<string>("Name")
                        .HasColumnType("character varying")
                        .HasColumnName("name");

                    b.Property<int?>("Stars")
                        .HasColumnType("integer")
                        .HasColumnName("stars");

                    b.Property<string>("Text")
                        .HasColumnType("character varying")
                        .HasColumnName("text");

                    b.HasKey("Id");

                    b.HasIndex("IdProduct");

                    b.ToTable("reviews");
                });

            modelBuilder.Entity("DataShopEntityFramework.Entities.OrderDetail", b =>
                {
                    b.HasOne("DataShopEntityFramework.Entities.Order", "Order")
                        .WithMany("Details")
                        .HasForeignKey("IdOrder")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DataShopEntityFramework.Entities.Product", "Product")
                        .WithMany("Orders")
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DataShopEntityFramework.Entities.Product", b =>
                {
                    b.HasOne("DataShopEntityFramework.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("IdCategory")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Category");
                });

            modelBuilder.Entity("DataShopEntityFramework.Entities.Review", b =>
                {
                    b.HasOne("DataShopEntityFramework.Entities.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DataShopEntityFramework.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DataShopEntityFramework.Entities.Order", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("DataShopEntityFramework.Entities.Product", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
