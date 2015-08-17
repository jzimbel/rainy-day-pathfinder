using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS4800ResearchProject
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
