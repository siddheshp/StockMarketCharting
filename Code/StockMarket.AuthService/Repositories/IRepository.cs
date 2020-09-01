using StckMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockMarket.AuthService.Repositories
{
    public interface IRepository<T>
    {
        bool Signup(T entity);
        Tuple<bool, string> Login(string username, string password);
        bool Logout();
        T GetProfile(string token);
        bool UpdateProfile(T entity);
    }
}
