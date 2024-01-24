using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelApp
{
    public static class currentUser
    {
        public static int Id { get; set; }

        //[Required]
        public static string firstName { get; set; }

        public static string familyName { get; set; }

        public static string thirdName { get; set; }

        public static bool isAdmin { get; set; }
    }
}
