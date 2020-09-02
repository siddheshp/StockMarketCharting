using StckMarket.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket.Dtos
{
    public class LoginDto
    {
        public UserType UserType { get; set; }
        public string Token { get; set; } 
    }
}
