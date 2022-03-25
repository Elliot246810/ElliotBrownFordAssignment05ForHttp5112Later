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
            //Access the Database
            MySqlConnection Subj = School.AccessDatabase();
            //Opens the DataBase
            Subj.Open();

            //Making a Create Command in Sql
            MySqlCommand mycmds = Subj.CreateCommand();

            //Sql Command Text or the What I want to be said in the create statement
            mycmds.CommandText = "Select t.* , c.classcode, c.classname From teachers t join classes c on t.teacherid = c.teacherid where lower(t.teacherfname) like lower('%" + searchKeyForName + "%') or lower(t.teacherlname) like lower('%" + searchKeyForName + "%')" +
                " or lower(concat(t.teacherfname, ' ' , t.teacherlname)) like lower('%" + searchKeyForName + "%')";

            //Sql Reader - reads the cmds line and excutes them
            MySqlDataReader ResultsCmds = mycmds.ExecuteReader();

            //List of Teachers
            List<Teacher> Teachers = new List<Teacher>();

            //While the cmd line is readed
            while (ResultsCmds.Read())
            {
                //Gets all of the Values from the tables
                int TeacherId = (int)ResultsCmds["teacherid"];
                string TeacherFname = (string)ResultsCmds["teacherfname"];
                string TeacherLname = (string)ResultsCmds["teacherlname"];
                string EmployeeNumber = (string)ResultsCmds["employeenumber"];
                DateTime Hiredate = (DateTime)ResultsCmds["hiredate"];
                double Salary = Convert.ToDouble(ResultsCmds["salary"]);
                string ClassCode = (string)(ResultsCmds["classcode"]);
                string ClassName = (string)(ResultsCmds["classname"]);
                //string TeacherName = ResultsCmds["teacherfname"] + " " + ResultsCmds["teacherlname"];

                //Puts them in a new Teacher Object
                Teacher NewTeacher = new Teacher();
                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.EmployeeNumber = EmployeeNumber;
                NewTeacher.Hiredate = Hiredate;
                NewTeacher.Salary = Salary;
                NewTeacher.ClassCode = ClassCode;
                NewTeacher.ClassName = ClassName;
                //Add new Teacher to the Teacher List
                Teachers.Add(NewTeacher);
            }
            //Closes the Connection
            Subj.Close();
            //Returns the new Student List
            return Teachers;
        }

        
        
        
        [HttpGet]
        [Route ("api/TeacherData/FindTeacher/{id}")]
        public Teacher FindTeacher (int? id)
        {
            //Gets a New Teacher Object
            Teacher NewTeacher = new Teacher();
            //Access the Database
            MySqlConnection Subjuect = School.AccessDatabase();
            //Opens the DataBase
            Subjuect.Open();

            //Making a Create Command in Sql
            MySqlCommand mycmds = Subjuect.CreateCommand();

            //Sql Command Text or the What I want to be said in the create statement
            mycmds.CommandText = "Select t.* , c.classcode, c.classname From teachers t join classes c on t.teacherid = c.teacherid where t.teacherid = " + id;

            //Sql Reader - reads the cmds line and excutes them
            MySqlDataReader ResultsCmds = mycmds.ExecuteReader();
            //While the cmd line is readed
            while (ResultsCmds.Read())
            {
                //Gets all of the Values from the tables
                int TeacherId = (int)ResultsCmds["teacherid"];
                string TeacherFname = (string)ResultsCmds["teacherfname"];
                string TeacherLname = (string)ResultsCmds["teacherlname"];
                string EmployeeNumber = (string)ResultsCmds["employeenumber"];
                DateTime Hiredate = (DateTime)ResultsCmds["hiredate"];
                double Salary = Convert.ToDouble(ResultsCmds["salary"]);
                string ClassCode = (string)(ResultsCmds["classcode"]);
                string ClassName = (string)(ResultsCmds["classname"]);
                //string TeacherName = ResultsCmds["teacherfname"] + " " + ResultsCmds["teacherlname"];

                //Puts them in the NewTeacher Object
                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.EmployeeNumber = EmployeeNumber;
                NewTeacher.Hiredate = Hiredate;
                NewTeacher.ClassCode = ClassCode;
                NewTeacher.ClassName = ClassName;
                NewTeacher.Salary = Salary;

            }
            //returns NewTeacher
            return NewTeacher;
        }


   



    }



}
