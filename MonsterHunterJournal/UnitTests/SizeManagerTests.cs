using NUnit.Framework;
using DataLayer;
using BusinessLayer;
using System.Linq;

namespace UnitTests
{
    class SizeManagerTests
    {
        SizeManager _sm = new SizeManager();
        [Test]
        public void AssertThatRetrieveAllSizes_Returns_CorrectNumberOfSizes()
        {
            using var db = new MonsterHunterJournalDBContext();
            int count = db.Sizes.ToList().Count;
            Assert.That(_sm.RetrieveListOfSizes().ToList().Count,Is.EqualTo(count));
        }

        [Test]
        public void AssertThatRetrieveSizeFloorGivenID_Returns_CorrectSizeFloor()
        {
            using var db = new MonsterHunterJournalDBContext();
            var query = db.Sizes.FirstOrDefault();
            Assert.That(_sm.GetSizeFloorFromID(query.SizeId), Is.EqualTo(query.SizeFloor));
        }
        [Test]
        public void AssertThatRetrieveCeilingFloorGivenID_Returns_CorrectCeilingFloor()
        {
            using var db = new MonsterHunterJournalDBContext();
            var query = db.Sizes.FirstOrDefault();
            Assert.That(_sm.GetSizeCeilingFromID(query.SizeId), Is.EqualTo(query.SizeCeiling));
        }
        [Test]
        public void AssertThatGetSize_Returns_CorrectSize()
        {
            using var db = new MonsterHunterJournalDBContext();
            var query = db.Sizes.FirstOrDefault();
            Size testSize = _sm.getSizeFromID(query.SizeId);
            Assert.That(testSize.SizeId, Is.EqualTo(query.SizeId));
            Assert.That(testSize.SizeFloor, Is.EqualTo(query.SizeFloor));
            Assert.That(testSize.SizeCeiling, Is.EqualTo(query.SizeCeiling));
        }

        [TestCase (4, 999.99,false)]
        [TestCase (4, 1000,true)]
        [TestCase (4, 4999.99, true)]
        [TestCase (4, 5000.00, false)]
        public void AssertThatGivenARecordedSizeAndSizeCategory_Returns_TrueOrFalseInRange(int sizeId, decimal recSize, bool expected)
        {
            using var db = new MonsterHunterJournalDBContext();
            Assert.That(_sm.CheckInRange(sizeId, recSize), Is.EqualTo(expected));
        }
    }
}
