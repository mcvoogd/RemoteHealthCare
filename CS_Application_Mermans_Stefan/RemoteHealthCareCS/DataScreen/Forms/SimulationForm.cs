using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataScreen
{
    public partial class SimulationForm : Form, StandardErgometer
    {
        public int pulse { get; set; }
        public int rotations { get; set; }
        public int speed { get; set; }
        public int power { get; set; }
        public int burned { get; set; }
        public int time { get; set; }
        public int reachedpower { get; set; }
        public int distance { get; set; }

        public SimulationForm()
        {
            pulse = 120;
            rotations = 100;
            speed = 25;
            power = 50;
            burned = 420;
            time = 120;
            reachedpower = 666;
            distance = 500;
            InitializeComponent();
    
        }

        private void pulseMin_Click(object sender, EventArgs e)
        {
            if (pulse > 0) { pulse--; }
            pulseCount.Text = "" + pulse;
        }

        private void pulsePlus_Click(object sender, EventArgs e)
        {
            if (pulse < 230) { pulse++; }
            pulseCount.Text = "" + pulse;
        }

        private void rotationMin_Click(object sender, EventArgs e)
        {
            if (rotations > 0) { rotations--; }
            rotationsCount.Text = "" + rotations;
        }

        private void rotationPlus_Click(object sender, EventArgs e)
        {
            if (rotations < 240) { rotations++; }
            rotationsCount.Text = "" + rotations;
        }

        private void speedMin_Click(object sender, EventArgs e)
        {
            if (speed > 0) { speed--; }
            speedCount.Text = "" + speed;
        }

        private void speedPlus_Click(object sender, EventArgs e)
        {
            if (speed < 60) { speed++; }
            speedCount.Text = "" + speed;
        }

        private void powerMin_Click(object sender, EventArgs e)
        {
            if (power > 0) { power--; }
            powerCount.Text = "" + power;
        }

        private void powerPlus_Click(object sender, EventArgs e)
        {
            if (power < 400) { power++; }
            powerCount.Text = "" + power;
        }

        private void burnedMin_Click(object sender, EventArgs e)
        {
            if (burned > 0) { burned--; }
            burnedCount.Text = "" + burned;
        }

        private void burnedPlus_Click(object sender, EventArgs e)
        {
            if (burned < 999) { burned++; }
            burnedCount.Text = "" + burned;
        }

        private void timeMin_Click(object sender, EventArgs e)
        {
            if (time > 0) { time--; }
            timeCount.Text = string.Format("{0:00}:{1:00}", time / 60, time % 60);
        }

        private void timePlus_Click(object sender, EventArgs e)
        {
            if (time < 999) { time++; }
            timeCount.Text = string.Format("{0:00}:{1:00}", time / 60, time % 60);
        }

        private void reachedPowerMin_Click(object sender, EventArgs e)
        {
            if (reachedpower > 0) { reachedpower--; }
            reachedPowerCount.Text = "" + reachedpower;
        }

        private void reachedPowerPlus_Click(object sender, EventArgs e)
        {
            if (reachedpower < 999) { reachedpower++; }
            reachedPowerCount.Text = "" + reachedpower;
        }

        private void distanceMin_Click(object sender, EventArgs e)
        {
            if (distance > 0) { distance--; }
            distanceCount.Text = "" + distance;
        }

        private void distancePlus_Click(object sender, EventArgs e)
        {
            if (distance < 999) { distance++; }
            distanceCount.Text = "" + distance;

        }


        private void verzendButton_Click(object sender, EventArgs e)
        {
            //    Console.WriteLine(
            //        "Hartslag = " + pulse + "\n" +
            //        "Rotaties = " + rotations + "\n" +
            //        "Snelheid = " + speed + "\n" +
            //        "Vermogen = " + power + "\n" +
            //        "Verbrande energie = " + burned + "\n" +
            //        "Tijd in minuten = " + time + "\n" +
            //        "Gehaald vermogen = " + reachedPower
            //        );
        }

       

        public void connect()
        {
            throw new NotImplementedException();
        }

        public void disconnect()
        {
            throw new NotImplementedException();
        }
    }
}
