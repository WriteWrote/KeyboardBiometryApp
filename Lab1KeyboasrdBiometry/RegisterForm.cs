using System;
using System.Windows.Forms;

namespace Lab1KeyboasrdBiometry
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void button_Enter_Click(object sender, EventArgs e)
        {
            Form1 mainForm = new Form1();
            mainForm.Show();
        }

        private void button_Create_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}