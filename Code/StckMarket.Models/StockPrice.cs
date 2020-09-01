using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StckMarket.Models
{
    public class StockPrice
    {
        public int Id { get; set; }
        [Required]
        public decimal CurrentPrice { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string Time { get; set; }
        //np
        [Required]
        public virtual CompanyStockExchange CompanyStockExchange { get; set; }
        //public virtual Company Company { get; set; }
        //public virtual StockExchange StockExchange { get; set; }
        ////foreign keys
        //public int CompanyId { get; set; }
        ////[ForeignKey("StockExchange")]
        //public int StockExchangeId { get; set; }
    }
}
