using PersonnelApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonnelApp
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            
            Dictionary<DateTime, string> test = new Dictionary<DateTime, string>();
            int id = 6;
            DateTime start = startPicker.Value.Date;
            DateTime end = endPicker.Value.Date;

            using (SqlConnection connection = new SqlConnection(MainDBConnection.Path))
            {
                await connection.OpenAsync();

                SqlDataReader reader = null;

                SqlCommand command = new SqlCommand("SELECT workday, status FROM shedule WHERE emploeeId=@emploeeId AND workday BETWEEN @start AND @end", connection);
                command.Parameters.AddWithValue("@emploeeId", id);
                command.Parameters.AddWithValue("@start", start);
                command.Parameters.AddWithValue("@end", end);
                try
                {
                    reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        //DateTime workday = reader.GetDateTime(0).Date;
                        test.Add(reader.GetDateTime(0).Date, reader.GetString(1));
                    }
                    //this.tabel.Add(new DateTime(2023, 12, 4), "Я");
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
            textbox.Text += $"{test.Count}\n";
            foreach (var item in test)
            {
                textbox.Text += $"workday = {item.Key.ToString("dd-MM-yyyy")}, status = {item.Value}\n";
            }




            EmploeeTabel empl = new EmploeeTabel(1, "Макарова", "Елена");


            /*empl.SetTabel(start, end);
            Dictionary<DateTime, string> tbl = empl.GetTabel();
            textbox2.Text += $"{empl.GetFio()}\n";
            textbox2.Text += $"{tbl.Count}\n";

           
            foreach (var item in tbl)
            {
                textbox2.Text += $"workday = {item.Key.ToString("dd-MM-yyyy")}, status = {item.Value}\n";
            }*/

        }
    }
}
