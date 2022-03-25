using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElliotBrownFordAssignment03ForHttp5112.Models;

namespace ElliotBrownFordAssignment03ForHttp5112.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This Actions Returns the view with the list of Students in them 
        /// </summary>
        /// <param name="searchKeyForName"> This allows user to search specific Students by their Student First name and Last Name</param>
        /// <returns>It return all of the Student names that are like the searchKeyForName</returns>
        //GET : /Student/List
        public ActionResult List(string searchKeyForNames = null)
        {
            StudentDataController controller = new StudentDataController();
            IEnumerable<Student> Students = controller.ListStudents(searchKeyForNames);
            return View(Students);
        }
        /// <summary>
        /// This Actions Returns the view with the Specifc Student in them 
        /// </summary>
        /// <param name="id"> This gets the specific Student ID so the user can see all of the specifcs of that Student</param>
        /// <returns>It return a specific Student</returns>
        //GET : /Student/Show/{id}
        public ActionResult Show(int id)
        {
            StudentDataController controller = new StudentDataController();
            Student NewStudent = controller.FindStudent(id);
            return View(NewStudent);
        }
    }
}