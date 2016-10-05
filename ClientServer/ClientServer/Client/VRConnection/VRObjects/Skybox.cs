using Client.VRConnection.Forms.Program;

namespace Client.VRConnection.VRObjects
{
    internal class Skybox
    {
        public Skybox(string name, string tunnelId)
        {
            Name = name;
            TunnelId = tunnelId;
        }

        public string Name { get; set; }
        public string TunnelId { get; set; }

        public string SetTime(double time)
        {
            return RequestCreater.TunnelSend(new
            {
                id = "scene/skybox/settime",
                data = new
                {
                    time
                }
            }, TunnelId);
        }

        public string Update()
        {
            return RequestCreater.TunnelSend(new
            {
                id = "scene/skybox/update"
            }, TunnelId);
        }
    }
}