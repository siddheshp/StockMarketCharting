using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Repositories
{
    public interface IRepository<T>
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        IEnumerable<T> Get();
        T Get(object key);
        IEnumerable<Student> Search(DateTime from, DateTime to);
    }
}
