using System;
using System.Collections.Generic;

namespace CS4800ResearchProject.Objects
{
    public class Building
    {
        public Guid Id;
        public string Name;
        public List<Door> Doors;

        public Building (Guid id, string name, List<Door> doors)
        {
            Id = id;
            Name = name;
            Doors = doors;
        }
    }
}
