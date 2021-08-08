using System;
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
        
        public string GetMonsterDescriptionByID(int id) // Needs unit tests
        {
            using var db = new MonsterHunterJournalDBContext();
            string stringToReturn = db.Monsters.Where(m => m.MonsterId == id).Select(m => m.Description).FirstOrDefault();
            return stringToReturn;
        }
        public string GetMonsterTypeByID(int id) // Needs unit tests
        {
            using var db = new MonsterHunterJournalDBContext();
            string stringToReturn = db.Monsters.Where(m => m.MonsterId == id).Select(m => m.Type).FirstOrDefault();
            return stringToReturn;
        }
        public int GetMonsterElementByID(int id) // Needs unit tests
        {
            using var db = new MonsterHunterJournalDBContext();
            int element = db.Monsters.Where(m => m.MonsterId == id).Select(m => m.PrimaryElementId).FirstOrDefault();
            return element;
        }
        public int GetMonsterAilmentByID(int id) // Needs unit tests
        {
            using var db = new MonsterHunterJournalDBContext();
            int ailment= db.Monsters.Where(m => m.MonsterId == id).Select(m => m.PrimaryAilmentId).FirstOrDefault();
            return ailment;
        }
        public void CreateNewMonsters(string testMonsterName, string description, string type, int threatLevel, int primaryElementId, int primaryAilmentId, int sizeID)
        {
            using var db = new MonsterHunterJournalDBContext();
            Monster monster = new Monster() { Name = testMonsterName
                , Description = description
                , Type = type
                , ThreatLevel = threatLevel
                , PrimaryElementId = primaryElementId
                , PrimaryAilmentId = primaryAilmentId
                , SizeId = sizeID };
            db.Monsters.Add(monster);
            db.SaveChanges();
        }
    }
}
