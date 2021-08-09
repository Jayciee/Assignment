using System;
using System.Collections.Generic;
using DataLayer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class HabitsManager
    {
        //string defaultDescription = "No one has added a countertactic for this habit yet";

        public List<Habit> GetListOfHabitsFromMonster(int monsterId)
        {
            using var db = new MonsterHunterJournalDBContext();
            var query = from h in db.Habits
                        join mh in db.MonstersHabits on h.HabitId equals mh.HabitId
                        join m in db.Monsters on mh.MonsterId equals m.MonsterId
                        where m.MonsterId == monsterId
                        select h;
            return query.ToList();    
        }

        public void CreateNewHabit(string habitName, string habitDescription)
        {
            using var db = new MonsterHunterJournalDBContext();
            Habit habit = new Habit() { HabitName = habitName, Description = habitDescription };
            db.Habits.Add(habit);
            db.SaveChanges();
        }
        public int FindHabitIdByName(string name) // Needs Unit Test
        {
            using var db = new MonsterHunterJournalDBContext();
            var query = from h in db.Habits
                        where h.HabitName==name
                        select h.HabitId;
            return query.FirstOrDefault();
        }
        public void UpdateHabitId(int idToChange, string newHabitName, string newHabitDescription) // Needs unit test
        {
            using var db = new MonsterHunterJournalDBContext();
            var query = from h in db.Habits
                        where h.HabitId == idToChange
                        select h;
            var habit = query.FirstOrDefault();
            habit.HabitName = newHabitName;
            habit.Description = newHabitDescription;
            db.SaveChanges();
        }
        public Habit GetHabitById(int id) // Needs Unit Test
        {
            using var db = new MonsterHunterJournalDBContext();
            var query = from h in db.Habits
                        where h.HabitId == id
                        select h;
            return query.FirstOrDefault();
        }
       
    }
}
