using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayer
{
    public partial class Monster
    {
        public Monster()
        {
            MonstersHabits = new HashSet<MonstersHabit>();
            Records = new HashSet<Record>();
        }

        public int MonsterId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int? ThreatLevel { get; set; }
        public int PrimaryElementId { get; set; }
        public int PrimaryAilmentId { get; set; }
        public string MonsterImage { get; set; }
        public int SizeId { get; set; }

        public virtual Ailment PrimaryAilment { get; set; }
        public virtual Element PrimaryElement { get; set; }
        public virtual Size Size { get; set; }
        public virtual ICollection<MonstersHabit> MonstersHabits { get; set; }
        public virtual ICollection<Record> Records { get; set; }
    }
}
