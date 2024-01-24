using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonnelApp
{
    public partial class FormShedule : Form
    {
        List<EmploeeTabel> EmplTabelList = new List<EmploeeTabel>();

        public FormShedule()
        {
            InitializeComponent();
        }

        private async void LoadData()
        {
            DateTime start = startPicker.Value;
            DateTime end = endPicker.Value;
            DateTime day = start;

            if (start > end)
            {
                MessageBox.Show("Начало периода указано позже его окончания");
                return;
            }

            if (dataGridView1 != null) 
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
            }
            
            if (EmplTabelList.Count() != 0)
            {
                EmplTabelList.Clear();
            }

            using (SqlConnection connection = new SqlConnection(MainDBConnection.Path))
            {


                await connection.OpenAsync();

                SqlDataReader reader = null;

                SqlCommand command = new SqlCommand("SELECT Id, familyName, firstName FROM [emploee]", connection);

                try
                {
                    reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        int id = reader.GetInt32(0);
                        string fname = Convert.ToString(reader["familyName"]);
                        string name = Convert.ToString(reader["firstName"]);
                        //EmploeeTabel empl = new EmploeeTabel(id, fname, name);
                        EmplTabelList.Add(new EmploeeTabel(id, fname, name));
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

                foreach (EmploeeTabel empl in EmplTabelList)
                {
                    empl.setTabel();
                }

                //dataGridView1.DefaultCellStyle.

                var fioColumn = new DataGridViewColumn();
                fioColumn.HeaderText = "Сотрудник";
                fioColumn.Width = 200;
                Font fioFont = new Font("Microsoft Sans Serif", 14);
                fioColumn.DefaultCellStyle.Font = fioFont;
                fioColumn.ReadOnly = true;
                fioColumn.Name = "fio";
                fioColumn.Frozen = true;
                fioColumn.CellTemplate = new DataGridViewTextBoxCell();
                dataGridView1.Columns.Add(fioColumn);

                
                while (day <= end)
                {
                    var column = new DataGridViewColumn();
                    column.HeaderText = day.ToShortDateString();
                    column.CellTemplate = new DataGridViewTextBoxCell();
                    column.Width = 65;
                    column.Name = day.ToShortDateString();
                    dataGridView1.Columns.Add(column);
                    if (dataGridView1.Columns.Count > 60) { break; }
                    day = day.AddDays(1);

                }

                foreach (var empl in EmplTabelList)
                {
                    int current = dataGridView1.Rows.Add(empl.GetFio());
                    foreach (var item in  empl.GetTabel()) 
                    {
                        Console.WriteLine(item.Key.ToShortDateString());
                        dataGridView1[item.Key.ToShortDateString(), current].Value = item.Value;
                        //dataGridView1
                    }
                }


            }
        }

        public void FormShedule_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void button2_Click(object sender, EventArgs e)
        {
            EmplTabelList.Clear();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
