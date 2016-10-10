using System;
using System.Windows.Forms;
using Client.Simulator;

namespace DataScreen.Forms
{
    public partial class SimulationForm : Form
    {
        public readonly Measurement Measurement;
        private int _time;

        public SimulationForm()
        {
            _time = 120;
            Measurement = new Measurement(120, 100, 25, 50, _time*(25/3.6), 10.0/3600.0*_time*70.0,
                new SimpleTime(_time/60, _time%60), 500);
            InitializeComponent();

            this.ClientSize = new System.Drawing.Size(250, 200);
            this.Name = "SimulationForm";

            RefreshText();
            Visible = true;
        }

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
            burnedCount.Text = "" + (int) Measurement.Burned;
            timeCount.Text = $"{_time/60:00}:{_time%60:00}";
            reachedPowerCount.Text = "" + Measurement.ReachedPower;
            distanceCount.Text = "" + (int) Measurement.Distance;
        }

        private void pulseMin_Click(object sender, EventArgs e)
        {
            if (Measurement.Pulse > 0)
                Measurement.Pulse--;
            pulseCount.Text = "" + Measurement.Pulse;
        }

        private void pulsePlus_Click(object sender, EventArgs e)
        {
            if (Measurement.Pulse < 230)
                Measurement.Pulse++;
            pulseCount.Text = "" + Measurement.Pulse;
        }

        private void rotationMin_Click(object sender, EventArgs e)
        {
            if (Measurement.Rotations > 0)
                Measurement.Rotations--;
            rotationsCount.Text = "" + Measurement.Rotations;
        }

        private void rotationPlus_Click(object sender, EventArgs e)
        {
            if (Measurement.Rotations < 240)
                Measurement.Rotations++;
            rotationsCount.Text = "" + Measurement.Rotations;
        }

        private void speedMin_Click(object sender, EventArgs e)
        {
            if (Measurement.Speed > 0)
                Measurement.Speed--;
            speedCount.Text = "" + Measurement.Speed;
        }

        private void speedPlus_Click(object sender, EventArgs e)
        {
            if (Measurement.Speed < 60)
                Measurement.Speed++;
            speedCount.Text = "" + Measurement.Speed;
        }

        private void powerMin_Click(object sender, EventArgs e)
        {
            if (Measurement.Power > 0)
                Measurement.Power--;
            powerCount.Text = "" + Measurement.Power;
        }

        private void powerPlus_Click(object sender, EventArgs e)
        {
            if (Measurement.Power < 400)
                Measurement.Power++;
            powerCount.Text = "" + Measurement.Power;
        }

        private void timeMin_Click(object sender, EventArgs e)
        {
            updateMeasurementhMin();

            timeCount.Text = $"{_time/60:00}:{_time%60:00}";
            distanceCount.Text = "" + (int) Measurement.Distance;
            burnedCount.Text = "" + (int) Measurement.Burned;
        }

        private void timePlus_Click(object sender, EventArgs e)
        {
            updateMeasurementPlus();

            timeCount.Text = $"{_time/60:00}:{_time%60:00}";
            distanceCount.Text = "" + (int) Measurement.Distance;
            burnedCount.Text = "" + (int) Measurement.Burned;
        }

        private void reachedPowerMin_Click(object sender, EventArgs e)
        {
            if (Measurement.ReachedPower > 0)
                Measurement.ReachedPower--;
            reachedPowerCount.Text = "" + Measurement.ReachedPower;
        }

        private void reachedPowerPlus_Click(object sender, EventArgs e)
        {
            if (Measurement.ReachedPower < 999)
                Measurement.ReachedPower++;
            reachedPowerCount.Text = "" + Measurement.ReachedPower;
        }

        public void UpdateSim()
        {
            if (timeCount.InvokeRequired)
            {
                SetTextCallBack d = UpdateSim;
                Invoke(d);
            }
            else
            {
                updateMeasurementPlus();

                var random = new Random();

                switch ((int) (random.NextDouble()*2))
                {
                    case 0:
                        if (Measurement.Pulse < 230)
                            Measurement.Pulse++;
                        break;
                    case 1:
                        if (Measurement.Pulse > 0)
                            Measurement.Pulse--;
                        break;
                }

                RefreshText();
            }
        }

        public void updateMeasurementPlus()
        {
            if (_time < 5999)
            {
                _time++;
                Measurement.Time = new SimpleTime(_time/60, _time%60);
                Measurement.Distance += Measurement.Speed/3.6;
                Measurement.Burned += 10.0/3600.0*70.0;
            }
        }

        public void updateMeasurementhMin()
        {
            if (_time > 0)
            {
                _time--;
                Measurement.Time = new SimpleTime(_time/60, _time%60);

                Measurement.Burned -= 10.0/3600.0*70.0;
                Measurement.Distance -= Measurement.Speed/3.6;

                if (Measurement.Distance < 0)
                    Measurement.Distance = 0;
                if (Measurement.Burned < 0)
                    Measurement.Burned = 0;
            }
        }

        private delegate void SetTextCallBack();

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // SimulationForm
        //    // 
        //    this.ClientSize = new System.Drawing.Size(284, 261);
        //    this.Name = "SimulationForm";
        //    this.ResumeLayout(false);

        //}
    }
}