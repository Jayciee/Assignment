using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;

namespace BusinessLayer
{
    public partial class RecordManager
    {
        public List<Record> RetrieveAllRecords()
        {
            using (var db = new MonsterHunterJournalDBContext())
            {
                return db.Records.ToList();
            }
        }

        public void AddNewRecord(string hunterName, decimal timeTaken, int monsterId, int weaponId, bool succeeded,decimal recordedMonsterSize = (decimal)00.00) 
        {
            using (var db = new MonsterHunterJournalDBContext())
            {
                var newRecord = new Record() { HunterName = hunterName, TimeTaken = timeTaken, RecordedMonsterSize= recordedMonsterSize , MonsterId = monsterId, WeaponId = weaponId, HuntSucceeded=succeeded};
                
                db.Records.Add(newRecord);
                db.SaveChanges();
            }
        }

        public List<Record> RetrieveRecordsFromByMonsterId(int id)
        {
            var db = new MonsterHunterJournalDBContext();
            return db.Records.Where(a => a.MonsterId == id).ToList();
        }

    }
}