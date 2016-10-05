using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using VRFrom_Gijs.Forms.Program;
using VRFrom_Gijs.Program;

using VRFrom_Gijs.VrObjects;
using Panel = VRFrom_Gijs.VrObjects.Panel;


namespace VRFrom_Gijs.Forms
{
    public partial class TunnelCommandForm : Form
    {
        public static AutoResetEvent Blocker;
        private Connection _connection;
        public string Name { get; set; }
        private Node _bike = null, _tree = null, _water =null, _house = null;
        private Panel _panel;
        private Skybox _skybox = null;
        private bool _send = false;
        private Random random = new Random();
        private List<Punt> points;
        private Forest forest;
        private City city;

        public TunnelCommandForm(Connection connection, string name)
        {
            InitializeComponent();
            Name = name;
            Blocker = new AutoResetEvent(false);
            _connection = connection;
        }

        private void createSceneButton_Click(object sender, EventArgs e)
        {
            forest = new Forest();
            city = new City();
            deletePane();
            Blocker.WaitOne(5000);
            deletePane();
            Blocker.WaitOne(5000);
            

            createPanel();
            Blocker.WaitOne(5000);

            createTerrain();
            Thread.Sleep(3000);
            paintTerrain();
            Blocker.WaitOne(5000);
            createWater();
            Blocker.WaitOne(5000);
            createForest();
            Blocker.WaitOne(5000);
            createCity();
            Blocker.WaitOne(5000);

            createBike();
            Blocker.WaitOne(5000);
            createRoad();
            Blocker.WaitOne(5000);
            followRoad();
            Blocker.WaitOne(5000);
            followBike();
            Blocker.WaitOne(5000);
            followCamera();
            Blocker.WaitOne(5000);

            drawPanel("Satan is love       1337");
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if(_skybox == null)
            _skybox = new Skybox("skybox", _connection.TunnelId);
            double time = (float)SetTime.Value/4.0f;
            _connection.SendMessage(_skybox.SetTime(time));         
        }

        private void deletePane()
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

        private void createTerrain()
        {
            Terrain terrain = new Terrain(_connection.TunnelId, _connection);
            var terrainNode = new Node("Terrain node", _connection.TunnelId, -100, -0.1, -100);
            _connection.SendMessage(terrainNode.SendString);

        }

        private void createBike()
        {
            _bike = new Node("bike", _connection.TunnelId, "data/NetworkEngine/models/bike/bike_anim.fbx", 0, 0, 0, 0.025, true);
            _connection.Nodes.Add(_bike);

            _connection.SendMessage(_bike.SendString);


        }

        private void createRoad()
        {
            _connection.SendMessage(RequestCreater.TunnelSend(new
            {
                id = "route/add",
                data = new
                {
                    nodes = new[]
                   {
                        new {pos = new[] {-20,-0.1,-40} , dir = new[] {5, 0, -5 }},
                        new {pos = new[] {90,-0.1,-40} , dir = new[] {5,0,5}},
                        new {pos = new[] {75,-0.1,80}, dir = new[] {-5,0,5}},
                        new {pos = new[] {-40,-0.1,70}, dir = new[] {-5,0,-5}}
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

        private void paintTerrain()
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

        private void followRoad()
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
                    rotateOffset = new[] { 0, 0, 0 },
                    positionOffset = new[] { 0, 0, 0 },

                }
            }, _connection.TunnelId));
            Blocker.Set();
        }

        private void followBike()
        {
            _connection.SendMessage(RequestCreater.TunnelSend(new
            {
                id = "scene/node/update",
                data = new
                {
                    id = _connection.cameraID,
                    parent = _bike.Uuid,
                    transform = new { position = new[] {0,50,0}, scale = 75.0, rotation = new[] {0,90,0} }

                }
            }, _connection.TunnelId));
        }

        private void createPanel()
        {
            _panel = new Panel("panel", 1, 0, 1.5, -0.5, 0, 0, 0, 1.98, 1.08, 1920, 1080, 0, 0, 1, 0, _connection.TunnelId, _connection.cameraID);
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

        private void drawPanel(string value)
        {
            int[] position = {100, 100};
            double sizeValue = 63;
            float[] color = {1, 0, 0, 1};
            string fontValue = "Arial";

            _panel.ClearPanel();
            _connection.SendMessage(_panel.ToSend);
            Blocker.WaitOne(5000);

            _panel.DrawText(value, position, sizeValue, color, fontValue);
            _connection.SendMessage(_panel.ToSend);
            Blocker.WaitOne(5000);

            _panel.SwapPanel();
            _connection.SendMessage(_panel.ToSend);
            Blocker.WaitOne(5000);
        }

        private void createForest()
        {
            points = forest.getForest();
            foreach (Punt point in points)
            {
                Thread.Sleep(10);
                _tree = new Node("tree", _connection.TunnelId, "data/NetworkEngine/models/trees/fantasy/tree2.obj", point.X, point.Z, point.Y, random.NextDouble() * 0.6 + 1);
                _connection.Nodes.Add(_tree);

                Thread.Sleep(10);
                _connection.SendMessage(_tree.SendString);
            }
        }

        private void createCity()
        {
            points = city.getCity();
            foreach (Punt point in points)
            {
                Thread.Sleep(10);
                _house = new Node("building", _connection.TunnelId, "data/NetworkEngine/models/houses/set1/house3.obj", point.X, point.Z, point.Y, 8);
                _connection.Nodes.Add(_house);

                Thread.Sleep(10);
                _connection.SendMessage(_house.SendString);
            }
        }

        private void createWater()
        {
            Thread.Sleep(10);
            _water = new Node("water", _connection.TunnelId, 50, 2, 15, true);
            _connection.Nodes.Add(_water);

            Thread.Sleep(10);
            _connection.SendMessage(_water.SendString);
        }

        private void followCamera()
        {
            _connection.SendMessage(RequestCreater.TunnelSend(new
            {
                id = "scene/node/update",
                data = new
                {
                    id = _connection.PanelId,
                    parent = _connection.cameraID,
                    transform = new { position = new[] { 0, 1, -0.5 }, scale = 0.29, rotation = new[] { -53, 0, 0 } }

                }
            }, _connection.TunnelId));
        }
    }
}
