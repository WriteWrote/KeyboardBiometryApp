using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Lab1KeyboasrdBiometry
{
    public partial class PassChangeForm : Form
    {
        private const String FILE_PATH_PASSWORD = "C:\\Users\\Рабочая\\Desktop\\BMIL_test\\currentKeyPhrase.txt";
        private String password;
        private Form1 parent;
        private List<String> preferredSymbols;
        private List<String> unvantedCombinations;
        private const int PASSWORD_POINTS = 5;

        public PassChangeForm(Form1 form)
        {
            InitializeComponent();

            using (StreamReader reader = new StreamReader(FILE_PATH_PASSWORD))
            {
                password = reader.ReadLine();
            }

            parent = form;
            preferredSymbols = new List<string>();
            try
            {
                using (StreamReader reader = new StreamReader("PasswordPreferredSymbols.txt"))
                {
                    while (!reader.EndOfStream)
                    {
                        preferredSymbols.Add(reader.ReadLine().Trim());
                    }
                }

                unvantedCombinations = new List<string>();
                using (StreamReader reader = new StreamReader("PasswordUnwantedCombination.txt"))
                {
                    while (!reader.EndOfStream)
                    {
                        unvantedCombinations.Add(reader.ReadLine().Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                //pass
            }
        }

        private void btn_ChangePass_Click(object sender, EventArgs e)
        {
            int score = 0;
            String newPass = tb_NewPass.Text;
            if (tb_OldPass.Text.Equals(password))
            {
                if (tb_NewPass.Text.Equals(tb_ConfirmNewPass.Text))
                {
                    if (newPass.Length > 8) score += 3;
                    if (newPass.Length > 11) score += 2;
                    // если есть заглавные буквы
                    if (!newPass.ToLowerInvariant().Equals(newPass)) score += 1;

                    foreach (var symbol in preferredSymbols)
                    {
                        if (newPass.Contains(symbol)) score += 1;
                    }
                    foreach (var combination in unvantedCombinations)
                    {
                        if (newPass.Contains(combination)) score -= 3;
                    }
                    
                    // final calculating
                    if (score >= PASSWORD_POINTS)
                    {
                        score = 0;
                        using (StreamWriter writer = new StreamWriter("currentKeyPhrase.txt", false))
                        {
                            writer.WriteLine(password);
                        }
                        MessageBox.Show("Password is changed!");
                    }
                    else
                    {
                        score = 0;
                        MessageBox.Show("Password is too weak, try again!");
                    }

                }
                else
                {
                    MessageBox.Show("Passwords do not match, but Ctrl+C Ctrl+V always works!");
                }
            }
            else
            {
                MessageBox.Show("Password is not incorrect, but you khow where to look up for a hint!");
            }
        }
    }
}