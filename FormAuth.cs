using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonnelApp
{
    public partial class FormAuth : Form
    {
        //SqlConnection credentials_db;
        public FormAuth()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextbox.Text;
            // Хэширование пароля
            byte[] hashedPasswordBytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password));
            string hashedPassword = Convert.ToBase64String(hashedPasswordBytes);

            if (CheckCredentials(username, hashedPassword))
            {
                //User currentUser = new User(username);


                
                Form form = new FormMain();
                form.Text = string.Concat("Добро пожаловать, ", currentUser.firstName, " ", currentUser.thirdName);
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверное имя пользователя или пароль.");
            }


        }
        private bool CheckCredentials(string username, string hashedPassword)
        {
            using (SqlConnection connection = new SqlConnection(AuthDBConnection.Path))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM users WHERE username=@username AND password=@password", connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", hashedPassword);
                int count = (int)command.ExecuteScalar();
                if (count > 0)
                {
                    SqlCommand init_command = new SqlCommand("SELECT firstName, familyName, thirdName, isAdmin FROM users WHERE username=@username", connection);
                    init_command.Parameters.AddWithValue("@username", username);

                    SqlDataReader reader = init_command.ExecuteReader();
                    if (reader.Read())
                    {
                        currentUser.firstName = reader.GetString(0);
                        currentUser.familyName = reader.GetString(1);
                        currentUser.thirdName = reader.GetString(2);
                        currentUser.isAdmin = Convert.ToBoolean(reader.GetString(3));
                    }

                    reader.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
