using Microsoft.EntityFrameworkCore;
using StckMarket.Models;
using StockMarket.AdminService.Models;
using StockMarket.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AdminService.Repositories
{
    public class StockpriceRepository : IRepository<StockPriceDto>
    {
        private AdminContext context;
        public StockpriceRepository(AdminContext context)
        {
            this.context = context;
        }
        public bool Add(StockPriceDto entity)
        {
            try
            {
                var stockprice = new StockPrice
                {
                    CurrentPrice = entity.CurrentPrice,
                    Date = entity.DateTime.ToShortDateString(),
                    Time = entity.DateTime.ToShortTimeString(),
                    CompanyStockExchange = context.CompanyStockExchanges.Find(entity.CompanyId, entity.StockExchangeCode)
                    //Company = context.Companies.Find(entity.CompanyId),
                    //StockExchange = context.StockExchanges.Find(entity.StockExchangeCode)
                };
                context.StockPrices.Add(stockprice);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(StockPriceDto entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StockPriceDto> Get()
        {
            var stockprices = new List<StockPriceDto>();
            foreach (var stockPrice in context.StockPrices)
            {
                stockprices.Add(new StockPriceDto
                {
                    Id = stockPrice.Id,
                    CurrentPrice = stockPrice.CurrentPrice,
                    DateTime = DateTime.Parse(stockPrice.Date + ' ' + stockPrice.Time),
                    CompanyId = stockPrice.CompanyStockExchange.CompanyId,
                    StockExchangeCode = stockPrice.CompanyStockExchange.StockExchangeCode
                });
            }

            return stockprices;
        }

        public StockPriceDto Get(object key)
        {
            throw new NotImplementedException();
        }

        public bool Update(StockPriceDto entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StockPrice> Get(DateTime fromDate, DateTime to,
            int companyId, string stockExchangeCode)
        {
            var stockPrices = context.StockPrices.Where(s =>
                s.CompanyStockExchange.CompanyId == companyId &&
                s.CompanyStockExchange.StockExchangeCode == stockExchangeCode &&
                Convert.ToDateTime(s.Date + ' ' + s.Time) >= fromDate &&
                Convert.ToDateTime(s.Date + ' ' + s.Time) <= to);

            var sp = from s in context.StockPrices
                     where s.CompanyStockExchange.CompanyId == companyId &&
                    s.CompanyStockExchange.StockExchangeCode == stockExchangeCode &&
                    Convert.ToDateTime(s.Date + ' ' + s.Time) >= fromDate &&
                    Convert.ToDateTime(s.Date + ' ' + s.Time) <= to
                     select s;

            return stockPrices;
        }
    }
}
