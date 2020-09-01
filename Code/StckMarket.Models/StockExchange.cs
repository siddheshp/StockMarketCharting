using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StckMarket.Models
{
    public class StockExchange
    {
        public StockExchange()
        {
            CompanyStockExchanges = new HashSet<CompanyStockExchange>();
        }
        [Key]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        //navigation property
        public virtual ICollection<CompanyStockExchange> CompanyStockExchanges { get; set; }
        //public virtual ICollection<StockPrice> StockPrices { get; set; }
        public virtual IPODetail IPODetail { get; set; }
    }
}