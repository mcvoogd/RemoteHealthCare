using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataScreen.Forms
{
    public partial class GraphPanel : Form
    {
        public GraphPanel()
        {
            InitializeComponent();
        }

        private void GraphPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics gObject = CreateGraphics();

            Brush blue = new SolidBrush(Color.Blue);
            Brush black = new SolidBrush(Color.Black);

            Pen bluePen = new Pen(blue, 8);
            Pen blackPen = new Pen(black, 8);
        }
    }
}
