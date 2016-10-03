using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Doctor
{
    public partial class mainForm : Form
    {
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);
        FontFamily _goodTimes;

        private void CargoPrivateFontCollection()
        {
            // Create the byte array and get its length

            byte[] fontArray = Doctor.Properties.Resources.good_times;
            int dataLength = Doctor.Properties.Resources.good_times.Length;


            // ASSIGN MEMORY AND COPY  BYTE[] ON THAT MEMORY ADDRESS
            IntPtr ptrData = Marshal.AllocCoTaskMem(dataLength);
            Marshal.Copy(fontArray, 0, ptrData, dataLength);

            uint cFonts = 0;
            AddFontMemResourceEx(ptrData, (uint)fontArray.Length, IntPtr.Zero, ref cFonts);

            PrivateFontCollection pfc = new PrivateFontCollection();
            //PASS THE FONT TO THE  PRIVATEFONTCOLLECTION OBJECT
            pfc.AddMemoryFont(ptrData, dataLength);

            //FREE THE  "UNSAFE" MEMORY
            Marshal.FreeCoTaskMem(ptrData);

            _goodTimes = pfc.Families[0];
        }

        public mainForm()
        {
            InitializeComponent();
            timeTimer.Start();

            CargoPrivateFontCollection();
            Fonts();
        }

        private void Fonts()
        {
            this.currentTimeLabel.Font = new System.Drawing.Font(_goodTimes, 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Font = new System.Drawing.Font(_goodTimes, 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadButton.Font = new System.Drawing.Font(_goodTimes, 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Font = new System.Drawing.Font(_goodTimes, 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Font = new System.Drawing.Font(_goodTimes, 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Font = new System.Drawing.Font(_goodTimes, 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Font = new System.Drawing.Font(_goodTimes, 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Font = new System.Drawing.Font(_goodTimes, 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Font = new System.Drawing.Font(_goodTimes, 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Font = new System.Drawing.Font(_goodTimes, 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Font = new System.Drawing.Font(_goodTimes, 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Font = new System.Drawing.Font(_goodTimes, 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addClientButton.Font = new System.Drawing.Font(_goodTimes, 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           
            this.userLabel.Font = new System.Drawing.Font(_goodTimes, 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectedLabel.Font = new System.Drawing.Font(_goodTimes, 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Font = new System.Drawing.Font(_goodTimes, 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Font = new System.Drawing.Font(_goodTimes, 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Font = new System.Drawing.Font(_goodTimes, 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void timeTimer_Tick(object sender, EventArgs e)
        {
            this.currentTimeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        //http://www.vbdotnetforums.com/charting/61007-hide-chart-series-clicking-series-legend.html
        //http://stackoverflow.com/questions/14124601/display-disabled-series-in-legend
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
