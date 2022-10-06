﻿using System;
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

        public Form1()
        {
            InitializeComponent();

            keysDownDict = new List<KeyValuePair<string, long>>();
            keysUpDict = new List<KeyValuePair<string, long>>();
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
            writeListToFile(keysDownDict, FILE_PATH_KEYS_DOWN_PHR1);
            writeListToFile(keysUpDict, FILE_PATH_KEYS_UP_PHR1);

            CalculateStats("1", FILE_PATH_STATS1, keysUpDict, keysDownDict);

            // clear dicts
            keysDownDict.Clear();
            keysUpDict.Clear();
        }

        private void btnSubmitPhrase2_Click(object sender, EventArgs e)
        {
            writeListToFile(keysDownDict, FILE_PATH_KEYS_DOWN_PHR2);
            writeListToFile(keysDownDict, FILE_PATH_KEYS_UP_PHR2);

            CalculateStats("2", FILE_PATH_STATS2, keysUpDict, keysDownDict);

            keysDownDict.Clear();
            keysUpDict.Clear();
        }

        private void writeListToFile(List<KeyValuePair<String, long>> list, String filepath)
        {
            using (StreamWriter writer = new StreamWriter(filepath))
            {
                foreach (var pair in list)
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
            //TODO: посчитать количество ошибок на количество пробелов
            //todo: сделать задание контрольной фразы
            //todo: оценить сложность контрольной фразы
            //todo: сделать проверку контрольной фразы на совпадение 
            //todo: сделать ДОписывание, а не ПЕРЕписывание документов о статистике
            //ToDo: решить проблему с русской раскладкой
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
            using (StreamWriter writer = new StreamWriter(filepath))
            {
                writer.WriteLine(DateTime.Now.ToString() + "\nPhrase " + number.ToString() + " stats:\n");

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
                }

                averageHoldingTime /= count;

                writer.WriteLine("\nAverage holding time: " + averageHoldingTime.ToString());
                writer.WriteLine("Speed: " + typingSpeed.ToString() + " nanos for one letter");
                writer.WriteLine();
            }
        }
    }
}