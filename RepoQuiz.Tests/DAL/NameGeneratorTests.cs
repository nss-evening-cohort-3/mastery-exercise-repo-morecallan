using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoQuiz.DAL;
using RepoQuiz.Models;

namespace RepoQuiz.Tests.DAL
{
    [TestClass]
    public class NameGeneratorTests
    {
        [TestMethod]
        public void NameGeneratorCanBeInstantiated()
        {
            //Arrange
            //Act
            NameGenerator name_generator = new NameGenerator();
            //Assert
            Assert.IsNotNull(name_generator);
        }

        [TestMethod]
        public void NameGeneratorStudentGeneratorWillReturnAStudent()
        {
            //Arrange
            NameGenerator name_generator = new NameGenerator();
            //Act
            Student random_student = name_generator.CreateNewRandomStudent();
            //Assert
            Assert.IsInstanceOfType(random_student, typeof(Student));
        }
    }
}
