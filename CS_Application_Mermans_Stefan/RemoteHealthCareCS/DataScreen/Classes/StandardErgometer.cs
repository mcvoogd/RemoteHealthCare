namespace DataScreen.Classes
{
    interface IStandardErgometer
    {
        int Pulse { get; set; }
        int Rotations { get; set; }
        int Speed { get; set; }
        int Power { get; set; }
        int Burned { get; set; }
        int Time { get; set; }
        int Reachedpower { get; set; }
        int Distance { get; set; }

        void Connect();
        void Disconnect();
    }
}
