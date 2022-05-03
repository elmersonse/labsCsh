namespace lab7
{
    public class Query1
    {
        public string Name { get; set; }
        public int Radius { get; set; }
        public int Temperature { get; set; }
        public int Atmosphere { get; set; }
        public int Life { get; set; }
        public string SatelliteName { get; set; }
        public int SatelliteRadius { get; set; }
        public int Distance { get; set; }

        public Query1(string name, int radius, int temperature, int atmosphere, int life, string satelliteName, int satelliteRadius, int distance)
        {
            Name = name;
            Radius = radius;
            Temperature = temperature;
            Atmosphere = atmosphere;
            Life = life;
            SatelliteName = satelliteName;
            SatelliteRadius = satelliteRadius;
            Distance = distance;
        }
    }
}