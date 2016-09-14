namespace VRConnectorForm.TunnelJson
{
    public class Data3
    {
    }

    public class Data2
    {
        public string id { get; set; }
        public Data3 data { get; set; }
    }

    public class Data
    {
        public string dest { get; set; }
        public Data2 data { get; set; }
    }

    public class RootObject
    {
        public string id { get; set; }
        public Data data { get; set; }
    }
}
