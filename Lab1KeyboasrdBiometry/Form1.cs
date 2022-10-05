using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Lab1KeyboasrdBiometry
{
    public partial class Form1 : Form
    {
        private const String FILE_PATH_KEYS_DOWN_PHR1 = "C:\\Users\\Рабочая\\Desktop\\BMIL_test\\phr1KDownLog.txt";
        private const String FILE_PATH_KEYS_UP_PHR1 = "C:\\Users\\Рабочая\\Desktop\\BMIL_test\\phr1KUpLog.txt";
        private const String FILE_PATH_KEYS_DOWN_PHR2 = "C:\\Users\\Рабочая\\Desktop\\BMIL_test\\phr2KDownLog.txt";
        private const String FILE_PATH_KEYS_UP_PHR2 = "C:\\Users\\Рабочая\\Desktop\\BMIL_test\\phr2KUpLog.txt";
        private const String FILE_PATH_STATS1 = "C:\\Users\\Рабочая\\Desktop\\BMIL_test\\phrase1Stats.txt";
        private const String FILE_PATH_STATS2 = "C:\\Users\\Рабочая\\Desktop\\BMIL_test\\phrase2Stats.txt";
        private const String FILE_PATH_PASSWORD = "C:\\Users\\Рабочая\\Desktop\\BMIL_test\\currentKeyPhrase.txt";

        private List<KeyValuePair<String, long>> keysDownDict;
        private List<KeyValuePair<String, long>> keysUpDict;

        private long prevTime = 0;

        public Form1()
        {
            InitializeComponent();

            keysDownDict = new List<KeyValuePair<string, long>>();
            keysUpDict = new List<KeyValuePair<string, long>>();
        }


        private void tB_phrase1_KeyDown(object sender, KeyEventArgs e)
        {
            if (tB_phrase1.Text.Equals(""))
            {
                prevTime = GetNanoseconds();
            }

            keysDownDict.Add(new KeyValuePair<string, long>(e.KeyCode.ToString(),
                GetNanoseconds()));
        }

        private void tB_phrase1_KeyUp(object sender, KeyEventArgs e)
        {
            keysUpDict.Add(new KeyValuePair<string, long>(e.KeyCode.ToString(),
                GetNanoseconds()));
        }

        private void btnSubmitPhrase1_Click(object sender, EventArgs e)
        {
            writeListToFile(keysDownDict, FILE_PATH_KEYS_DOWN_PHR1);
            writeListToFile(keysUpDict, FILE_PATH_KEYS_UP_PHR1);
            
            /*
    	скорость ввода - количество введенных символов, разделенное на время печатания;
    	динамика ввода - характеризуется временем между нажатиями клавиш и временем их удержания;
    	частота возникновение ошибок при вводе;
    	использование клавиш - например, какие функциональные клавиши нажимаются для 
        ввода заглавных букв.
             */

            long typingSpeed = (keysUpDict[keysUpDict.Count - 1].Value - keysDownDict[0].Value) /
                               keysUpDict.Count;

            // collect timings for each case for each letter
            Dictionary<String, List<long>> timings = new Dictionary<string, List<long>>();
            String prevLetter = "";

            foreach (var letterPair in keysDownDict)
            {
                try
                {
                    timings.Add(letterPair.Key, new List<long>());
                    timings[letterPair.Key].Add(letterPair.Value - prevTime);
                }
                catch (Exception ex)
                {
                    if (prevLetter.Equals(letterPair.Key))
                    {
                        int length = timings[letterPair.Key].Count;
                        timings[letterPair.Key][length - 1] += (letterPair.Value - prevTime);
                    }
                    else
                    {
                        timings[letterPair.Key].Add(letterPair.Value - prevTime);
                    }
                }
                finally
                {
                    prevTime = letterPair.Value;
                    prevLetter = letterPair.Key;
                }
            }

            //go through timings for each letter and find a medium value
            //also writing statistic
            using (StreamWriter writer = new StreamWriter(FILE_PATH_STATS1))
            {
                writer.WriteLine("DateTime: " + DateTime.Now.ToString());
                writer.WriteLine("Phrase 1 stats:\n");
                writer.WriteLine("Average speed: " + typingSpeed);
                writer.WriteLine("\nLetterholding speed:\n");
                
                foreach (var letterTime in timings)
                {
                    long sum = 0;
                    foreach (var time in letterTime.Value)
                    {
                        sum += time;
                    }

                    sum = sum / letterTime.Value.Count;

                    writer.WriteLine("Letter " + letterTime.Key.ToString() + " time= " + sum.ToString());
                }
            }
            
            // clear dicts
            keysDownDict.Clear();
            keysUpDict.Clear();
        }

        private void btnSubmitPhrase2_Click(object sender, EventArgs e)
        {
            writeListToFile(keysDownDict, FILE_PATH_KEYS_DOWN_PHR2);
            writeListToFile(keysDownDict, FILE_PATH_KEYS_UP_PHR2);

            // calculate and
            // push text in the .txt for first phrase 
            // clear dicts

            //ToDo: решить проблему с русской раскладкой

            keysDownDict.Clear();
            keysUpDict.Clear();
        }

        private void writeListToFile(List<KeyValuePair<String, long>> list, String filepath)
        {
            using (StreamWriter writer = new StreamWriter(filepath))
            {
                foreach (var pair in keysDownDict)
                {
                    writer.WriteLine(pair.Key.ToString() + " " + pair.Value.ToString());
                }
            }
        }

        private void tB_phrase2_KeyDown(object sender, KeyEventArgs e)
        {
            keysDownDict.Add(new KeyValuePair<string, long>(e.KeyCode.ToString(),
                GetNanoseconds()));
        }

        private void tB_phrase2_KeyUp(object sender, KeyEventArgs e)
        {
            keysUpDict.Add(new KeyValuePair<string, long>(e.KeyCode.ToString(),
                GetNanoseconds()));
        }

        private void button_CalcRes_Click(object sender, EventArgs e)
        {
            //ToDo: recover stats from statsNNN.txt
            //TODO: make some predictions where this is actually user or not
            //ToDo: * make graphics 
        }

        public static long GetNanoseconds()
        {
            double timestamp = Stopwatch.GetTimestamp();
            double nanoseconds = 1_000_000_000.0 * timestamp / Stopwatch.Frequency;

            return (long)nanoseconds;
        }
    }
}