﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VRConnectorForm.Program;
using VRConnectorForm.VRobjects;

namespace VRConnectorForm.Forms
{
    public partial class TunnelCommandForm : Form
    {
        private Connection _connection;
        private string name { get; set; }
        private Node auto = null;
        private Node house = null;
        private Skybox skybox = null;
       

        public TunnelCommandForm(Connection connection, string name)
        {
            InitializeComponent();
            this.name = name;   
            _connection = connection;
        }

        private void sedCommandButton_Click(object sender, EventArgs e)
        {        
            string req =
                "{ \"id\" : \"tunnel/send\", \"data\" : {\"dest\" :\"" + _connection.TunnelID +
                "\", \"data\" : { \"id\" : \"scene/node/add\", \"data\" : { \"name\" : \"car\", \"components\" : { \"transform\" : { \"position\" : [ 0, 0, 0 ], \"scale\" : 0.025 , \"rotation\" : [ 0, 0, 0 ] }, \"model\" : { \"file\" : \"data/NetworkEngine/models/cars/white/car_white.obj\" } } } } } }";
            _connection.sendMessage(req);
        }

        private void StatisticsButton_Click_1(object sender, EventArgs e)
        {
            if (TunnelId.Text == "")
            {
                TunnelId.Text = "User ID : " + _connection.TunnelID;
                NameLabel.Text = "User : " + name;
            }
            else
            {
                TunnelId.Text = "";
                NameLabel.Text = "";

            }
        }

        private void CreateAuto_Click(object sender, EventArgs e)
        {
             auto = new Node("car", _connection.TunnelID, "data/NetworkEngine/models/cars/white/car_white.obj", 5, 0,10 , 0.025);
            _connection.nodes.Add(auto);         
        }

        private void SendAuto_Click(object sender, EventArgs e)
        {
            if(auto != null)
            _connection.sendMessage(auto.SendString);
        }

        private void MoveCar_Click(object sender, EventArgs e)
        {
            _connection.sendMessage(auto.MoveNode(20, 0, 50, 20));
        }

        private void addTerrainButton_Click(object sender, EventArgs e)
        {
            Terrain terrain = new Terrain(_connection.TunnelID,_connection);
            var terrainNode = new Node("Terrain node", _connection.TunnelID, -128, 0.5, -128);
            _connection.sendMessage(terrainNode.SendString);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if(skybox == null)
            skybox = new Skybox("skybox", _connection.TunnelID);
            double time = (float)SetTime.Value/4.0f;
            _connection.sendMessage(skybox.SetTime(time));

           
            //_connection.sendMessage(skybox.Update());
        }

        private void CreateHouse_Click(object sender, EventArgs e)
        {
             house = new Node("house", _connection.TunnelID, "data/NetworkEngine/models/houses/set1/house3.obj", 10,0, -50, 7);
        }

        private void SendHouse_Click(object sender, EventArgs e)
        {
            if(house != null)
            _connection.sendMessage(house.SendString);
        }

        //"data/NetworkEngine/models/cars/white/car_white.obj"

    }
}
