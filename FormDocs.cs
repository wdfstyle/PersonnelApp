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
            var helper = new WordHelper("order.doc");
            var items = new Dictionary<string, string>
            {
                { "<NUM>", orderNumberBox.Text},
                {"<DATE>", datePicker.Value.Date.ToString("dd MM yyyy")},
                {"<EMPL>", emplBox.SelectedItem.ToString()},
            };
            helper.Process(items);
        }

        private System.Drawing.Printing.PrintDocument docToPrint =
        new System.Drawing.Printing.PrintDocument();
        private void previewButton_Click(object sender, EventArgs e)
        {

        // Allow the user to choose the page range he or she would
        // like to print.
            PrintDialog1.AllowSomePages = true;

            // Show the help button.
            PrintDialog1.ShowHelp = true;

            // Set the Document property to the PrintDocument for 
            // which the PrintPage Event has been handled. To display the
            // dialog, either this property or the PrinterSettings property 
            // must be set 
            PrintDialog1.Document = docToPrint;

            DialogResult result = PrintDialog1.ShowDialog();

            // If the result is OK then print the document.
            if (result == DialogResult.OK)
            {
                docToPrint.Print();
            }
        }
    }
}
