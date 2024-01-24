using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace PersonnelApp
{
    class EmploeeTabel
    {
        int Id;
        string fio;
        //Dictionary<DateTime, string> tabel;

        public EmploeeTabel(int id, string fname, string name)
        {
            this.Id = id;
            this.fio = $"{fname} {name}";
            //this.tabel = new Dictionary<DateTime, string>();
        }

        public string GetFio() { return fio; }
        public int GetId() { return Id; }
        
        //public Dictionary<DateTime, string> GetTabel() {  return tabel; }
        
        /*async public void SetTabel(DateTime start, DateTime end)
        {
            using (SqlConnection connection = new SqlConnection(MainDBConnection.Path))
            {
                await connection.OpenAsync();

                SqlDataReader reader = null;

                SqlCommand command = new SqlCommand("SELECT workday, status FROM shedule WHERE emploeeId=@emploeeId AND workday BETWEEN @start AND @end", connection);
                command.Parameters.AddWithValue("@emploeeId", this.Id);
                command.Parameters.AddWithValue("@start", start);
                command.Parameters.AddWithValue("@end", end);

                try
                {
                    reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        this.tabel.Add(reader.GetDateTime(0).Date, reader.GetString(1));
                    }
                    //this.tabel.Add(new DateTime(2023, 12, 4), "Я");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    string content = "TABEL FILLED:\n";
                    foreach (var item in this.tabel)
                    {
                        content += $"workday = {item.Key.ToString("dd-MM-yyyy")}, status = {item.Value}\n";
                    }
                        MessageBox.Show(content);
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }
            }
        }*/
    }
}
