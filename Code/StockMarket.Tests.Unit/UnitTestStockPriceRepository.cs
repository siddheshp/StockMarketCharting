using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using StckMarket.Models;
using StockMarket.AdminService.Models;
using StockMarket.AdminService.Repositories;
using StockMarket.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StockMarket.Tests.Unit
{
    [TestFixture]
    public class UnitTestStockPriceRepository
    {
        DbContextOptions<AdminContext> options = new DbContextOptionsBuilder<AdminContext>()
            .UseInMemoryDatabase("StockMarketDB")
            .Options;
        AdminContext context = null;

        [SetUp]
        public void Setup()
        {
            context = new AdminContext(options);
            context.StockPrices.AddRange(GetStockPriceList());
            context.SaveChanges();
        }

        private IEnumerable<StockPrice> GetStockPriceList()
        {
            var cse = new CompanyStockExchange
            {
                CompanyId = 1,
                StockExchangeCode = "BSE"
            };

            return new List<StockPrice>
            {
                new StockPrice
                {
                    Id = 1,
                    CurrentPrice = 100,
                    Date = new DateTime().ToShortDateString(),
                    Time = new DateTime().ToShortTimeString(),
                    CompanyStockExchange = cse
                },
                new StockPrice
                {
                    Id = 2,
                    CurrentPrice = 101,
                    Date = new DateTime().ToShortDateString(),
                    Time = new DateTime().AddMinutes(1).ToShortTimeString(),
                    CompanyStockExchange = cse
                }
            };
        }

        [TearDown]
        public void Teardown()
        {
            if (context!=null)
            {
                context.Dispose();
            }
        }

        [Test]
        public void Test_Get_ShouldReturnStockPriceList()
        {
            //Arrange
            IRepository<StockPriceDto> repository = new StockpriceRepository(context);
            //Act
            var list = repository.Get();
            //Assert
            var actualCount = list.Count();
            Assert.That(actualCount, Is.EqualTo(GetStockPriceList().Count()),
                "Stock price List count does not match");
        }
    }
}