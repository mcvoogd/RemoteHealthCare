using Newtonsoft.Json;

namespace VRConnectorForm.Program
{
    static class RequestCreater
    {
        public static string TunnelSend(dynamic Command, string tunnelID )
        {
            string toSend = JsonConvert.SerializeObject(new
            {
                id = "tunnel/send",
                data = new
                {
                    dest = tunnelID,
                    data = Command
                }
            });

            return toSend;
        }

        public static string SceneNodeUpdate(string Uuid, int x, int y, int z, int sx, int sy, int sz, int rx, int ry,
            int rz, string nameValue, int speedValue, string tunnelID)
        {
            return TunnelSend(new
            {
                id = "scene/node/update",
                data = new
                {
                    id = Uuid,
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
            }, tunnelID);
        }

        public static string SceneNodeMoveTo(string Uuid, int x, int y, int z, int timeValue, string tunnelID)
        {

            return RequestCreater.TunnelSend(
                new
                {
                    id = "scene/node/moveto",
                    data = new
                    {
                        id = Uuid,
                        stop = "stop",
                        position = new[] { x, y, z },
                        rotate = "none",
                        interpolate = "linear",
                        followheight = false,
                        time = timeValue
                    }
                }, tunnelID);
        }

        public static string SceneNodeDelete(string Uuid, string tunnelID)
        {
            return TunnelSend(new
            {
                id = "scene/node/delete",
                data = new
                {
                    id = Uuid
                }
            }, tunnelID);
        }

        public static string SceneNodeFind(string name, string tunnelID)
        {
            return TunnelSend(new
            {
                id = "scene/node/find",
                data = new
                {
                    name = name
                }
            }, tunnelID);
        }

        public static string SceneNodeAddLayer(string uuid, string diffuseValue, string normalValue, int minHeightValue, int maxHeightValue,
            int fadeDistValue, string tunnelID)
        {
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
                , tunnelID);
        }

        //public static string SceneNodeDelLayer()
    }
}
