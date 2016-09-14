using System;
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
        private string ID { get; set; }
        private Node auto;

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
            Console.WriteLine(_connection.TunnelID);
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
             auto = new Node("car", _connection.TunnelID, "data/NetworkEngine/models/cars/white/car_white.obj", 20, 0, 0);
            _connection.nodes.Add(auto);         
        }

        private void SendAuto_Click(object sender, EventArgs e)
        {
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

        //"data/NetworkEngine/models/cars/white/car_white.obj"

    }
}
