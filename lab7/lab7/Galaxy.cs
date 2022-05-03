using System;
using System.Collections.Generic;

namespace lab7
{
    public partial class Galaxy
    {
        public Galaxy()
        {
            Planets = new HashSet<Planet>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Planet> Planets { get; set; }

        public Galaxy(string? name)
        {
            Name = name;
        }

        public Galaxy(int id, string? name)
        {
            Id = id;
            Name = name;
        }
    }
}
