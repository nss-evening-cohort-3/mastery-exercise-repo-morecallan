using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using System.Data.Entity;
using System.Linq;
using RepoQuiz.Models;
using RepoQuiz.DAL;

namespace RepoQuiz.Tests.DAL
{
    [TestClass]
    public class StudentRepositoryTests
    {
        Mock<StudentContext> mock_context { get; set; }
        Mock<DbSet<Student>> mock_student_table { get; set; }
        List<Student> student_list { get; set; }
        StudentRepository repo { get; set; }

        public void ConnectMocksToDatastore()
        {
            var queryable_list = student_list.AsQueryable();

            mock_student_table.As<IQueryable<Student>>().Setup(m => m.Provider).Returns(queryable_list.Provider);
            mock_student_table.As<IQueryable<Student>>().Setup(m => m.Expression).Returns(queryable_list.Expression);
            mock_student_table.As<IQueryable<Student>>().Setup(m => m.ElementType).Returns(queryable_list.ElementType);
            mock_student_table.As<IQueryable<Student>>().Setup(m => m.GetEnumerator()).Returns(() => queryable_list.GetEnumerator());

            mock_context.Setup(c => c.Students).Returns(mock_student_table.Object);

            mock_student_table.Setup(t => t.Add(It.IsAny<Student>())).Callback((Student s) => student_list.Add(s));
        }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<StudentContext>();
            mock_student_table = new Mock<DbSet<Student>>();
            student_list = new List<Student>();
            repo = new StudentRepository(mock_context.Object);

            ConnectMocksToDatastore();
        }

        [TestCleanup]
        public void TearDown()
        {
            repo = null; 
        }

        [TestMethod]
        public void StudentRepoOriginallyHasNoStudents()
        {
            //Arrange
            List<Student> students_returned = repo.GetStudents();
            //Act
            int expected_student_count = 0;
            int actual_student_count = students_returned.Count();
            //Assert
            Assert.AreEqual(expected_student_count, actual_student_count);
        }

        [TestMethod]
        public void StudentRepoCanAddStudent()
        {
            //Arrange
            repo.AddStudent("Callan", "Morrison", "Creative Writing");
            List<Student> students_returned = repo.GetStudents();
            //Act
            int expected_student_count = 1;
            int actual_student_count = students_returned.Count();
            //Assert
            Assert.AreEqual(expected_student_count, actual_student_count);
        }

        [TestMethod]
        public void StudentRepoWillUpdateIfTheyAreNotUnique()
        {

            //Arrange
            Student first_student = new Student { FirstName = "Callan", LastName = "Morrison", Major = "Creative Writing" };
            Student not_unique_student = new Student { FirstName = "Callan", LastName = "Morrison", Major = "Creative Writing" };

            repo.AddStudent(first_student);
            repo.AddStudent(not_unique_student);
            List<Student> students_returned = repo.GetStudents();
            //Act
            int expected_student_count = 1;
            int actual_student_count = students_returned.Count();
            //Assert
        }
    }
}
