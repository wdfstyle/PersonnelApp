using PersonnelApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FormOrderOut : Form
    {
        public FormOrderOut()
        {
            InitializeComponent();
        }

        public string currentEmpl = "";
        public string currentNum = "";
        public string currentDate = "";

        private void button1_Click(object sender, EventArgs e)
        {
            var helper = new WordHelper(@"приказ_увольнение.doc");

            var items = new Dictionary<string, string>
            {
                { "<NUM>", currentNum },
                { "<DATE>", currentDate },
                { "<EMPL>", currentEmpl },
                { "<DEP>", depBox.Text },
                { "<PROF>", profPicker.Text },
                { "<REASON>", reasonBox.Text },
                { "<OSN>", osnBox.Text },
                { "<OUT_DATE>", datePicker.Value.Date.ToString("dd.MM.yyyy") },
                { "<DOC_DATE>", docDatePicker.Value.Date.ToString("dd.MM.yyyy") },
                { "DOC_NUM", docNumBox.Text },
            };
            helper.Process(items);
            MessageBox.Show("Документ сформирован", "Ответ от сервера", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
