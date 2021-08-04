using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayer
{
    public partial class MonstersHabit
    {
        public int MonsterId { get; set; }
        public int HabitId { get; set; }

        public virtual Habit Habit { get; set; }
        public virtual Monster Monster { get; set; }
    }
}
