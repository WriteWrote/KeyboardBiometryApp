using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ZedGraph;

namespace Lab1KeyboasrdBiometry
{
    public partial class Form1 : Form
    {
        private const String FILE_PATH_KEYS_DOWN_PHR1 = "phr1KDownLog.txt";
        private const String FILE_PATH_KEYS_UP_PHR1 = "phr1KUpLog.txt";
        private const String FILE_PATH_KEYS_DOWN_PHR2 = "phr2KDownLog.txt";
        private const String FILE_PATH_KEYS_UP_PHR2 = "phr2KUpLog.txt";
        private const String FILE_PATH_STATS1 = "phrase1Stats.txt";
        private const String FILE_PATH_STATS2 = "phrase2Stats.txt";
        private const String FILE_PATH_PASSWORD = "currentKeyPhrase.txt";

        private List<KeyValuePair<String, long>> keysDownDict;
        private List<KeyValuePair<String, long>> keysUpDict;

        private String password;
        private static long refAvgHoldingTime;
        private static long refAvgSpeed;
        private static Double refAvgError;
        private static Dictionary<String, long> refKeyHolding;

        // score for decision making
        private int score = 0;
        // list of average speeds for making graphics
        List<long> avgSpdsForGist = new List<long>();

        public Form1()
        {
            InitializeComponent();

            keysDownDict = new List<KeyValuePair<string, long>>();
            keysUpDict = new List<KeyValuePair<string, long>>();

            refAvgError = 0.0;
            refAvgSpeed = 0;
            refAvgHoldingTime = 0;
            refKeyHolding = new Dictionary<string, long>();

            using (StreamReader reader = new StreamReader(FILE_PATH_PASSWORD))
            {
                password = reader.ReadLine();
            }
        }


        private void tB_phrase1_KeyDown(object sender, KeyEventArgs e)
        {
            if (keysDownDict.Count == 0 ||
                !keysDownDict[keysDownDict.Count - 1].Key.Equals(e.KeyCode.ToString()))
            {
                keysDownDict.Add(new KeyValuePair<string, long>(e.KeyCode.ToString(),
                    GetNanoseconds()));
            }
        }

        private void tB_phrase1_KeyUp(object sender, KeyEventArgs e)
        {
            if (keysUpDict.Count == 0 ||
                !keysUpDict[keysUpDict.Count - 1].Key.Equals(e.KeyCode.ToString()))
            {
                keysUpDict.Add(new KeyValuePair<string, long>(e.KeyCode.ToString(),
                    GetNanoseconds()));
            }
        }

        private void btnSubmitPhrase1_Click(object sender, EventArgs e)
        {
            if (tB_phrase1.Text != "")
            {
                writeListToFile(keysDownDict, FILE_PATH_KEYS_DOWN_PHR1);
                writeListToFile(keysUpDict, FILE_PATH_KEYS_UP_PHR1);

                CalculateStats("1", FILE_PATH_STATS1, keysUpDict, keysDownDict);

                // clear dicts
                keysDownDict.Clear();
                keysUpDict.Clear();
                tB_phrase1.Text = "";
            }
            else
            {
                MessageBox.Show("Type something, dummy!");
            }
        }

        private void btnSubmitPhrase2_Click(object sender, EventArgs e)
        {
            if (tB_phrase2.Text != "")
            {
                writeListToFile(keysDownDict, FILE_PATH_KEYS_DOWN_PHR2);
                writeListToFile(keysUpDict, FILE_PATH_KEYS_UP_PHR2);

                CalculateStats("2", FILE_PATH_STATS2, keysUpDict, keysDownDict);

                if (!password.Equals(tB_phrase2.Text))
                {
                    MessageBox.Show("Password is incorrect, dummy!");
                }
                else
                {
                    score += 5;
                }

                keysDownDict.Clear();
                keysUpDict.Clear();
                tB_phrase2.Text = "";
            }
            else
            {
                MessageBox.Show("Type something, dummy!");
            }
        }

        private void writeListToFile(List<KeyValuePair<String, long>> list, String filepath)
        {
            using (StreamWriter writer = new StreamWriter(filepath, true))
            {
                foreach (var pair in list)
                {
                    writer.WriteLine(pair.Key.ToString() + " " + pair.Value.ToString());
                }
            }
        }

        private void tB_phrase2_KeyDown(object sender, KeyEventArgs e)
        {
            if (keysDownDict.Count == 0 ||
                !keysDownDict[keysDownDict.Count - 1].Key.Equals(e.KeyCode.ToString()))
            {
                keysDownDict.Add(new KeyValuePair<string, long>(e.KeyCode.ToString(),
                    GetNanoseconds()));
            }
        }

        private void tB_phrase2_KeyUp(object sender, KeyEventArgs e)
        {
            if (keysUpDict.Count == 0 ||
                !keysUpDict[keysUpDict.Count - 1].Key.Equals(e.KeyCode.ToString()))
            {
                keysUpDict.Add(new KeyValuePair<string, long>(e.KeyCode.ToString(),
                    GetNanoseconds()));
            }
        }

        private void button_CalcRes_Click(object sender, EventArgs e)
        {
            // STATS for all times
            // calculate average time for holding for each letter
            Dictionary<String, long> avgKeyHoldings = new Dictionary<string, long>();
            // average nanos for one tap
            long avgSpeed = 0;
            // average holding time for average letter
            long avgHolding = 0;
            // average expectations of errors
            Double avgError = 0.0;

            CalcStats(FILE_PATH_STATS1,
                avgSpeed,
                avgHolding,
                avgError,
                avgKeyHoldings
            );

            avgKeyHoldings.Clear();
            avgSpeed = 0;
            avgError = 0.0;
            avgHolding = 0;

            CalcStats(FILE_PATH_STATS2,
                avgSpeed,
                avgHolding,
                avgError,
                avgKeyHoldings
            );

            // avgKeyHoldings.Clear();
            avgSpeed = 0;
            avgError = 0.0;
            avgHolding = 0;

            if (score > 15)
            {
                lblCollectedData.Text = "Вы действительно - вы? Ответ машины: " + "Да";
            }
            else
            {
                lblCollectedData.Text = "Вы действительно - вы? Ответ машины: " + "Нет";
            }
            
            // make graphics
            GraphForm g = new GraphForm(avgSpdsForGist,
                "Скорость ввода парольной фразы\n(за все время)",
                "Наблюдения, №",
                "Время, наносекунды*",
                "измерения");
            GraphForm g2 = new GraphForm(avgKeyHoldings.Values.ToList(),
                "Динамика ввода символов парольной фразы\n(текущее наблюдение)",
                "символы, №",
                "Время, наносекунды",
                "измерения");
            g.Show();
            g2.Show();
            avgSpdsForGist.Clear();
            avgKeyHoldings.Clear();
            score = 0;
        }

        private static long GetNanoseconds()
        {
            double timestamp = Stopwatch.GetTimestamp();
            double nanoseconds = 1_000_000_000.0 * timestamp / Stopwatch.Frequency;

            return (long)nanoseconds;
        }

        private static void CalculateStats(String number, String filepath, List<KeyValuePair<String, long>> upList,
            List<KeyValuePair<String, long>> downList)
        {
            Double backCount = 0;
            Double spaceCount = 0;
            long typingSpeed = (upList[upList.Count - 1].Value - downList[0].Value) /
                               upList.Count;
            // get diffs betw kDownDict and kUpDict to know how much nanos took each button to hold
            Dictionary<String, List<long>> dict = new Dictionary<string, List<long>>();
            foreach (var pair in upList)
            {
                var letter = new KeyValuePair<String, long>();
                foreach (var p in downList)
                {
                    if (p.Key.Equals(pair.Key))
                    {
                        letter = p;
                    }
                }

                downList.Remove(letter);

                // thus we get a list of letter - holding time
                // all diffs write into a dict
                if (!dict.ContainsKey(pair.Key))
                {
                    dict.Add(pair.Key, new List<long>());
                }

                dict[pair.Key].Add(pair.Value - letter.Value);
            }

            // after this go through dict and find a middle value of holding time for each letter
            // also calculate average holding time for all letters
            long averageHoldingTime = 0;
            int count = 0;
            using (StreamWriter writer = new StreamWriter(filepath, true))
            {
                //writer.WriteLine(DateTime.Now.ToString() + "\nPhrase " + number.ToString() + " stats:\n");

                foreach (var l in dict)
                {
                    long time = 0;
                    foreach (var t in l.Value)
                    {
                        averageHoldingTime += t;
                        time += t;
                    }

                    count += l.Value.Count;
                    long hold = time / l.Value.Count;

                    writer.WriteLine(l.Key.ToString() + " -> " + hold.ToString());

                    if (!refKeyHolding.ContainsKey(l.Key))
                    {
                        refKeyHolding.Add(l.Key, hold);
                    }

                    if (l.Key.Equals(Keys.Back.ToString()))
                    {
                        backCount += l.Value.Count;
                    }

                    if (l.Key.Equals(Keys.Space.ToString()))
                    {
                        spaceCount += l.Value.Count;
                    }
                }

                averageHoldingTime /= count;

                writer.WriteLine("\nAverage holding time: " + averageHoldingTime.ToString() + " nanos");
                refAvgHoldingTime = averageHoldingTime;
                writer.WriteLine("Speed: " + typingSpeed.ToString() + " nanos for one letter");
                refAvgSpeed = typingSpeed;
                Double d = backCount / (spaceCount + 1);
                writer.WriteLine("Errors: " + d.ToString() + " error/word in average");
                refAvgError = d;
                writer.WriteLine();
            }
        }

        private void btn_ChangePassword_Click(object sender, EventArgs e)
        {
            PassChangeForm passChangeForm = new PassChangeForm(this);
            passChangeForm.Show();
        }

        public void SetPass(String password)
        {
            this.password = password;
        }

        private static void ReadStats(Dictionary<String, List<long>> allKeyHoldings,
            List<long> avgSpeeds,
            List<long> avgHoldings,
            List<Double> avgErrors,
            String filepath)
        {
            using (StreamReader reader = new StreamReader(filepath))
            {
                String text = reader.ReadToEnd();
                String[] lines = text.Split('\n');

                /*
                dateTime
                el
                key -> <long>
                el
                average holding time: <long>
                Speed: <long> nanos for one letter
                Errors: <Double> error/word in average
                */

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

                        if (l.Contains("->"))
                        {
                            String[] pairString = l.Split('-');
                            KeyValuePair<String, long> pair = new KeyValuePair<string, long>(pairString[0].Trim(),
                                long.Parse(pairString[1].Remove(0, 1).Trim()));
                            if (!allKeyHoldings.ContainsKey(pair.Key))
                            {
                                allKeyHoldings.Add(pair.Key, new List<long>());
                            }

                            allKeyHoldings[pair.Key].Add(pair.Value);
                        }
                    }
                }
            }
        }

        private void CalcStats(String filepath, long avgSpeed, long avgHolding, Double avgError,
            Dictionary<String, long> avgKeyHoldings)
        {
            // score should be at least == 5 for now (if the password was correct)
            Dictionary<String, List<long>> allKeyHoldings = new Dictionary<string, List<long>>();
            List<long> avgHoldings = new List<long>();
            List<Double> avgErrors = new List<double>();

            ReadStats(allKeyHoldings, avgSpdsForGist, avgHoldings, avgErrors, filepath);

            foreach (var speed in avgSpdsForGist)
            {
                avgSpeed += speed;
            }

            avgSpeed /= avgSpdsForGist.Count;

            foreach (var holding in avgHoldings)
            {
                avgHolding += holding;
            }

            avgHolding /= avgHoldings.Count;

            foreach (var error in avgErrors)
            {
                avgError += error;
            }

            avgError /= avgErrors.Count;

            foreach (var keyHolding in allKeyHoldings)
            {
                long res = 0;
                foreach (var holding in keyHolding.Value)
                {
                    res += holding;
                }

                res /= keyHolding.Value.Count;

                try
                {
                    avgKeyHoldings.Add(keyHolding.Key, res);
                }
                catch (Exception e)
                {
                    MessageBox.Show("");
                }
            }

            //////// calculate part

            if (refAvgError < avgError * 1.15 &&
                refAvgError > avgError * 0.85)
            {
                score += 1;
            }

            if (refAvgSpeed < avgSpeed * 1.15 &&
                refAvgSpeed > avgSpeed * 0.85)
            {
                score += 2;
            }

            if (refAvgHoldingTime < avgHolding * 1.15 &&
                refAvgHoldingTime > avgHolding * 0.85)
            {
                score += 2;
            }

            double addon = 0.0;
            foreach (var key in avgKeyHoldings.Keys)
            {
                if (refKeyHolding.ContainsKey(key) &&
                    refKeyHolding[key] < avgKeyHoldings[key] * 1.15 &&
                    refKeyHolding[key] > avgKeyHoldings[key] * 0.85)
                {
                    addon += 0.25;
                }
            }

            score += Convert.ToInt32(addon);
        }
    }
}