using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Doctor.Classes;
using Doctor.Properties;

namespace Doctor.Forms
{
    public delegate void SetCurrentPatient(Patient patient);

    public delegate void SendMessage(dynamic message);

    public delegate List<Patient> GetAllPatients();

    public partial class MainForm : Form
    {
        private Patient _currentPatient;
        private FontFamily _goodTimes;
        private readonly SendMessage _sendMessage;
        public readonly GetAllPatients _getAllPatients;
        public int ClientId { get; set; }
        private List<Patient> _patients = new List<Patient>();

        private readonly SetCurrentPatient _setCurrentPatient;

        public MainForm(SetCurrentPatient setCurrentPatient, SendMessage sendMessage, GetAllPatients getAllPatients)
        {
            _setCurrentPatient = setCurrentPatient;
            _sendMessage = sendMessage;
            _getAllPatients = getAllPatients;
            _currentPatient = null;

            InitializeComponent();
            timeTimer.Start();

            CargoPrivateFontCollection();
            Fonts();
            AddSplitButton();
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
            saveButton.Font = new Font(_goodTimes, 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            loadButton.Font = new Font(_goodTimes, 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Font = new Font(_goodTimes, 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Font = new Font(_goodTimes, 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Font = new Font(_goodTimes, 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Font = new Font(_goodTimes, 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Font = new Font(_goodTimes, 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Font = new Font(_goodTimes, 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Font = new Font(_goodTimes, 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Font = new Font(_goodTimes, 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Font = new Font(_goodTimes, 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            addClientButton.Font = new Font(_goodTimes, 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            userLabel.Font = new Font(_goodTimes, 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            connectedLabel.Font = new Font(_goodTimes, 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Font = new Font(_goodTimes, 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label12.Font = new Font(_goodTimes, 18F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            label13.Font = new Font(_goodTimes, 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);

            chatSendButton.Font = new Font(_goodTimes, 5.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        }

        private void timeTimer_Tick(object sender, EventArgs e)
        {
            currentTimeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        //http://www.vbdotnetforums.com/charting/61007-hide-chart-series-clicking-series-legend.html
        //http://stackoverflow.com/questions/14124601/display-disabled-series-in-legend
        private void chart1_Click(object sender, EventArgs e)
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
            _currentPatient = (Patient)clientListBox.SelectedItem;
            _setCurrentPatient(_currentPatient);
        }
    }
}