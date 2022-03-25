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
    public class TeacherDataController : ApiController
    {
        private SchoolTeacherDbContext School = new SchoolTeacherDbContext();
        [HttpGet]
        public IEnumerable<Teacher> ListTeachers(string searchKeyForName = null)

        {

            MySqlConnection Subj = School.AccessDatabase();

            Subj.Open();


            MySqlCommand mycmds = Subj.CreateCommand();

            
            mycmds.CommandText = "Select t.* , c.classcode, c.classname From teachers t join classes c on t.teacherid = c.teacherid where lower(t.teacherfname) like lower('%" + searchKeyForName + "%') or lower(t.teacherlname) like lower('%" + searchKeyForName + "%')" +
                " or lower(concat(t.teacherfname, ' ' , t.teacherlname)) like lower('%" + searchKeyForName + "%')";


            MySqlDataReader ResultsCmds = mycmds.ExecuteReader();

            
            List<Teacher> Teachers = new List<Teacher>();


            while (ResultsCmds.Read())
            {
                int TeacherId = (int)ResultsCmds["teacherid"];
                string TeacherFname = (string)ResultsCmds["teacherfname"];
                string TeacherLname = (string)ResultsCmds["teacherlname"];
                string EmployeeNumber = (string)ResultsCmds["employeenumber"];
                DateTime Hiredate = (DateTime)ResultsCmds["hiredate"];
                double Salary = Convert.ToDouble(ResultsCmds["salary"]);
                string ClassCode = (string)(ResultsCmds["classcode"]);
                string ClassName = (string)(ResultsCmds["classname"]);
                //string TeacherName = ResultsCmds["teacherfname"] + " " + ResultsCmds["teacherlname"];

                Teacher NewTeacher = new Teacher();
                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.EmployeeNumber = EmployeeNumber;
                NewTeacher.Hiredate = Hiredate;
                NewTeacher.Salary = Salary;
                NewTeacher.ClassCode = ClassCode;
                NewTeacher.ClassName = ClassName;

                Teachers.Add(NewTeacher);
            }

            Subj.Close();

            return Teachers;
        }

        
        
        
        [HttpGet]
        [Route ("api/TeacherData/FindTeacher/{id}")]
        public Teacher FindTeacher (int? id)
        {
            Teacher NewTeacher = new Teacher();

            MySqlConnection Subjuect = School.AccessDatabase();

            Subjuect.Open();


            MySqlCommand mycmds = Subjuect.CreateCommand();


            mycmds.CommandText = "Select t.* , c.classcode, c.classname From teachers t join classes c on t.teacherid = c.teacherid where t.teacherid = " + id;


            MySqlDataReader ResultsCmds = mycmds.ExecuteReader();

            while (ResultsCmds.Read())
            {
                int TeacherId = (int)ResultsCmds["teacherid"];
                string TeacherFname = (string)ResultsCmds["teacherfname"];
                string TeacherLname = (string)ResultsCmds["teacherlname"];
                string EmployeeNumber = (string)ResultsCmds["employeenumber"];
                DateTime Hiredate = (DateTime)ResultsCmds["hiredate"];
                double Salary = Convert.ToDouble(ResultsCmds["salary"]);
                string ClassCode = (string)(ResultsCmds["classcode"]);
                string ClassName = (string)(ResultsCmds["classname"]);
                //string TeacherName = ResultsCmds["teacherfname"] + " " + ResultsCmds["teacherlname"];

                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.EmployeeNumber = EmployeeNumber;
                NewTeacher.Hiredate = Hiredate;
                NewTeacher.ClassCode = ClassCode;
                NewTeacher.ClassName = ClassName;
                NewTeacher.Salary = Salary;

            }

            return NewTeacher;
        }


        /*[HttpGet]
        [Route("api/TeacherData/SearchTeachersByName/{searchKeyForName}")]
        public IEnumerable<Teacher> SearchTeachersByName(string searchKeyForName=null)

        {

            MySqlConnection Subj = School.AccessDatabase();

            Subj.Open();


            MySqlCommand mycmds = Subj.CreateCommand();


            mycmds.CommandText = "Select t.* , c.classcode, c.classname From teachers t join classes c on t.teacherid = c.teacherid where lower(t.teacherfname) like lower('%" + searchKeyForName+ "%') or lower(t.teacherlname) like lower('%" + searchKeyForName + "%')" +
                " or lower(concat(t.teacherfname, ' ' , t.teacherlname)) like lower('%" + searchKeyForName + "%')";


            MySqlDataReader ResultsCmds = mycmds.ExecuteReader();


            List<Teacher> Teachers = new List<Teacher>();


            while (ResultsCmds.Read())
            {
                int TeacherId = (int)ResultsCmds["teacherid"];
                string TeacherFname = (string)ResultsCmds["teacherfname"];
                string TeacherLname = (string)ResultsCmds["teacherlname"];
                string EmployeeNumber = (string)ResultsCmds["employeenumber"];
                DateTime Hiredate = (DateTime)ResultsCmds["hiredate"];
                double Salary = Convert.ToDouble(ResultsCmds["salary"]);
                string ClassCode = (string)(ResultsCmds["classcode"]);
                string ClassName = (string)(ResultsCmds["classname"]);
                //string TeacherName = ResultsCmds["teacherfname"] + " " + ResultsCmds["teacherlname"];

                Teacher NewTeacher = new Teacher();
                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.EmployeeNumber = EmployeeNumber;
                NewTeacher.Hiredate = Hiredate;
                NewTeacher.Salary = Salary;
                NewTeacher.ClassCode = ClassCode;
                NewTeacher.ClassName = ClassName;

                Teachers.Add(NewTeacher);
            }

            Subj.Close();

            return Teachers;
        }*/




    }



}
