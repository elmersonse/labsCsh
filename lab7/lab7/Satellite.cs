using System;
using System.Collections.Generic;

namespace lab7
{
    public partial class Satellite
    {
        public int Id { get; set; }
        public int? PlanetId { get; set; }
        public string? Name { get; set; }
        public int? Radius { get; set; }
        public int? Distance { get; set; }

        public virtual Planet? Planet { get; set; }

        public Satellite(int? planetId, string? name, int? radius, int? distance)
        {
            PlanetId = planetId;
            Name = name;
            Radius = radius;
            Distance = distance;
        }

        public Satellite(int id, int? planetId, string? name, int? radius, int? distance)
        {
            Id = id;
            PlanetId = planetId;
            Name = name;
            Radius = radius;
            Distance = distance;
        }
    }
}
