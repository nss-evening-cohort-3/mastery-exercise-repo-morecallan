using RepoQuiz.DAL;
using RepoQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepoQuiz.Controllers
{
    public class StudentController : Controller
    {

        private StudentRepository repo = new StudentRepository();

        // GET: Student
        public ActionResult Index()
        {
            List<Student> classroom = repo.GetStudents();
            ViewBag.Classroom = classroom;
            return View();
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            Student student_to_view = repo.ReturnSingleStudentById(id);
            ViewBag.Student = student_to_view;
            return View();
        }

    }
}
