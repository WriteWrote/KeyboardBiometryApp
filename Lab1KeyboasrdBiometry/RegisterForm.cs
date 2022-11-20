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
                        sw.Close();
                    }
                }
            }

            // adding username to users
            names.Add(newUser.Name);
            users.Add(newUser);

            using (StreamWriter writer = new StreamWriter(USERLIST, true))
            {
                writer.WriteLine("\n" + newUser.Name);
                writer.Close();
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

            String currPass = "";
            long avgHoldingTime = 0;
            long avgSpeed = 0;
            Double avgErrors = 0.0;

            foreach (var name in names)
            {
                string currFile = name + "\\phrase1Stats.txt";
                if (File.Exists(currFile))
                {
                    //Read stats from last time
                    using (StreamReader reader = new StreamReader(currFile))
                    {
                        String[] values = CollectStats(currFile, avgSpeed, avgHoldingTime, avgErrors);

                        avgSpeed = long.Parse(values[0]);
                        avgHoldingTime = long.Parse(values[1]);
                        avgErrors = Double.Parse(values[2]);
                        
                        reader.Close();
                    }
                }

                currFile = name + "\\currentKeyPhrase.txt";
                if (File.Exists(currFile))
                {
                    //read password for user
                    using (StreamReader reader = new StreamReader(currFile))
                    {
                        currPass = reader.ReadToEnd().Trim(new char[] { '\r', '\n' });
                        reader.Close();
                    }
                }

                users.Add(new User(name, currPass, avgHoldingTime, avgSpeed, avgErrors));
            }
        }

        private void comboBox_users_SelectedIndexChanged(object sender, EventArgs e)
        {
            // через зад, но я хз, это не джава
            List<User> selectedUser = users.Where(x => x.Name.Equals(comboBox_users.SelectedItem)).ToList();

            if (selectedUser.Count != 0)
            {
                textBox_info.Text = "Name: " + selectedUser[0].Name + Environment.NewLine +
                                    "Password: " + selectedUser[0].Password + Environment.NewLine +
                                    "Speed: " + selectedUser[0].AvgSpeed + Environment.NewLine +
                                    "Holding time: " + selectedUser[0].AvgHoldingTime + Environment.NewLine +
                                    "Errors: " + selectedUser[0].AvgErrors + Environment.NewLine;
            }
        }

        private List<String> readUsernamesFromFile()
        {
            using (StreamReader reader = new StreamReader(USERLIST))
            {
                String text = reader.ReadToEnd();
                List<String> list = new List<string>();

                foreach (var VARIABLE in text.Split('\n').ToList())
                {
                    list.Add(VARIABLE.Split('\r')[0]);
                }

                reader.Close();
                return list;
            }
        }

        private static void readRawStats(StreamReader reader,
            List<long> avgSpeeds,
            List<long> avgHoldings,
            List<Double> avgErrors)
        {
            String text = reader.ReadToEnd();
            reader.Close();
            String[] lines = text.Split('\n');

            foreach (var l in lines)
            {
                if (!DateTime.TryParse(l, out DateTime result))
                {
                    if (l.Contains("Average holding time:"))
                    {
                        String s = l.Split(':')[1].Trim().Split(' ')[0];
                        avgHoldings.Add(long.Parse(s.Trim()));
                    }

                    if (l.Contains("Speed:"))
                    {
                        String s = l.Split(':')[1].Trim().Split(' ')[0];
                        avgSpeeds.Add(long.Parse(s.Trim()));
                    }

                    if (l.Contains("Errors:"))
                    {
                        String s = l.Split(':')[1].Trim().Split(' ')[0];
                        avgErrors.Add(Double.Parse(s.Trim()));
                    }
                }
            }
        }

        private String[] CollectStats(String filepath, long avgSpeed, long avgHolding, Double avgError)
        {
            List<long> avgSpeeds = new List<long>();
            List<long> avgHoldings = new List<long>();
            List<Double> avgErrors = new List<double>();

            readRawStats(new StreamReader(filepath), avgSpeeds, avgHoldings, avgErrors);

            foreach (var speed in avgSpeeds)
            {
                avgSpeed += speed;
            }

            if (avgSpeeds.Count == 0)
            {
                avgSpeed = 0;
            }
            else
            {
                avgSpeed /= avgSpeeds.Count;
            }

            foreach (var holding in avgHoldings)
            {
                avgHolding += holding;
            }

            if (avgHoldings.Count == 0)
            {
                avgHolding = 0;
            }
            else
            {
                avgHolding /= avgHoldings.Count;
            }

            foreach (var error in avgErrors)
            {
                avgError += error;
            }

            if (avgErrors.Count == 0)
            {
                avgError = 0;
            }
            else
            {
                avgError /= avgErrors.Count;
            }

            return new[] { avgSpeed.ToString(), avgHolding.ToString(), avgError.ToString() };
        }

        private void button_showAll_Click(object sender, EventArgs e)
        {
            textBox_info.Text = "";
            foreach (var user in users)
            {
                textBox_info.Text += "Name: " + user.Name + Environment.NewLine +
                                     "Password: " + user.Password + Environment.NewLine +
                                     "Speed: " + user.AvgSpeed + Environment.NewLine +
                                     "Holding time: " + user.AvgHoldingTime + Environment.NewLine +
                                     "Errors: " + user.AvgErrors + Environment.NewLine + Environment.NewLine;
            }
        }
    }
}