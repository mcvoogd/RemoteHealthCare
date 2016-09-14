using DataScreen.Classes;
using System;
using System.Windows.Forms;

namespace DataScreen.Forms
{


    public partial class SimulationForm : Form
    {
        public readonly Measurement Measurement;
        private int _time;

        delegate void SetTextCallBack();

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        public void RefreshText()
        {
            pulseCount.Text = "" + Measurement.Pulse;
            rotationsCount.Text = "" + Measurement.Rotations;
            speedCount.Text = "" + Measurement.Speed;
            powerCount.Text = "" + Measurement.Power;
            burnedCount.Text = "" + Measurement.Burned;
            timeCount.Text = string.Format("{0:00}:{1:00}", _time / 60, _time % 60);
            reachedPowerCount.Text = "" + Measurement.ReachedPower;
            distanceCount.Text = "" + Measurement.Distance;
        }

        public SimulationForm()
        {

            _time = 120;
            Measurement = new Measurement(120, 100, 25, 50, (int)(_time*(25/3.6)), 666 ,new SimpleTime(_time/60,_time%60), 500);
            InitializeComponent();
            RefreshText();
        }

        private void pulseMin_Click(object sender, EventArgs e)
        {
            if (Measurement.Pulse > 0) { Measurement.Pulse--; }
            pulseCount.Text = "" + Measurement.Pulse;
        }

        private void pulsePlus_Click(object sender, EventArgs e)
        {
            if (Measurement.Pulse < 230) { Measurement.Pulse++; }
            pulseCount.Text = "" +  Measurement.Pulse;
        }

        private void rotationMin_Click(object sender, EventArgs e)
        {
            if (Measurement.Rotations  > 0) { Measurement.Rotations --; }
            rotationsCount.Text = "" + Measurement.Rotations ;
        }

        private void rotationPlus_Click(object sender, EventArgs e)
        {
            if (Measurement.Rotations  < 240) { Measurement.Rotations ++; }
            rotationsCount.Text = "" + Measurement.Rotations ;
        }

        private void speedMin_Click(object sender, EventArgs e)
        {
            if (Measurement.Speed > 0) { Measurement.Speed--; }
            speedCount.Text = "" + Measurement.Speed;
        }

        private void speedPlus_Click(object sender, EventArgs e)
        {
            if (Measurement.Speed < 60) { Measurement.Speed++; }
            speedCount.Text = "" + Measurement.Speed;
        }

        private void powerMin_Click(object sender, EventArgs e)
        {
            if (Measurement.Power  > 0) { Measurement.Power --; }
            powerCount.Text = "" + Measurement.Power ;
        }

        private void powerPlus_Click(object sender, EventArgs e)
        {
            if (Measurement.Power  < 400) { Measurement.Power ++; }
            powerCount.Text = "" + Measurement.Power ;
        }

        private void burnedMin_Click(object sender, EventArgs e)
        {
            if (Measurement.Burned > 0) { Measurement.Burned--; }
            burnedCount.Text = "" + Measurement.Burned;
        }

        private void burnedPlus_Click(object sender, EventArgs e)
        {
            if (Measurement.Burned < 999) { Measurement.Burned++; }
            burnedCount.Text = "" + Measurement.Burned;
        }

        private void timeMin_Click(object sender, EventArgs e)
        {
            if (_time > 0) { _time--; }
            Measurement.Time = new SimpleTime(_time / 60, _time % 60);
            Measurement.Distance = (int)(_time * (25 / 3.6));
            timeCount.Text = string.Format("{0:00}:{1:00}", _time / 60, _time % 60);
            distanceCount.Text = "" + Measurement.Distance;
        }

        private void timePlus_Click(object sender, EventArgs e)
        {
            if (_time < 5999) { _time++; }
            Measurement.Time = new SimpleTime(_time / 60, _time % 60);
            Measurement.Distance = (int)(_time * (25 / 3.6));
            timeCount.Text = string.Format("{0:00}:{1:00}", _time / 60, _time % 60);
            distanceCount.Text = "" + Measurement.Distance;
        }

        private void reachedPowerMin_Click(object sender, EventArgs e)
        {
            if (Measurement.ReachedPower > 0) { Measurement.ReachedPower--; }
            reachedPowerCount.Text = "" + Measurement.ReachedPower;
        }

        private void reachedPowerPlus_Click(object sender, EventArgs e)
        {
            if (Measurement.ReachedPower < 999) { Measurement.ReachedPower++; }
            reachedPowerCount.Text = "" + Measurement.ReachedPower;
        }

        private void distanceMin_Click(object sender, EventArgs e)
        {
            if (Measurement.Distance > 0) { Measurement.Distance--; }
            distanceCount.Text = "" + Measurement.Distance;
        }

        private void distancePlus_Click(object sender, EventArgs e)
        {
            if (Measurement.Distance < 999) { Measurement.Distance++; }
            distanceCount.Text = "" + Measurement.Distance;
        }

        public void updateSim()
        {

            if (this.timeCount.InvokeRequired)
            {
                SetTextCallBack d = new SetTextCallBack(updateSim);
                this.Invoke(d);
            }
            else
            {
                if (_time < 5999)
                {
                    _time++;
                    Measurement.Time = new SimpleTime(_time / 60, _time % 60);
                    Measurement.Distance += (int)(Measurement.Speed / 3.6);

                }

                Random random = new Random();

                switch((int)(random.NextDouble()*2))
                    {
                        case 0:
                            Measurement.Pulse++;
                            break;
                        case 1:
                            Measurement.Pulse--;
                            break;
                    }

                RefreshText();
            }

            
        }

        private void verzendButton_Click(object sender, EventArgs e)
        {
            // TODO remove
        }
   }
}