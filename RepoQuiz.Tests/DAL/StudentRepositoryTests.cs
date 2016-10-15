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
        public void StudentRepoCanAddAnEntireClassroomOfUniqueStudents()
        {

            //Arrange
            repo.AddWholeNewClassroomFullOfUniqueStudents(10);
            List<Student> students_returned = repo.GetStudents();
            //Act
            int expected_student_count = 10;
            int actual_student_count = students_returned.Count();
            //Assert
            Assert.AreEqual(expected_student_count, actual_student_count);
        }

        [TestMethod]
        public void StudentRepoCanGetAllStudents()
        {
            //Arrange
            repo.AddWholeNewClassroomFullOfUniqueStudents(40);
            List<Student> students_returned = repo.GetStudents();
            //Act
            int expected_student_count = 40;
            int actual_student_count = students_returned.Count();
            //Assert
            Assert.AreEqual(expected_student_count, actual_student_count);
        }

        [TestMethod]
        public void CanReturnASpecificStudentById()
        {
            //Arrange
            repo.AddWholeNewClassroomFullOfUniqueStudents(10);
            repo.AddStudent(new Student { StudentId = 12, FirstName = "Marcus", LastName = "Fear", Major = "Chemistry" });
            Student student_returned = repo.ReturnSingleStudentById(12);
            //Act
            string expected_student_firstname = "Marcus";
            string actual_student_firstname = student_returned.FirstName;
            //Assert
            Assert.AreEqual(expected_student_firstname, actual_student_firstname);
        }
    }
}
