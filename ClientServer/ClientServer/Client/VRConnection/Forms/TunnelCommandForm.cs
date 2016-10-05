using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Client.VRConnection.Forms.Program;
using Client.VRConnection.VRObjects;
using Panel = Client.VRConnection.VRObjects.Panel;

namespace Client.VRConnection.Forms
{
    public partial class TunnelCommandForm : Form
    {
        public static AutoResetEvent Blocker;
        private readonly VrConnection _connection;
        private readonly Random _random = new Random();
        private Node _bike, _tree, _water, _house;
        private City _city;
        private Forest _forest;
        private Panel _panel;
        private List<Punt> _points;
        private bool _send;
        private Skybox _skybox;

        public TunnelCommandForm(VrConnection connection, string name)
        {
            InitializeComponent();
            Name = name;
            Blocker = new AutoResetEvent(false);
            ;
            ;   //  Console.WriteLine(connection.TunnelID + " <- ID");
            _connection = connection;
        }

        public string Name { get; set; }

        private void createSceneButton_Click(object sender, EventArgs e)
        {
            _forest = new Forest();
            _city = new City();
            DeletePane();
            Blocker.WaitOne(5000);
            DeletePane();
            Blocker.WaitOne(5000);

            CreatePanel();
            Blocker.WaitOne(5000);
            DrawPanel("Satan is love");
            Blocker.WaitOne(5000);

            CreateTerrain();
            Thread.Sleep(3000);
            PaintTerrain();
            Blocker.WaitOne(5000);
            CreateWater();
            Blocker.WaitOne(5000);
            CreateForest();
            Blocker.WaitOne(5000);
            CreateCity();
            Blocker.WaitOne(5000);

            CreateBike();
            Blocker.WaitOne(5000);
            CreateRoad();
            Blocker.WaitOne(5000);
            FollowRoad();
            Blocker.WaitOne(5000);
            FollowBike();
            Blocker.WaitOne(5000);
            FollowCamera();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (_skybox == null)
                _skybox = new Skybox("skybox", _connection.TunnelId);
            double time = SetTime.Value/4.0f;
            _connection.SendMessage(_skybox.SetTime(time));
        }

        private void DeletePane()
        {
            
            if (!_send)
            {
                _send = true;
                _connection.SendMessage(RequestCreater.GetScene(_connection.TunnelId));
            }
            else
            {
                _connection.SendMessage(RequestCreater.SceneNodeDelete(_connection.GroundPlanId, _connection.TunnelId));
                Blocker.Set();
            }
        }

        private void CreateTerrain()
        {
            var terrain = new Terrain(_connection.TunnelId, _connection);
            var terrainNode = new Node("Terrain node", _connection.TunnelId, -100, -0.1, -100);
            _connection.SendMessage(terrainNode.SendString);
        }

        private void CreateBike()
        {
            _bike = new Node("bike", _connection.TunnelId, "data/NetworkEngine/models/bike/bike_anim.fbx", 0, 0, 0,
                0.025, true);
            _connection.Nodes.Add(_bike);

            _connection.SendMessage(_bike.SendString);
        }

        private void CreateRoad()
        {
            _connection.SendMessage(RequestCreater.TunnelSend(new
            {
                id = "route/add",
                data = new
                {
                    nodes = new[]
                    {
                        new {pos = new[] {-20, -0.1, -40}, dir = new[] {5, 0, -5}},
                        new {pos = new[] {90, -0.1, -40}, dir = new[] {5, 0, 5}},
                        new {pos = new[] {75, -0.1, 80}, dir = new[] {-5, 0, 5}},
                        new {pos = new[] {-40, -0.1, 70}, dir = new[] {-5, 0, -5}}
                    }
                }
            }, _connection.TunnelId));

            Thread.Sleep(1500);

            _connection.SendMessage(RequestCreater.TunnelSend(new
            {
                id = "scene/road/add",
                data = new
                {
                    route = _connection.RouteId
                }
            }, _connection.TunnelId));
        }

        private void PaintTerrain()
        {
            _connection.SendMessage(
                RequestCreater.TunnelSend(new
                {
                    id = "scene/node/addlayer",
                    data = new
                    {
                        id = _connection.TerrainId,
                        normal = "data/NetworkEngine/textures/terrain/mntn_green_n.jpg",
                        diffuse = "data/NetworkEngine/textures/terrain/mntn_green_d.jpg",
                        minHeight = 16,
                        maxHeight = 30,
                        fadeDist = 0
                    }
                }, _connection.TunnelId));

            _connection.SendMessage(
                RequestCreater.TunnelSend(new
                {
                    id = "scene/node/addlayer",
                    data = new
                    {
                        id = _connection.TerrainId,
                        normal = "data/NetworkEngine/textures/terrain/grass_green_n.jpg",
                        diffuse = "data/NetworkEngine/textures/terrain/grass_green_d.jpg",
                        minHeight = 2,
                        maxHeight = 16,
                        fadeDist = 0
                    }
                }, _connection.TunnelId));

            _connection.SendMessage(
                RequestCreater.TunnelSend(new
                {
                    id = "scene/node/addlayer",
                    data = new
                    {
                        id = _connection.TerrainId,
                        normal = "data/NetworkEngine/textures/terrain/ground_dry2_n.jpg",
                        diffuse = "data/NetworkEngine/textures/terrain/ground_dry2_d.jpg",
                        minHeight = 0,
                        maxHeight = 1,
                        fadeDist = 1
                    }
                }, _connection.TunnelId));
        }

        private void FollowRoad()
        {
            _connection.SendMessage(RequestCreater.TunnelSend(new
            {
                id = "route/follow",
                data = new
                {
                    route = _connection.RouteId,
                    node = _bike.Uuid,
                    speed = 5.0,
                    offset = 0.0,
                    rotate = "XZ",
                    followHeight = true,
                    rotateOffset = new[] {0, 0, 0},
                    positionOffset = new[] {0, 0, 0}
                }
            }, _connection.TunnelId));
            Blocker.Set();
        }

        private void FollowBike()
        {
            _connection.SendMessage(RequestCreater.TunnelSend(new
            {
                id = "scene/node/update",
                data = new
                {
                    id = _connection.cameraID,
                    parent = _bike.Uuid,
                    transform = new {position = new[] {0, 50, 0}, scale = 75.0, rotation = new[] {0, 90, 0}}
                }
            }, _connection.TunnelId));
        }

        private void CreatePanel()
        {
            _panel = new Panel("panel", 1, 0, 1.5, -0.5, 0, 0, 0, 2, 1, 2000, 1000, 0, 0, 0, 0,
                _connection.TunnelId, _connection.cameraID);
            _connection.SendMessage(_panel.ToSend);
            Blocker.WaitOne(5000);

            MakePanelId();

            _panel.SwapPanel();
            _connection.SendMessage(_panel.ToSend);
            Blocker.WaitOne(5000);
       }

        private void MakePanelId()
        {
            if (_panel.Uuid == null)
            {
                Thread.Sleep(10);
                _panel.Uuid = _connection.PanelId;

                MakePanelId();
            }
        }

        private void DrawPanel(string textValue)
        {
            int[] position = {100, 100};
            double sizeValue = 32;
            double[] color = {0, 0, 0, 1};
            string fontValue = "segoeui";

            _panel.ClearPanel();
            _connection.SendMessage(_panel.ToSend);
            Blocker.WaitOne(5000);

            _panel.DrawText(textValue, position, sizeValue, color, fontValue);
            _connection.SendMessage(_panel.ToSend);
            Blocker.WaitOne(5000);

            _panel.SwapPanel();
            _connection.SendMessage(_panel.ToSend);
            Blocker.WaitOne(5000);
        }
    
        private void CreateForest()
        {
            _points = _forest.getForest();

            foreach (Punt point in _points)
            {
                Thread.Sleep(10);
                _tree = new Node("tree", _connection.TunnelId, "data/NetworkEngine/models/trees/fantasy/tree2.obj",
                    point.X, point.Z, point.Y, GetRandom());
                _connection.Nodes.Add(_tree);

                Thread.Sleep(10);
                _connection.SendMessage(_tree.SendString);
            }
        }

        private void CreateCity()
        {
            _points = _city.getCity();

            foreach (Punt point in _points)
            {
                Thread.Sleep(10);
                _house = new Node("building", _connection.TunnelId, "data/NetworkEngine/models/houses/set1/house3.obj",
                    point.X, point.Z, point.Y, 8);
                _connection.Nodes.Add(_house);

                Thread.Sleep(10);
                _connection.SendMessage(_house.SendString);
            }
        }

        private Double GetRandom()
        {
            return _random.NextDouble()*0.6 + 1;
        }

        private void CreateWater()
        {
            Thread.Sleep(10);
            _water = new Node("water", _connection.TunnelId, 50, 2, 15, true);
            _connection.Nodes.Add(_water);

            Thread.Sleep(10);
            _connection.SendMessage(_water.SendString);
        }

        private void FollowCamera()
        {
            _connection.SendMessage(RequestCreater.TunnelSend(new
            {
                id = "scene/node/update",
                data = new
                {
                    id = _connection.PanelId,
                    parent = _connection.cameraID,
                    transform = new {position = new[] {0, 1, -0.5}, scale = 0.29, rotation = new[] {-53, 0, 0}}
                }
            }, _connection.TunnelId));
        }
    }
}