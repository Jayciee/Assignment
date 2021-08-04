using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayer
{
    public partial class Ailment
    {
        public Ailment()
        {
            Monsters = new HashSet<Monster>();
            Weapons = new HashSet<Weapon>();
        }

        public int AilmentId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Monster> Monsters { get; set; }
        public virtual ICollection<Weapon> Weapons { get; set; }
    }
}
