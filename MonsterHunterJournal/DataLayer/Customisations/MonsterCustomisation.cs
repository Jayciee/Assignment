using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public partial class Monster
    {
        
            
        public override string ToString()
        {
            return $"{Name} of type {Type} of element {GetElementName(PrimaryElementId)}";
        }
        private string GetElementName(int elementIDToSearch)
        {
            using var db = new MonsterHunterJournalDBContext();
            string name = db.Elements.Where(e => e.ElementId == elementIDToSearch).Select(e => e.Name).FirstOrDefault().ToString();
            return name;
        }
        private string GetAilmentName(int ailmentIDToSearch)
        {
            using var db = new MonsterHunterJournalDBContext();
            string name = db.Elements.Where(e => e.ElementId == ailmentIDToSearch).Select(e => e.Name).FirstOrDefault().ToString();
            return name;
        }
    }
}
