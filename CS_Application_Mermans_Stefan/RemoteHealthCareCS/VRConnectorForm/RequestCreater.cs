using Newtonsoft.Json;

namespace VRConnectorForm
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

        public static dynamic AddNode(string Name, string FileName, int x, int y, int z, double ScaleValue = 0.025, double xR = 0, double yR = 0, double zR = 0)
        {
            return new
            {
                id = "scene/node/add",
                data = new
                {
                    name = Name,
                    components = new
                    {
                        transform = new
                        {
                            position = new[] {x, y, x},
                            scale = ScaleValue,
                            rotation = new[] {xR, yR, zR}
                        },
                        model = new
                        {
                            file = FileName
                        }
                    }

                }
            };


        }
    }
}
