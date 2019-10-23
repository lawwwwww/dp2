﻿// <auto-generated />
using System;
using Cafe_POS_Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Cafe_POS_Application.Migrations
{
    [DbContext(typeof(DbContextModel))]
    [Migration("20191023050250_CafePos")]
    partial class CafePos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Cafe_POS_Application.Models.Employee", b =>
                {
                    b.Property<int>("EmpID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(30)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<string>("ContactInfo");

                    b.Property<string>("Email");

                    b.Property<string>("EmpName");

                    b.Property<string>("Gender");

                    b.Property<DateTime>("HireDate");

                    b.Property<string>("Password");

                    b.Property<string>("Role");

                    b.HasKey("EmpID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Cafe_POS_Application.Models.Inventory", b =>
                {
                    b.Property<string>("FoodCode")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(30);

                    b.Property<string>("DishName");

                    b.Property<string>("Drinks");

                    b.Property<int>("Quantity");

                    b.HasKey("FoodCode");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("Cafe_POS_Application.Models.Menu", b =>
                {
                    b.Property<string>("FoodCode")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(30);

                    b.Property<string>("Description");

                    b.Property<string>("DishName");

                    b.Property<string>("Drinks");

                    b.Property<double>("Price");

                    b.HasKey("FoodCode");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("Cafe_POS_Application.Models.Order", b =>
                {
                    b.Property<int>("OrderNo")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(30)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("EmpName");

                    b.Property<string>("FoodCode");

                    b.Property<int>("Quantity");

                    b.Property<string>("Size");

                    b.Property<int>("TableNo");

                    b.HasKey("OrderNo");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Cafe_POS_Application.Models.Payment", b =>
                {
                    b.Property<int>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(30)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount");

                    b.Property<double>("Balance");

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("OrderDetails");

                    b.Property<int>("OrderNo");

                    b.Property<double>("Price");

                    b.Property<int>("Quantity");

                    b.HasKey("TransactionID");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Cafe_POS_Application.Models.Tables", b =>
                {
                    b.Property<int>("TableNo")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(30)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Reservation");

                    b.Property<DateTime>("ReservationDate");

                    b.Property<string>("Status");

                    b.HasKey("TableNo");

                    b.ToTable("Table");
                });

            modelBuilder.Entity("Cafe_POS_Application.Models.TransactionLog", b =>
                {
                    b.Property<int>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(30)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime");

                    b.Property<string>("EmpName");

                    b.Property<int?>("EmployeeEmpID");

                    b.Property<string>("OrderDetails");

                    b.Property<int>("OrderNo");

                    b.Property<string>("PaymentMethod");

                    b.Property<double>("Price");

                    b.Property<int>("Quantity");

                    b.Property<int>("TableNo");

                    b.HasKey("TransactionID");

                    b.HasIndex("EmployeeEmpID");

                    b.HasIndex("TableNo");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Cafe_POS_Application.Models.TransactionLog", b =>
                {
                    b.HasOne("Cafe_POS_Application.Models.Employee", "Employee")
                        .WithMany("TransactionLog")
                        .HasForeignKey("EmployeeEmpID");

                    b.HasOne("Cafe_POS_Application.Models.Tables", "Tables")
                        .WithMany("TransactionLog")
                        .HasForeignKey("TableNo")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}