using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using StreamWriter = System.IO.StreamWriter;

namespace Lab1KeyboasrdBiometry
{
    public partial class RegisterForm : Form
    {
        private String USERLIST = "userlist.txt";
        private List<String> names;
        private List<String> FILES;
        private List<User> users;

        public RegisterForm()
        {
            InitializeComponent();

            FILES = new List<string>();

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
            if (comboBox_users.SelectedItem == null)
            {
                MessageBox.Show("Выберите пользователя");
            }
            else
            {
                // через зад, но я хз, это не джава
                List<User> selectedUser = users.Where(x => x.Name.Equals(comboBox_users.SelectedItem)).ToList();

                if (selectedUser.Count != 0)
                {
                    Form1 mainForm = new Form1(selectedUser[0]);
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show("Нет такого пользователя, вы сломали программу!");
                }
            }
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

            foreach (var filepath in FILES)
            {
                string currFile = newUser.Name + "\\" + filepath + ".txt";
                if (!File.Exists(currFile))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(currFile))
                    {
                        sw.Write("");
                        if (filepath.Contains("KeyPhrase"))
                        {
                            sw.Write(newUser.Password);
                        }
                    }
                }
            }

            // adding username to users
            names.Add(newUser.Name);
            users.Add(newUser);

            using (StreamWriter writer = new StreamWriter(USERLIST, true))
            {
                writer.WriteLine("\n" + newUser.Name);
            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            users = new List<User>();
            names = readUsernamesFromFile();
            
            foreach (var name in names)
            {
                comboBox_users.Items.Add(name);
            }


            // todo: добавить считывание всех файлов, начинающихся с user... и вытаскивание оттуда средних параметров

            String currPass = "";
            long avgHoldingTime = 0;
            long avgSpeed = 0;
            Double avgErrors = 0.0;
            
            foreach (var name in names)
            {
                string currFile = name + "\\phrase1Stats.txt";
                    if (!File.Exists(currFile))
                    {
                        //Read stats from last time
                        using (StreamReader reader = new StreamReader(currFile))
                        {
                            
                            
                        }
                    }

                    currFile = name + "\\currentKeyPhrase.txt";
                    if (!File.Exists(currFile))
                    {
                        //read password for user
                        using (StreamReader reader = new StreamReader(currFile))
                        {
                            currPass = reader.ReadToEnd();
                        }
                    }
                    
                    users.Add(new User(name, currPass, avgHoldingTime, avgSpeed, avgErrors));
            }
        }

        private void comboBox_users_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Todo: подтягивать и отображать в textbox статы для конкретного пользователя
        }

        private List<String> readUsernamesFromFile()
        {
            using (StreamReader reader = new StreamReader(USERLIST))
            {
                String text = reader.ReadToEnd();
                return text.Split('\n').ToList();
            }
        }
    }
}