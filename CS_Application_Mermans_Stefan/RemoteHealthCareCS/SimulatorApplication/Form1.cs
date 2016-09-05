using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimulatorApplication
{
    public partial class Form1 : Form
    {
        public int pulse = 70;

        public Form1()
        {
            InitializeComponent();
        }

        private void pulseMinButton_Click(object sender, EventArgs e)
        {
            if (pulse > 0) { pulse--; }
            pulseLabel.Text = "" + pulse;
        }

        private void pulsePlusButton_Click(object sender, EventArgs e)
        {
            if (pulse < 230) { pulse++; }
            pulseLabel.Text = "" + pulse;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
