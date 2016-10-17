using System;
using System.Collections.Generic;
using System.Threading;
using Client.VRConnection.VRObjects;

namespace Client.VRConnection.Forms.Program
{
    public class Tunnel
    {
        public static AutoResetEvent Blocker;
        public Panel Panel { get; set; }

        private readonly VrConnection _connection;
        private readonly Random _random = new Random();
        private Node _bike, _tree, _water, _house;
        private City _city;
        private Forest _forest;
        private List<Punt> _points;
        private bool _send;
        private Skybox _skybox;
        private float _currentSpeed;
        public Tunnel(VrConnection connection, string name)
        {
            Name = name;
            Blocker = new AutoResetEvent(false);
            _connection = connection;
            Blocker.WaitOne(5000);
        }

        public string Name { get; set; }
        public void CreateScene()
        {
            _currentSpeed = 5f;
            _forest = new Forest();
            _city = new City();
            DeletePane();
            Blocker.WaitOne(5000);
            DeletePane();
            Blocker.WaitOne(5000);

            CreateTerrain();
            Blocker.WaitOne(5000);
            PaintTerrain();
            Blocker.WaitOne(5000);

            CreateBike();
            Blocker.WaitOne(5000);
            CreateRoad();
            Blocker.WaitOne(5000);
            FollowRoad();
            Blocker.WaitOne(5000);
            FollowBike();
            Blocker.WaitOne(5000);
            CreatePanel();
            Blocker.WaitOne(5000);
            FollowCamera();
        }

        public void CreateProps()
        {
            Blocker.WaitOne(5000);
            CreateWater();
            Blocker.WaitOne(5000);
            CreateForest();
            Blocker.WaitOne(5000);
            CreateCity();
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

        private void CreatePanel()
        {
            Panel = new Panel("panel", 1, 0, 1.5, -0.5, 0, 0, 0, 2, 1, 1500, 750, 1, 1, 1, 1,
                _connection.TunnelId, _connection.cameraID);
            _connection.SendMessage(Panel.ToSend);
            Blocker.WaitOne(5000);

            MakePanelId();

            Panel.SwapPanel();
            _connection.SendMessage(Panel.ToSend);
            Blocker.WaitOne(5000);
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

        private void CreateForest()
        {
            _points = _forest.getForest();

            foreach (Punt point in _points)
            {
                _tree = new Node("tree", _connection.TunnelId, "data/NetworkEngine/models/trees/fantasy/tree2.obj",
                    point.X, point.Z, point.Y, GetRandom());
                _connection.Nodes.Add(_tree);
                _connection.SendMessage(_tree.SendString);
            }
        }

        private void CreateCity()
        {
            _points = _city.getCity();

            foreach (Punt point in _points)
            {
                _house = new Node("building", _connection.TunnelId, "data/NetworkEngine/models/houses/set1/house3.obj",
                    point.X, point.Z, point.Y, 8);
                _connection.Nodes.Add(_house);
                _connection.SendMessage(_house.SendString);
            }
        }

        private void CreateWater()
        {
            _water = new Node("water", _connection.TunnelId, 20, 2, 15, true);
            _connection.Nodes.Add(_water);
            _connection.SendMessage(_water.SendString);
            Blocker.WaitOne(5000);
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
                    rotateOffset = new[] { 0, 0, 0 },
                    positionOffset = new[] { 0, 0, 0 }
                }
            }, _connection.TunnelId));
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
                    transform = new { position = new[] { 0, 50, 0 }, scale = 75.0, rotation = new[] { 0, 90, 0 } }
                }
            }, _connection.TunnelId));
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
                    transform = new { position = new[] { 0, 1, -0.5 }, scale = 0.29, rotation = new[] { -53, 0, 0 } }
                }
            }, _connection.TunnelId));
        }

        public void DrawPanel(string textValue)
        {
            int[] position = { 100, 100 };
            double sizeValue = 32;
            double[] color = { 0, 0, 0, 1 };
            string fontValue = "segoeui";
            ;
            Panel.ClearPanel();
            _connection.SendMessage(Panel.ToSend);
            Blocker.WaitOne(5000);

            Panel.DrawText(textValue, position, sizeValue, color, fontValue);
            _connection.SendMessage(Panel.ToSend);
            Blocker.WaitOne(5000);

            Panel.SwapPanel();
            _connection.SendMessage(Panel.ToSend);
            Blocker.WaitOne(5000);
        }

        public void DrawRipBackslashNPanel(string[] textValues)
        {
            int[] position = {0, 100 };
            double sizeValue = 150;
            double[] color = { 0, 0, 0, 1 };
            string fontValue = "segoeui";

            if (Panel == null) return;
            Panel.ClearPanel();
            _connection.SendMessage(Panel.ToSend);

            Panel.SetClearColor(new double[] { 1, 1, 1, 1});
            _connection.SendMessage(Panel.ToSend);
            Blocker.WaitOne(5000);

            foreach (var s in textValues)
            {
                Panel.DrawText(s, position, sizeValue, color, fontValue);
                _connection.SendMessage(Panel.ToSend);

                position[1] += 100;
                Blocker.WaitOne(5000);
            }

            Panel.SwapPanel();
            _connection.SendMessage(Panel.ToSend);

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

        private void MakePanelId()
        {
            while (Panel.Uuid == null)
            {
                Thread.Sleep(10);
                Panel.Uuid = _connection.PanelId;
            }
        }

        private void PaintTerrain()
        {
            Thread.Sleep(1000);
            Blocker.WaitOne(5000);

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

            Blocker.WaitOne(5000);

            _connection.SendMessage(
              RequestCreater.TunnelSend(new
              {
                  id = "scene/node/addlayer",
                  data = new
                  {
                      id = _connection.TerrainId,
                      normal = "data/NetworkEngine/textures/terrain/snow_grass_n.jpg",
                      diffuse = "data/NetworkEngine/textures/terrain/snow_grass_d.jpg",
                      minHeight = 17,
                      maxHeight = 32,
                      fadeDist = 1
                  }
              }, _connection.TunnelId));

            Blocker.WaitOne(5000);

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
                        fadeDist = 1
                    }
                }, _connection.TunnelId));

            Blocker.WaitOne(5000);
        }

        public void UpdateSpeed(float speed)
        {
            speed /= 5f;
            if ((int)_currentSpeed == (int)speed) return;
            float difSpeed = speed - _currentSpeed;

            for (int i = 0; i < 2; i++)
            {
                if (difSpeed < 0)
                {
                    _currentSpeed -= difSpeed / 2;
                }
                else
                {
                    _currentSpeed += difSpeed / 2;
                }

                _connection.SendMessage(RequestCreater.TunnelSend(new
                {
                    id = "route/follow/speed",
                    data = new
                    {
                        id = _bike.Uuid,
                        speed = _currentSpeed

                    }
                }, _connection.TunnelId));
                Blocker.WaitOne(5000);
            }

        }

        public void ResetScene()
        {
            _connection.SendMessage(RequestCreater.TunnelSend(new
            {
                id = "scene/pause",
                data = new
                {
                }
            }, _connection.TunnelId));
            Blocker.WaitOne(5000);

            _connection.SendMessage(RequestCreater.TunnelSend(new
            {
                id = "scene/reset",
                data = new
                {
                }
            }, _connection.TunnelId));
            Blocker.WaitOne(5000);

            _connection.SendMessage(RequestCreater.TunnelSend(new
            {
                id = "scene/skybox/update",
                data = new
                {
                    type = "static",
                    files = new
                    {
                        xpos = "data/networkengine/textures/skyboxes/interstellar/interstellar_dn.png",
                        xneg = "data/networkengine/textures/skyboxes/interstellar/interstellar_dn.png",
                        ypos = "data/networkengine/textures/skyboxes/interstellar/interstellar_dn.png",
                        yneg = "data/networkengine/textures/skyboxes/interstellar/interstellar_dn.png",
                        zpos = "data/networkengine/textures/skyboxes/interstellar/interstellar_dn.png",
                        zneg = "data/networkengine/textures/skyboxes/interstellar/interstellar_dn.png"

                    }
                }
            }, _connection.TunnelId));
            Blocker.WaitOne(5000);


        }

        private Double GetRandom()
        {
            return _random.NextDouble() * 0.6 + 1;
        }



    }
}