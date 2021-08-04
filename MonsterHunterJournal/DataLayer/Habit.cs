using System;
using System.Collections.Generic;

#nullable disable

namespace DataLayer
{
    public partial class Habit
    {
        public Habit()
        {
            CounterTactics = new HashSet<CounterTactic>();
            MonstersHabits = new HashSet<MonstersHabit>();
        }

        public int HabitId { get; set; }
        public string HabitName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<CounterTactic> CounterTactics { get; set; }
        public virtual ICollection<MonstersHabit> MonstersHabits { get; set; }
    }
}
