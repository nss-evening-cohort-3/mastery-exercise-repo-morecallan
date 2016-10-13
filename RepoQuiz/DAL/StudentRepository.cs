using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepoQuiz.Models;

namespace RepoQuiz.DAL
{
    public class StudentRepository
    {
        public StudentContext Context { get; set; }

        public StudentRepository
()
        {
            Context = new StudentRepository();
        }

        public StudentRepository(StudentContext _context)
        {
            Context = _context;
        }

        public List<Students> GetStudents()
        {
            return Context.Authors.ToList();
        }

        public Student CheckIfStudentIsInDatabaseByName(string name)
        {
            Student found_student = Context.Students.FirstOrDefault(a => a.Name.toLower() == name.ToLower());
            return found_student;
        }

        public void AddOrUpdateStudent(Student student)
        {
            Context.Students.AddOrUpdate(s => s.Name, student);
            Context.SaveChanges();
        }

        public void AddStudent(string first_name, string last_name, string major)
        {
            Student student = new Student { FirstName = first_name, LastName = last_name, Major = major };
            Context.Students.Add(student);
            Context.SaveChanges();
        }
       
    }
}