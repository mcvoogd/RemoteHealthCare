﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VRConnectorForm
{
    public partial class TunnelCommandForm : Form
    {
        private Connection _connection;

        public TunnelCommandForm(Connection connection)
        {
            InitializeComponent();
            TunnelId.Text = "Connected Tunnel : " + connection.TunnelID; //TODO : no tunnelID is set when initializing tunnelform.
          //  Console.WriteLine(connection.TunnelID + " <- ID");
            _connection = connection;
        }

        private void sedCommandButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Sending car");             
            string req =
                "{ \"id\" : \"tunnel/send\", \"data\" : {\"dest\" :\"" + _connection.TunnelID +
                "\", \"data\" : { \"id\" : \"scene/node/add\", \"data\" : { \"name\" : \"car\", \"components\" : { \"transform\" : { \"position\" : [ 0, 0, 0 ], \"scale\" : 0.025 , \"rotation\" : [ 0, 0, 0 ] }, \"model\" : { \"file\" : \"data/NetworkEngine/models/cars/white/car_white.obj\" } } } } } }";
            _connection.sendMessage(req);
            Console.WriteLine(_connection.TunnelID);

        }

        private void StatisticsButton_Click_1(object sender, EventArgs e)
        {
            TunnelId.Text = _connection.TunnelID;
            NameLabel.Text = _connection.UserName;
        }
    }
}
