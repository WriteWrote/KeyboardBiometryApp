using System;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;


namespace Lab1KeyboasrdBiometry
{
    public partial class GraphForm : Form
    {
        private ZedGraphControl _control;

        public GraphForm()
        {
            InitializeComponent();

            _control = new ZedGraphControl();
            this.Controls.Add(_control);
        }

        // Build the Chart
        private void CreateGraph(ZedGraphControl zgc)
        {
            // get a reference to the GraphPane
            GraphPane myPane = zgc.GraphPane;

            // Set the Titles
            myPane.Title.Text = "My Test Graph\n(For CodeProject Sample)";
            myPane.XAxis.Title.Text = "My X Axis";
            myPane.YAxis.Title.Text = "My Y Axis";

            // Make up some data arrays based on the Sine function
            double x, y1, y2;
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            for (int i = 0; i < 36; i++)
            {
                x = (double)i + 5;
                y1 = 1.5 + Math.Sin((double)i * 0.2);
                y2 = 3.0 * (1.5 + Math.Sin((double)i * 0.2));
                list1.Add(x, y1);
                list2.Add(x, y2);
            }

            // Generate a red curve with diamond
            // symbols, and "Porsche" in the legend
            LineItem myCurve = myPane.AddCurve("Porsche",
                list1, Color.Red, SymbolType.Diamond);

            // Generate a blue curve with circle
            // symbols, and "Piper" in the legend
            LineItem myCurve2 = myPane.AddCurve("Piper",
                list2, Color.Blue, SymbolType.Circle);

            // Tell ZedGraph to refigure the
            // axes since the data have changed
            zgc.AxisChange();
        }
    }
}