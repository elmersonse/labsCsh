namespace lab7
{
    public class Query4
    {
        public string Name { get; set; }
        public string GalaxyName { get; set; }
        public int Radius { get; set; }
        public int Temperature { get; set; }
        public int Atmosphere { get; set; }
        public int Life { get; set; }
        public int Count { get; set; }

        public Query4(string name, string galaxyName, int radius, int temperature, int atmosphere, int life, int count)
        {
            Name = name;
            GalaxyName = galaxyName;
            Radius = radius;
            Temperature = temperature;
            Atmosphere = atmosphere;
            Life = life;
            Count = count;
        }
    }
}