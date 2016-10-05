namespace Server.TinyDB
{
    public class TinyDataBase
    {
        public TinyDataBase()
        {
            ChatSystem = new ChatSystem();
            MeasurementSystem = new MeasurementSystem();
        }

        public MeasurementSystem MeasurementSystem { get; set; }
        public ChatSystem ChatSystem { get; set; }
    }
}