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
    public partial class FormOtpusk : Form
    {
        public FormOtpusk()
        {
            InitializeComponent();
        }

        public string currentEmpl = "";
        public string currentNum = "";
        public string currentDate = "";


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var helper = new WordHelper(@"приказ_отпуск.doc");

            var items = new Dictionary<string, string>
            {
                { "<NUM>", currentNum },
                { "<DATE>", currentDate },
                { "<EMPL>", currentEmpl },
                { "<DEP>", depBox.Text },
                { "<PROF>", profPicker.Text },
                { "<OSN>", osnBox.Text },
                { "<START>", startPicker.Value.Date.ToString("dd.MM.yyyy") },
                { "<END>", endPicker.Value.Date.ToString("dd.MM.yyyy") },
                { "COUNT", countBox.Text },
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
    }
}
