using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ElliotBrownFordAssignment03ForHttp5112.Models;
using MySql.Data.MySqlClient;

namespace ElliotBrownFordAssignment03ForHttp5112.Controllers
{
    public class ClassesDataController : ApiController
    {

        private SchoolTeacherDbContext School = new SchoolTeacherDbContext();
        [HttpGet]
        public IEnumerable<Classes> ListClasses (string searchKeyForName = null)

        {
            //Access the Database
            MySqlConnection Subj = School.AccessDatabase();
            //Opens the DataBase
            Subj.Open();

            //Making a Create Command in Sql
            MySqlCommand mycmds = Subj.CreateCommand();

            //Sql Command Text or the What I want to be said in the create statement
            mycmds.CommandText = "Select * From classes where lower(classname) like lower('%" + searchKeyForName + "%') ";

            //Sql Reader - reads the cmds line and excutes them
            MySqlDataReader ResultsCmds = mycmds.ExecuteReader();

            //List of Classes
            List<Classes> Classess = new List<Classes>();

            //While the cmd line is readed
            while (ResultsCmds.Read())
            {
                //Gets all of the Values from the tables
                int ClassId = Convert.ToInt32(ResultsCmds["classid"]);
                string ClassCode = (string)ResultsCmds["classcode"];
                string ClassName = (string)ResultsCmds["classname"];
                DateTime StartDate = (DateTime)ResultsCmds["startdate"];
                DateTime FinishDate = (DateTime)ResultsCmds["finishdate"];
                //string TeacherName = ResultsCmds["teacherfname"] + " " + ResultsCmds["teacherlname"];

                //Puts them in a new Classes Object
                Classes NewClasses = new Classes();
                NewClasses.ClassId = ClassId;
                NewClasses.ClassCode = ClassCode;
                NewClasses.ClassName = ClassName;
                NewClasses.StartDate = StartDate;
                NewClasses.FinishDate = FinishDate;


                //Add new Class to the Classes List
                Classess.Add(NewClasses);
            }
            //Closes the Connection
            Subj.Close();
            //Returns the new Classes List
            return Classess;
        }




        [HttpGet]
        [Route("api/ClassesData/FindStudent/{id}")]
        public Classes FindClasses(int? id)
        {
            //Gets a New Class Object
            Classes NewClasses = new Classes();
            //Access the Database
            MySqlConnection Subjuect = School.AccessDatabase();
            //Opens the DataBase
            Subjuect.Open();

            //Making a Create Command in Sql
            MySqlCommand mycmds = Subjuect.CreateCommand();

            //Sql Command Text or the What I want to be said in the create statement
            mycmds.CommandText = "Select * From classes where classid = " + id;

            //Sql Reader - reads the cmds line and excutes them
            MySqlDataReader ResultsCmds = mycmds.ExecuteReader();
            //While the cmd line is readed
            while (ResultsCmds.Read())
            {
                //Gets all of the Values from the tables
                int ClassId = Convert.ToInt32(ResultsCmds["classid"]);
                string ClassCode = (string)ResultsCmds["classcode"];
                string ClassName = (string)ResultsCmds["classname"];
                DateTime StartDate = (DateTime)ResultsCmds["startdate"];
                DateTime FinishDate = (DateTime)ResultsCmds["finishdate"];
                //string TeacherName = ResultsCmds["teacherfname"] + " " + ResultsCmds["teacherlname"];

                //Puts them in the NewClasses Object
                NewClasses.ClassId = ClassId;
                NewClasses.ClassCode = ClassCode;
                NewClasses.ClassName = ClassName;
                NewClasses.StartDate = StartDate;
                NewClasses.FinishDate = FinishDate;

            }

            //returns NewClassess
            return NewClasses;
        }

    }
}
