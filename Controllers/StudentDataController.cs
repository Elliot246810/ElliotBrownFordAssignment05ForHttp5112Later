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

            MySqlConnection Subj = School.AccessDatabase();

            Subj.Open();


            MySqlCommand mycmds = Subj.CreateCommand();


            mycmds.CommandText = "Select * From students where lower(studentfname) like lower('%" + searchKeyForNames + "%') or lower(studentlname) like lower('%" + searchKeyForNames + "%')" +
                " or lower(concat(studentfname, ' ' , studentlname)) like lower('%" + searchKeyForNames + "%')";


            MySqlDataReader ResultsCmds = mycmds.ExecuteReader();


            List<Student> Students = new List<Student>();


            while (ResultsCmds.Read())
            {
                int StudentId =   Convert.ToInt32(ResultsCmds["studentid"]);
                string StudentFname = (string)ResultsCmds["studentfname"];
                string StudentLname = (string)ResultsCmds["studentlname"];
                string StudentNumber = (string)ResultsCmds["studentnumber"];
                DateTime EnrolDate = (DateTime)ResultsCmds["enroldate"];


                Student NewStudent = new Student();
                NewStudent.StudentId = StudentId;
                NewStudent.StudentFname = StudentFname;
                NewStudent.StudentLname = StudentLname;
                NewStudent.StudentNumber = StudentNumber;
                NewStudent.EnrolDate = EnrolDate;



                Students.Add(NewStudent);
            }

            Subj.Close();

            return Students;
        }




        [HttpGet]
        [Route("api/StudentData/FindStudent/{id}")]
        public Student FindStudent(int? id)
        {
            Student NewStudent = new Student();

            MySqlConnection Subjuect = School.AccessDatabase();

            Subjuect.Open();


            MySqlCommand mycmds = Subjuect.CreateCommand();


            mycmds.CommandText = "Select *  From students   where studentid = " + id;


            MySqlDataReader ResultsCmds = mycmds.ExecuteReader();

            while (ResultsCmds.Read())
            {
                int StudentId = Convert.ToInt32(ResultsCmds["studentid"]);
                string StudentFname = (string)ResultsCmds["studentfname"];
                string StudentLname = (string)ResultsCmds["studentlname"];
                string StudentNumber = (string)ResultsCmds["studentnumber"];
                DateTime EnrolDate = (DateTime)ResultsCmds["enroldate"];

                //string TeacherName = ResultsCmds["teacherfname"] + " " + ResultsCmds["teacherlname"];

                NewStudent.StudentId = StudentId;
                NewStudent.StudentFname = StudentFname;
                NewStudent.StudentLname = StudentLname;
                NewStudent.StudentNumber = StudentNumber;
                NewStudent.EnrolDate = EnrolDate;



            }

            return NewStudent;
        }

    }
}
