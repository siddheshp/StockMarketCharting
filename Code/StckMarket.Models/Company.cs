using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StckMarket.Models
{
    public class Company
    {
        public Company()
        {
            CompanyStockExchanges = new HashSet<CompanyStockExchange>();
        }
        public int Id { get; set; }
        [Required]
        public string CompayName { get; set; }
        public virtual ICollection<CompanyStockExchange> CompanyStockExchanges { get; set; }
        public virtual IPODetail IPODetail { get; set; }
        //public virtual ICollection<StockPrice> StockPrices { get; set; }
    }
}