using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;
namespace BusinessLayer
{
    public class SizeManager
    {

        public List<Size> RetrieveListOfSizes()
        {
            using var db = new MonsterHunterJournalDBContext();
            return db.Sizes.ToList();
        }

        public bool CheckInRange(int sizeId, decimal recSize)
        {
            using var db = new MonsterHunterJournalDBContext();
            var query = db.Sizes.Where(a => a.SizeId == sizeId).FirstOrDefault();
            if (recSize>=query.SizeFloor && recSize<= query.SizeCeiling)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public decimal GetSizeFloorFromID(int sizeId)
        {
            using var db = new MonsterHunterJournalDBContext();
            return db.Sizes.Where(a => a.SizeId == sizeId).Select(a => a.SizeFloor).FirstOrDefault();
        }

        public decimal GetSizeCeilingFromID(int sizeId)
        {
            using var db = new MonsterHunterJournalDBContext();
            return db.Sizes.Where(a => a.SizeId == sizeId).Select(a => a.SizeCeiling).FirstOrDefault();
        }
        public Size getSizeFromID(int sizeId)
        {
            using var db = new MonsterHunterJournalDBContext();
            return db.Sizes.Where(a => a.SizeId == sizeId).FirstOrDefault();
        }
    }
}
