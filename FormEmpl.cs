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
    public partial class FormEmpl : Form
    {
        public FormEmpl()
        {
            InitializeComponent();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            while (EmplListBox.CheckedIndices.Count > 0)
            {
                EmplListBox.Items.RemoveAt(EmplListBox.CheckedIndices[0]);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Form newEmpl = new FormNewEmpl();
            newEmpl.Show();
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            EmplListBox.Sorted = true;
        }

        private async void FormEmpl_Load(object sender, EventArgs e)
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

                        EmplListBox.Items.Add($"{familyName} {firstName} {thirdName}");
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
    }
}
