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

        public MainForm(DoctorConnector connector)
        {
            this._connector = connector;
            _currentPatient = null;

            InitializeComponent();
            timeTimer.Start();

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

        // This looks like it has been copy pasted...
        // Dem comments -Stefan
        private void MakeChartSlider()
        {
            _chartHeight = progressChart.ChartAreas[0];  // pick the right ChartArea..
            _serieHeight = progressChart.Series[0];      // ..and Series!

            // factors to convert values to pixels
            const double xFactor = 0.03; // use your numbers!
            const double yFactor = 0.02; // use your numbers!

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
            progressChart.Annotations.Add(_rectangle);
        }

        private void progressChart_AnnotationPositionChanging(object sender, AnnotationPositionChangingEventArgs e)
        {
            // move the rectangle with the line
            if (sender == _verticalLine) _rectangle.X = _verticalLine.X - _rectangle.Width / 2;

            // display the current Y-value
            int pt1 = (int)e.NewLocationX;
            double step = (_serieHeight.Points[pt1 + 1].YValues[0] - _serieHeight.Points[pt1].YValues[0]);
            double deltaX = e.NewLocationX - _serieHeight.Points[pt1].XValue;
            double val = _serieHeight.Points[pt1].YValues[0] + step * deltaX;
            progressChart.Titles[0].Text = $"X = {e.NewLocationX:0.00}   Y = {val:0.00}";
            _rectangle.Text = $"{val:0.00}";
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
            powerLegendaLabel.Font = new System.Drawing.Font(_goodTimes, 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            kjLegendaLabel.Font = new System.Drawing.Font(_goodTimes, 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            rpmLegendaLabel.Font = new System.Drawing.Font(_goodTimes, 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            pulseLegendaLabel.Font = new System.Drawing.Font(_goodTimes, 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            kmhLegendaLabel.Font = new System.Drawing.Font(_goodTimes, 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label10.Font = new System.Drawing.Font(_goodTimes, 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void timeTimer_Tick(object sender, EventArgs e)
        {
            if(!Visible)return;
            currentTimeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
            FillPatientsToList();
            _connector.SendMessage(new
            {
                id = "get/patients",
                
            });
            if (_currentPatient != null)
            _connector.SendMessage(new
            {
                id = "get/patient/data",
                data = new
                {
                    clientId = _currentPatient.ClientId
                }
            });
            if (_connector.GetMostRecentMeasurement() != null)
            {
                Console.WriteLine("measurement added..");
                SetAllMeasurementData(_connector.GetMostRecentMeasurement());
            }
        }

       private void chatSendButton_Click_1(object sender, EventArgs e)
        {
            if (_currentPatient == null)
            {
                Console.WriteLine("Not connected to a patient");
                return;
            }

            _connector.SendMessage(new
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
                _connector.SetCurrentPatient(_currentPatient);
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
            FillPatientsToList();
        }

        public void FillPatientsToList()
        {
            List<Patient> list = _connector.GetAllPatients();
            clientListBox.Text = "";
            clientListBox.Items.Clear();
            foreach (var patient in list)
            {
                clientListBox.Items.Add(patient);
            }
        }

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
                dataChart.Series["RPM"].Enabled = false;
            }
            else
            {
                rpmLegendaLabel.BackColor = Color.Yellow;
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
    }
}