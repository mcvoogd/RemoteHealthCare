﻿using System;
using Client.VRConnection.Forms.Program;

namespace Client.VRConnection.VRObjects
{
    public class Node
    {
        public readonly string SendString;
        public readonly string TunnelId;

        public Node(string naam, string tunnelId, string filename, int x, int y, int z, double scale)
        {
            Naam = naam;
            TunnelId = tunnelId;
            SendString = AddModelNode(tunnelId, Naam, filename, x, y, z, scale);
        }

        public Node(string naam, string tunnelId, string filename, int x, int y, int z, double scale, bool hasAnimation)
        {
            Naam = naam;
            TunnelId = tunnelId;
            SendString = AddMovingModelNode(tunnelId, Naam, filename, x, y, z, scale, 0, 0, 0, hasAnimation);
        }

        public Node(string name, string tunnelId, double x, double y, double z)
        {
            Naam = name;
            TunnelId = tunnelId;
            SendString = AddTerrainNode(TunnelId, "Terrain node", x, y, z);
        }

        public Node(string name, string tunnelId, double x, double y, double z, bool hasWater)
        {
            if (hasWater)
            {
                Console.WriteLine("Creating Water Node");
                Naam = name;
                TunnelId = tunnelId;
                SendString = WaterNode(TunnelId, "Water node", x, y, z);
            }
            else
            {
                new Node(name, tunnelId, x, y, z);
            }
        }

        public string Naam { get; set; }
        public string Uuid { get; set; }

        private dynamic AddModelNode(string tunnelId, string name, string fileName, int x, int y, int z,
            double scaleValue = 1, double xR = 0, double yR = 0, double zR = 0)
        {
            return RequestCreater.TunnelSend(new
            {
                id = "scene/node/add",
                data = new
                {
                    name,
                    components = new
                    {
                        transform = new
                        {
                            position = new[] {x, y, z},
                            scale = scaleValue,
                            rotation = new[] {xR, yR, zR}
                        },
                        model = new
                        {
                            file = fileName
                        }
                    }
                }
            }, tunnelId);
        }

        private dynamic AddMovingModelNode(string tunnelId, string name, string fileName, int x, int y, int z,
            double scaleValue, double xR, double yR, double zR, bool hasAnimation)
        {
            return RequestCreater.TunnelSend(new
            {
                id = "scene/node/add",
                data = new
                {
                    name,
                    components = new
                    {
                        transform = new
                        {
                            position = new[] {x, y, z},
                            scale = scaleValue,
                            rotation = new[] {xR, yR, zR}
                        },
                        model = new
                        {
                            file = fileName,
                            animated = hasAnimation,
                            animation = "Armature|Fietsen"
                        }
                    }
                }
            }, tunnelId);
        }

        private dynamic AddTerrainNode(string tunnelId, string Name, double x, double y, double z, double scaleValue = 1,
            double xR = 0, double yR = 0, double zR = 0)
        {
            return RequestCreater.TunnelSend(new
            {
                id = "scene/node/add",
                data = new
                {
                    name = Name,
                    components = new
                    {
                        transform = new
                        {
                            position = new[] {x, y, z},
                            scale = scaleValue,
                            rotation = new[] {xR, yR, zR}
                        },
                        terrain = new
                        {
//                           smoothnormals = true
                        }
                    }
                }
            }, TunnelId);
        }

        public string MoveNode(int x, int y, int z, int timeValue)
        {
            if (Uuid == null)
            {
                string temp;
                VrConnection.VRobjecten.TryGetValue(Naam, out temp);
                Uuid = temp;
            }
            return RequestCreater.TunnelSend(
                new
                {
                    id = "scene/node/moveto",
                    data = new
                    {
                        id = Uuid,
                        position = new[] {x, y, z},
                        rotate = "none",
                        interpolate = "linear",
                        followheight = true,
                        time = timeValue
                    }
                }, TunnelId);
        }

        public string WaterNode(string tunnelId, string Name, double x, double y, double z, double scaleValue = 1,
            double xR = 0, double yR = 0, double zR = 0)
        {
            return RequestCreater.TunnelSend(new
            {
                id = "scene/node/add",
                data = new
                {
                    name = Name,
                    components = new
                    {
                        transform = new
                        {
                            position = new[] {x, y, z},
                            scale = scaleValue,
                            rotation = new[] {xR, yR, zR}
                        },
                        water = new
                        {
                            size = new[] {80, 107},
                            resolution = 0.1
                        }
                    }
                }
            }, TunnelId);
        }
    }
}