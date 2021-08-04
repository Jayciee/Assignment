using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayer
{
    public partial class Record
    {
        public int RecordId { get; set; }
        public string HunterName { get; set; }
        public decimal? TimeTaken { get; set; }
        public decimal? RecordedMonsterSize { get; set; }
        public int MonsterId { get; set; }
        public int WeaponId { get; set; }
        public bool HuntSucceeded { get; set; }

        public virtual Monster Monster { get; set; }
        public virtual Weapon Weapon { get; set; }
    }
}
