using System.Collections.Generic;
using System.Linq;
using DataLayer;

namespace BusinessLayer
{
    public partial class MonsterManager
    {
        public List<Monster> RetrieveAllMonsters()
        {
            using (var db = new MonsterHunterJournalDBContext())
            {
                return db.Monsters.ToList();
            }
        }
        public int GetMonsterIDByName(string monsterName)
        {
            using var db = new MonsterHunterJournalDBContext();
            int idToReturn = db.Monsters.Where(m => m.Name == monsterName).Select(m=>m.MonsterId).FirstOrDefault();
            return idToReturn;
        }
    }
}
