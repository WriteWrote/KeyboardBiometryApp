using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Lab1KeyboasrdBiometry
{
    public partial class Form1 : Form
    {
        private static String FILE_PATH_KEYS_DOWN_PHR1 = "C:\\Users\\Рабочая\\Desktop\\BMIL_test\\phr1KDownLog.txt";
        private static String FILE_PATH_KEYS_UP_PHR1 = "C:\\Users\\Рабочая\\Desktop\\BMIL_test\\phr1KUpLog.txt";
        private static String FILE_PATH_KEYS_DOWN_PHR2 = "C:\\Users\\Рабочая\\Desktop\\BMIL_test\\phr2KDownLog.txt";
        private static String FILE_PATH_KEYS_UP_PHR2 = "C:\\Users\\Рабочая\\Desktop\\BMIL_test\\phr2KUpLog.txt";
        private static String FILE_PATH_STATS1 = "C:\\Users\\Рабочая\\Desktop\\BMIL_test\\phrase1Stats.txt";
        private static String FILE_PATH_STATS2 = "C:\\Users\\Рабочая\\Desktop\\BMIL_test\\phrase2Stats.txt";
        private static String FILE_PATH_PASSWORD = "C:\\Users\\Рабочая\\Desktop\\BMIL_test\\currentKeyPhrase.txt";


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
            // calculate and
            // push text in the .txt for first phrase 
            // clear dicts

            //ToDo: решить проблему с русской раскладкой
            writeListToFile(keysDownDict, FILE_PATH_KEYS_DOWN_PHR1);
            writeListToFile(keysUpDict, FILE_PATH_KEYS_UP_PHR1);

            keysDownDict.Clear();
            keysUpDict.Clear();
        }

        private void btnSubmitPhrase2_Click(object sender, EventArgs e)
        {
            writeListToFile(keysDownDict, FILE_PATH_KEYS_DOWN_PHR2);
            writeListToFile(keysDownDict, FILE_PATH_KEYS_UP_PHR2);

            // calculate and


            // push text in the .txt for second phrase


            // clear dicts

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