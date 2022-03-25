using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElliotBrownFordAssignment03ForHttp5112.Models;

namespace ElliotBrownFordAssignment03ForHttp5112.Controllers
{
    public class ClassesController : Controller
    {
        // GET: Classes
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// This Actions Returns the view with the list of classes in them 
        /// </summary>
        /// <param name="searchKeyForName"> This allows user to search specific classes by their class name</param>
        /// <returns>It return all of the class names that are like the searchKeyForName</returns>
        //GET : /Classes/List
        public ActionResult List(string searchKeyForName = null)
        {
            ClassesDataController controller = new ClassesDataController();
            IEnumerable<Classes> Classess = controller.ListClasses(searchKeyForName);
            return View(Classess);
        }
        /// <summary>
        /// This Actions Returns the view with the Specifc Class in them 
        /// </summary>
        /// <param name="id"> This gets the specific class ID so the user can see all of the specifcs of that class</param>
        /// <returns>It return a specific Class</returns>
        //GET : /Classes/Show/{id}
        public ActionResult Show(int id)
        {
            ClassesDataController controller = new ClassesDataController();
            Classes NewClasses = controller.FindClasses(id);
            return View(NewClasses);
        }
    }
}