using DataScreen.Classes;
using System;
using System.Windows.Forms;

namespace DataScreen.Forms
{
    public partial class SimulationForm : Form, IStandardErgometer
    {
        public int Pulse { get; set; }
        public int Rotations { get; set; }
        public int Speed { get; set; }
        public int Power { get; set; }
        public int Burned { get; set; }
        public int Time { get; set; }
        public int Reachedpower { get; set; }
        public int Distance { get; set; }

        public SimulationForm()
        {
            Pulse = 120;
            Rotations = 100;
            Speed = 25;
            Power = 50;
            Burned = 420;
            Time = 120;
            Reachedpower = 666;
            Distance = 500;
            InitializeComponent();
        }

        private void pulseMin_Click(object sender, EventArgs e)
        {
            if (Pulse > 0) { Pulse--; }
            pulseCount.Text = "" + Pulse;
        }

        private void pulsePlus_Click(object sender, EventArgs e)
        {
            if (Pulse < 230) { Pulse++; }
            pulseCount.Text = "" + Pulse;
        }

        private void rotationMin_Click(object sender, EventArgs e)
        {
            if (Rotations > 0) { Rotations--; }
            rotationsCount.Text = "" + Rotations;
        }

        private void rotationPlus_Click(object sender, EventArgs e)
        {
            if (Rotations < 240) { Rotations++; }
            rotationsCount.Text = "" + Rotations;
        }

        private void speedMin_Click(object sender, EventArgs e)
        {
            if (Speed > 0) { Speed--; }
            speedCount.Text = "" + Speed;
        }

        private void speedPlus_Click(object sender, EventArgs e)
        {
            if (Speed < 60) { Speed++; }
            speedCount.Text = "" + Speed;
        }

        private void powerMin_Click(object sender, EventArgs e)
        {
            if (Power > 0) { Power--; }
            powerCount.Text = "" + Power;
        }

        private void powerPlus_Click(object sender, EventArgs e)
        {
            if (Power < 400) { Power++; }
            powerCount.Text = "" + Power;
        }

        private void burnedMin_Click(object sender, EventArgs e)
        {
            if (Burned > 0) { Burned--; }
            burnedCount.Text = "" + Burned;
        }

        private void burnedPlus_Click(object sender, EventArgs e)
        {
            if (Burned < 999) { Burned++; }
            burnedCount.Text = "" + Burned;
        }

        private void timeMin_Click(object sender, EventArgs e)
        {
            if (Time > 0) { Time--; }
            timeCount.Text = string.Format("{0:00}:{1:00}", Time / 60, Time % 60);
        }

        private void timePlus_Click(object sender, EventArgs e)
        {
            if (Time < 999) { Time++; }
            timeCount.Text = string.Format("{0:00}:{1:00}", Time / 60, Time % 60);
        }

        private void reachedPowerMin_Click(object sender, EventArgs e)
        {
            if (Reachedpower > 0) { Reachedpower--; }
            reachedPowerCount.Text = "" + Reachedpower;
        }

        private void reachedPowerPlus_Click(object sender, EventArgs e)
        {
            if (Reachedpower < 999) { Reachedpower++; }
            reachedPowerCount.Text = "" + Reachedpower;
        }

        private void distanceMin_Click(object sender, EventArgs e)
        {
            if (Distance > 0) { Distance--; }
            distanceCount.Text = "" + Distance;
        }

        private void distancePlus_Click(object sender, EventArgs e)
        {
            if (Distance < 999) { Distance++; }
            distanceCount.Text = "" + Distance;
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

        public void Connect()
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }
    }
}
