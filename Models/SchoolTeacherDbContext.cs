using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace ElliotBrownFordAssignment03ForHttp5112.Models
{
    /// <summary>
    /// This Classes gets the connection to my database so I'm able to access the tables in that database
    /// </summary>
    ///
    public class SchoolTeacherDbContext
    {
        private static string User { get { return "root"; } }


        private static string Password { get { return "root"; } }


        private static string Database { get { return "teachers"; } }


        private static string Server { get { return "localhost"; } }

        private static string Port { get { return "3306"; } }


        protected static string ConnectionString
        {
            get
            {
                return "server = " + Server
                    + "; user = " + User
                    + "; database = " + Database
                    + "; port = " + Port
                    + "; password = " + Password;




            }
        }


        public MySqlConnection AccessDatabase()
        {
            return new MySqlConnection(ConnectionString);
        }
    }




}