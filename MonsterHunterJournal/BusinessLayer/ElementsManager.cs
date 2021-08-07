using System.Collections.Generic;
using System.Linq;
using DataLayer;


namespace BusinessLayer
{
    public class ElementsManager
    {
        public List<Element> RetrieveAllElements()
        {
            using (var db = new MonsterHunterJournalDBContext())
            {
                return db.Elements.ToList();
            }
        }
        public string GetElementNameFromID(int id)
        {
            using var db = new MonsterHunterJournalDBContext();
            return db.Elements.Where(a => a.ElementId == id).Select(a => a.Name).FirstOrDefault();
        }
        public int getElementIDFromName(string name)
        {
            using var db = new MonsterHunterJournalDBContext();
            return db.Elements.Where(a => a.Name == name).Select(a => a.ElementId).FirstOrDefault();
        }
    }
}
