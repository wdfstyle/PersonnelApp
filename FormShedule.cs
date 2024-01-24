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
        List<EmploeeTabel> emplList = new List<EmploeeTabel>();

        public FormShedule()
        {
            InitializeComponent();
        }

        public async void LoadData()
        {
            DateTime start = startPicker.Value.Date;
            DateTime end = endPicker.Value.Date;
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
            
            if (emplList.Count() != 0)
            {
                emplList.Clear();
            }

            using (SqlConnection connection = new SqlConnection(MainDBConnection.Path))
            {


                await connection.OpenAsync();

                SqlDataReader reader = null;

                SqlCommand command = new SqlCommand("SELECT Id, familyName, firstName FROM emploee", connection);

                try
                {
                    reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        int id = reader.GetInt32(0);
                        string fname = Convert.ToString(reader["familyName"]);
                        string name = Convert.ToString(reader["firstName"]);
                        EmploeeTabel empl = new EmploeeTabel(id, fname, name);
                        emplList.Add(empl);
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
                //connection.Close();
            }

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
                    column.HeaderText = day.ToString("dd-MM-yyyy");
                    column.CellTemplate = new DataGridViewTextBoxCell();
                    column.Width = 65;
                    column.Name = day.Date.ToString("dd-MM-yyyy");
                    dataGridView1.Columns.Add(column);
                    if (dataGridView1.Columns.Count > 60) { break; }
                    day = day.AddDays(1);

                }

                foreach (var empl in emplList)
                {
                    
                    Dictionary<DateTime, string> tabel = new Dictionary<DateTime, string>();
                    using (SqlConnection tabel_connection = new SqlConnection(MainDBConnection.Path))
                    {
                        await tabel_connection.OpenAsync();

                        SqlDataReader tabel_reader = null;

                        SqlCommand tabel_command = new SqlCommand("SELECT workday, status FROM shedule WHERE emploeeId=@emploeeId AND workday BETWEEN @start AND @end", tabel_connection);

                        tabel_command.Parameters.AddWithValue("@emploeeId", empl.GetId());
                        tabel_command.Parameters.AddWithValue("@start", start);
                        tabel_command.Parameters.AddWithValue("@end", end);

                        try
                        {
                            tabel_reader = await tabel_command.ExecuteReaderAsync();

                            while (await tabel_reader.ReadAsync())
                            {
                                tabel.Add(tabel_reader.GetDateTime(0).Date, tabel_reader.GetString(1));
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            if (tabel_reader != null)
                            {
                                tabel_reader.Close();
                            }
                            tabel_command.Parameters.Clear();
                        }
                    }
                    
                int current_row = dataGridView1.Rows.Add(empl.GetFio());
                dataGridView1.Rows[current_row].Height = 50;
                foreach (var item in tabel)
                {
                    string current_col = item.Key.Date.ToString("dd-MM-yyyy");
                    dataGridView1[current_col, current_row].Value = item.Value.Trim();
                }
                tabel.Clear();
                    
                


            }
        }

        public void FormShedule_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void button2_Click(object sender, EventArgs e)
        {
            //emplList.Clear();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.Value.ToString().Trim() == "Н")
                cell.Style.BackColor = Color.LightCoral;
            else if (cell.Value.ToString().Trim() == "В")
                cell.Style.BackColor = Color.LightGray;
            else if (cell.Value.ToString().Trim() == "ОТ")
                cell.Style.BackColor = Color.White;
            else if (cell.Value.ToString().Trim() == "Я")
                cell.Style.BackColor = Color.LightGreen;
            else if (cell.Value.ToString().Trim() == "ДО")
                cell.Style.BackColor = Color.Gold;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Данные записаны", "Ответ от сервера");

        }
    }
}
