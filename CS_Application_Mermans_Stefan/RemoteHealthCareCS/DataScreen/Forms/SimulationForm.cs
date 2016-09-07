using DataScreen.Classes;
using System;
using System.Windows.Forms;

namespace DataScreen.Forms
{
    public partial class SimulationForm : Form
    {
        public readonly Measurement measurement;
        private int Time;

        public SimulationForm()
        {
            Time = 120;
            measurement = new Measurement(120, 100, 25, 50, 420, new SimpleTime(Time/60,Time%60), 666, 500);
            InitializeComponent();
        }

        private void pulseMin_Click(object sender, EventArgs e)
        {
            if (measurement.Pulse > 0) { measurement.Pulse--; }
            pulseCount.Text = "" + measurement.Pulse;
        }

        private void pulsePlus_Click(object sender, EventArgs e)
        {
            if (measurement.Pulse < 230) { measurement.Pulse++; }
            pulseCount.Text = "" +  measurement.Pulse;
        }

        private void rotationMin_Click(object sender, EventArgs e)
        {
            if (measurement.Rotations  > 0) { measurement.Rotations --; }
            rotationsCount.Text = "" + measurement.Rotations ;
        }

        private void rotationPlus_Click(object sender, EventArgs e)
        {
            if (measurement.Rotations  < 240) { measurement.Rotations ++; }
            rotationsCount.Text = "" + measurement.Rotations ;
        }

        private void speedMin_Click(object sender, EventArgs e)
        {
            if (measurement.Speed > 0) { measurement.Speed--; }
            speedCount.Text = "" + measurement.Speed;
        }

        private void speedPlus_Click(object sender, EventArgs e)
        {
            if (measurement.Speed < 60) { measurement.Speed++; }
            speedCount.Text = "" + measurement.Speed;
        }

        private void powerMin_Click(object sender, EventArgs e)
        {
            if (measurement.Power  > 0) { measurement.Power --; }
            powerCount.Text = "" + measurement.Power ;
        }

        private void powerPlus_Click(object sender, EventArgs e)
        {
            if (measurement.Power  < 400) { measurement.Power ++; }
            powerCount.Text = "" + measurement.Power ;
        }

        private void burnedMin_Click(object sender, EventArgs e)
        {
            if (measurement.Burned > 0) { measurement.Burned--; }
            burnedCount.Text = "" + measurement.Burned;
        }

        private void burnedPlus_Click(object sender, EventArgs e)
        {
            if (measurement.Burned < 999) { measurement.Burned++; }
            burnedCount.Text = "" + measurement.Burned;
        }

        private void timeMin_Click(object sender, EventArgs e)
        {
            if (Time > 0) { Time--; }
            timeCount.Text = string.Format("{0:00}:{1:00}", Time / 60, Time % 60);
            measurement.Time = new SimpleTime(Time / 60, Time % 60);
        }

        private void timePlus_Click(object sender, EventArgs e)
        {
            if (Time < 999) { Time++; }
            timeCount.Text = string.Format("{0:00}:{1:00}", Time / 60, Time % 60);
            measurement.Time = new SimpleTime(Time / 60, Time % 60);
        }

        private void reachedPowerMin_Click(object sender, EventArgs e)
        {
            if (measurement.ReachedPower > 0) { measurement.ReachedPower--; }
            reachedPowerCount.Text = "" + measurement.ReachedPower;
        }

        private void reachedPowerPlus_Click(object sender, EventArgs e)
        {
            if (measurement.ReachedPower < 999) { measurement.ReachedPower++; }
            reachedPowerCount.Text = "" + measurement.ReachedPower;
        }

        private void distanceMin_Click(object sender, EventArgs e)
        {
            if (measurement.Distance > 0) { measurement.Distance--; }
            distanceCount.Text = "" + measurement.Distance;
        }

        private void distancePlus_Click(object sender, EventArgs e)
        {
            if (measurement.Distance < 999) { measurement.Distance++; }
            distanceCount.Text = "" + measurement.Distance;
        }

        private void CommandButton_Click(object sender, EventArgs e)
        {
            String command = this.CommandBox.Text;
            string input = command.Substring(0, 2);
            switch (input)
            {
                case "PW":
                    power = Int32.Parse(System.Text.RegularExpressions.Regex.Match(command, @"\d+").Value);
                    break;

                case "PD":
                    distance = Int32.Parse(System.Text.RegularExpressions.Regex.Match(command, @"\d+").Value);
                    break;

                default:
                    Console.WriteLine("Command not recognized");
                    break;

            }

        private void verzendButton_Click(object sender, EventArgs e)
        {
            // TODO implent
        }
   }
}
