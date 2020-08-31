using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Repositories
{
    interface IStudentRepository: IRepository<Student>
    {
        bool IsExisting(int id);
    }
}
