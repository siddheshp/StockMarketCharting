﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockMarket.AdminService.Models;

namespace StockMarket.AdminService.Migrations
{
    [DbContext(typeof(AdminContext))]
    [Migration("20200901052244_addDbSet")]
    partial class addDbSet
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StckMarket.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompayName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("StckMarket.Models.CompanyStockExchange", b =>
                {
                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("StockExchangeCode")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("CompanyId", "StockExchangeCode");

                    b.HasIndex("StockExchangeCode");

                    b.ToTable("CompanyStockExchanges");
                });

            modelBuilder.Entity("StckMarket.Models.IPODetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<decimal>("PricePerShare")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("StockExchangeCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("StockExchangeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId")
                        .IsUnique();

                    b.HasIndex("StockExchangeCode")
                        .IsUnique()
                        .HasFilter("[StockExchangeCode] IS NOT NULL");

                    b.ToTable("IPODetails");
                });

            modelBuilder.Entity("StckMarket.Models.StockExchange", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("StockExchanges");
                });

            modelBuilder.Entity("StckMarket.Models.StockPrice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int?>("CompanyStockExchangeCompanyId")
                        .HasColumnType("int");

                    b.Property<string>("CompanyStockExchangeStockExchangeCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("CurrentPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StockExchangeCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Time")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("StockExchangeCode");

                    b.HasIndex("CompanyStockExchangeCompanyId", "CompanyStockExchangeStockExchangeCode");

                    b.ToTable("StockPrices");
                });

            modelBuilder.Entity("StckMarket.Models.CompanyStockExchange", b =>
                {
                    b.HasOne("StckMarket.Models.Company", "Company")
                        .WithMany("CompanyStockExchanges")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StckMarket.Models.StockExchange", "StockExchange")
                        .WithMany("CompanyStockExchanges")
                        .HasForeignKey("StockExchangeCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StckMarket.Models.IPODetail", b =>
                {
                    b.HasOne("StckMarket.Models.Company", "Company")
                        .WithOne("IPODetail")
                        .HasForeignKey("StckMarket.Models.IPODetail", "CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StckMarket.Models.StockExchange", "StockExchange")
                        .WithOne("IPODetail")
                        .HasForeignKey("StckMarket.Models.IPODetail", "StockExchangeCode");
                });

            modelBuilder.Entity("StckMarket.Models.StockPrice", b =>
                {
                    b.HasOne("StckMarket.Models.Company", null)
                        .WithMany("StockPrices")
                        .HasForeignKey("CompanyId");

                    b.HasOne("StckMarket.Models.StockExchange", null)
                        .WithMany("StockPrices")
                        .HasForeignKey("StockExchangeCode");

                    b.HasOne("StckMarket.Models.CompanyStockExchange", "CompanyStockExchange")
                        .WithMany()
                        .HasForeignKey("CompanyStockExchangeCompanyId", "CompanyStockExchangeStockExchangeCode");
                });
#pragma warning restore 612, 618
        }
    }
}
