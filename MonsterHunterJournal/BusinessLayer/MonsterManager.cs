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
    }
}
