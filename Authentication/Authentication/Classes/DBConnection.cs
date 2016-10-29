using DBManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Authentication.Classes
{
    public class DBConnection
    {
        public DBOpeartion cobject = new DBOpeartion(System.Configuration.ConfigurationManager.ConnectionStrings["ElearningConnectionString"].ConnectionString);
        public static string ConnectString = System.Configuration.ConfigurationManager.ConnectionStrings["ElearningConnectionString"].ConnectionString;

    }
}