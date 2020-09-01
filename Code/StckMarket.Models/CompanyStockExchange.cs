using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StckMarket.Models
{
    public class CompanyStockExchange
    {
        public Company Company { get; set; }
        public StockExchange StockExchange { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public string StockExchangeCode { get; set; } 
    }
}
