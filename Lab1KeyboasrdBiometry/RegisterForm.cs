using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Lab1KeyboasrdBiometry
{
    public partial class RegisterForm : Form
    {
        private String USERLIST = "userlist.txt";
        private List<String> names;
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

        private void button1_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            names = new List<string>();
            using (StreamReader reader = new StreamReader(USERLIST))
            {
                String text = reader.ReadToEnd();
                names = text.Split('\n').ToList();
            }

            foreach (var name in names)
            {
                comboBox_users.Items.Add(name);
            }
        }
    }
}