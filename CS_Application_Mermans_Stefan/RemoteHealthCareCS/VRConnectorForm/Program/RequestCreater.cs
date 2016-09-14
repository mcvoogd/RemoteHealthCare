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
    }
}
