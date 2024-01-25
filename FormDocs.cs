using Microsoft.Office.Interop.Word;
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
using WindowsFormsApp1;


namespace PersonnelApp
{
    public partial class FormDocs : Form
    {
        public FormDocs()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void FormDocs_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(MainDBConnection.Path))
            {
                await connection.OpenAsync();

                SqlDataReader reader = null;

                SqlCommand command = new SqlCommand("SELECT familyName, firstName, thirdName FROM [emploee]", connection);

                try
                {
                    reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        string familyName = Convert.ToString(reader["familyName"]);
                        string firstName = Convert.ToString(reader["firstName"]);
                        string thirdName = Convert.ToString(reader["thirdName"]);

                        emplBox.Items.Add($"{familyName} {firstName} {thirdName}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }
            }
        }

        private void makeButton_Click(object sender, EventArgs e)
        {

            /*var docTypes = new Dictionary<string, string>
            {
                {"отпуск", @"приказ_отпуск.doc" },
                {"прием", @"приказ_прием.doc" },
                {"увольнение", @"приказ_увольнение.doc" },
            };*/


            switch (orderTypeBox.Text)
            {
                case "Отпуск":
                    
                    var form = new FormOtpusk();
                    form.currentEmpl = emplBox.SelectedItem.ToString();
                    form.currentNum = orderNumberBox.Text;
                    form.currentDate = datePicker.Value.Date.ToString("dd MM yyyy");
                    form.Show();
                    break;

                case "Приём":
                    
                    var form1 = new FormOrderIn();
                    form1.currentEmpl = emplBox.SelectedItem.ToString();
                    form1.currentNum = orderNumberBox.Text;
                    form1.currentDate = datePicker.Value.Date.ToString("dd MM yyyy");
                    form1.Show();

                    break;

                case "Увольнение":

                    var form2 = new FormOrderOut();
                    form2.currentEmpl = emplBox.SelectedItem.ToString();
                    form2.currentNum = orderNumberBox.Text;
                    form2.currentDate = datePicker.Value.Date.ToString("dd MM yyyy");
                    form2.Show();
                    break;
            }


            /*var helper = new WordHelper(docTypes[orderTypeBox.Text]);
            var items = new Dictionary<string, string>
            {
                { "<NUM>", orderNumberBox.Text},
                {"<DATE>", datePicker.Value.Date.ToString("dd MM yyyy")},
                {"<EMPL>", emplBox.SelectedItem.ToString()},
            };
            helper.Process(items);
            MessageBox.Show("Документ сформирован", "Ответ от сервера", MessageBoxButtons.OK,MessageBoxIcon.Information);*/
        }

        private void previewButton_Click(object sender, EventArgs e)
        {

            if (CurrentDocument.currentDoc != null)
            {
                CurrentDocument.currentDoc.PrintDoc();
            }
            else
            {
                MessageBox.Show("Файл не загружен");
            }
        }
    }
}
