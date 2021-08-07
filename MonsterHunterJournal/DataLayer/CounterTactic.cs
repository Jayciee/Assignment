using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayer
{
    public partial class CounterTactic
    {
        public int WeaponTypeId { get; set; }
        public int HabitId { get; set; }
        public string Description { get; set; }
        public string? CRTest { get; set; }
        public virtual Habit Habit { get; set; }
        public virtual WeaponType WeaponType { get; set; }
    }
}
