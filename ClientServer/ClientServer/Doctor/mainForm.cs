using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Doctor
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            timeTimer.Start();
        }

        private void timeTimer_Tick(object sender, EventArgs e)
        {
            this.currentTimeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        //http://www.vbdotnetforums.com/charting/61007-hide-chart-series-clicking-series-legend.html
        private void chart1_Click(object sender, EventArgs e)
        {
            HitTestResult seriesHit = chart1.HitTest(MousePosition.X, MousePosition.Y);
            if (seriesHit.ChartElementType == ChartElementType.DataPoint)
            {
                MessageBox.Show("Selected by Series!");
                // ^^ This, as a test box, works fine...
                var parameterNameStr = seriesHit.Series.Name;
                // ^^ This is what I want but is causing trouble!
            }
            else if (seriesHit.ChartElementType == ChartElementType.LegendItem)
            {
                MessageBox.Show("Selected by Legend!!");
            }
            else
            {
                MessageBox.Show("Whoops, try again!");
            }
        }
    }
}
