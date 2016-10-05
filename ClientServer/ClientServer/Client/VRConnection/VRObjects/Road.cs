using Client.VRConnection.Forms.Program;

namespace Client.VRConnection.VRObjects
{
    internal class Road
    {
        public Road(string name, string tunnelId)
        {
            Name = name;
            TunnelId = tunnelId;
        }

        public string Name { get; set; }
        public string TunnelId { get; set; }

        public dynamic Add(string uuid)
        {
            return RequestCreater.TunnelSend(new
            {
                id = "scene/road/add",
                data = new
                {
                    route = uuid
                }
            }, TunnelId);
        }

        public dynamic Delete()
        {
            return RequestCreater.TunnelSend(new
            {
                id = "scene/road/delete"
            }, TunnelId);
        }
    }
}