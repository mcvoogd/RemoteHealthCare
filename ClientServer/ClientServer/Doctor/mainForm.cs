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
            var result = chart1.HitTest(MousePosition.X, MousePosition.Y);
            if (result.ChartElementType == ChartElementType.LegendItem)
            {
                if (result.Series.Color == Color.Transparent)
                {
                    result.Series.Color = Color.Empty;
                }
                else
                {
                    result.Series.Color = Color.Transparent;
                }
            }
        }
    }
}
