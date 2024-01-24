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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PersonnelApp
{
    public partial class FormDepartments : Form
    {
        public FormDepartments()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void FormDepartments_Load(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(MainDBConnection.Path))
            {
                await connection.OpenAsync();
                
                SqlDataReader depsReader = null;

                SqlCommand command = new SqlCommand("SELECT name FROM department", connection);

                try
                {
                    depsReader = await command.ExecuteReaderAsync();

                    while (await depsReader.ReadAsync())
                    {
                        checkedListBox1.Items.Add(Convert.ToString(depsReader["name"]));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (depsReader != null)
                    {
                        depsReader.Close();
                    } 
                }


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            while (checkedListBox1.CheckedIndices.Count > 0)
            {
                checkedListBox1.Items.RemoveAt(checkedListBox1.CheckedIndices[0]);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Add(textBox1.Text);
        }
    }
}
