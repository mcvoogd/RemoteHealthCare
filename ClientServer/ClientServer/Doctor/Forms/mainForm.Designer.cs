using System;
using System.Windows.Forms.DataVisualization.Charting;

namespace Doctor.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine1 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine2 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine3 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.StripLine stripLine4 = new System.Windows.Forms.DataVisualization.Charting.StripLine();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 10D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 5D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(3D, 7D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(4D, 6D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(24D, 80D);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.currentTimeLabel = new System.Windows.Forms.Label();
            this.timeTimer = new System.Windows.Forms.Timer(this.components);
            this.startButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.kmLabel = new System.Windows.Forms.Label();
            this.avgkmLabel = new System.Windows.Forms.Label();
            this.wattsLabel = new System.Windows.Forms.Label();
            this.avgwattsLabel = new System.Windows.Forms.Label();
            this.rpmLabel = new System.Windows.Forms.Label();
            this.kjLabel = new System.Windows.Forms.Label();
            this.kmhLabel = new System.Windows.Forms.Label();
            this.bpmLabel = new System.Windows.Forms.Label();
            this.powerLabel = new System.Windows.Forms.Label();
            this.avgbpmLabel = new System.Windows.Forms.Label();
            this.avgpowerLabel = new System.Windows.Forms.Label();
            this.avgrpmLabel = new System.Windows.Forms.Label();
            this.avgkmhLabel = new System.Windows.Forms.Label();
            this.clientListBox = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dataChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.userLabel = new System.Windows.Forms.Label();
            this.connectedLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.chatReceiveTextBox = new System.Windows.Forms.RichTextBox();
            this.chatSendTextBox = new System.Windows.Forms.TextBox();
            this.progressChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.trainingComboBox = new System.Windows.Forms.ComboBox();
            this.userAddButton = new System.Windows.Forms.Button();
            this.brakeButton = new System.Windows.Forms.Button();
            this.powerLegendaLabel = new System.Windows.Forms.Label();
            this.kjLegendaLabel = new System.Windows.Forms.Label();
            this.rpmLegendaLabel = new System.Windows.Forms.Label();
            this.pulseLegendaLabel = new System.Windows.Forms.Label();
            this.kmhLegendaLabel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.historyListBox = new System.Windows.Forms.ListBox();
            this.UpdateDataLive = new System.Windows.Forms.Timer(this.components);
            this.stopButton = new System.Windows.Forms.Button();
            this.chatSendButton = new Doctor.Classes.SplitButton();
            this.printButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressChart)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1241, 676);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(114, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Henk";
            // 
            // currentTimeLabel
            // 
            this.currentTimeLabel.AutoSize = true;
            this.currentTimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.currentTimeLabel.ForeColor = System.Drawing.Color.White;
            this.currentTimeLabel.Location = new System.Drawing.Point(745, 34);
            this.currentTimeLabel.Name = "currentTimeLabel";
            this.currentTimeLabel.Size = new System.Drawing.Size(0, 13);
            this.currentTimeLabel.TabIndex = 1;
            // 
            // timeTimer
            // 
            this.timeTimer.Interval = 1000;
            this.timeTimer.Tick += new System.EventHandler(this.timeTimer_Tick);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.White;
            this.startButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.startButton.ForeColor = System.Drawing.Color.Black;
            this.startButton.Location = new System.Drawing.Point(664, 566);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(110, 33);
            this.startButton.TabIndex = 3;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(51, 269);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Time";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(208, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Km";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(333, 269);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "watts";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(489, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "km/h";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(658, 269);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "kJ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(790, 269);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "RPM";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(921, 269);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Power";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(1085, 269);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "BPM";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timeLabel
            // 
            this.timeLabel.BackColor = System.Drawing.Color.Transparent;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.ForeColor = System.Drawing.Color.White;
            this.timeLabel.Location = new System.Drawing.Point(20, 298);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(130, 36);
            this.timeLabel.TabIndex = 12;
            this.timeLabel.Text = "00:00:00";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kmLabel
            // 
            this.kmLabel.BackColor = System.Drawing.Color.Transparent;
            this.kmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kmLabel.ForeColor = System.Drawing.Color.White;
            this.kmLabel.Location = new System.Drawing.Point(171, 298);
            this.kmLabel.Name = "kmLabel";
            this.kmLabel.Size = new System.Drawing.Size(118, 36);
            this.kmLabel.TabIndex = 13;
            this.kmLabel.Text = "00,0";
            this.kmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // avgkmLabel
            // 
            this.avgkmLabel.BackColor = System.Drawing.Color.Transparent;
            this.avgkmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avgkmLabel.ForeColor = System.Drawing.Color.White;
            this.avgkmLabel.Location = new System.Drawing.Point(171, 348);
            this.avgkmLabel.Name = "avgkmLabel";
            this.avgkmLabel.Size = new System.Drawing.Size(118, 23);
            this.avgkmLabel.TabIndex = 14;
            this.avgkmLabel.Text = "00,0";
            this.avgkmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wattsLabel
            // 
            this.wattsLabel.BackColor = System.Drawing.Color.Transparent;
            this.wattsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wattsLabel.ForeColor = System.Drawing.Color.White;
            this.wattsLabel.Location = new System.Drawing.Point(320, 298);
            this.wattsLabel.Name = "wattsLabel";
            this.wattsLabel.Size = new System.Drawing.Size(118, 36);
            this.wattsLabel.TabIndex = 15;
            this.wattsLabel.Text = "000";
            this.wattsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // avgwattsLabel
            // 
            this.avgwattsLabel.BackColor = System.Drawing.Color.Transparent;
            this.avgwattsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avgwattsLabel.ForeColor = System.Drawing.Color.White;
            this.avgwattsLabel.Location = new System.Drawing.Point(320, 348);
            this.avgwattsLabel.Name = "avgwattsLabel";
            this.avgwattsLabel.Size = new System.Drawing.Size(118, 23);
            this.avgwattsLabel.TabIndex = 16;
            this.avgwattsLabel.Text = "000";
            this.avgwattsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rpmLabel
            // 
            this.rpmLabel.BackColor = System.Drawing.Color.Transparent;
            this.rpmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rpmLabel.ForeColor = System.Drawing.Color.White;
            this.rpmLabel.Location = new System.Drawing.Point(762, 298);
            this.rpmLabel.Name = "rpmLabel";
            this.rpmLabel.Size = new System.Drawing.Size(118, 36);
            this.rpmLabel.TabIndex = 19;
            this.rpmLabel.Text = "000";
            this.rpmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kjLabel
            // 
            this.kjLabel.BackColor = System.Drawing.Color.Transparent;
            this.kjLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kjLabel.ForeColor = System.Drawing.Color.White;
            this.kjLabel.Location = new System.Drawing.Point(615, 298);
            this.kjLabel.Name = "kjLabel";
            this.kjLabel.Size = new System.Drawing.Size(118, 36);
            this.kjLabel.TabIndex = 18;
            this.kjLabel.Text = "000";
            this.kjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kmhLabel
            // 
            this.kmhLabel.BackColor = System.Drawing.Color.Transparent;
            this.kmhLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kmhLabel.ForeColor = System.Drawing.Color.White;
            this.kmhLabel.Location = new System.Drawing.Point(467, 298);
            this.kmhLabel.Name = "kmhLabel";
            this.kmhLabel.Size = new System.Drawing.Size(118, 36);
            this.kmhLabel.TabIndex = 17;
            this.kmhLabel.Text = "00,0";
            this.kmhLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bpmLabel
            // 
            this.bpmLabel.BackColor = System.Drawing.Color.Transparent;
            this.bpmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bpmLabel.ForeColor = System.Drawing.Color.White;
            this.bpmLabel.Location = new System.Drawing.Point(1057, 298);
            this.bpmLabel.Name = "bpmLabel";
            this.bpmLabel.Size = new System.Drawing.Size(118, 36);
            this.bpmLabel.TabIndex = 21;
            this.bpmLabel.Text = "000";
            this.bpmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // powerLabel
            // 
            this.powerLabel.BackColor = System.Drawing.Color.Transparent;
            this.powerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.powerLabel.ForeColor = System.Drawing.Color.White;
            this.powerLabel.Location = new System.Drawing.Point(911, 298);
            this.powerLabel.Name = "powerLabel";
            this.powerLabel.Size = new System.Drawing.Size(118, 36);
            this.powerLabel.TabIndex = 20;
            this.powerLabel.Text = "00%";
            this.powerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // avgbpmLabel
            // 
            this.avgbpmLabel.BackColor = System.Drawing.Color.Transparent;
            this.avgbpmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avgbpmLabel.ForeColor = System.Drawing.Color.White;
            this.avgbpmLabel.Location = new System.Drawing.Point(1057, 348);
            this.avgbpmLabel.Name = "avgbpmLabel";
            this.avgbpmLabel.Size = new System.Drawing.Size(118, 23);
            this.avgbpmLabel.TabIndex = 23;
            this.avgbpmLabel.Text = "000";
            this.avgbpmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // avgpowerLabel
            // 
            this.avgpowerLabel.BackColor = System.Drawing.Color.Transparent;
            this.avgpowerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avgpowerLabel.ForeColor = System.Drawing.Color.White;
            this.avgpowerLabel.Location = new System.Drawing.Point(911, 348);
            this.avgpowerLabel.Name = "avgpowerLabel";
            this.avgpowerLabel.Size = new System.Drawing.Size(118, 23);
            this.avgpowerLabel.TabIndex = 22;
            this.avgpowerLabel.Text = "00%";
            this.avgpowerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // avgrpmLabel
            // 
            this.avgrpmLabel.BackColor = System.Drawing.Color.Transparent;
            this.avgrpmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avgrpmLabel.ForeColor = System.Drawing.Color.White;
            this.avgrpmLabel.Location = new System.Drawing.Point(762, 348);
            this.avgrpmLabel.Name = "avgrpmLabel";
            this.avgrpmLabel.Size = new System.Drawing.Size(118, 23);
            this.avgrpmLabel.TabIndex = 24;
            this.avgrpmLabel.Text = "000";
            this.avgrpmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // avgkmhLabel
            // 
            this.avgkmhLabel.BackColor = System.Drawing.Color.Transparent;
            this.avgkmhLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avgkmhLabel.ForeColor = System.Drawing.Color.White;
            this.avgkmhLabel.Location = new System.Drawing.Point(467, 348);
            this.avgkmhLabel.Name = "avgkmhLabel";
            this.avgkmhLabel.Size = new System.Drawing.Size(118, 23);
            this.avgkmhLabel.TabIndex = 25;
            this.avgkmhLabel.Text = "00,0";
            this.avgkmhLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // clientListBox
            // 
            this.clientListBox.BackColor = System.Drawing.Color.Black;
            this.clientListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clientListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientListBox.ForeColor = System.Drawing.Color.White;
            this.clientListBox.FormattingEnabled = true;
            this.clientListBox.ItemHeight = 24;
            this.clientListBox.Location = new System.Drawing.Point(12, 104);
            this.clientListBox.Name = "clientListBox";
            this.clientListBox.Size = new System.Drawing.Size(284, 120);
            this.clientListBox.TabIndex = 26;
            this.clientListBox.DoubleClick += new System.EventHandler(this.clientListBox_DoubleClick_1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(9, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Client                      ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataChart
            // 
            this.dataChart.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.InterlacedColor = System.Drawing.Color.White;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.LineWidth = 2;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            stripLine1.BackColor = System.Drawing.Color.White;
            stripLine1.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.StripLines.Add(stripLine1);
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.InterlacedColor = System.Drawing.Color.White;
            chartArea1.AxisY.IsLabelAutoFit = false;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.LineWidth = 2;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea1.AxisY.MinorTickMark.LineColor = System.Drawing.Color.White;
            stripLine2.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.StripLines.Add(stripLine2);
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisY2.LineColor = System.Drawing.Color.White;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.BorderColor = System.Drawing.Color.White;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 94F;
            chartArea1.Position.Width = 94F;
            chartArea1.Position.X = 3F;
            chartArea1.Position.Y = 5F;
            chartArea1.ShadowColor = System.Drawing.Color.White;
            this.dataChart.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.BorderColor = System.Drawing.Color.Transparent;
            legend1.Enabled = false;
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.HeaderSeparatorColor = System.Drawing.Color.White;
            legend1.IsTextAutoFit = false;
            legend1.ItemColumnSeparatorColor = System.Drawing.Color.White;
            legend1.Name = "Legend1";
            legend1.Position.Auto = false;
            legend1.Position.Height = 10F;
            legend1.Position.Width = 75F;
            legend1.TitleForeColor = System.Drawing.Color.White;
            legend1.TitleSeparatorColor = System.Drawing.Color.White;
            this.dataChart.Legends.Add(legend1);
            this.dataChart.Location = new System.Drawing.Point(-32, 385);
            this.dataChart.Name = "dataChart";
            this.dataChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.dataChart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series1.LabelBackColor = System.Drawing.Color.White;
            series1.LabelForeColor = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.MarkerColor = System.Drawing.Color.White;
            series1.Name = "Power (Watts)";
            series1.SmartLabelStyle.CalloutLineColor = System.Drawing.Color.White;
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Purple;
            series2.Enabled = false;
            series2.Legend = "Legend1";
            series2.Name = "KJ";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Yellow;
            series3.Enabled = false;
            series3.Legend = "Legend1";
            series3.Name = "RPM";
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Red;
            series4.Enabled = false;
            series4.Legend = "Legend1";
            series4.Name = "Pulse";
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Color = System.Drawing.Color.Blue;
            series5.Enabled = false;
            series5.Legend = "Legend1";
            series5.Name = "Km/h";
            this.dataChart.Series.Add(series1);
            this.dataChart.Series.Add(series2);
            this.dataChart.Series.Add(series3);
            this.dataChart.Series.Add(series4);
            this.dataChart.Series.Add(series5);
            this.dataChart.Size = new System.Drawing.Size(956, 175);
            this.dataChart.TabIndex = 29;
            this.dataChart.Text = "chart1";
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.BackColor = System.Drawing.Color.Transparent;
            this.userLabel.ForeColor = System.Drawing.Color.Black;
            this.userLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.userLabel.Location = new System.Drawing.Point(920, 9);
            this.userLabel.MaximumSize = new System.Drawing.Size(220, 65);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(27, 13);
            this.userLabel.TabIndex = 30;
            this.userLabel.Text = "user";
            this.userLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // connectedLabel
            // 
            this.connectedLabel.AutoSize = true;
            this.connectedLabel.BackColor = System.Drawing.Color.Transparent;
            this.connectedLabel.ForeColor = System.Drawing.Color.Red;
            this.connectedLabel.Location = new System.Drawing.Point(982, 593);
            this.connectedLabel.Name = "connectedLabel";
            this.connectedLabel.Size = new System.Drawing.Size(78, 13);
            this.connectedLabel.TabIndex = 31;
            this.connectedLabel.Text = "Not connected";
            this.connectedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.BackColor = System.Drawing.Color.Transparent;
            this.versionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionLabel.ForeColor = System.Drawing.Color.Black;
            this.versionLabel.Location = new System.Drawing.Point(306, 615);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(32, 16);
            this.versionLabel.TabIndex = 33;
            this.versionLabel.Text = "v1.0";
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Doctor.Properties.Resources.avans_logo;
            this.pictureBox1.Location = new System.Drawing.Point(64, 574);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(155, 49);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(894, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 13);
            this.label11.TabIndex = 35;
            this.label11.Text = "Chat                          ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(894, 385);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(108, 13);
            this.label12.TabIndex = 36;
            this.label12.Text = "Historie                      ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(306, 572);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 13);
            this.label13.TabIndex = 37;
            this.label13.Text = "status";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chatReceiveTextBox
            // 
            this.chatReceiveTextBox.BackColor = System.Drawing.Color.Black;
            this.chatReceiveTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatReceiveTextBox.ForeColor = System.Drawing.Color.White;
            this.chatReceiveTextBox.Location = new System.Drawing.Point(897, 104);
            this.chatReceiveTextBox.Name = "chatReceiveTextBox";
            this.chatReceiveTextBox.ReadOnly = true;
            this.chatReceiveTextBox.Size = new System.Drawing.Size(290, 113);
            this.chatReceiveTextBox.TabIndex = 38;
            this.chatReceiveTextBox.Text = "";
            // 
            // chatSendTextBox
            // 
            this.chatSendTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatSendTextBox.Location = new System.Drawing.Point(897, 223);
            this.chatSendTextBox.Name = "chatSendTextBox";
            this.chatSendTextBox.Size = new System.Drawing.Size(210, 26);
            this.chatSendTextBox.TabIndex = 39;
            // 
            // progressChart
            // 
            this.progressChart.BackColor = System.Drawing.Color.Transparent;
            chartArea2.AxisX.InterlacedColor = System.Drawing.Color.White;
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea2.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisX.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX.LineWidth = 2;
            chartArea2.AxisX.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea2.AxisX.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            stripLine3.BackColor = System.Drawing.Color.White;
            stripLine3.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisX.StripLines.Add(stripLine3);
            chartArea2.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea2.AxisX2.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY.InterlacedColor = System.Drawing.Color.White;
            chartArea2.AxisY.IsLabelAutoFit = false;
            chartArea2.AxisY.LabelStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            chartArea2.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisY.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY.LineWidth = 2;
            chartArea2.AxisY.MajorGrid.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY.MajorGrid.LineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea2.AxisY.MinorGrid.LineColor = System.Drawing.Color.White;
            chartArea2.AxisY.MinorTickMark.LineColor = System.Drawing.Color.White;
            stripLine4.ForeColor = System.Drawing.Color.White;
            chartArea2.AxisY.StripLines.Add(stripLine4);
            chartArea2.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea2.AxisY2.LineColor = System.Drawing.Color.White;
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.BackSecondaryColor = System.Drawing.Color.White;
            chartArea2.BorderColor = System.Drawing.Color.White;
            chartArea2.Name = "ChartArea1";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 100F;
            chartArea2.Position.Width = 100F;
            chartArea2.ShadowColor = System.Drawing.Color.White;
            this.progressChart.ChartAreas.Add(chartArea2);
            legend2.BackColor = System.Drawing.Color.Transparent;
            legend2.BorderColor = System.Drawing.Color.Transparent;
            legend2.Enabled = false;
            legend2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend2.ForeColor = System.Drawing.Color.White;
            legend2.HeaderSeparatorColor = System.Drawing.Color.White;
            legend2.IsTextAutoFit = false;
            legend2.ItemColumnSeparatorColor = System.Drawing.Color.White;
            legend2.Name = "Legend1";
            legend2.Position.Auto = false;
            legend2.Position.Height = 10F;
            legend2.Position.Width = 75F;
            legend2.TitleForeColor = System.Drawing.Color.White;
            legend2.TitleSeparatorColor = System.Drawing.Color.White;
            this.progressChart.Legends.Add(legend2);
            this.progressChart.Location = new System.Drawing.Point(302, 72);
            this.progressChart.Name = "progressChart";
            this.progressChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.progressChart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series6.BorderWidth = 2;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.SplineArea;
            series6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series6.LabelBackColor = System.Drawing.Color.White;
            series6.LabelForeColor = System.Drawing.Color.White;
            series6.Legend = "Legend1";
            series6.MarkerColor = System.Drawing.Color.White;
            series6.Name = "Height";
            dataPoint1.LabelBackColor = System.Drawing.Color.White;
            dataPoint2.LabelBackColor = System.Drawing.Color.White;
            dataPoint3.LabelBackColor = System.Drawing.Color.White;
            dataPoint4.LabelBackColor = System.Drawing.Color.White;
            dataPoint5.LabelBackColor = System.Drawing.Color.White;
            series6.Points.Add(dataPoint1);
            series6.Points.Add(dataPoint2);
            series6.Points.Add(dataPoint3);
            series6.Points.Add(dataPoint4);
            series6.Points.Add(dataPoint5);
            series6.SmartLabelStyle.CalloutLineColor = System.Drawing.Color.White;
            this.progressChart.Series.Add(series6);
            this.progressChart.Size = new System.Drawing.Size(586, 182);
            this.progressChart.TabIndex = 42;
            this.progressChart.Text = "chart2";
            this.progressChart.AnnotationPositionChanged += new System.EventHandler(this.progressChart_AnnotationPositionChanged);
            this.progressChart.AnnotationPositionChanging += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.AnnotationPositionChangingEventArgs>(this.progressChart_AnnotationPositionChanging);
            // 
            // trainingComboBox
            // 
            this.trainingComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trainingComboBox.FormattingEnabled = true;
            this.trainingComboBox.Items.AddRange(new object[] {
            "Mountains",
            "Forest",
            "Street"});
            this.trainingComboBox.Location = new System.Drawing.Point(531, 566);
            this.trainingComboBox.Name = "trainingComboBox";
            this.trainingComboBox.Size = new System.Drawing.Size(127, 33);
            this.trainingComboBox.TabIndex = 43;
            // 
            // userAddButton
            // 
            this.userAddButton.BackColor = System.Drawing.Color.White;
            this.userAddButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.userAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.userAddButton.ForeColor = System.Drawing.Color.Black;
            this.userAddButton.Location = new System.Drawing.Point(190, 73);
            this.userAddButton.Margin = new System.Windows.Forms.Padding(2);
            this.userAddButton.Name = "userAddButton";
            this.userAddButton.Size = new System.Drawing.Size(107, 26);
            this.userAddButton.TabIndex = 44;
            this.userAddButton.Text = "add user";
            this.userAddButton.UseVisualStyleBackColor = false;
            this.userAddButton.Click += new System.EventHandler(this.userAddButton_Click);
            // 
            // brakeButton
            // 
            this.brakeButton.BackColor = System.Drawing.Color.Red;
            this.brakeButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.brakeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.brakeButton.ForeColor = System.Drawing.Color.White;
            this.brakeButton.Location = new System.Drawing.Point(309, 30);
            this.brakeButton.Name = "brakeButton";
            this.brakeButton.Size = new System.Drawing.Size(196, 36);
            this.brakeButton.TabIndex = 45;
            this.brakeButton.Text = "Emergency brake";
            this.brakeButton.UseVisualStyleBackColor = false;
            this.brakeButton.Click += new System.EventHandler(this.brakeButton_Click);
            // 
            // powerLegendaLabel
            // 
            this.powerLegendaLabel.AutoSize = true;
            this.powerLegendaLabel.BackColor = System.Drawing.Color.Green;
            this.powerLegendaLabel.ForeColor = System.Drawing.Color.White;
            this.powerLegendaLabel.Location = new System.Drawing.Point(47, 385);
            this.powerLegendaLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.powerLegendaLabel.Name = "powerLegendaLabel";
            this.powerLegendaLabel.Size = new System.Drawing.Size(74, 13);
            this.powerLegendaLabel.TabIndex = 46;
            this.powerLegendaLabel.Text = "Power (Watts)";
            this.powerLegendaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.powerLegendaLabel.Click += new System.EventHandler(this.powerLegendaLabel_Click);
            // 
            // kjLegendaLabel
            // 
            this.kjLegendaLabel.AutoSize = true;
            this.kjLegendaLabel.BackColor = System.Drawing.Color.Transparent;
            this.kjLegendaLabel.ForeColor = System.Drawing.Color.White;
            this.kjLegendaLabel.Location = new System.Drawing.Point(178, 385);
            this.kjLegendaLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.kjLegendaLabel.Name = "kjLegendaLabel";
            this.kjLegendaLabel.Size = new System.Drawing.Size(19, 13);
            this.kjLegendaLabel.TabIndex = 47;
            this.kjLegendaLabel.Text = "KJ";
            this.kjLegendaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.kjLegendaLabel.Click += new System.EventHandler(this.kjLegendaLabel_Click);
            // 
            // rpmLegendaLabel
            // 
            this.rpmLegendaLabel.AutoSize = true;
            this.rpmLegendaLabel.BackColor = System.Drawing.Color.Transparent;
            this.rpmLegendaLabel.ForeColor = System.Drawing.Color.White;
            this.rpmLegendaLabel.Location = new System.Drawing.Point(213, 385);
            this.rpmLegendaLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rpmLegendaLabel.Name = "rpmLegendaLabel";
            this.rpmLegendaLabel.Size = new System.Drawing.Size(31, 13);
            this.rpmLegendaLabel.TabIndex = 48;
            this.rpmLegendaLabel.Text = "RPM";
            this.rpmLegendaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rpmLegendaLabel.Click += new System.EventHandler(this.rpmLegendaLabel_Click);
            // 
            // pulseLegendaLabel
            // 
            this.pulseLegendaLabel.AutoSize = true;
            this.pulseLegendaLabel.BackColor = System.Drawing.Color.Transparent;
            this.pulseLegendaLabel.ForeColor = System.Drawing.Color.White;
            this.pulseLegendaLabel.Location = new System.Drawing.Point(264, 385);
            this.pulseLegendaLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.pulseLegendaLabel.Name = "pulseLegendaLabel";
            this.pulseLegendaLabel.Size = new System.Drawing.Size(33, 13);
            this.pulseLegendaLabel.TabIndex = 49;
            this.pulseLegendaLabel.Text = "Pulse";
            this.pulseLegendaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pulseLegendaLabel.Click += new System.EventHandler(this.pulseLegendaLabel_Click);
            // 
            // kmhLegendaLabel
            // 
            this.kmhLegendaLabel.AutoSize = true;
            this.kmhLegendaLabel.BackColor = System.Drawing.Color.Transparent;
            this.kmhLegendaLabel.ForeColor = System.Drawing.Color.White;
            this.kmhLegendaLabel.Location = new System.Drawing.Point(332, 385);
            this.kmhLegendaLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.kmhLegendaLabel.Name = "kmhLegendaLabel";
            this.kmhLegendaLabel.Size = new System.Drawing.Size(33, 13);
            this.kmhLegendaLabel.TabIndex = 50;
            this.kmhLegendaLabel.Text = "Km/h";
            this.kmhLegendaLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.kmhLegendaLabel.Click += new System.EventHandler(this.kmhLegendaLabel_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(57, 541);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 51;
            this.label10.Text = "Tijd (sec)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // historyListBox
            // 
            this.historyListBox.BackColor = System.Drawing.Color.Black;
            this.historyListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.historyListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.historyListBox.ForeColor = System.Drawing.Color.White;
            this.historyListBox.FormattingEnabled = true;
            this.historyListBox.ItemHeight = 24;
            this.historyListBox.Location = new System.Drawing.Point(896, 420);
            this.historyListBox.Margin = new System.Windows.Forms.Padding(2);
            this.historyListBox.Name = "historyListBox";
            this.historyListBox.Size = new System.Drawing.Size(291, 120);
            this.historyListBox.TabIndex = 52;
            // 
            // UpdateDataLive
            // 
            this.UpdateDataLive.Interval = 1000;
            this.UpdateDataLive.Tick += new System.EventHandler(this.UpdateDataLive_Tick);
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.White;
            this.stopButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.stopButton.ForeColor = System.Drawing.Color.Black;
            this.stopButton.Location = new System.Drawing.Point(780, 566);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(110, 33);
            this.stopButton.TabIndex = 53;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // chatSendButton
            // 
            this.chatSendButton.AutoSize = true;
            this.chatSendButton.BackColor = System.Drawing.Color.White;
            this.chatSendButton.FlatAppearance.BorderSize = 0;
            this.chatSendButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chatSendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatSendButton.ForeColor = System.Drawing.Color.Black;
            this.chatSendButton.Location = new System.Drawing.Point(1113, 223);
            this.chatSendButton.Name = "chatSendButton";
            this.chatSendButton.Size = new System.Drawing.Size(74, 29);
            this.chatSendButton.TabIndex = 41;
            this.chatSendButton.Text = "Verzenden";
            this.chatSendButton.UseVisualStyleBackColor = false;
            this.chatSendButton.Click += new System.EventHandler(this.chatSendButton_Click);
            // 
            // printButton
            // 
            this.printButton.BackColor = System.Drawing.Color.Black;
            this.printButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.printButton.ForeColor = System.Drawing.Color.Transparent;
            this.printButton.Image = global::Doctor.Properties.Resources.print;
            this.printButton.Location = new System.Drawing.Point(857, 381);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(28, 20);
            this.printButton.TabIndex = 54;
            this.printButton.UseVisualStyleBackColor = false;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::Doctor.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(1199, 635);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.historyListBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.kmhLegendaLabel);
            this.Controls.Add(this.pulseLegendaLabel);
            this.Controls.Add(this.rpmLegendaLabel);
            this.Controls.Add(this.kjLegendaLabel);
            this.Controls.Add(this.powerLegendaLabel);
            this.Controls.Add(this.brakeButton);
            this.Controls.Add(this.userAddButton);
            this.Controls.Add(this.trainingComboBox);
            this.Controls.Add(this.progressChart);
            this.Controls.Add(this.chatSendButton);
            this.Controls.Add(this.chatSendTextBox);
            this.Controls.Add(this.chatReceiveTextBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.connectedLabel);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.dataChart);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.clientListBox);
            this.Controls.Add(this.avgkmhLabel);
            this.Controls.Add(this.avgrpmLabel);
            this.Controls.Add(this.avgbpmLabel);
            this.Controls.Add(this.avgpowerLabel);
            this.Controls.Add(this.bpmLabel);
            this.Controls.Add(this.powerLabel);
            this.Controls.Add(this.rpmLabel);
            this.Controls.Add(this.kjLabel);
            this.Controls.Add(this.kmhLabel);
            this.Controls.Add(this.avgwattsLabel);
            this.Controls.Add(this.wattsLabel);
            this.Controls.Add(this.avgkmLabel);
            this.Controls.Add(this.kmLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.currentTimeLabel);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dokter Console";
            ((System.ComponentModel.ISupportInitialize)(this.dataChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progressChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label currentTimeLabel;
        private System.Windows.Forms.Timer timeTimer;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.Label timeLabel;
        public System.Windows.Forms.Label kmLabel;
        public System.Windows.Forms.Label avgkmLabel;
        public System.Windows.Forms.Label wattsLabel;
        public System.Windows.Forms.Label avgwattsLabel;
        public System.Windows.Forms.Label rpmLabel;
        public System.Windows.Forms.Label kjLabel;
        public System.Windows.Forms.Label kmhLabel;
        public System.Windows.Forms.Label bpmLabel;
        public System.Windows.Forms.Label powerLabel;
        public System.Windows.Forms.Label avgbpmLabel;
        public System.Windows.Forms.Label avgpowerLabel;
        public System.Windows.Forms.Label avgrpmLabel;
        public System.Windows.Forms.Label avgkmhLabel;
        public System.Windows.Forms.ListBox clientListBox;
        public System.Windows.Forms.DataVisualization.Charting.Chart dataChart;
        public System.Windows.Forms.Label userLabel;
        public System.Windows.Forms.Label connectedLabel;
        public System.Windows.Forms.RichTextBox chatReceiveTextBox;
        public System.Windows.Forms.TextBox chatSendTextBox;
        public Classes.SplitButton chatSendButton;
        public System.Windows.Forms.DataVisualization.Charting.Chart progressChart;
        private System.Windows.Forms.ComboBox trainingComboBox;
        private System.Windows.Forms.Button userAddButton;
        private System.Windows.Forms.Button brakeButton;
        private System.Windows.Forms.Label powerLegendaLabel;
        private System.Windows.Forms.Label kjLegendaLabel;
        private System.Windows.Forms.Label rpmLegendaLabel;
        private System.Windows.Forms.Label pulseLegendaLabel;
        private System.Windows.Forms.Label kmhLegendaLabel;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.ListBox historyListBox;
        private System.Windows.Forms.Timer UpdateDataLive;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button printButton;
    }
}

