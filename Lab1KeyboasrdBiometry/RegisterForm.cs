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
        private List<String> FILES;
        public RegisterForm()
        {
            InitializeComponent();
            
            FILES.Add("currentKeyPhrase");
            FILES.Add("phr1KDownLog");
            FILES.Add("phr2KDownLog");
            FILES.Add("phr1KUpLog");
            FILES.Add("phr2KUpLog");
            FILES.Add("phrase1Stats");
            FILES.Add("phrase2Stats");
        }

        private void button_Enter_Click(object sender, EventArgs e)
        {
            Form1 mainForm = new Form1();
            mainForm.Show();
        }

        private void button_Create_Click(object sender, EventArgs e)
        {
            User newUser = new User(textBox_name.Text.Trim(),
                textBox_password.Text,
                0,
                0,
                0);
            
            // creating files w/ stats for user
            Directory.CreateDirectory(newUser.Name);
            string path = @"c:\temp\MyTest.txt";
            if (!File.Exists("\\" + newUser.Name + ""))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("Hello");
                    sw.WriteLine("And");
                    sw.WriteLine("Welcome");
                }
            }

            // adding username to users

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
            
            
            // todo: добавить считывание всех файлов, начинающихся с user... и вытаскивание оттуда средних параметров
        }

        private void comboBox_users_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Todo: подтягивать и отображать в textbox статы для конкретного пользователя
        }
    }
}