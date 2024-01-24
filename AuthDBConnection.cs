using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelApp
{
    public static class AuthDBConnection
    {
        public static string Path = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\PersonnelApp\user_db.mdf;Integrated Security = True";
    }
}
