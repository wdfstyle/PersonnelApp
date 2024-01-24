using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonnelApp
{
    public partial class FormNewUser : Form
    {
        public FormNewUser()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (usernameTextBox.Text == "" |  passwordTextBox.Text == "" | confirmPassTextBox.Text == "") 
            {
                MessageBox.Show("Недостаточно данных для добавления пользователя\nЗаполните поля Имя пользователя, пароль, подверждение пароля");
            }
            else if (passwordTextBox.Text != confirmPassTextBox.Text)
            {
                MessageBox.Show("Введенные пароли не совпадают");
            }
            else
            {
                User newUser = new User();
                newUser.username = usernameTextBox.Text;
                
                byte[] hashedPasswordBytes = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(passwordTextBox.Text));
                newUser.password = Convert.ToBase64String(hashedPasswordBytes);

                newUser.firstName = nameTextBox.Text;
                newUser.familyName = familyNameTextBox.Text;
                newUser.thirdName = thirdNameTextBox.Text;
                newUser.isAdmin = IsAdminCheckBox.Checked;
                
                if (newUser.AddToDB()) 
                {
                    MessageBox.Show("Пользователь добавлен");
                }
                else 
                { 
                    MessageBox.Show("Пользользователь с таким именем уже существует"); 
                }
            }
        }
    }
}
