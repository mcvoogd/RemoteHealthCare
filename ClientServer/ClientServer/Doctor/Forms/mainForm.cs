using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Doctor.Classes;
using Doctor.Properties;
using Message = Doctor.Classes.Message;

namespace Doctor.Forms
{
    public delegate void UpdateMessagesDelegate(Message message);

    public partial class MainForm : Form
    {
        public bool Recieved = false;
        private Patient _currentPatient;
        private FontFamily _goodTimes;
        
        private ChartArea _chartHeight;
        private VerticalLineAnnotation _verticalLine;
        private Series _serieHeight;
        private RectangleAnnotation _rectangle;

        public int ClientId { get; set; }
        private List<Measurement> _patientMeasurements = new List<Measurement>();
        private List<Patient> _patients = new List<Patient>();
        private readonly DoctorConnector _connector;
        private Measurement _lastMeasurement = new Measurement(0, 0, 0, 0, 0, 0, 0, 0, 0);
        private List<HistoryItem> _currentHistoryItems = new List<HistoryItem>();

        public bool SessionStarted;
        public bool SessionStopped = true;

        private bool _historyRequested = false;

        private UpdateMessagesDelegate _updateMessages;
        private ContextMenuStrip contextMenuStrip;

        private List<Training> trainings = new List<Training>();

        public MainForm(DoctorConnector connector)
        {
            FormClosing += mainForm_FormClosing;

            _updateMessages = UpdateMessagesDelegate;
            _connector = connector;
            _connector.UpdateMessages = UpdateMessages;
            _currentPatient = null;

            InitializeComponent();
            timeTimer.Start();
            UpdateDataLive.Start();

            CargoPrivateFontCollection();
            Fonts();
            AddSplitButton();
            MakeChartSlider();

            trainings.Add(new Training());
        }

        private void UpdateMessages(Message message)
        {
            Invoke(_updateMessages, message);
        }

        private void UpdateMessagesDelegate(Message message)
        {
            chatReceiveTextBox.Text += $"{message.Time:t}--{message.Name}: {message.MessageValue}\n";

            chatReceiveTextBox.SelectionStart = chatReceiveTextBox.TextLength;
            chatReceiveTextBox.ScrollToCaret();
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

            _verticalLine.Name = "line";

            progressChart.Annotations.Add(_verticalLine);
            //progressChart.Annotations.Add(_rectangle);
        }

        private void progressChart_AnnotationPositionChanged(object sender, EventArgs e)
        {
            if (_verticalLine.X > progressChart.Series[0].Points[progressChart.Series[0].Points.Count -1].XValue)
                _verticalLine.X = progressChart.Series[0].Points[progressChart.Series[0].Points.Count - 1].XValue;
            else if (_verticalLine.X < progressChart.Series[0].Points[0].XValue)
                _verticalLine.X = progressChart.Series[0].Points[0].XValue;
            else
                _verticalLine.X = (int)(_verticalLine.X + 0.5);
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
            contextMenuStrip = chatSendButton.ContextMenuStrip;
            Controls.Add(chatSendButton);

            this.contextMenuStrip.ItemClicked += new ToolStripItemClickedEventHandler(this.contextMenuStrip_ItemClicked);
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
            #region Online case.
            if (_currentPatient.IsOnline)
            {
                if (!SessionStarted) return;
                _connector.SendMessage(new
                {
                    id = "get/patient/data",
                    data = new
                    {
                        clientId = _currentPatient.ClientId
                    }
                });
                //tot else is correct.
                if (_connector.GetMostRecentMeasurement() == null) return;
                var tempMeasurement = _connector.GetMostRecentMeasurement();
                if (tempMeasurement.Equals(_lastMeasurement)) return;
                SetAllMeasurementData(tempMeasurement);
                FillAllCharts(tempMeasurement);
                _lastMeasurement = tempMeasurement;
            }
            #endregion
            #region Offline case
            else
            {
                //bug : this breaks everything.
                if (!_historyRequested)
                {
                    _connector.CurrentPatientMeasurements.Clear();
                    _connector.SendMessage(new
                    {
                        id = "get/patient/history",
                        data = new {
                        patient = _connector.CurrentPatient.ClientId
                    }
                    });
                    _historyRequested = true;
                }
                if (_connector.receivedHistoryMeasurements)
                {
                    ResetAllCharts();
                    if (_connector.CurrentPatientMeasurements.Count <= 0) return;
                    var measurements = new List<Measurement>(_connector.CurrentPatientMeasurements);
                    foreach (var measurement in measurements)
                    {
                        FillAllCharts(measurement);
                    }
                    _connector.receivedHistoryMeasurements = false;
                }
                var list = _connector.CurrentPatientHistoryItems;
                if (historyListBox.Items.Count != list.Count && list.Count != 0)
                {
                    _currentHistoryItems.Clear();
                    historyListBox.Items.Clear();
                    int index = 1;
                    foreach (var historyItem in list)
                    {
                        historyListBox.Items.Add($"Training {index}");
                        _currentHistoryItems.Add(historyItem);
                        index++;
                    }
                }
            }
            #endregion
        }

        public void FillAllCharts(Measurement tempMeasurement)
        {
            dataChart.Series["Power (Watts)"].Points.Add(tempMeasurement.Power); //power
            dataChart.Series["Km/h"].Points.Add(tempMeasurement.Speed); //speed
            dataChart.Series["KJ"].Points.Add(tempMeasurement.Burned); //burned
            dataChart.Series["RPM"].Points.Add(tempMeasurement.Rotations); //rotations
            dataChart.Series["Pulse"].Points.Add(tempMeasurement.Pulse); //pulse
        }

        public void ResetAllCharts()
        {
            dataChart.Series["Power (Watts)"].Points.Clear();
            dataChart.Series["Km/h"].Points.Clear();
            dataChart.Series["KJ"].Points.Clear();
            dataChart.Series["RPM"].Points.Clear();
            dataChart.Series["Pulse"].Points.Clear();
            timeLabel.Text = "0";
            kmLabel.Text = "0";
            wattsLabel.Text = "0";
            kmhLabel.Text = "0";
            kjLabel.Text = "0";
            rpmLabel.Text = "0";
            powerLabel.Text = "0";
            bpmLabel.Text = "0";
        }

        private void clientListBox_DoubleClick_1(object sender, EventArgs e)
        {
            ResetGui();
//            _connector.SetCurrentPatient(null); // to reset user, dont know if needed. just for test.
            _currentPatient = (Patient)clientListBox.SelectedItem;
            if (_currentPatient == null) return;

            _connector.SetCurrentPatient(_currentPatient);
            _historyRequested = false;
            connectedLabel.Text = $"{_currentPatient.Name}";
        }

        public void ResetGui()
        {
            ResetAllCharts();
            _currentHistoryItems.Clear();
            historyListBox.Items.Clear();
            SessionStarted = false;
            SessionStopped = true;
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

        private dynamic GetMessageForServer(dynamic message)
        {
            dynamic toSend = new
            {
                id = _currentPatient,
                data = new
                {
                    message
                }
            };
            return toSend;
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
            if(!_currentPatient.IsOnline)return;
            if (SessionStarted) return;
            SessionStarted = true;
            SessionStopped = false;
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (!_currentPatient.IsOnline) return;
            if (SessionStopped) return;
            ResetAllCharts();
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

            chatReceiveTextBox.Text += $"{DateTime.Now:t}--{userLabel.Text}: {chatSendTextBox.Text}\n"; 
            _connector.SendMessage(new
            {
                id = "message/send",
                data = new
                {
                    targetid = _currentPatient.ClientId,
                    originid = ClientId,
                    name = userLabel.Text,
                    message = chatSendTextBox.Text
                }
            });
            chatSendTextBox.Text = "";
        }

        private void contextMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Verzenden aan allen")
            {
                //TODO for you Stefan.
            }
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
                    Application.Exit(); //wat doet dit hier? dubbel??
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
            _connector.SendMessage(new
            {
                 id = "bike/break",
                 data = new
                 {
                     targetid = _currentPatient.ClientId,
                     originid = ClientId
                 }
            });
        }

        private void historyListBox_DoubleClick(object sender, EventArgs e)
        {
            if (_currentHistoryItems == null || _currentHistoryItems.Count <= 0) return;
            _connector.SendMessage(new
            {
                id = "get/patient/history/measurements",
                data = new
                {
                    patient = _currentPatient.ClientId,
                    historyItem = historyListBox.SelectedIndex
                }
            });
            
        }

        private void trainingComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TODO Should work like this. I must test it
            //BUG: natuurlijk werkt het niet, je wilt een string casten naar een training?
            Training t = null;
            foreach (Training temp in trainings)
            {
                if (trainingComboBox.SelectedItem.Equals(temp.TrainingName))
                {
                    t = temp;
                }
            }
            if (t != null)
            {
                List<dynamic> toSend = t.SendTraining();
                dynamic message = new
                {
                    id = "change/resistance/sendList",
                    data = new
                    {
                        toSend
                    }
                };
                _connector.SendMessage(GetMessageForServer(message));
            }
            else
            {
                Console.WriteLine("Nothing to send Boss!");
            }
        }

        private void updateTrainingBox()
        {
            trainingComboBox.Items.Clear();
            foreach (Training t in trainings)
            {
                trainingComboBox.Items.Add(t.TrainingName);
            }
        }

        private void userLabel_Click(object sender, EventArgs e)
        {

        }

        private void progressChart_Click(object sender, EventArgs e)
        {

        }
    }
}