using System;
using System.Collections.Generic;

namespace lab7
{
    public partial class Planet
    {
        public Planet()
        {
            Satellites = new HashSet<Satellite>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? GalaxyId { get; set; }
        public int? Radius { get; set; }
        public int? CoreTemperature { get; set; }
        public int? Atmosphere { get; set; }
        public int? Life { get; set; }

        public virtual Galaxy? Galaxy { get; set; }
        public virtual ICollection<Satellite> Satellites { get; set; }

        public Planet(string? name, int? galaxyId, int? radius, int? coreTemperature, int? atmosphere, int? life)
        {
            Name = name;
            GalaxyId = galaxyId;
            Radius = radius;
            CoreTemperature = coreTemperature;
            Atmosphere = atmosphere;
            Life = life;
        }

        public Planet(int id, string? name, int? galaxyId, int? radius, int? coreTemperature, int? atmosphere, int? life)
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
