using DemoAPI.Controllers;
using DemoAPI.Models;
using DemoAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NUnitTests.Unit
{
    [TestFixture]
    public class UnitTestStudentController
    {
        DbContextOptions<StudentContext> options = new DbContextOptionsBuilder<StudentContext>()
            .UseInMemoryDatabase("ProductDB")
            .Options;
        StudentContext context = null;

        [SetUp]
        public void Setup()
        {
            context = new StudentContext(options);

            context.Students.AddRange(GetStudentList());
            context.SaveChanges();
        }

        private static List<Student> GetStudentList()
        {
            return new List<Student>()
                {
                    new Student{Id=1, Name="Param",
                        DateOfBirth = new DateTime(1996,1,1), Gender=Gender.Male},
                    new Student{Id=2, Name="Shona",
                        DateOfBirth = new DateTime(1996,1,1), Gender=Gender.Female}
                };
        }

        [TearDown]
        public void TearDown()
        {
            if (context != null)
            {
                context.Dispose();
            }
        }

        [Test]
        public void Test_StudentRepo_Get_StudentList()
        {
            //Arrange
            IRepository<Student> repository = new StudentRepository(context);

            //Act
            var studentList = repository.Get();

            //Assert
            var actualCount = studentList.Count();
            Assert.That(GetStudentList().Count, Is.EqualTo(2), "List of students is not matching");
        }
    }
}