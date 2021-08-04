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

        public void addNewRecord(string hunterName, decimal timeTaken, decimal recordedMonsterSize, int monsterId, int weaponId, bool succeeded) 
        {
            using (var db = new MonsterHunterJournalDBContext())
            {
                var newRecord = new Record() { HunterName = hunterName, TimeTaken = timeTaken, RecordedMonsterSize= recordedMonsterSize , MonsterId = monsterId, WeaponId = weaponId, HuntSucceeded=succeeded};
                
                db.Records.Add(newRecord);
                db.SaveChanges();
                
            }
        }
        public void addNewRecord(int recordID, string hunterName, decimal timeTaken, decimal recordedMonsterSize, int monsterId, int weaponId, bool succeeded)
        {
            using (var db = new MonsterHunterJournalDBContext())
            {
                var newRecord = new Record() { RecordId=recordID, HunterName = hunterName, TimeTaken = timeTaken, RecordedMonsterSize = recordedMonsterSize, MonsterId = monsterId, WeaponId = weaponId, HuntSucceeded = succeeded };

                db.Records.Add(newRecord);
                db.SaveChanges();

            }
        }
    }
}