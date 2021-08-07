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
        public string GetMonsterNameByID(int id)
        {
            using var db = new MonsterHunterJournalDBContext();
            string stringToReturn = db.Monsters.Where(m => m.MonsterId == id).Select(m => m.Name).FirstOrDefault();
            return stringToReturn;
        }
    }
}
