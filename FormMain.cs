using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonnelApp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DepartmentsButton_Click(object sender, EventArgs e)
        {
            Form deps = new FormDepartments();
            deps.Show();
        }

        private void EmplButton_Click(object sender, EventArgs e)
        {
            Form empl = new FormEmpl();
            empl.Show();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            if (currentUser.isAdmin)
            {
                addUserButton.Visible = true;
            }
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            Form addNewUserForm = new FormNewUser();
            addNewUserForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form sheduleForm = new FormShedule();
            sheduleForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form docsForm = new FormDocs();
            docsForm.Show();
        }
    }
}
