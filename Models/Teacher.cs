using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace ElliotBrownFordAssignment03ForHttp5112.Models
{

    /// <summary>
    /// This Classes Allows Me To Use this properties as if they were the database Table Colmuns
    /// </summary>
    ///
    public class Teacher
    {
        public int TeacherId;
        public string TeacherFname;
        public string TeacherLname;
        public string EmployeeNumber;
        public DateTime Hiredate;
        public double Salary;
        public string ClassCode;
        public string ClassName;
    }
}