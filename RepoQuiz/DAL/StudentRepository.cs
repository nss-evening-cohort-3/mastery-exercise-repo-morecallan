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
            Context = new StudentContext();
        }

        public StudentRepository(StudentContext _context)
        {
            Context = _context;
        }

        public List<Student> GetStudents()
        {
            return Context.Students.ToList();
        }

        public Student CheckIfStudentIsInDatabaseByName(string firstname, string lastname, string major)
        {
            Student found_student = Context.Students.FirstOrDefault(a => a.FirstName.ToLower() == firstname.ToLower() && a.LastName.ToLower() == lastname.ToLower() && a.Major.ToLower() == major.ToLower);
            return found_student;
        }

        public void AddOrUpdateStudent(Student student)
        {
            if (CheckIfStudentIsInDatabaseByName(student.FirstName, student.LastName, student.Major) == null)
            {
                Context.Students.Add(student);
                Context.SaveChanges();
            }
            else
            {
                Student existing_student = CheckIfStudentIsInDatabaseByName(student.FirstName, student.LastName, student.Major);
                Context.Entry(existing_student).CurrentValues.SetValues(student);
            }
            
        }

        public void AddStudent(string first_name, string last_name, string major)
        {
            Student student = new Student { FirstName = first_name, LastName = last_name, Major = major };
            Context.Students.Add(student);
            Context.SaveChanges();
        }
       
    }
}