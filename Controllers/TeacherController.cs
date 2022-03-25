using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElliotBrownFordAssignment03ForHttp5112.Models;

namespace ElliotBrownFordAssignment03ForHttp5112.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// This Actions Returns the view with the list of Teachers in them 
        /// </summary>
        /// <param name="searchKeyForName"> This allows user to search specific Teachers by their Teacher First name and Last Name</param>
        /// <returns>It return all of the Teacher names that are like the searchKeyForName</returns>

        //GET : /Teacher/List
        public ActionResult List(string searchKeyForName = null)
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers(searchKeyForName);
            return View(Teachers);
        }
        /// <summary>
        /// This Actions Returns the view with the Specifc Teacher in them 
        /// </summary>
        /// <param name="id"> This gets the specific Teacher ID so the user can see all of the specifcs of that Teacher</param>
        /// <returns>It return a specific Teacher</returns>

        //GET : /Teacher/Show/{id}
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);
            return View(NewTeacher);
        }
    
    }
}