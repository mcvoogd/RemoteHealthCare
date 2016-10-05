﻿namespace Doctor.Forms
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
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 10D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(2D, 5D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint3 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(3D, 7D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint4 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(4D, 6D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint5 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(24D, 80D);
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint6 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 55D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint7 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(7D, 23D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint8 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(23D, 97D);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.currentTimeLabel = new System.Windows.Forms.Label();
            this.timeTimer = new System.Windows.Forms.Timer(this.components);
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
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
            this.addClientButton = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.userLabel = new System.Windows.Forms.Label();
            this.connectedLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.chatReceiveTextBox = new System.Windows.Forms.RichTextBox();
            this.chatSendTextBox = new System.Windows.Forms.TextBox();
            this.chatSendButton = new Doctor.Classes.SplitButton();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1655, 832);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(151, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Henk";
            // 
            // currentTimeLabel
            // 
            this.currentTimeLabel.AutoSize = true;
            this.currentTimeLabel.BackColor = System.Drawing.Color.Transparent;
            this.currentTimeLabel.ForeColor = System.Drawing.Color.White;
            this.currentTimeLabel.Location = new System.Drawing.Point(977, 49);
            this.currentTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentTimeLabel.Name = "currentTimeLabel";
            this.currentTimeLabel.Size = new System.Drawing.Size(0, 17);
            this.currentTimeLabel.TabIndex = 1;
            // 
            // timeTimer
            // 
            this.timeTimer.Interval = 1000;
            this.timeTimer.Tick += new System.EventHandler(this.timeTimer_Tick);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.White;
            this.saveButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.saveButton.ForeColor = System.Drawing.Color.Black;
            this.saveButton.Location = new System.Drawing.Point(819, 697);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(180, 43);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "SAVE";
            this.saveButton.UseVisualStyleBackColor = false;
            // 
            // loadButton
            // 
            this.loadButton.BackColor = System.Drawing.Color.White;
            this.loadButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.loadButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loadButton.ForeColor = System.Drawing.Color.Black;
            this.loadButton.Location = new System.Drawing.Point(1007, 697);
            this.loadButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(180, 43);
            this.loadButton.TabIndex = 3;
            this.loadButton.Text = "LOAD";
            this.loadButton.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(68, 331);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Time";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(280, 331);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "km";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(444, 331);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "watts";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(652, 331);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "km/h";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(877, 331);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(22, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "kJ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(1053, 331);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "RPM";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(1228, 331);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "Power";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(1447, 331);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 17);
            this.label8.TabIndex = 11;
            this.label8.Text = "BPM";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timeLabel
            // 
            this.timeLabel.BackColor = System.Drawing.Color.Transparent;
            this.timeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.ForeColor = System.Drawing.Color.White;
            this.timeLabel.Location = new System.Drawing.Point(27, 367);
            this.timeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(173, 44);
            this.timeLabel.TabIndex = 12;
            this.timeLabel.Text = "00:00:00";
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kmLabel
            // 
            this.kmLabel.BackColor = System.Drawing.Color.Transparent;
            this.kmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kmLabel.ForeColor = System.Drawing.Color.White;
            this.kmLabel.Location = new System.Drawing.Point(228, 367);
            this.kmLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kmLabel.Name = "kmLabel";
            this.kmLabel.Size = new System.Drawing.Size(157, 44);
            this.kmLabel.TabIndex = 13;
            this.kmLabel.Text = "00,0";
            this.kmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // avgkmLabel
            // 
            this.avgkmLabel.BackColor = System.Drawing.Color.Transparent;
            this.avgkmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avgkmLabel.ForeColor = System.Drawing.Color.White;
            this.avgkmLabel.Location = new System.Drawing.Point(228, 428);
            this.avgkmLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.avgkmLabel.Name = "avgkmLabel";
            this.avgkmLabel.Size = new System.Drawing.Size(157, 28);
            this.avgkmLabel.TabIndex = 14;
            this.avgkmLabel.Text = "00,0";
            this.avgkmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wattsLabel
            // 
            this.wattsLabel.BackColor = System.Drawing.Color.Transparent;
            this.wattsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wattsLabel.ForeColor = System.Drawing.Color.White;
            this.wattsLabel.Location = new System.Drawing.Point(427, 367);
            this.wattsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.wattsLabel.Name = "wattsLabel";
            this.wattsLabel.Size = new System.Drawing.Size(157, 44);
            this.wattsLabel.TabIndex = 15;
            this.wattsLabel.Text = "000";
            this.wattsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // avgwattsLabel
            // 
            this.avgwattsLabel.BackColor = System.Drawing.Color.Transparent;
            this.avgwattsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avgwattsLabel.ForeColor = System.Drawing.Color.White;
            this.avgwattsLabel.Location = new System.Drawing.Point(427, 428);
            this.avgwattsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.avgwattsLabel.Name = "avgwattsLabel";
            this.avgwattsLabel.Size = new System.Drawing.Size(157, 28);
            this.avgwattsLabel.TabIndex = 16;
            this.avgwattsLabel.Text = "000";
            this.avgwattsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rpmLabel
            // 
            this.rpmLabel.BackColor = System.Drawing.Color.Transparent;
            this.rpmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rpmLabel.ForeColor = System.Drawing.Color.White;
            this.rpmLabel.Location = new System.Drawing.Point(1016, 367);
            this.rpmLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.rpmLabel.Name = "rpmLabel";
            this.rpmLabel.Size = new System.Drawing.Size(157, 44);
            this.rpmLabel.TabIndex = 19;
            this.rpmLabel.Text = "000";
            this.rpmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kjLabel
            // 
            this.kjLabel.BackColor = System.Drawing.Color.Transparent;
            this.kjLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kjLabel.ForeColor = System.Drawing.Color.White;
            this.kjLabel.Location = new System.Drawing.Point(820, 367);
            this.kjLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kjLabel.Name = "kjLabel";
            this.kjLabel.Size = new System.Drawing.Size(157, 44);
            this.kjLabel.TabIndex = 18;
            this.kjLabel.Text = "000";
            this.kjLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kmhLabel
            // 
            this.kmhLabel.BackColor = System.Drawing.Color.Transparent;
            this.kmhLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kmhLabel.ForeColor = System.Drawing.Color.White;
            this.kmhLabel.Location = new System.Drawing.Point(623, 367);
            this.kmhLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.kmhLabel.Name = "kmhLabel";
            this.kmhLabel.Size = new System.Drawing.Size(157, 44);
            this.kmhLabel.TabIndex = 17;
            this.kmhLabel.Text = "00,0";
            this.kmhLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bpmLabel
            // 
            this.bpmLabel.BackColor = System.Drawing.Color.Transparent;
            this.bpmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bpmLabel.ForeColor = System.Drawing.Color.White;
            this.bpmLabel.Location = new System.Drawing.Point(1409, 367);
            this.bpmLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.bpmLabel.Name = "bpmLabel";
            this.bpmLabel.Size = new System.Drawing.Size(157, 44);
            this.bpmLabel.TabIndex = 21;
            this.bpmLabel.Text = "000";
            this.bpmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // powerLabel
            // 
            this.powerLabel.BackColor = System.Drawing.Color.Transparent;
            this.powerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.powerLabel.ForeColor = System.Drawing.Color.White;
            this.powerLabel.Location = new System.Drawing.Point(1215, 367);
            this.powerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.powerLabel.Name = "powerLabel";
            this.powerLabel.Size = new System.Drawing.Size(157, 44);
            this.powerLabel.TabIndex = 20;
            this.powerLabel.Text = "00%";
            this.powerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // avgbpmLabel
            // 
            this.avgbpmLabel.BackColor = System.Drawing.Color.Transparent;
            this.avgbpmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avgbpmLabel.ForeColor = System.Drawing.Color.White;
            this.avgbpmLabel.Location = new System.Drawing.Point(1409, 428);
            this.avgbpmLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.avgbpmLabel.Name = "avgbpmLabel";
            this.avgbpmLabel.Size = new System.Drawing.Size(157, 28);
            this.avgbpmLabel.TabIndex = 23;
            this.avgbpmLabel.Text = "000";
            this.avgbpmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // avgpowerLabel
            // 
            this.avgpowerLabel.BackColor = System.Drawing.Color.Transparent;
            this.avgpowerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avgpowerLabel.ForeColor = System.Drawing.Color.White;
            this.avgpowerLabel.Location = new System.Drawing.Point(1215, 428);
            this.avgpowerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.avgpowerLabel.Name = "avgpowerLabel";
            this.avgpowerLabel.Size = new System.Drawing.Size(157, 28);
            this.avgpowerLabel.TabIndex = 22;
            this.avgpowerLabel.Text = "00%";
            this.avgpowerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // avgrpmLabel
            // 
            this.avgrpmLabel.BackColor = System.Drawing.Color.Transparent;
            this.avgrpmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avgrpmLabel.ForeColor = System.Drawing.Color.White;
            this.avgrpmLabel.Location = new System.Drawing.Point(1016, 428);
            this.avgrpmLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.avgrpmLabel.Name = "avgrpmLabel";
            this.avgrpmLabel.Size = new System.Drawing.Size(157, 28);
            this.avgrpmLabel.TabIndex = 24;
            this.avgrpmLabel.Text = "000";
            this.avgrpmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // avgkmhLabel
            // 
            this.avgkmhLabel.BackColor = System.Drawing.Color.Transparent;
            this.avgkmhLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.avgkmhLabel.ForeColor = System.Drawing.Color.White;
            this.avgkmhLabel.Location = new System.Drawing.Point(623, 428);
            this.avgkmhLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.avgkmhLabel.Name = "avgkmhLabel";
            this.avgkmhLabel.Size = new System.Drawing.Size(157, 28);
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
            this.clientListBox.ItemHeight = 29;
            this.clientListBox.Items.AddRange(new object[] {
            "Kevin",
            "Martijn",
            "Menno",
            "Stefan",
            "Gijs",
            "Cas",
            "Kevin",
            "Martijn",
            "Menno",
            "Stefan",
            "Gijs",
            "Cas",
            "Kevin",
            "Martijn",
            "Menno",
            "Stefan",
            "Gijs",
            "Cas"});
            this.clientListBox.Location = new System.Drawing.Point(16, 128);
            this.clientListBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clientListBox.Name = "clientListBox";
            this.clientListBox.Size = new System.Drawing.Size(379, 174);
            this.clientListBox.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(12, 89);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(131, 17);
            this.label9.TabIndex = 27;
            this.label9.Text = "Client                      ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addClientButton
            // 
            this.addClientButton.BackColor = System.Drawing.Color.White;
            this.addClientButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.addClientButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addClientButton.ForeColor = System.Drawing.Color.Black;
            this.addClientButton.Location = new System.Drawing.Point(360, 89);
            this.addClientButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addClientButton.Name = "addClientButton";
            this.addClientButton.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.addClientButton.Size = new System.Drawing.Size(35, 32);
            this.addClientButton.TabIndex = 28;
            this.addClientButton.Text = "+";
            this.addClientButton.UseVisualStyleBackColor = false;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.Transparent;
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
            chartArea1.ShadowColor = System.Drawing.Color.White;
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.BorderColor = System.Drawing.Color.Transparent;
            legend1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(-43, 474);
            this.chart1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.chart1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series1.LabelBackColor = System.Drawing.Color.White;
            series1.LabelForeColor = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.MarkerColor = System.Drawing.Color.White;
            series1.Name = "Power (Watts)";
            dataPoint1.LabelBackColor = System.Drawing.Color.White;
            dataPoint2.LabelBackColor = System.Drawing.Color.White;
            dataPoint3.LabelBackColor = System.Drawing.Color.White;
            dataPoint4.LabelBackColor = System.Drawing.Color.White;
            dataPoint5.LabelBackColor = System.Drawing.Color.White;
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            series1.Points.Add(dataPoint3);
            series1.Points.Add(dataPoint4);
            series1.Points.Add(dataPoint5);
            series1.SmartLabelStyle.CalloutLineColor = System.Drawing.Color.White;
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Yellow;
            series2.Legend = "Legend1";
            series2.Name = "KJ";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "RPM";
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Red;
            series4.Legend = "Legend1";
            series4.Name = "Pulse";
            series5.BorderWidth = 2;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend1";
            series5.Name = "Km/h";
            series5.Points.Add(dataPoint6);
            series5.Points.Add(dataPoint7);
            series5.Points.Add(dataPoint8);
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Series.Add(series5);
            this.chart1.Size = new System.Drawing.Size(1179, 219);
            this.chart1.TabIndex = 29;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.BackColor = System.Drawing.Color.Transparent;
            this.userLabel.ForeColor = System.Drawing.Color.Black;
            this.userLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.userLabel.Location = new System.Drawing.Point(1227, 11);
            this.userLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userLabel.MaximumSize = new System.Drawing.Size(293, 80);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(115, 17);
            this.userLabel.TabIndex = 30;
            this.userLabel.Text = "Martijn de Voogd";
            this.userLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // connectedLabel
            // 
            this.connectedLabel.AutoSize = true;
            this.connectedLabel.BackColor = System.Drawing.Color.Transparent;
            this.connectedLabel.ForeColor = System.Drawing.Color.Red;
            this.connectedLabel.Location = new System.Drawing.Point(1309, 730);
            this.connectedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.connectedLabel.Name = "connectedLabel";
            this.connectedLabel.Size = new System.Drawing.Size(100, 17);
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
            this.versionLabel.Location = new System.Drawing.Point(408, 757);
            this.versionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(39, 20);
            this.versionLabel.TabIndex = 33;
            this.versionLabel.Text = "v1.0";
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Doctor.Properties.Resources.avans_logo;
            this.pictureBox1.Location = new System.Drawing.Point(85, 706);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(207, 60);
            this.pictureBox1.TabIndex = 34;
            this.pictureBox1.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(1192, 89);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(141, 17);
            this.label11.TabIndex = 35;
            this.label11.Text = "Chat                          ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(1192, 474);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(132, 17);
            this.label12.TabIndex = 36;
            this.label12.Text = "Historie                   ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(408, 709);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 17);
            this.label13.TabIndex = 37;
            this.label13.Text = "status";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chatReceiveTextBox
            // 
            this.chatReceiveTextBox.BackColor = System.Drawing.Color.Black;
            this.chatReceiveTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatReceiveTextBox.ForeColor = System.Drawing.Color.White;
            this.chatReceiveTextBox.Location = new System.Drawing.Point(1196, 128);
            this.chatReceiveTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chatReceiveTextBox.Name = "chatReceiveTextBox";
            this.chatReceiveTextBox.ReadOnly = true;
            this.chatReceiveTextBox.Size = new System.Drawing.Size(385, 138);
            this.chatReceiveTextBox.TabIndex = 38;
            this.chatReceiveTextBox.Text = "Hoi fietser\n\tHallo dokter\nHoe gaat het?\n\tGoed!";
            // 
            // chatSendTextBox
            // 
            this.chatSendTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatSendTextBox.Location = new System.Drawing.Point(1196, 274);
            this.chatSendTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chatSendTextBox.Name = "chatSendTextBox";
            this.chatSendTextBox.Size = new System.Drawing.Size(279, 30);
            this.chatSendTextBox.TabIndex = 39;
            // 
            // chatSendButton
            // 
            this.chatSendButton.AutoSize = true;
            this.chatSendButton.BackColor = System.Drawing.Color.White;
            this.chatSendButton.FlatAppearance.BorderSize = 0;
            this.chatSendButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chatSendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatSendButton.ForeColor = System.Drawing.Color.Black;
            this.chatSendButton.Location = new System.Drawing.Point(1484, 274);
            this.chatSendButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chatSendButton.Name = "chatSendButton";
            this.chatSendButton.Size = new System.Drawing.Size(99, 36);
            this.chatSendButton.TabIndex = 41;
            this.chatSendButton.Text = "Verzenden";
            this.chatSendButton.UseVisualStyleBackColor = false;
            this.chatSendButton.Click += new System.EventHandler(this.chatSendButton_Click_1);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Doctor.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(1599, 782);
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
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.addClientButton);
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
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.currentTimeLabel);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dokter Console";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label currentTimeLabel;
        private System.Windows.Forms.Timer timeTimer;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
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
        public System.Windows.Forms.Button addClientButton;
        public System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        public System.Windows.Forms.Label userLabel;
        public System.Windows.Forms.Label connectedLabel;
        public System.Windows.Forms.RichTextBox chatReceiveTextBox;
        public System.Windows.Forms.TextBox chatSendTextBox;
        public Classes.SplitButton chatSendButton;
    }
}
