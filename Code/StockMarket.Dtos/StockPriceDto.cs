using System;
using System.ComponentModel.DataAnnotations;

namespace StockMarket.Dtos
{
    public class StockPriceDto
    {
        public int Id { get; set; } 
        [Required]
        public decimal CurrentPrice { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public string StockExchangeCode { get; set; } 
    }
}
