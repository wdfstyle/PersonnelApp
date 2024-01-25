using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace PersonnelApp
{
    public partial class FormOrderIn : Form
    {
        public FormOrderIn()
        {
            InitializeComponent();
        }
        public string currentEmpl = "";
        public string currentNum = "";
        public string currentDate = "";



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var helper = new WordHelper(@"приказ_прием.doc");

            string ispLength = "-";
            if (checkBox1.Checked)
            {
                ispLength = isplengthBox.Text;
            }

            var items = new Dictionary<string, string>
            {
                { "<NUM>", currentNum },
                { "<DATE>", currentDate },
                { "<EMPL>", currentEmpl },
                { "<DEP>", depBox.Text },
                { "<PROF>", profPicker.Text },
                { "<OKLAD>", okladBox.Text },
                { "<OVER>", overBox.Text },
                { "<IN_DATE>", datePicker.Value.Date.ToString("dd.MM.yyyy") },
                { "<LEN>", ispLength},
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
