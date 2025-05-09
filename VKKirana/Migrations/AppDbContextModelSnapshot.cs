﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VKKirana.Data;

#nullable disable

namespace VKKirana.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("CustomerOrderProduct", b =>
                {
                    b.Property<Guid>("CustomerOrdersOrderId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("OrderItemsId")
                        .HasColumnType("char(36)");

                    b.HasKey("CustomerOrdersOrderId", "OrderItemsId");

                    b.HasIndex("OrderItemsId");

                    b.ToTable("CustomerOrderProduct");
                });

            modelBuilder.Entity("VKKirana.Entities.CustomerOrder", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateOnly>("OrderDate")
                        .HasColumnType("date");

                    b.Property<Guid?>("OrderStatusId")
                        .HasColumnType("char(36)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("OrderId");

                    b.HasIndex("OrderStatusId");

                    b.ToTable("CustomerOrders");
                });

            modelBuilder.Entity("VKKirana.Entities.OrderStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("OrderStatus");

                    b.HasData(
                        new
                        {
                            Id = new Guid("cb1a5dc1-4b47-48d6-866c-bcb123684ca1"),
                            Status = "Pending"
                        },
                        new
                        {
                            Id = new Guid("7e74aeb4-a430-43e5-a5d8-4e2b00a0979c"),
                            Status = "Processing"
                        },
                        new
                        {
                            Id = new Guid("c54496d8-8d2c-4ba3-8bfc-6afcbe8a3dcf"),
                            Status = "Delivered"
                        },
                        new
                        {
                            Id = new Guid("9cde19d5-eca6-4c86-8bce-fd4ae82ec5f2"),
                            Status = "Cancelled"
                        });
                });

            modelBuilder.Entity("VKKirana.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("product_id");

                    b.Property<string>("Categories")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("GETUTCDATE()");

                    MySqlPropertyBuilderExtensions.UseMySqlComputedColumn(b.Property<DateTime>("CreatedAt"));

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("product_name");

                    b.Property<double>("Price")
                        .HasPrecision(6, 2)
                        .HasColumnType("double");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Products", t =>
                        {
                            t.HasComment("A Product Table for Ecommerce Website");
                        });
                });

            modelBuilder.Entity("CustomerOrderProduct", b =>
                {
                    b.HasOne("VKKirana.Entities.CustomerOrder", null)
                        .WithMany()
                        .HasForeignKey("CustomerOrdersOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VKKirana.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("OrderItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VKKirana.Entities.CustomerOrder", b =>
                {
                    b.HasOne("VKKirana.Entities.OrderStatus", "OrderStatus")
                        .WithMany()
                        .HasForeignKey("OrderStatusId");

                    b.Navigation("OrderStatus");
                });
#pragma warning restore 612, 618
        }
    }
}
