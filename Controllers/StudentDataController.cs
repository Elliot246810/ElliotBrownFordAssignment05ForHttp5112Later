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
    public class StudentDataController : ApiController
    {



        private SchoolTeacherDbContext School = new SchoolTeacherDbContext();
        [HttpGet]
        public IEnumerable<Student> ListStudents(string searchKeyForNames = null)

        {
            //Access the Database
            MySqlConnection Subj = School.AccessDatabase();
            //Opens the DataBase
            Subj.Open();

            //Making a Create Command in Sql
            MySqlCommand mycmds = Subj.CreateCommand();

            //Sql Command Text or the What I want to be said in the create statement
            mycmds.CommandText = "Select * From students where lower(studentfname) like lower('%" + searchKeyForNames + "%') or lower(studentlname) like lower('%" + searchKeyForNames + "%')" +
                " or lower(concat(studentfname, ' ' , studentlname)) like lower('%" + searchKeyForNames + "%')";

            //Sql Reader - reads the cmds line and excutes them
            MySqlDataReader ResultsCmds = mycmds.ExecuteReader();

            //List of Students
            List<Student> Students = new List<Student>();

            //While the cmd line is readed
            while (ResultsCmds.Read())
            {
                //Gets all of the Values from the tables
                int StudentId =   Convert.ToInt32(ResultsCmds["studentid"]);
                string StudentFname = (string)ResultsCmds["studentfname"];
                string StudentLname = (string)ResultsCmds["studentlname"];
                string StudentNumber = (string)ResultsCmds["studentnumber"];
                DateTime EnrolDate = (DateTime)ResultsCmds["enroldate"];

                //Puts them in a new Student Object
                Student NewStudent = new Student();
                NewStudent.StudentId = StudentId;
                NewStudent.StudentFname = StudentFname;
                NewStudent.StudentLname = StudentLname;
                NewStudent.StudentNumber = StudentNumber;
                NewStudent.EnrolDate = EnrolDate;


                //Add new Student to the Student List
                Students.Add(NewStudent);
            }
            //Closes the Connection
            Subj.Close();
            //Returns the new Student List
            return Students;
        }




        [HttpGet]
        [Route("api/StudentData/FindStudent/{id}")]
        public Student FindStudent(int? id)
        {
            //Gets a New Student Object
            Student NewStudent = new Student();
            //Access the Database
            MySqlConnection Subjuect = School.AccessDatabase();
            //Opens the DataBase
            Subjuect.Open();

            //Making a Create Command in Sql
            MySqlCommand mycmds = Subjuect.CreateCommand();

            //Sql Command Text or the What I want to be said in the create statement
            mycmds.CommandText = "Select *  From students   where studentid = " + id;

            //Sql Reader - reads the cmds line and excutes them
            MySqlDataReader ResultsCmds = mycmds.ExecuteReader();
            //While the cmd line is readed
            while (ResultsCmds.Read())
            {
                //Gets all of the Values from the tables
                int StudentId = Convert.ToInt32(ResultsCmds["studentid"]);
                string StudentFname = (string)ResultsCmds["studentfname"];
                string StudentLname = (string)ResultsCmds["studentlname"];
                string StudentNumber = (string)ResultsCmds["studentnumber"];
                DateTime EnrolDate = (DateTime)ResultsCmds["enroldate"];

                //string TeacherName = ResultsCmds["teacherfname"] + " " + ResultsCmds["teacherlname"];
                //Puts them in the NewStudent Object
                NewStudent.StudentId = StudentId;
                NewStudent.StudentFname = StudentFname;
                NewStudent.StudentLname = StudentLname;
                NewStudent.StudentNumber = StudentNumber;
                NewStudent.EnrolDate = EnrolDate;



            }
            //returns NewStudent
            return NewStudent;
        }

    }
}
