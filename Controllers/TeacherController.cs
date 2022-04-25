using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElliotBrownFordAssignment03ForHttp5112.Models;
using System.Diagnostics;

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
            Teacher selectedTeacher = controller.FindTeacher(id);
            return View(selectedTeacher);
        }
        //Get : /Teacher/DeleteConfirm
        public ActionResult DeleteConfirm(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);
            return View(NewTeacher);
        }

        //POST : /Teacher/Delete/{id}
        public ActionResult Delete(int id)
        {

            TeacherDataController deletedcontroller = new TeacherDataController();
            deletedcontroller.DeleteTeacher(id);
            return RedirectToAction("List");
        }

        //GET : /Teacher/New
        public ActionResult New()
        {

            return View();
        }

        //POST : /Teacher/Create
        [HttpPost]
        public ActionResult Create(string TeacherFname, string TeacherLname , string EmployeeNumber , DateTime? Hiredate , double Salary, string ClassCode , string ClassName)
        {
            Debug.WriteLine("I Have accessed the Create Method");

            Teacher NewTeacher = new Teacher();
            NewTeacher.TeacherFname = TeacherFname;
            NewTeacher.TeacherLname = TeacherLname;
            NewTeacher.EmployeeNumber = EmployeeNumber;
            NewTeacher.Hiredate = Hiredate;
            NewTeacher.Salary = Salary;

            TeacherDataController newcontroller = new TeacherDataController();
            newcontroller.AddTeacher(NewTeacher);

            return RedirectToAction("List");
        }
            
        //GET : /Teacher/Update/{id}
        public ActionResult Update(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher selectedTeacher = controller.FindTeacher(id);
            return View(selectedTeacher)
        }

        //POST : /Teacher/Update/{id}
        public ActionResult Update(int id,string TeacherFname, string TeacherLname, string EmployeeNumber, DateTime? Hiredate, double Salary)
        {
            Teacher TeacherInfo = new Teacher();
            TeacherInfo.TeacherFname = TeacherFname;
            TeacherInfo.TeacherLname = TeacherLname;
            TeacherInfo.EmployeeNumber = EmployeeNumber;
            TeacherInfo.Hiredate = Hiredate;
            TeacherInfo.Salary = Salary;

            TeacherDataController newcontroller = new TeacherDataController();
            newcontroller.UpdateTeacher(id, TeacherInfo);
            return RedirectToAction("Show/" + id);
        }
    }
}