using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonnelApp
{
    public partial class FormNewEmpl : Form
    {
        public FormNewEmpl()
        {
            InitializeComponent();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        /*private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }*/

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (this.FamilyNameBox.Text == "" | this.NameBox.Text == "")
            {
                MessageBox.Show("Недостаточно данных для добавления сотрудника\nЗаполните поля Фамилия, Имя, Отчество");
            }

            else 
            {
                Emploee empl = new Emploee();
                empl.Name = this.NameBox.Text;
                empl.FamilyName = this.FamilyNameBox.Text; 
                empl.ThirdName = this.ThirdNameBox.Text;
                if (MaleRadioButton.Checked)
                {
                    empl.Gender = "М";
                }
                else { empl.Gender = "Ж"; }

                if (PhoneHomeBox.Text != "")
                {
                    empl.PhoneHome = PhoneHomeBox.Text;
                }
                if (PhoneMobileBox.Text != "")
                {
                    empl.PhoneMobile = PhoneMobileBox.Text;
                }
                if (AddressBox.Text != "") 
                { 
                    empl.Address = AddressBox.Text;
                }

                string message = $"Будет добален сотрудник:\n\nФИО - {empl.FamilyName} {empl.Name} {empl.ThirdName}\n\nМобильный тел. - {empl.PhoneMobile}\nДомашний тел. - {empl.PhoneHome}\n";

                DialogResult result =  MessageBox.Show(
                                                        message, 
                                                        "Подтверждение записи", 
                                                        MessageBoxButtons.OKCancel, 
                                                        MessageBoxIcon.Question, 
                                                        MessageBoxDefaultButton.Button1);
                if (result == DialogResult.OK)
                {
                    using (SqlConnection connection = new SqlConnection(MainDBConnection.Path))
                    {
                        await connection.OpenAsync();

                        SqlCommand command = new SqlCommand("INSERT INTO emploee (firstName, familyName, thirdName, gender, homePhone, mobilePhone) " +
                                                            "VALUES (@name, @fname, @tname, @gender, @hphone, @mphone)", connection);
                        command.Parameters.AddWithValue("name", empl.Name);
                        command.Parameters.AddWithValue("fname", empl.FamilyName);
                        command.Parameters.AddWithValue("tname", empl.ThirdName);
                        command.Parameters.AddWithValue("gender", empl.Gender);
                        command.Parameters.AddWithValue("hphone", empl.PhoneHome);
                        command.Parameters.AddWithValue("mphone", empl.PhoneMobile);

                        await command.ExecuteNonQueryAsync();

                    }
                }
                MessageBox.Show("Сотрудник добавлен в БД\n","Ответ от сервера");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
