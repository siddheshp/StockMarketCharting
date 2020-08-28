using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected StudentContext()
        {
        }

        public virtual DbSet<Student> Students { get; set; } 
    }
}
