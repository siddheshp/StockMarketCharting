using Microsoft.EntityFrameworkCore;
using StckMarket.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminService.Models
{
    public class AdminContextDB : DbContext
    {
        public AdminContextDB([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected AdminContextDB()
        {
        }

        public virtual DbSet<StockPrice> StockPrices { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<IPODetail> IPODetails { get; set; }
        public virtual DbSet<StockExchange> StockExchanges { get; set; } 
    }
}
