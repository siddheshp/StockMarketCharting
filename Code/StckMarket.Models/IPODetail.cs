using System;
using System.Collections.Generic;
using System.Text;

namespace StckMarket.Models
{
    public class IPODetail
    {
        public int Id { get; set; }
        public decimal PricePerShare { get; set; }
        public int CompanyId { get; set; }
        public int StockExchangeId { get; set; }
        public virtual Company Company { get; set; }
        public virtual StockExchange StockExchange { get; set; }
    } 
}
