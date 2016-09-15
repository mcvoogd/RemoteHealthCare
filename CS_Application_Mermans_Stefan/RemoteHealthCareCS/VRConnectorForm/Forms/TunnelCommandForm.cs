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
        private Node auto = null;
        private Node house = null;
        private Skybox skybox = null;
        private bool send = false;

        public TunnelCommandForm(Connection connection, string name)
        {
            InitializeComponent();
            this.name = name;   
            _connection = connection;
        }

        private void sedCommandButton_Click(object sender, EventArgs e)
        {
            if (!send)
            {
                send = true;
                _connection.sendMessage( RequestCreater.GetScene(_connection.TunnelID));
            }
            else
            {
                _connection.sendMessage(RequestCreater.SceneNodeDelete(_connection.GroundPlanID, _connection.TunnelID));
            }
        }

        private void StatisticsButton_Click_1(object sender, EventArgs e)
        {
            
                _connection.sendMessage(
                    RequestCreater.TunnelSend(new
                    {
                        id = "scene/node/addlayer",
                        data = new
                        {
                            id = _connection.TerrainId,
                            normal = "data/NetworkEngine/textures/terrain/adesert_mntn4_n.jpg",
                            diffuse = "data/NetworkEngine/textures/terrain/adesert_mntn4_d.jpg",
                            minHeight = 0,
                            maxHeight = 30,
                            fadeDist = 1
                        }
                    }, _connection.TunnelID));
   }

        private void CreateAuto_Click(object sender, EventArgs e)
        {
             auto = new Node("car", _connection.TunnelID, "data/NetworkEngine/models/cars/white/car_white.obj", 0, 0, 0 , 0.025);
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
        }

        private void CreateHouse_Click(object sender, EventArgs e)
        {
            if(house == null)
             house = new Node("house", _connection.TunnelID, "data/NetworkEngine/models/houses/set1/house3.obj", 10,0, -50, 7);
        }

        private void SendHouse_Click(object sender, EventArgs e)
        {
            if(house != null)
            _connection.sendMessage(house.SendString);
        }

        private void CreateRoute_Click(object sender, EventArgs e)
        {
            _connection.sendMessage(RequestCreater.TunnelSend(new
            {
                id = "route/add",
                data = new
                {
                    nodes = new[]
                    {
                        new {pos = new[] {0,0,0} , dir = new[] {5, 0, -5 }},
                        new {pos = new[] {50,0,0} , dir = new[] {5,0,5}},
                        new {pos = new[] {50,0,50}, dir = new[] {-5,0,5}},
                        new {pos = new[] {0,0,50}, dir = new[] {-5,0,-5}}
                     }
                }
            }, _connection.TunnelID));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _connection.sendMessage(RequestCreater.TunnelSend(new
            {
                id = "scene/road/add",
                data = new
                {
                    route = _connection.RouteID
                }
            }, _connection.TunnelID));
        }

        private void FollowRoad_Click(object sender, EventArgs e)
        {
            _connection.sendMessage(RequestCreater.TunnelSend(new
            {
                id = "route/follow",
                data = new
                {
                    route = _connection.RouteID,
                    node = auto.Uuid,
                    speed = 1.0,
                    offset = 0.0,
                    rotate = "XZ",
                    followHeight = false,
                    rotateOffset = new[] { 0, Math.PI/2, 0 },
                    positionOffset = new[] { 0, 0, 0 },

                }
            }, _connection.TunnelID));
        }
    }
}
