using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Lab1KeyboasrdBiometry
{
    public partial class Form1 : Form
    {
        //ToDo: 2 diff .txt for now, in first - control phrase, in second - personal phrase
        // after writing control phrase submit dicts to .txt
        // then clear them and record timings for personal phrase
        // also submit to .txt and clear
        private Dictionary<Char, DateTime> keysDownDict;
        private Dictionary<Char, DateTime> keysUpDict;

        public Form1()
        {
            InitializeComponent();
            
        }


        private void tB_phrase1_KeyDown(object sender, KeyEventArgs e)
        {
            keysDownDict.Add('E', DateTime.Now);
            
            //throw new System.NotImplementedException();
        }

        private void tB_phrase1_KeyUp(object sender, KeyEventArgs e)
        {
            keysUpDict.Add('E', DateTime.Now);
            
            
            //throw new System.NotImplementedException();
        }
    }
}