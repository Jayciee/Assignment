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

        public void addNewRecord() 
        {
            using (var db = new MonsterHunterJournalDBContext())
            {
                
            }
        }
    }
}