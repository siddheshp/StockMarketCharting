using Microsoft.EntityFrameworkCore;
using StckMarket.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminService.Models
{
    public class AdminContext : DbContext
    {
        public AdminContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected AdminContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompanyStockExchange>()
                .HasKey(bc => new { bc.CompanyId, bc.StockExchangeCode });
            //modelBuilder.Entity<CompanyStockExchange>()
            //    .HasOne(bc => bc.Company)
            //    .WithMany(b => b.)
            //    .HasForeignKey(bc => bc.compa);
            //modelBuilder.Entity<CompanyStockExchange>()
            //    .HasOne(bc => bc.StockExchange)
            //    .WithMany(c => c.Companies)
            //    .HasForeignKey(bc => bc.);
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<StockPrice> StockPrices { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<IPODetail> IPODetails { get; set; }
        public virtual DbSet<StockExchange> StockExchanges { get; set; }
        public virtual DbSet<CompanyStockExchange> CompanyStockExchanges { get; set; }
    }
}
