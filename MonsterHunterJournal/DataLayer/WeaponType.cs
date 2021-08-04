using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayer
{
    public partial class WeaponType
    {
        public WeaponType()
        {
            CounterTactics = new HashSet<CounterTactic>();
            Weapons = new HashSet<Weapon>();
        }

        public int WeaponTypeId { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<CounterTactic> CounterTactics { get; set; }
        public virtual ICollection<Weapon> Weapons { get; set; }
    }
}
