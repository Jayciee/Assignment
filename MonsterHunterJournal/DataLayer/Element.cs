using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayer
{
    public partial class Element
    {
        public Element()
        {
            Monsters = new HashSet<Monster>();
            Weapons = new HashSet<Weapon>();
        }

        public int ElementId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Monster> Monsters { get; set; }
        public virtual ICollection<Weapon> Weapons { get; set; }
    }
}
