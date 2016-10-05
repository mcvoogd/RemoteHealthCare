using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Doctor.Classes;
using Doctor.Properties;

namespace Doctor.Forms
{
    public delegate void SetCurrentPatient(Patient patient);
    public delegate void SendMessage(dynamic message);
    public delegate List<Patient> GetAllPatients();
    public delegate List<Measurement> GetMeasurementsFromPatient();

    public partial class MainForm : Form
    {
        public bool recieved = false;
        private Patient _currentPatient;
        private FontFamily _goodTimes;
        private readonly SendMessage _sendMessage;
        public readonly GetAllPatients _getAllPatients;

        ChartArea CA;
        Series S1;
        VerticalLineAnnotation VA;
        RectangleAnnotation RA;

        private readonly GetMeasurementsFromPatient _GetMeasurementsFromPatient;
        public int ClientId { get; set; }
        private List<Measurement> _patientMeasurements = new List<Measurement>();
        private List<Patient> _patients = new List<Patient>();
        private DoctorConnector _connector;
        private readonly SetCurrentPatient _setCurrentPatient;

        public MainForm(SetCurrentPatient setCurrentPatient, SendMessage sendMessage, GetAllPatients getAllPatients, GetMeasurementsFromPatient getMeasurementsFromPatient, DoctorConnector connector1)
        {
            _setCurrentPatient = setCurrentPatient;
            _sendMessage = sendMessage;
            _getAllPatients = getAllPatients;
            _GetMeasurementsFromPatient = getMeasurementsFromPatient;
            this._connector = connector1;
            _currentPatient = null;

            InitializeComponent();
            timeTimer.Start();

            CargoPrivateFontCollection();
            Fonts();
            AddSplitButton();
            makeChartSlider();
        }

        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [In] ref uint pcFonts);

        private void CargoPrivateFontCollection()
        {
            // Create the byte array and get its length

            var fontArray = Resources.good_times;
            var dataLength = Resources.good_times.Length;

            // ASSIGN MEMORY AND COPY  BYTE[] ON THAT MEMORY ADDRESS
            var ptrData = Marshal.AllocCoTaskMem(dataLength);
            Marshal.Copy(fontArray, 0, ptrData, dataLength);

            uint cFonts = 0;
            AddFontMemResourceEx(ptrData, (uint) fontArray.Length, IntPtr.Zero, ref cFonts);

            var pfc = new PrivateFontCollection();
            //PASS THE FONT TO THE  PRIVATEFONTCOLLECTION OBJECT
            pfc.AddMemoryFont(ptrData, dataLength);

            //FREE THE  "UNSAFE" MEMORY
            Marshal.FreeCoTaskMem(ptrData);

            _goodTimes = pfc.Families[0];
        }

        private void makeChartSlider()
        {
            CA = progressChart.ChartAreas[0];  // pick the right ChartArea..
            S1 = progressChart.Series[0];      // ..and Series!

            // factors to convert values to pixels
            double xFactor = 0.03;         // use your numbers!
            double yFactor = 0.02;        // use your numbers!

            // the vertical line
            VA = new VerticalLineAnnotation();
            VA.AxisX = CA.AxisX;
            VA.AllowMoving = true;
            VA.IsInfinitive = true;
            VA.ClipToChartArea = CA.Name;
            VA.Name = "myLine";
            VA.LineColor = Color.Red;
            VA.LineWidth = 2;         // use your numbers!
            VA.X = 1;

            // the rectangle
            RA = new RectangleAnnotation();
            RA.AxisX = CA.AxisX;
            RA.IsSizeAlwaysRelative = false;
            RA.Width = 20 * xFactor;         // use your numbers!
            RA.Height = 8 * yFactor;        // use your numbers!
            VA.Name = "myRect";
            RA.LineColor = Color.Red;
            RA.BackColor = Color.Red;
            RA.AxisY = CA.AxisY;
            RA.Y = -RA.Height;
            RA.X = VA.X - RA.Width / 2;

            RA.Text = "Cliënt";
            RA.ForeColor = Color.White;
            RA.Font = new System.Drawing.Font("Arial", 8f);

            progressChart.Annotations.Add(VA);
            progressChart.Annotations.Add(RA);
        }

        private void progressChart_AnnotationPositionChanging(object sender, AnnotationPositionChangingEventArgs e)
        {
            // move the rectangle with the line
            if (sender == VA) RA.X = VA.X - RA.Width / 2;

            // display the current Y-value
            int pt1 = (int)e.NewLocationX;
            double step = (S1.Points[pt1 + 1].YValues[0] - S1.Points[pt1].YValues[0]);
            double deltaX = e.NewLocationX - S1.Points[pt1].XValue;
            double val = S1.Points[pt1].YValues[0] + step * deltaX;
            progressChart.Titles[0].Text = String.Format(
                                    "X = {0:0.00}   Y = {1:0.00}", e.NewLocationX, val);
            RA.Text = String.Format("{0:0.00}", val);
            progressChart.Update();
        }

        private void progressChart_AnnotationPositionChanged(object sender, EventArgs e)
        {
            VA.X = (int)(VA.X + 0.5);
            RA.X = VA.X - RA.Width / 2;
        }
        private void AddSplitButton()
        {
            chatSendButton.FlatStyle = FlatStyle.Popup;
            chatSendButton.BackColor = Color.White;
            chatSendButton.ContextMenuStrip = new ContextMenuStrip();
            chatSendButton.ContextMenuStrip.Font = new Font(_goodTimes, 5.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chatSendButton.ContextMenuStrip.Items.Add("Verzenden aan allen");
            Controls.Add(chatSendButton);
        }

        private void Fonts()
        {
            currentTimeLabel.Font = new Font(_goodTimes, 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            //saveButton.Font = new Font(_goodTimes, 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loadButton.Font = new Font(_goodTimes, 10.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Font = new Font(_goodTimes, 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Font = new Font(_goodTimes, 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Font = new Font(_goodTimes, 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Font = new Font(_goodTimes, 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Font = new Font(_goodTimes, 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Font = new Font(_goodTimes, 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Font = new Font(_goodTimes, 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Font = new Font(_goodTimes, 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Font = new Font(_goodTimes, 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            refreshClientButton.Font = new Font(_goodTimes, 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            userLabel.Font = new Font(_goodTimes, 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            userAddButton.Font = new Font(_goodTimes, 9.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            connectedLabel.Font = new Font(_goodTimes, 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Font = new Font(_goodTimes, 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label12.Font = new Font(_goodTimes, 18F, FontStyle.Regular | FontStyle.Underline, GraphicsUnit.Point, 0);
            label13.Font = new Font(_goodTimes, 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            brakeButton.Font = new Font(_goodTimes, 10.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataChart.Legends["Legend1"].Font = new System.Drawing.Font(_goodTimes, 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chatSendButton.Font = new Font(_goodTimes, 5.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        }

        private void timeTimer_Tick(object sender, EventArgs e)
        {
            currentTimeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
            if(_currentPatient != null)
            _sendMessage(new
            {
                id = "get/patient/data",
                data = new
                {
                    clientId = _currentPatient.ClientId
                }
            });
            if (_connector.GetMostRecentMeasurement() != null)
            SetAllMeasurementData(_connector.GetMostRecentMeasurement());
        }

        //http://www.vbdotnetforums.com/charting/61007-hide-chart-series-clicking-series-legend.html
        //http://stackoverflow.com/questions/14124601/display-disabled-series-in-legend
        private void dataChart_Click(object sender, EventArgs e)
        {
            var seriesHit = dataChart.HitTest(MousePosition.X, MousePosition.Y);
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

        private void chatSendButton_Click_1(object sender, EventArgs e)
        {
            if (_currentPatient == null)
            {
                Console.WriteLine("Not connected to a patient");
                return;
            }

            _sendMessage(new
            {
                id = "message/send",
                targetid = _currentPatient.ClientId,
                originid = ClientId,
                data = new
                {
                    message = chatSendTextBox.Text
                }
            });
        }

        private void clientListBox_DoubleClick_1(object sender, EventArgs e)
        {
            //TODO GRANTED CLIENT IS ONLINE. YOU KNOW WHAT.
            _currentPatient = (Patient)clientListBox.SelectedItem;
            if (_currentPatient == null) return;
                _setCurrentPatient(_currentPatient);
            //REDUNDANT!

            //            Thread listener = new Thread(ListenMethodMsrsment);
            //            listener.Start();
        }
        //REDUNDANT!
        //        public void ListenMethodMsrsment()
        //        {
        //            while (!_connector.recievedMeasurements)
        //            {
        //            }
        //            List<Measurement> measurements = _GetMeasurementsFromPatient();
        //            _connector.recievedMeasurements = false;
        //            //SELFDESTRUCTED.
        //        }
        //REDUNDANT!

        public void SetAllMeasurementData(Measurement m)
        {
            timeLabel.Text = m.Time.ToString();
            kmLabel.Text = m.Distance.ToString();
            wattsLabel.Text = m.Power.ToString();
            kmhLabel.Text = m.Speed.ToString();
            kjLabel.Text = m.Burned.ToString();
            rpmLabel.Text = m.Rotations.ToString();
            powerLabel.Text = m.Power.ToString();
            bpmLabel.Text = m.Pulse.ToString();
        }

        private void refreshClientButton_Click(object sender, EventArgs e)
        {
            List<Patient> list = _getAllPatients();
            clientListBox.Text = "";
            clientListBox.Items.Clear();
            foreach (var patient in list)
            {
                clientListBox.Items.Add(patient);
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            Training t = (Training)trainingComboBox.SelectedItem;
            t.SendTraining();
        }
    }
}