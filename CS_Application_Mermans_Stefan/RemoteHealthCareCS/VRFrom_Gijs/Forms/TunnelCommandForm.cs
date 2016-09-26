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
using VRFrom_Gijs.Program;
using VRFrom_Gijs.VrObjects;


namespace VRFrom_Gijs.Forms
{
    public partial class TunnelCommandForm : Form
    {
        public static AutoResetEvent blocker;
        private Connection _connection;
        public string Name { get; set; }
        private Node _bike = null;
        private Skybox _skybox = null;
        private bool _send = false;

        public TunnelCommandForm(Connection connection, string name)
        {
            InitializeComponent();
            Name = name;
            blocker = new AutoResetEvent(false);
            ;
            ;   //  Console.WriteLine(connection.TunnelID + " <- ID");
            _connection = connection;
        }

        private void createSceneButton_Click(object sender, EventArgs e)
        {
            deletePane();
            blocker.WaitOne(5000);
            deletePane();
            blocker.WaitOne(5000);

            createTerrain();
            Thread.Sleep(1000);
            paintTerrain();
            blocker.WaitOne(5000);

            createBike();
            blocker.WaitOne(5000);
            createRoad();
            blocker.WaitOne(5000);

            followRoad();
            blocker.WaitOne(5000);
            followBike();
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
                blocker.Set();
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

                        new {pos = new[] {11,-0.1,-14} , dir = new[] {5, 0, -5 }},
                        new {pos = new[] {72,-0.1,-14} , dir = new[] {5,0,5}},
                        new {pos = new[] {72,-0.1,26}, dir = new[] {-5,0,5}},
                        new {pos = new[] {11,-0.1,26}, dir = new[] {-5,0,-5}}


                     }
                }
            }, _connection.TunnelId));

            Thread.Sleep(1000);
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
                        normal = "data/NetworkEngine/textures/terrain/moss_ground_d.jpg",
                        diffuse = "data/NetworkEngine/textures/terrain/moss_ground_d.jpg",
                        minHeight = 0,
                        maxHeight = 30,
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
            blocker.Set();
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
                    transform = new { position = new[] { 0,100,0}, scale = 10.0, rotation = new[] { Math.PI / 2, 0, 0 } }

                }
            }, _connection.TunnelId));
        }

       
    }
}
