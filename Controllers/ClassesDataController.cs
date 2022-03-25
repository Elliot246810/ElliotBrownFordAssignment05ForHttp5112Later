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

            MySqlConnection Subj = School.AccessDatabase();

            Subj.Open();


            MySqlCommand mycmds = Subj.CreateCommand();


            mycmds.CommandText = "Select * From classes where lower(classname) like lower('%" + searchKeyForName + "%') ";


            MySqlDataReader ResultsCmds = mycmds.ExecuteReader();


            List<Classes> Classess = new List<Classes>();


            while (ResultsCmds.Read())
            {
                int ClassId = Convert.ToInt32(ResultsCmds["classid"]);
                string ClassCode = (string)ResultsCmds["classcode"];
                string ClassName = (string)ResultsCmds["classname"];
                DateTime StartDate = (DateTime)ResultsCmds["startdate"];
                DateTime FinishDate = (DateTime)ResultsCmds["finishdate"];
                //string TeacherName = ResultsCmds["teacherfname"] + " " + ResultsCmds["teacherlname"];

                Classes NewClasses = new Classes();
                NewClasses.ClassId = ClassId;
                NewClasses.ClassCode = ClassCode;
                NewClasses.ClassName = ClassName;
                NewClasses.StartDate = StartDate;
                NewClasses.FinishDate = FinishDate;

                Classess.Add(NewClasses);
            }

            Subj.Close();

            return Classess;
        }




        [HttpGet]
        [Route("api/ClassesData/FindStudent/{id}")]
        public Classes FindClasses(int? id)
        {
            Classes NewClasses = new Classes();

            MySqlConnection Subjuect = School.AccessDatabase();

            Subjuect.Open();


            MySqlCommand mycmds = Subjuect.CreateCommand();


            mycmds.CommandText = "Select * From classes where classid = " + id;


            MySqlDataReader ResultsCmds = mycmds.ExecuteReader();

            while (ResultsCmds.Read())
            {
                int ClassId = Convert.ToInt32(ResultsCmds["classid"]);
                string ClassCode = (string)ResultsCmds["classcode"];
                string ClassName = (string)ResultsCmds["classname"];
                DateTime StartDate = (DateTime)ResultsCmds["startdate"];
                DateTime FinishDate = (DateTime)ResultsCmds["finishdate"];
                //string TeacherName = ResultsCmds["teacherfname"] + " " + ResultsCmds["teacherlname"];

                NewClasses.ClassId = ClassId;
                NewClasses.ClassCode = ClassCode;
                NewClasses.ClassName = ClassName;
                NewClasses.StartDate = StartDate;
                NewClasses.FinishDate = FinishDate;

            }

            return NewClasses;
        }

    }
}
