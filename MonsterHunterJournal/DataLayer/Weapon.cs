using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayer
{
    public partial class Weapon
    {
        public Weapon()
        {
            Records = new HashSet<Record>();
        }

        public int WeaponId { get; set; }
        public string Name { get; set; }
        public int? WeaponTypeId { get; set; }
        public int? Rarity { get; set; }
        public int? ElementId { get; set; }
        public int? AilmentId { get; set; }

        public virtual Ailment Ailment { get; set; }
        public virtual Element Element { get; set; }
        public virtual WeaponType WeaponType { get; set; }
        public virtual ICollection<Record> Records { get; set; }
    }
}
