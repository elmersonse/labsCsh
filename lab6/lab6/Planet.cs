namespace lab6
{
    public class Planet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GalaxyId { get; set; }
        public int Radius { get; set; }
        public int CoreTemperature { get; set; }
        public int Atmosphere { get; set; }
        public int Life { get; set; }

        public Planet()
        {
        }

        public Planet(int id, string name, int galaxyId, int radius, int coreTemperature, int atmosphere, int life)
        {
            Id = id;
            Name = name;
            GalaxyId = galaxyId;
            Radius = radius;
            CoreTemperature = coreTemperature;
            Atmosphere = atmosphere;
            Life = life;
        }
    }
}
