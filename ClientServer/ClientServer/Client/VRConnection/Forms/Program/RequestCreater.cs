using System;
using Newtonsoft.Json;

namespace Client.VRConnection.Forms.Program
{
    internal static class RequestCreater
    {
        public static dynamic TunnelSend(dynamic command, string tunnelId)
        {
            var toSend = JsonConvert.SerializeObject(new
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

        public static dynamic SceneNodeUpdate(string uuid, int x, int y, int z, int sx, int sy, int sz, int rx, int ry,
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
                        position = new[] {x, y, z},
                        scale = new[] {sx, sy, sz},
                        rotation = new[] {rx, ry, rz}
                    },
                    animation = new
                    {
                        name = nameValue,
                        speed = speedValue
                    }
                }
            }, tunnelId);
        }

        public static dynamic SceneNodeMoveTo(string uuid, int x, int y, int z, int timeValue, string tunnelId)
        {
            return TunnelSend(
                new
                {
                    id = "scene/node/moveto",
                    data = new
                    {
                        id = uuid,
                        stop = "stop",
                        position = new[] {x, y, z},
                        rotate = "none",
                        interpolate = "linear",
                        followheight = false,
                        time = timeValue
                    }
                }, tunnelId);
        }

        public static dynamic SceneNodeDelete(string uuid, string tunnelId)
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

        public static dynamic SceneNodeFind(string name, string tunnelId)
        {
            return TunnelSend(new
            {
                id = "scene/node/find",
                data = new
                {
                    name
                }
            }, tunnelId);
        }

        public static dynamic SceneNodeAddLayer(string uuid, string diffuseValue, string normalValue, int minHeightValue,
            int maxHeightValue,
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

        public static dynamic GetScene(string tunnelId)
        {
            return TunnelSend(new
            {
                id = "scene/get"
            }, tunnelId);
        }

        //public static string SceneNodeDelLayer()
    }
}