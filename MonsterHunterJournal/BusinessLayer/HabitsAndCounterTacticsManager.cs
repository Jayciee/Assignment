using System;
using System.Collections.Generic;
using DataLayer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class HabitsAndCounterTacticsManager
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

        public string GetCounterTactic(int weaponId, int habitId)
        {
            using var db = new MonsterHunterJournalDBContext();
            return db.CounterTactics.Where(a => a.WeaponTypeId == weaponId && a.HabitId == habitId).Select(a => a.Description).FirstOrDefault();

            
        }
    }
}
