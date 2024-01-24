using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonnelApp
{
    class EmploeeTabel
    {
        int Id;
        string fio;
        Dictionary<DateTime, string> tabel;

        public EmploeeTabel(int id, string fname, string name)
        {
            this.Id = id;
            this.fio = $"{fname} {name}";
            this.tabel = new Dictionary<DateTime, string>();
        }

        public string GetFio() { return fio; }
        public Dictionary<DateTime, string> GetTabel() {  return tabel; }
        
        async public void setTabel()
        {
            using (SqlConnection connection = new SqlConnection(MainDBConnection.Path))
            {
                await connection.OpenAsync();

                SqlDataReader reader = null;

                SqlCommand command = new SqlCommand("SELECT date, status FROM [shedule] WHERE emploeeId=@emploeeId", connection);
                command.Parameters.AddWithValue("@emploeeId", this.Id);
                try
                {
                    reader = await command.ExecuteReaderAsync();

                    while (await reader.ReadAsync())
                    {
                        this.tabel.Add(reader.GetDateTime(0), reader.GetString(1));
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
