using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelApp
{
    public class User
    {
        public int Id { get; set; }

        //[Required]
        public string username { get; set; }
        
        public string password { get; set; }
        
        public string firstName { get; set; }

        public string familyName { get; set; }

        public string thirdName { get; set; }

        public bool isAdmin = false;

        public bool AddToDB() 
            {
                using (SqlConnection connection = new SqlConnection(AuthDBConnection.Path))
                {
                    connection.Open();
                    SqlCommand check_command = new SqlCommand("SELECT COUNT(*) FROM users WHERE username=@username", connection);
                    check_command.Parameters.AddWithValue("@username", username);
                    int count = (int)check_command.ExecuteScalar();
                    if (count > 0) 
                    {
                        return false;
                    }
                    else
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO [users] (username, Password, IsAdmin, firstName, familyName, thirdName)VALUES(@username, @password, @isAdmin, @firstName, @familyName, @thirdName)", connection);
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);
                        command.Parameters.AddWithValue("@isAdmin", Convert.ToString(isAdmin));
                        command.Parameters.AddWithValue("@firstName", firstName);
                        command.Parameters.AddWithValue("@familyName", familyName);
                        command.Parameters.AddWithValue("@thirdName", thirdName);
                        command.ExecuteNonQuery();
                        return true;
                    }

                }
            }
    }
}
