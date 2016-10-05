using System;
using Newtonsoft.Json;

namespace Client.VRConnection.Forms.Program
{
    static class RequestCreater
    {
        public static string TunnelSend(dynamic command, string tunnelId )
        {
            string toSend = JsonConvert.SerializeObject(new
            {
                id = "tunnel/send",
                data = new
                {
                    dest = tunnelId,
                    data = command
                }
            });

            return toSend;
        }

        public static string SceneNodeUpdate(string uuid, int x, int y, int z, int sx, int sy, int sz, int rx, int ry,
            int rz, string nameValue, int speedValue, string tunnelId)
        {
            return TunnelSend(new
            {
                id = "scene/node/update",
                data = new
                {
                    id = uuid,
                    transform = new
                    {
                        position = new [] {x,y,z},
                        scale = new [] {sx,sy,sz},
                        rotation = new [] {rx,ry,rz}
                    },
                    animation = new
                    {
                        name = nameValue,
                        speed = speedValue
                    }
                    
                }
            }, tunnelId);
        }

        public static string SceneNodeMoveTo(string uuid, int x, int y, int z, int timeValue, string tunnelId)
        {

            return RequestCreater.TunnelSend(
                new
                {
                    id = "scene/node/moveto",
                    data = new
                    {
                        id = uuid,
                        stop = "stop",
                        position = new[] { x, y, z },
                        rotate = "none",
                        interpolate = "linear",
                        followheight = false,
                        time = timeValue
                    }
                }, tunnelId);
        }

        public static string SceneNodeDelete(string uuid, string tunnelId)
        {
            return TunnelSend(new
            {
                id = "scene/node/delete",
                data = new
                {
                    id = uuid
                }
            }, tunnelId);
        }

        public static string SceneNodeFind(string name, string tunnelId)
        {
            return TunnelSend(new
            {
                id = "scene/node/find",
                data = new
                {
                    name = name
                }
            }, tunnelId);
        }

        public static string SceneNodeAddLayer(string uuid, string diffuseValue, string normalValue, int minHeightValue, int maxHeightValue,
            int fadeDistValue, string tunnelId)
        {
            Console.WriteLine("Terrain id" + uuid);

            return TunnelSend(new
                {
                    id = "scene/node/addlayer",
                    data = new
                    {
                        id = uuid,
                        diffuse = diffuseValue,
                        normal = normalValue,
                        minHeight = maxHeightValue,
                        maxHeight = maxHeightValue,
                        fadeDist = fadeDistValue
                    }
                }
                , tunnelId);
        }

        public static string GetScene(string tunnelId)
        {
            return RequestCreater.TunnelSend(new
            {
                id = "scene/get"
            }, tunnelId);
        }
        //public static string SceneNodeDelLayer()
    }
}
