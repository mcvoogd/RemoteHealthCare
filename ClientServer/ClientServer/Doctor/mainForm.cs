using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
