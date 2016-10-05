using Client.VRConnection.Forms.Program;

namespace Client.VRConnection.VRObjects
{
    internal class Scene
    {
        public Scene(string name, string tunnelId, string filename)
        {
            Name = name;
            TunnelId = tunnelId;
            Filename = filename;
        }

        public string Name { get; set; }
        public string TunnelId { get; set; }
        public string Filename { get; set; }

        public dynamic GetScene()
        {
            return RequestCreater.TunnelSend(new
            {
                id = "scene/get"
            }, TunnelId);
        }

        public dynamic SaveScene(string filename, bool overwrite = true)
        {
            return RequestCreater.TunnelSend(new
            {
                id = "scene/save",
                data = new
                {
                    filename,
                    overwrite
                }
            }, TunnelId);
        }

        public dynamic LoadScene(string filename)
        {
            return RequestCreater.TunnelSend(new
            {
                id = "scene/load",
                data = new
                {
                    filename
                }
            }, TunnelId);
        }

        public dynamic RaycastScene(int[] start, int[] direction, bool physics)
        {
            return RequestCreater.TunnelSend(new
            {
                id = "scene/raycast",
                data = new
                {
                    start,
                    direction,
                    physics
                }
            }, TunnelId);
        }
    }
}