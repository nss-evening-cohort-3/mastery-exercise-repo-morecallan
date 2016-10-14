using RepoQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepoQuiz.DAL
{
    public class RandomRosterGenerator
    {

        public bool DoesStudentAlreadyExistInRoster(Student student_to_check, List<Student> current_list)
        {
            bool student_exists = false;
            for (var i = 0; i < current_list.Count(); i++)
            {
                if (student_to_check.FirstName == current_list[i].FirstName && student_to_check.LastName == current_list[i].LastName && student_to_check.Major == current_list[i].Major)
                {
                    student_exists = true;
                    break;
                }
            }
            return student_exists;
        }

        public List<Student> PublicClassRosterGenerator(int number_of_desired_students)
        {
            NameGenerator student_generator = new NameGenerator();
            List<Student> new_class_roster = new List<Student>();
            int i = 0;
            while (i < number_of_desired_students)
            {
                Student new_student = student_generator.CreateNewRandomStudent();
                if (DoesStudentAlreadyExistInRoster(new_student, new_class_roster) == false)
                {
                    new_class_roster.Add(new_student);
                    i++;
                }
            }
            return new_class_roster;
        }
    }
}