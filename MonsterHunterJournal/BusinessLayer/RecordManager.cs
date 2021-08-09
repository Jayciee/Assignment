using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DataLayer;

namespace BusinessLayer
{
    public partial class RecordManager
    {
        public List<Record> RetrieveAllRecords()
        {
            using var db = new MonsterHunterJournalDBContext();
            var query = from r in db.Records
                        select r;
            var queryList = new List<Record>();
            foreach (var item in query)
            {
                Debug.WriteLine(item.HunterName);
                queryList.Add(item);
            }
            return queryList;
            //return db.Records.ToList();
            
        }
        //public void SetSelectedRecord(Object selecteRecord)
        //{
        //    SelectedRecord = (Product)selectedRecord;
        //}

        public void AddNewRecord(string hunterName, decimal timeTaken, int monsterId, int weaponId, bool succeeded,decimal recordedMonsterSize = (decimal)00.00) 
        {
            using (var db = new MonsterHunterJournalDBContext())
            {
                var newRecord = new Record() { HunterName = hunterName, TimeTaken = timeTaken, RecordedMonsterSize= recordedMonsterSize , MonsterId = monsterId, WeaponId = weaponId, HuntSucceeded=succeeded};
                
                db.Records.Add(newRecord);
                db.SaveChanges();
            }
        }
        public Record GetRecordByRecordId(int recordId) // Needs Unit test
        {
            var db = new MonsterHunterJournalDBContext();
            return db.Records.Where(a => a.RecordId == recordId).FirstOrDefault();
        }

        public int GetMonsterIdFromRecordId(int recordId) // Needs Unit Test
        {
            var db = new MonsterHunterJournalDBContext();
            return db.Records.Where(a => a.RecordId == recordId).Select(a=>a.MonsterId).FirstOrDefault();
        }
        public int GetWeaponIdFromRecordId(int recordId)
        {
            var db = new MonsterHunterJournalDBContext();
            return db.Records.Where(a => a.RecordId == recordId).Select(a => a.WeaponId).FirstOrDefault();
        }
        public int GetRecordIdByNameTimeAndSize(string name, decimal time, decimal size) // Needs Unit Test
        {
            var db = new MonsterHunterJournalDBContext();
            return db.Records.Where(a => a.HunterName==name && a.TimeTaken==time && a.RecordedMonsterSize==size).Select(a=>a.RecordId).FirstOrDefault();
        }
        public List<Record> RetrieveRecordsByMonsterId(int id)
        {
            var db = new MonsterHunterJournalDBContext();
            return db.Records.Where(a => a.MonsterId == id).ToList();
        }
        public List<Record> RetrieveRecordsByMonsterIdSortedByTimeDesc(int id) // Needs unit Test
        {
            var db = new MonsterHunterJournalDBContext();
            var query = from r in db.Records
                        where r.MonsterId == id
                        orderby r.TimeTaken descending
                        select r;
            return query.ToList();
        }
        public List<Record> RetrieveRecordsByMonsterIdSortedByTimeAsc(int id) // Needs unit Test
        {
            var db = new MonsterHunterJournalDBContext();
            var query = from r in db.Records
                        where r.MonsterId == id
                        orderby r.TimeTaken ascending
                        select r;
            return query.ToList();
        }
        public List<Record> RetrieveRecordsByMonsterIdSortedBySizeDesc(int id) // Needs unit Test
        {
            var db = new MonsterHunterJournalDBContext();
            var query = from r in db.Records
                        where r.MonsterId == id
                        orderby r.RecordedMonsterSize descending
                        select r;
            return query.ToList();
        }
        public List<Record> RetrieveRecordsByMonsterIdSortedBySizeAsc(int id) // Needs unit Test
        {
            var db = new MonsterHunterJournalDBContext();
            var query = from r in db.Records
                        where r.MonsterId == id
                        orderby r.RecordedMonsterSize ascending
                        select r;
            return query.ToList();
        }
        
        public bool UpdateNewRecord(int recordId,string hunterName, decimal newTime, decimal newSize, int newMonsterId, int newWeaponId, bool newHuntSuccess)
        {
            using (var db = new MonsterHunterJournalDBContext())
            {
                var query = db.Records.Where(a => a.RecordId == recordId).FirstOrDefault();
                if (query == null)
                {
                    Debug.WriteLine($"Customer {recordId} not found");
                    return false;
                }
                query.HunterName = hunterName;
                query.TimeTaken = newTime;
                query.RecordedMonsterSize = newSize;
                query.MonsterId = newMonsterId;
                query.WeaponId = newWeaponId;
                query.HuntSucceeded = newHuntSuccess;
                
                db.SaveChanges();
            }
            return true;

        }

        public void DeleteRecord(int recordId)
        {
            using (var db = new MonsterHunterJournalDBContext())
            {
                var query = db.Records.Where(a => a.RecordId == recordId).FirstOrDefault();
                db.RemoveRange(query);
                db.SaveChanges();
            }
        }
    }
}