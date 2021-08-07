using System.Collections.Generic;
using System.Linq;
using DataLayer;

namespace BusinessLayer
{
    public class AilmentManager
    {
        public List<Ailment> RetrieveAllAilments()
        {
            using (var db = new MonsterHunterJournalDBContext())
            {
                return db.Ailments.ToList();
            }
        }
        public string GetAilmentNameFromID(int id)
        {
            using var db = new MonsterHunterJournalDBContext();
            return db.Ailments.Where(a => a.AilmentId == id).Select(a=> a.Name).FirstOrDefault();
        }
        public int getAilmentIDFromName(string name)
        {
            using var db = new MonsterHunterJournalDBContext();
            return db.Ailments.Where(a => a.Name == name).Select(a => a.AilmentId).FirstOrDefault();
        }
    }
}
