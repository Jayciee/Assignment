using System;
using System.Collections.Generic;
using DataLayer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CounterTacticsManager
    {
        public string GetCounterTacticDescription(int weaponId, int habitId)
        {
            using var db = new MonsterHunterJournalDBContext();
            var query = db.CounterTactics.Where(a => a.WeaponTypeId == weaponId && a.HabitId == habitId).Select(a => a.Description).FirstOrDefault();
            return query == null ? "CounterTactic does not yet Exist" : query;
        }
        public void CreateNewCounterTactic(int weaponTypeId, int habitId)
        {
            using var db = new MonsterHunterJournalDBContext();
            CounterTactic counterTactic = new CounterTactic() { WeaponTypeId = weaponTypeId, HabitId = habitId };
            db.CounterTactics.Add(counterTactic);
            db.SaveChanges();
        }

        public void CreateNewCounterTactic(int weaponTypeId, int habitId, string counterTacticTestDescription)
        {
            using var db = new MonsterHunterJournalDBContext();
            CounterTactic counterTactic = new CounterTactic() { WeaponTypeId = weaponTypeId, HabitId = habitId, Description=counterTacticTestDescription };
            db.CounterTactics.Add(counterTactic);
            db.SaveChanges();
        }
    }
}
