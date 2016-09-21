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

        public TunnelCommandForm(Connection connection, String name)
        {
            InitializeComponent();
            Name = name;
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
            var terrainNode = new Node("Terrain node", _connection.TunnelId, -100, 0.5, -100);
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
                        //grid is 200x200

                        new {pos = new[] {-14,10,-35} , dir = new[] {5, 0, -5 }},
                        new {pos = new[] {35,10,-35} , dir = new[] {5,0,5}},
                        new {pos = new[] {35,10,31}, dir = new[] {-5,0,5}},
                        new {pos = new[] {-14,10,31}, dir = new[] {-5,0,5}}

                        //new {pos = new[] {-77,0, -74} , dir = new[] {5, 0, -5 }},
                        //new {pos = new[] {-66,0,-74} , dir = new[] {5,0,5}},
                        //new {pos = new[] {-41,0,-65}, dir = new[] {-5,0,5}},
                        //new {pos = new[] {-9,0,-69}, dir = new[] {-5,0,-5}},
                        //new {pos = new[] {44,0,-69}, dir = new[] {-5,0,-5}},
                        //new {pos = new[] {64,0,-59}, dir = new[] {-5,0,-5}},
                        //new {pos = new[] {67,0,-50}, dir = new[] {-5,0,-5}},
                        //new {pos = new[] {69,0,-26}, dir = new[] {-5,0,-5}},
                        //new {pos = new[] {59,0,-13}, dir = new[] {-5,0,-5}},
                        //new {pos = new[] {34,0,-13}, dir = new[] {-5,0,-5}},
                        //new {pos = new[] {14,0,-13}, dir = new[] {-5,0,-5}},
                        //new {pos = new[] {-13,0,-21}, dir = new[] {-5,0,-5}},
                        //new {pos = new[] {-35,0,-19}, dir = new[] {-5,0,-5}},
                        //new {pos = new[] {-7,0,0}, dir = new[] {-5,0,-5}},
                        //new {pos = new[] {28,0,2}, dir = new[] {-5,0,-5}},
                        //new {pos = new[] {51,0,2}, dir = new[] {-5,0,-5}},
                        //new {pos = new[] {65,0,4}, dir = new[] {-5,0,-5}},
                        //new {pos = new[] {73,0,11}, dir = new[] {-5,0,-5}},
                        //new {pos = new[] {71,0,21}, dir = new[] {-5,0,-5}},
                        //new {pos = new[] {62,0,35}, dir = new[] {-5,0,-5}},
                        //new {pos = new[] {9,0,38}, dir = new[] {-5,0,-5}},
                        //new {pos = new[] {-14,0,32}, dir = new[] {-5,0,-5}},
                        //new {pos = new[] {-36,0,38}, dir = new[] {-5,0,-5}},
                        //new {pos = new[] {-23,0,58}, dir = new[] {-5,0,-5}},
                        //new {pos = new[] {0,0,65}, dir = new[] {-5,0,-5}},
                        //new {pos = new[] {16,0,74}, dir = new[] {-5,0,-5}},
                        //new {pos = new[] {6,0,84}, dir = new[] {-5,0,-5}},
                        //new {pos = new[] {-40,0,84}, dir = new[] {-5,0,-5}},
                        //new {pos = new[] {-59,0,76}, dir = new[] {-5,0,-5}},
                        //new {pos = new[] {-87,0,47}, dir = new[] {-5,0,-5}},
                        //new {pos = new[] {-87,0,35}, dir = new[] {-5,0,-5}},
                        //new {pos = new[] {-68,0,6}, dir = new[] {-5,0,-5}},
                        //new {pos = new[] {-69,0,-7}, dir = new[] {-5,0,-5}},
                        //new {pos = new[] {-83,0,-48}, dir = new[] {-5,0,-5}}
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
