using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ZedGraph;


namespace Lab1KeyboasrdBiometry
{
    public partial class GraphForm : Form
    {
        private ZedGraphControl _control1;
        private List<long> speeds;
        private String title, xTitle, yTitle, curveTitle;

        public GraphForm(List<long> speeds,
            String title, String xTitle, String yTitle, String curveTitle)
        {
            InitializeComponent();

            _control1 = new ZedGraphControl();
            this.Controls.Add(_control1);
            this.speeds = speeds;

            this.title = title;
            this.xTitle = xTitle;
            this.yTitle = yTitle;
            this.curveTitle = curveTitle;
        }

        // Build the Chart
        private void CreateGraph(ZedGraphControl zgc,
            String title,
            String xTitle,
            String yTitle,
            String curveTitle,
            List<long> yValues
        )
        {
            // get a reference to the GraphPane
            GraphPane myPane = zgc.GraphPane;

            // Set the Titles
            myPane.Title.Text = title;
            myPane.XAxis.Title.Text = xTitle;
            myPane.YAxis.Title.Text = yTitle;

            PointPairList list1 = new PointPairList();

            for (int i = 0; i < yValues.Count; i++)
            {
                list1.Add(i, yValues[i]);
            }

            // Generate a red curve with diamond
            // symbols, and "Porsche" in the legend
            LineItem myCurve = myPane.AddCurve(curveTitle,
                list1, Color.Red, SymbolType.Diamond);

            // Tell ZedGraph to refigure the
            // axes since the data have changed
            zgc.AxisChange();
            // Size the control to fill the form with a margin
            zgc.Location = new Point(10, 10);
            // Leave a small margin around the outside of the control
            zgc.Size = new Size(ClientRectangle.Width - 20,
                ClientRectangle.Height - 20);
        }

        private void GraphForm_Load_1(object sender, EventArgs e)
        {
            // Setup the graph
            CreateGraph(_control1, title, xTitle, yTitle, curveTitle, speeds);
        }
    }
}