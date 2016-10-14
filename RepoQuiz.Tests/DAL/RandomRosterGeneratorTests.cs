using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepoQuiz.DAL;
using RepoQuiz.Models;
using System.Collections.Generic;

namespace RepoQuiz.Tests.DAL
{
    [TestClass]
    public class RandomRosterGeneratorTests
    {
        [TestMethod]
        public void RandomRosterGeneratorCanBeInstantiated()
        {
            //Arrange
            //Act
            RandomRosterGenerator random_roster_generator = new RandomRosterGenerator();
            //Assert
            Assert.IsNotNull(random_roster_generator);
        }

        [TestMethod]
        public void RandomRosterGeneratorWillReturnTrueIfStudentAlreadyExistsInList()
        {
            //Arrange
            RandomRosterGenerator random_roster_generator = new RandomRosterGenerator();
            Student test_student = new Student { FirstName = "Callan", LastName = "Morrison", Major = "Creative Writing" };
            List<Student> students_list = new List<Student>
            {
                new Student { FirstName = "Callan", LastName = "Morrison", Major = "Creative Writing" },
                new Student { FirstName = "Frank", LastName = "Good", Major = "Math" }
            };
            //Act
            bool expected_result = true;
            bool actual_result = random_roster_generator.DoesStudentAlreadyExistInRoster(test_student, students_list);
            //Assert
            Assert.AreEqual(expected_result, actual_result);
        }

        [TestMethod]
        public void RandomRosterGeneratorWillReturnFalseIfStudentIsUniqueToList()
        {
            //Arrange
            RandomRosterGenerator random_roster_generator = new RandomRosterGenerator();
            Student test_student = new Student { FirstName = "Callahan", LastName = "Morrison", Major = "Creative Writing" };
            List<Student> students_list = new List<Student>
            {
                new Student { FirstName = "Callan", LastName = "Morrison", Major = "Creative Writing" },
                new Student { FirstName = "Frank", LastName = "Good", Major = "Math" }
            };
            //Act
            bool expected_result = false;
            bool actual_result = random_roster_generator.DoesStudentAlreadyExistInRoster(test_student, students_list);
            //Assert
            Assert.AreEqual(expected_result, actual_result);
        }

        [TestMethod]
        public void RandomRosterGeneratorWillGenerateAListWithTheNumberOfStudentsYouDesire()
        {
            //Arrange
            RandomRosterGenerator random_roster_generator = new RandomRosterGenerator();
            List<Student> unique_new_classroom = random_roster_generator.PublicClassRosterGenerator(5);
            //Act
            int expected_result = 5;
            int actual_result = unique_new_classroom.Count;
            //Assert
            Assert.AreEqual(expected_result, actual_result);
        }
    }
}
