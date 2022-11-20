using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Lab1KeyboasrdBiometry
{
    public partial class PassChangeForm : Form
    {
        private const String FILE_PATH_PASSWORD = "currentKeyPhrase.txt";

        private String password;

        private Form1 parent;
        private List<String> preferredSymbols;
        private List<String> unvantedCombinations;
        private const int PASSWORD_POINTS = 5;
        private User currentUser;

        private Random RANDOM = new Random();

        private String CHARS =
            "ЙЦУКЕНГШЩЗХЪФЫВАПРОЛДЖЭЯЧСМИТЬБЮйцукенгшщзхъфывапролджэячсмитьбюABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        private String NUMERICS = "0123456789";
        private String SYMBOLS = "!@#$%^&*()_+|/.,\\-=\"№;%:?*{}[]~'";


        public PassChangeForm(Form1 form, User currentUser)
        {
            InitializeComponent();

            this.currentUser = currentUser;

            using (StreamReader reader = new StreamReader(currentUser.Name + "\\" + FILE_PATH_PASSWORD))
            {
                password = reader.ReadLine();
                reader.Close();
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
                    reader.Close();
                }

                unvantedCombinations = new List<string>();
                using (StreamReader reader = new StreamReader("PasswordUnwantedCombination.txt"))
                {
                    while (!reader.EndOfStream)
                    {
                        unvantedCombinations.Add(reader.ReadLine().Trim());
                    }
                    reader.Close();
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
                        using (StreamWriter writer = new StreamWriter(currentUser.Name + "\\" + FILE_PATH_PASSWORD, false))
                        {
                            writer.WriteLine(newPass);
                            writer.Close();
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

            // label.Text = "";
            label.Text = "Сложность пароля: " + CalculatePasswordDifficalty( newPass);
        }

        private Double CalculatePasswordDifficalty(String pass)
        {
            // https://habr.com/ru/post/116331/

            Double bits = Math.Log(CHARS.Length) * (pass.Length / Math.Log(2));
            return bits;
        }

        private void btn_GenPass_Click(object sender, EventArgs e)
        {
            int type = cB_Diffs.SelectedIndex;
            tb_NewPass.Text = "";

            if (type == 0)
            {
                for (int i = 0; i < 7; i++)
                {
                    tb_NewPass.Text += GetRandomChar(CHARS);
                }
            }
            else if (type == 1)
            {
                for (int i = 0; i < 9; i++)
                {
                    char ch = GetRandomChar(CHARS);
                    if (i % 3 == 0)
                    {
                        ch = Char.ToUpper(ch);
                        tb_NewPass.Text += GetRandomNumeric();
                    }

                    tb_NewPass.Text += ch;
                }
            }
            else if (type == 2)
            {
                for (int i = 0; i < 9; i++)
                {
                    char ch = GetRandomChar(CHARS);
                    if (i % 3 == 0)
                    {
                        ch = Char.ToUpper(ch);
                        if (i % 2 == 0)
                        {
                            tb_NewPass.Text += GetRandomSymbol();
                        }
                        else
                        {
                            tb_NewPass.Text += GetRandomNumeric();
                        }
                    }

                    tb_NewPass.Text += ch;
                }
            }
            else
            {
                for (int i = 0; i < 15; i++)
                {
                    char ch = GetRandomChar(CHARS);
                    if (i % 2 == 0)
                    {
                        tb_NewPass.Text += GetRandomSymbol();
                        if (i % 3 == 0)
                        {
                            tb_NewPass.Text += GetRandomNumeric();
                        }
                    }

                    tb_NewPass.Text += ch;
                }
            }
        }

        private char GetRandomChar(String chars)
        {
            return chars[RANDOM.Next(chars.Length)];
        }

        private char GetRandomNumeric()
        {
            return NUMERICS[RANDOM.Next(NUMERICS.Length)];
        }

        private char GetRandomSymbol()
        {
            return SYMBOLS[RANDOM.Next(SYMBOLS.Length)];
        }
    }
}