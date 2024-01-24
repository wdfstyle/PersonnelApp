using PersonnelApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void button1_Click(object sender, EventArgs e)
        {
            EmploeeTabel empl = new EmploeeTabel(1, "Макарова", "Елена");
           
            foreach (var item in empl.GetTabel())
            {
                txtbox.Text += item.Key.ToShortDateString();
            }
            
        }
    }
}
