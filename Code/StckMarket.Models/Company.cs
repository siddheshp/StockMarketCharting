using System.Collections;
using System.Collections.Generic;

namespace StckMarket.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string CompayName { get; set; }
        public virtual StockExchange StockExchange { get; set; }
        public virtual IPODetail IPODetail { get; set; }
        public virtual ICollection<StockPrice> StockPrices { get; set; }
    }
}