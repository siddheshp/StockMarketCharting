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
            throw new NotImplementedException();
        }

        public StockPriceDto Get(object key)
        {
            throw new NotImplementedException();
        }

        public bool Update(StockPriceDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
