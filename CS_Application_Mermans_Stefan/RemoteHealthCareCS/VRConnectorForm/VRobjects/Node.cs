﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VRConnectorForm.Program;

namespace VRConnectorForm.VRobjects
{
    public class Node
    {
        public string Naam { get; set; }
        public string Uuid { get; set; } = null;
        public readonly string SendString;
        public readonly string TunnelId;

        public Node(string naam, string tunnelId, string filename, int x, int y, int z, double scale)
        {
            this.Naam = naam;
            this.TunnelId = tunnelId;
            SendString = AddModelNode(tunnelId, Naam, filename, x, y, z, scale);
        }

        public Node(string name, string tunnelId, double x, double y, double z)
        {
            Naam = name;
            TunnelId = tunnelId;
            SendString = AddTerrainNode(TunnelId, "Terrain node", x, y, z);
        }

        private dynamic AddModelNode(string tunnelId, string name, string fileName, int x, int y, int z, double scaleValue = 1, double xR = 0, double yR = 0, double zR = 0)
        {
            return RequestCreater.TunnelSend(new
            {
                id = "scene/node/add",
                data = new
                {
                    name = name,
                    components = new
                    {
                        transform = new
                        {
                            position = new[] { x, y, z },
                            scale = scaleValue,
                            rotation = new[] { xR, yR, zR }
                        },
                        model = new
                        {
                            file = fileName
                        }
                    }

                }
            }, tunnelId);
        }

        private dynamic AddTerrainNode(string tunnelId, string Name, double x, double y, double z, double scaleValue = 1, double xR = 0, double yR = 0, double zR = 0)
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
                            position = new[] { x, y, z },
                            scale = scaleValue,
                            rotation = new[] { xR, yR, zR }
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
                Connection.VRobjecten.TryGetValue(Naam, out temp);
                Uuid = temp;
            }            
            return RequestCreater.TunnelSend(
                new
                {
                    id = "scene/node/moveto",
                    data = new
                    {
                        id = Uuid,                      
                        position = new []{x,y,z},
                        rotate = "none",
                        interpolate = "linear",
                        followheight = false,
                        time = timeValue
                    }
                }, TunnelId);
        }


    }
}
