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
        public string Name { get; set; }
        private Node _auto = null;
        private Node _house = null;
        private Skybox _skybox = null;
        private bool _send = false;

        public TunnelCommandForm(Connection connection, String name, String ID)
        {
            InitializeComponent();
            this.name = name;
            this.ID = ID;
            ;
            ;   //  Console.WriteLine(connection.TunnelID + " <- ID");
            _connection = connection;
        }

        private void sedCommandButton_Click(object sender, EventArgs e)
        {
            if (!_send)
            {
                _send = true;
                _connection.SendMessage( RequestCreater.GetScene(_connection.TunnelId));
            }
            else
            {
                _connection.SendMessage(RequestCreater.SceneNodeDelete(_connection.GroundPlanId, _connection.TunnelId));
            }
        }

        private void StatisticsButton_Click_1(object sender, EventArgs e)
        {
            
                _connection.SendMessage(
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
                    }, _connection.TunnelId));
   }

        private void CreateAuto_Click(object sender, EventArgs e)
        {
             _auto = new Node("car", _connection.TunnelId, "data/NetworkEngine/models/cars/white/car_white.obj", 0, 0, 0 , 0.025);
            _connection.Nodes.Add(_auto);         
        }

        private void SendAuto_Click(object sender, EventArgs e)
        {
            if(_auto != null)
            _connection.SendMessage(_auto.SendString);
        }

        private void MoveCar_Click(object sender, EventArgs e)
        {
            _connection.SendMessage(_auto.MoveNode(20, 0, 50, 20));
        }

        private void addTerrainButton_Click(object sender, EventArgs e)
        {
           Terrain terrain = new Terrain(_connection.TunnelId,_connection);
            var terrainNode = new Node("Terrain node", _connection.TunnelId, -128, 0.5, -128);
            _connection.SendMessage(terrainNode.SendString);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if(_skybox == null)
            _skybox = new Skybox("skybox", _connection.TunnelId);
            double time = (float)SetTime.Value/4.0f;
            _connection.SendMessage(_skybox.SetTime(time));         
        }

        private void CreateHouse_Click(object sender, EventArgs e)
        {
            if(_house == null)
             _house = new Node("house", _connection.TunnelId, "data/NetworkEngine/models/houses/set1/house3.obj", 10,0, -50, 7);
        }

        private void SendHouse_Click(object sender, EventArgs e)
        {
            if(_house != null)
            _connection.SendMessage(_house.SendString);
        }

        private void CreateRoute_Click(object sender, EventArgs e)
        {
            _connection.SendMessage(RequestCreater.TunnelSend(new
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
            }, _connection.TunnelId));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _connection.SendMessage(RequestCreater.TunnelSend(new
            {
                id = "scene/road/add",
                data = new
                {
                    route = _connection.RouteId
                }
            }, _connection.TunnelId));
        }

        private void FollowRoad_Click(object sender, EventArgs e)
        {
            _connection.SendMessage(RequestCreater.TunnelSend(new
            {
                id = "route/follow",
                data = new
                {
                    route = _connection.RouteId,
                    node = _auto.Uuid,
                    speed = 1.0,
                    offset = 0.0,
                    rotate = "XZ",
                    followHeight = false,
                    rotateOffset = new[] { 0, Math.PI/2, 0 },
                    positionOffset = new[] { 0, 0, 0 },

                }
            }, _connection.TunnelId));
        }
    }
}
