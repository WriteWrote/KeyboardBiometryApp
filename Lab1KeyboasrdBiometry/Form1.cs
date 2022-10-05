using System;
using System.Collections.Generic;

using System.IO;

using System.Windows.Forms;

namespace Lab1KeyboasrdBiometry
{
    public partial class Form1 : Form
    {
        //ToDo: 2 diff .txt for now, in first - control phrase, in second - personal phrase
        // after writing control phrase submit dicts to .txt
        // then clear them and record timings for personal phrase
        // also submit to .txt and clear

        private static String FILE_PATH_KEYS_DOWN_PHR1 = "C:\\Users\\Рабочая\\Desktop\\BMIL_test\\phr1KDownLog.txt";
        private static String FILE_PATH_KEYS_UP_PHR1 = "C:\\Users\\Рабочая\\Desktop\\BMIL_test\\phr1KUpLog.txt";
        private static String FILE_PATH_KEYS_DOWN_PHR2 = "C:\\Users\\Рабочая\\Desktop\\BMIL_test\\phr2KDownLog.txt";
        private static String FILE_PATH_KEYS_UP_PHR2 = "C:\\Users\\Рабочая\\Desktop\\BMIL_test\\phr2KUpLog.txt";
        private static String FILE_PATH_STATS1 = "C:\\Users\\Рабочая\\Desktop\\BMIL_test\\phrase1Stats.txt";
        private static String FILE_PATH_STATS2 = "C:\\Users\\Рабочая\\Desktop\\BMIL_test\\phrase2Stats.txt";
        private static String FILE_PATH_PASSWORD = "C:\\Users\\Рабочая\\Desktop\\BMIL_test\\currentKeyPhrase.txt";
        

        private List<KeyValuePair<String, DateTime>> keysDownDict;
        private List<KeyValuePair<String, DateTime>> keysUpDict;
        
        public Form1()
        {
            InitializeComponent();
            
            keysDownDict = new List<KeyValuePair<string, DateTime>>();
            keysUpDict = new List<KeyValuePair<string, DateTime>>();
        }


        private void tB_phrase1_KeyDown(object sender, KeyEventArgs e)
        {
            keysDownDict.Add(new KeyValuePair<string, DateTime>(e.KeyCode.ToString(),
                DateTime.Now));
        }

        private void tB_phrase1_KeyUp(object sender, KeyEventArgs e)
        {
            keysUpDict.Add(new KeyValuePair<string, DateTime>(e.KeyCode.ToString(),
                                                                    DateTime.Now));
        }

        private void btnSubmitPhrase1_Click(object sender, EventArgs e)
        {
            // calculate and
            // push text in the .txt for first phrase 
            // clear dicts
            

            // if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
            //     return;
            // String currentFilename = saveFileDialog.FileName.Trim();
            // if (!currentFilename.Contains(".txt"))
            // {
            //     currentFilename += ".txt";
            // }

            //ToDo: решить проблему с русской раскладкой
            writeListToFile(keysDownDict, FILE_PATH_KEYS_DOWN_PHR1);
            writeListToFile(keysUpDict, FILE_PATH_KEYS_UP_PHR1);
            
            keysDownDict.Clear();
            keysUpDict.Clear();
        }

        private void btnSubmitPhrase2_Click(object sender, EventArgs e)
        {
            // calculate and
            // push text in the .txt for second phrase
            // clear dicts
            
            
            writeListToFile(keysDownDict, FILE_PATH_KEYS_DOWN_PHR2);
            writeListToFile(keysDownDict, FILE_PATH_KEYS_UP_PHR2);
            
            keysDownDict.Clear();
            keysUpDict.Clear();
        }

        private void writeListToFile(List<KeyValuePair<String, DateTime>> list, String filepath)
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
            keysDownDict.Add(new KeyValuePair<string, DateTime>(e.KeyCode.ToString(),
                DateTime.Now));
        }

        private void tB_phrase2_KeyUp(object sender, KeyEventArgs e)
        {
            keysUpDict.Add(new KeyValuePair<string, DateTime>(e.KeyCode.ToString(),
                DateTime.Now));
        }
    }
}