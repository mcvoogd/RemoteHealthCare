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
    public partial class MainForm : Form
    {
        public bool Recieved = false;
        private Patient _currentPatient;
        private FontFamily _goodTimes;
        
        private ChartArea _chartHeight;
        private Series _serieHeight;
        private VerticalLineAnnotation _verticalLine;
        private RectangleAnnotation _rectangle;

        public int ClientId { get; set; }
        private List<Measurement> _patientMeasurements = new List<Measurement>();
        private List<Patient> _patients = new List<Patient>();
        private readonly DoctorConnector _connector;
        private Measurement _lastMeasurement = new Measurement(0, 0, 0, 0, 0, 0, 0, 0, 0);

        public bool SessionStarted;
        public bool SessionStopped = true;

        public MainForm(DoctorConnector connector)
        {
            FormClosing += mainForm_FormClosing;

            _connector = connector;
            _currentPatient = null;

            InitializeComponent();
            timeTimer.Start();
            UpdateDataLive.Start();

            CargoPrivateFontCollection();
            Fonts();
            AddSplitButton();
            MakeChartSlider();
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

        private void MakeChartSlider()
        {
            _chartHeight = progressChart.ChartAreas[0];
            _serieHeight = progressChart.Series[0];

            // factors to convert values to pixels
            const double xFactor = 0.03;
            const double yFactor = 0.02;

            // the vertical line
            _verticalLine = new VerticalLineAnnotation
            {
                AxisX = _chartHeight.AxisX,
                AllowMoving = true,
                IsInfinitive = true,
                ClipToChartArea = _chartHeight.Name,
                Name = "myLine",
                LineColor = Color.Red,
                LineWidth = 2,
                X = 1
            };

            // the rectangle
            _rectangle = new RectangleAnnotation
            {
                AxisX = _chartHeight.AxisX,
                IsSizeAlwaysRelative = false,
                Width = 20*xFactor,
                Height = 8*yFactor
            };

            _verticalLine.Name = "myRect";
            _rectangle.LineColor = Color.Red;
            _rectangle.BackColor = Color.Red;
            _rectangle.AxisY = _chartHeight.AxisY;
            _rectangle.Y = -_rectangle.Height;
            _rectangle.X = _verticalLine.X - _rectangle.Width / 2;

            _rectangle.Text = "Cliënt";
            _rectangle.ForeColor = Color.White;
            _rectangle.Font = new System.Drawing.Font("Arial", 8f);

            progressChart.Annotations.Add(_verticalLine);
            //progressChart.Annotations.Add(_rectangle);
        }

        private void progressChart_AnnotationPositionChanging(object sender, AnnotationPositionChangingEventArgs e)
        {
            // move the rectangle with the line
            if (sender == _verticalLine) _rectangle.X = _verticalLine.X - _rectangle.Width / 2;

            // display the current Y-value
            int pt1 = (int)e.NewLocationX;
            //double step = (_serieHeight.Points[pt1 + 1].YValues[0] - _serieHeight.Points[pt1].YValues[0]);
            //double deltaX = e.NewLocationX - _serieHeight.Points[pt1].XValue;
            //double val = _serieHeight.Points[pt1].YValues[0] + step * deltaX;
            //progressChart.Titles[0].Text = $"X = {e.NewLocationX:0.00}   Y = {val:0.00}";
            //_rectangle.Text = $"{val:0.00}";
            progressChart.Update();
        }

        private void progressChart_AnnotationPositionChanged(object sender, EventArgs e)
        {
            _verticalLine.X = (int)(_verticalLine.X + 0.5);
            _rectangle.X = _verticalLine.X - _rectangle.Width / 2;
        }
        private void AddSplitButton()
        {
            chatSendButton.FlatStyle = FlatStyle.Popup;
            chatSendButton.BackColor = Color.White;
            chatSendButton.ContextMenuStrip = new ContextMenuStrip
            {
                Font = new Font(_goodTimes, 5.25F, FontStyle.Regular, GraphicsUnit.Point, 0)
            };
            chatSendButton.ContextMenuStrip.Items.Add("Verzenden aan allen");
            Controls.Add(chatSendButton);
        }

        private void Fonts()
        {
            currentTimeLabel.Font = new Font(_goodTimes, 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            //saveButton.Font = new Font(_goodTimes, 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            startButton.Font = new Font(_goodTimes, 10.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            stopButton.Font = new Font(_goodTimes, 10.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Font = new Font(_goodTimes, 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Font = new Font(_goodTimes, 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Font = new Font(_goodTimes, 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Font = new Font(_goodTimes, 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Font = new Font(_goodTimes, 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Font = new Font(_goodTimes, 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Font = new Font(_goodTimes, 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Font = new Font(_goodTimes, 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Font = new Font(_goodTimes, 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            userLabel.Font = new Font(_goodTimes, 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            userAddButton.Font = new Font(_goodTimes, 9.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            connectedLabel.Font = new Font(_goodTimes, 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            printButton.Font = new Font(_goodTimes, 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label12.Font = new Font(_goodTimes, 18F, FontStyle.Regular | FontStyle.Underline, GraphicsUnit.Point, 0);
            label13.Font = new Font(_goodTimes, 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            brakeButton.Font = new Font(_goodTimes, 10.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataChart.Legends["Legend1"].Font = new Font(_goodTimes, 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chatSendButton.Font = new Font(_goodTimes, 5.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            powerLegendaLabel.Font = new Font(_goodTimes, 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            kjLegendaLabel.Font = new Font(_goodTimes, 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rpmLegendaLabel.Font = new Font(_goodTimes, 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pulseLegendaLabel.Font = new Font(_goodTimes, 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            kmhLegendaLabel.Font = new Font(_goodTimes, 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Font = new Font(_goodTimes, 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        }

        private void timeTimer_Tick(object sender, EventArgs e)
        {
            if(!Visible)return;
            currentTimeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
        }


        private void UpdateDataLive_Tick(object sender, EventArgs e)
        {
            if (!Visible) return;
            FillPatientsToList();
            _connector.SendMessage(new
            {
                id = "get/patients",
                data = new
                {
                    patientList = _connector.CurrentPatients
                }
            });
            if (_currentPatient == null) return; //patient cant be null and must be online to show live data.
            if (_currentPatient.IsOnline && SessionStarted)
            {
                _connector.SendMessage(new
                {
                    id = "get/patient/data",
                    data = new
                    {
                        clientId = _currentPatient.ClientId
                    }
                });

                if (_connector.GetMostRecentMeasurement() == null) return;
                var tempMeasurement = _connector.GetMostRecentMeasurement();
                if (tempMeasurement.Equals(_lastMeasurement)) return;
                SetAllMeasurementData(tempMeasurement);
                FillAllCharts(tempMeasurement);
                _lastMeasurement = tempMeasurement;
            }
            else
            {
                historyListBox.Items.Clear();
                historyListBox.Items.Add("Test1");
                historyListBox.Items.Add("Test2");
                historyListBox.Items.Add("UserOffline");
                historyListBox.Items.Add("Test3");
            }
        }

        public void FillAllCharts(Measurement tempMeasurement)
        {
            dataChart.Series["Power (Watts)"].Points.Add(tempMeasurement.Power); //power
            dataChart.Series["Km/h"].Points.Add(tempMeasurement.Speed); //speed
            dataChart.Series["KJ"].Points.Add(tempMeasurement.Burned); //burned
            dataChart.Series["RPM"].Points.Add(tempMeasurement.Rotations); //rotations
            dataChart.Series["Pulse"].Points.Add(tempMeasurement.Pulse); //pulse
        }

        private void clientListBox_DoubleClick_1(object sender, EventArgs e)
        {
            _currentPatient = (Patient)clientListBox.SelectedItem;
            if (_currentPatient == null) return;
                _connector.SetCurrentPatient(_currentPatient);
        }
    
        public void SetAllMeasurementData(Measurement m)
        {
            timeLabel.Text = $"{m.Time.Minutes:00}:{m.Time.Seconds:00}";
            double distance = m.Distance / 10f;
            kmLabel.Text = $"{distance:00}";
            wattsLabel.Text = m.Power.ToString();
            kmhLabel.Text = m.Speed.ToString();
            kjLabel.Text = m.Burned.ToString();
            rpmLabel.Text = m.Rotations.ToString();
            powerLabel.Text = m.Power.ToString();
            bpmLabel.Text = m.Pulse.ToString();
        }

        public void FillPatientsToList()
        {
            var list = _connector.GetAllPatients();
            if(list == null) return;
            clientListBox.Items.Clear();
            foreach (var patient in list)
            {
                clientListBox.Items.Add(patient);
            }
            _connector.PatientesList.Clear();
        }

        private void userAddButton_Click(object sender, EventArgs e)
        {
            new AcountCreationForm(_connector) { Visible = true};
        }

        #region  labels..

        

        private void powerLegendaLabel_Click(object sender, EventArgs e)
        {
            if (powerLegendaLabel.BackColor != Color.Transparent)
            {
                powerLegendaLabel.BackColor = Color.Transparent;
                dataChart.Series["Power (Watts)"].Enabled = false;
            }
            else
            {
                powerLegendaLabel.BackColor = Color.Green;
                dataChart.Series["Power (Watts)"].Enabled = true;
            }
        }

        private void kjLegendaLabel_Click(object sender, EventArgs e)
        {
            if (kjLegendaLabel.BackColor != Color.Transparent)
            {
                kjLegendaLabel.BackColor = Color.Transparent;
                dataChart.Series["KJ"].Enabled = false;
            }
            else
            {
                kjLegendaLabel.BackColor = Color.Purple;
                dataChart.Series["KJ"].Enabled = true;
            }
        }

        private void rpmLegendaLabel_Click(object sender, EventArgs e)
        {
            if (rpmLegendaLabel.BackColor != Color.Transparent)
            {
                rpmLegendaLabel.BackColor = Color.Transparent;
                rpmLegendaLabel.ForeColor = Color.White;
                dataChart.Series["RPM"].Enabled = false;
            }
            else
            {
                rpmLegendaLabel.BackColor = Color.Yellow;
                rpmLegendaLabel.ForeColor = Color.Black;
                dataChart.Series["RPM"].Enabled = true;
            }
        }

        private void pulseLegendaLabel_Click(object sender, EventArgs e)
        {
            if (pulseLegendaLabel.BackColor != Color.Transparent)
            {
                pulseLegendaLabel.BackColor = Color.Transparent;
                dataChart.Series["Pulse"].Enabled = false;
            }
            else
            {
                pulseLegendaLabel.BackColor = Color.Red;
                dataChart.Series["Pulse"].Enabled = true;
            }
        }

        private void kmhLegendaLabel_Click(object sender, EventArgs e)
        {
            if (kmhLegendaLabel.BackColor != Color.Transparent)
            {
                kmhLegendaLabel.BackColor = Color.Transparent;
                dataChart.Series["Km/h"].Enabled = false;
            }
            else
            {
                kmhLegendaLabel.BackColor = Color.Blue;
                dataChart.Series["Km/h"].Enabled = true;
            }
        }

#endregion

        private void startButton_Click(object sender, EventArgs e)
        {
            if (SessionStarted) return;
            SessionStarted = true;
            SessionStopped = false;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (SessionStopped) return;
            SessionStopped = true;
            SessionStarted = false;
        }

        private void chatSendButton_Click(object sender, EventArgs e)
        {
            if (_currentPatient == null)
            {
                Console.WriteLine("Not connected to a patient");
                return;
            }

            _connector.SendMessage(new
            {
                id = "message/send",
                data = new
                {
                    targetid = _currentPatient.ClientId,
                    originid = ClientId,
                    message = chatSendTextBox.Text
                }
            });
        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show("Do you really want to exit?", "Exit", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    _connector.SendMessage(new
                    {
                        id = "client/disconnect",
                        data = new
                        {
                            Disonnect = true
                        }
                    });
                    Environment.Exit(1);
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            this.dataChart.Printing.PrintPreview();
        }

        private void brakeButton_Click(object sender, EventArgs e)
        {

        }
    }
}