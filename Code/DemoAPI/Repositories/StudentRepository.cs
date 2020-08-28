using DemoAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Repositories
{
    public class StudentRepository : IRepository<Student>
    {
        private StudentContext context;

        public StudentRepository(StudentContext context)
        {
            this.context = context;
        }
        public bool Add(Student entity)
        {
            try
            {
                //insert 
                context.Students.Add(entity);
                int updates = context.SaveChanges();
                if (updates > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Student entity)
        {
            try
            {
                context.Students.Remove(entity);
                var updates = context.SaveChanges();
                if (updates > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Student> Get()
        {
            //select * from students
            var students = context.Students;
            return students;
        }

        public Student Get(object key)
        {
            var student = context.Students.Find(key);
            return student;
        }

        public bool Update(Student entity)
        {
            try
            {
                context.Entry(entity).State = EntityState.Modified;
                var updates = context.SaveChanges();
                if (updates > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        IEnumerable<Student> Search(DateTime from, DateTime to)
        {
            var students = context.Students.Where(s => );
            return students;
        }
    }
}
