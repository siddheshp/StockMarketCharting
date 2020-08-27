using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StckMarket.Models
{
    public class StockExchange
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        //navigation property
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<StockPrice> StockPrices { get; set; }
        public virtual IPODetail IPODetail { get; set; }
    }
}