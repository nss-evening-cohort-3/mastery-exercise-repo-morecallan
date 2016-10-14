using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepoQuiz.DAL
{
    public class NameGenerator

    // This class should be used to generate random names and Majors for Students.
    // This is NOT your Repository
    // All methods should be Unit Tested :)
    {
        public List<string> First = new List<string>() { "Elizabreth", "Meldor", "Aliviyah", "Mhavrych", "Beberly", "Danger", "Sweetmeat", "Nevaeh", "C'andre", "Colon", "Abcde", "Baby", "Merika", "Jerica", "Panthy", "Reighleigh", "Appaloosa", "Gotham", "Yunique", "Melanomia", "Shakira" };
        public List<string> Last = new List<string>() { "Smith", "Johnson", "Williams", "Jones", "Brown", "Davis", "Miller", "Wilson", "Moore", "Taylor", "Anderson", "Thomas", "Jackson", "White", "Harris", "Martin", "Thompson", "Garcia", "Martinez", "Robinson", "Clark" };
        public List<string> Majors = new List<string>() { "Business Administration", "Nursing", "Psychology", "Cosmetology", "Economics", "Culinary Arts", "Chemistry", "Pharmacy" };

    }
}