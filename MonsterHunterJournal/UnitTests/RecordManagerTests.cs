using NUnit.Framework;
using DataLayer;
using BusinessLayer;
using System.Linq;
using System.Diagnostics;

namespace UnitTests
{
    public class RecordManagerTests
    {
        RecordManager _recordManager;
        string testName = "testBot123";
        decimal testTime = (decimal) 40.00;
        decimal testSize = (decimal) 1000.00;
        int testMonsterID = 4;
        int testWeaponID = 1;
        bool testHuntSuccess = true;
        bool testHuntFail = false;

        [SetUp]
        public void Setup()
        {
            _recordManager = new RecordManager();
            // remove test entry in DB if present
            using (var db = new MonsterHunterJournalDBContext())
            {
                var selectedCustomers =
                from r in db.Records
                where r.HunterName == testName
                select r;

                db.Records.RemoveRange(selectedCustomers);
                db.SaveChanges();
            }
        }
        
        [Test]
        public void WhenCreatingNewRecord_AssertThatNumberOfRecordsIncrements()
        {
            using var db = new MonsterHunterJournalDBContext();

            var listOfCustomersQuery = _recordManager.RetrieveAllRecords();
            int numOfRecordsPreAdd = listOfCustomersQuery.Count();
            _recordManager.AddNewRecord(testName, testTime,testMonsterID,testWeaponID,testHuntSuccess, testSize);
            Assert.That(numOfRecordsPreAdd + 1, Is.EqualTo(db.Records.ToList().Count()));
        }
        [Test]
        public void WhenCreatingNewRecord_AssertRecordDetailsAreAccurate()
        {
            using var db = new MonsterHunterJournalDBContext();

            var listOfCustomersQuery = _recordManager.RetrieveAllRecords();
            int numOfRecordsPreAdd = listOfCustomersQuery.Count();
            _recordManager.AddNewRecord(testName, testTime,testMonsterID, testWeaponID, testHuntSuccess, testSize);
            var details = db.Records.Where(r => r.HunterName == testName).FirstOrDefault();
            Assert.That(details.HunterName, Is.EqualTo(testName));
            Assert.That(details.TimeTaken, Is.EqualTo(testTime));
            Assert.That(details.RecordedMonsterSize, Is.EqualTo(testSize));
            Assert.That(details.MonsterId, Is.EqualTo(testMonsterID));
            Assert.That(details.WeaponId, Is.EqualTo(testWeaponID));
            Assert.That(details.HuntSucceeded, Is.EqualTo(testHuntSuccess));
        }
        [Test]
        public void WhenUpdatingNewRecord_AssertChangesHaveBeenMade()
        {
            decimal newTime = (decimal)00.01;
            int newMonsterId = 4;
            int newWeaponId = 2;
            bool newHuntSuccess = false;
            decimal newSize = (decimal)3000.00;
            int idToCheck;

            using (var db = new MonsterHunterJournalDBContext())
            {
                _recordManager.AddNewRecord(testName, testTime, testMonsterID, testWeaponID, testHuntSuccess, testSize);
                var record =
                   from r in db.Records
                   where r.HunterName == testName
                   select r;
                _recordManager.UpdateNewRecord(record.FirstOrDefault().RecordId, testName, newTime, newSize, newMonsterId, newWeaponId, newHuntSuccess);
                idToCheck = record.FirstOrDefault().RecordId;
            }
            using (var db = new MonsterHunterJournalDBContext())
            {
                var detailsQuery =
                from r in db.Records
                where r.HunterName == testName
                select r;
                var details = detailsQuery.FirstOrDefault();
                Assert.That(details.HunterName, Is.EqualTo(testName));
                Assert.That(details.TimeTaken, Is.EqualTo(newTime));
                Assert.That(details.RecordedMonsterSize, Is.EqualTo(newSize));
                Assert.That(details.MonsterId, Is.EqualTo(newMonsterId));
                Assert.That(details.WeaponId, Is.EqualTo(newWeaponId));
                Assert.That(details.HuntSucceeded, Is.EqualTo(newHuntSuccess));
            }
        }
        [Test]
        public void WhenUpdatingNonExistentRecord_Return_false()
        {
            using var db = new MonsterHunterJournalDBContext();
            bool worked = _recordManager.UpdateNewRecord(999, testName, testTime, testSize, testMonsterID, testWeaponID, testHuntSuccess);
            Assert.That(worked, Is.EqualTo(false));
        }
        [Test]
        public void WhenDeletingRecord_ListOfRecordsGoesDownByOneIncrement()
        {
            using var db = new MonsterHunterJournalDBContext();
            _recordManager.AddNewRecord(testName, testTime, testMonsterID, testWeaponID, testHuntSuccess, testSize);
            var record =
               from r in db.Records
               where r.HunterName == testName
               select r;
            int preCount = db.Records.ToList().Count();
            _recordManager.DeleteNewRecord(record.FirstOrDefault().RecordId);
            int postCount = db.Records.ToList().Count();
            Assert.That(preCount - 1, Is.EqualTo(postCount));
        }
        [Test]
        public void AssertThatWhenSearchingRecordsByMonsterID_Return_ListOfRecordsAssociatedWithMonsterID()
        {
            using var db = new MonsterHunterJournalDBContext();
            int id = db.Monsters.Select(a => a.MonsterId).FirstOrDefault();
            var query = db.Records.Where(a => a.MonsterId == id);
            Assert.That(_recordManager.RetrieveRecordsFromByMonsterId(id).Where(a=>a.MonsterId==id).ToList().Count,Is.EqualTo(query.ToList().Count));
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new MonsterHunterJournalDBContext())
            {
                //RemovingRecord
                var record =
                from r in db.Records
                where r.HunterName == "testBot123"
                select r;

                db.Records.RemoveRange(record);
                db.SaveChanges();
            }
        }
    }
}