using NUnit.Framework;
using DataLayer;
using BusinessLayer;
using System.Linq;

namespace UnitTests
{
    class MonsterManagerTests
    {
        MonsterManager _mm = new MonsterManager();
        [SetUp]
        public void Setup()
        {

        }
        [Test]
        public void AssertThatRetrieveAllMonsters_Returns_CorrectNumberOfMonsters()
        {
            using var db = new MonsterHunterJournalDBContext();
            int count = db.Monsters.ToList().Count();
            Assert.That(_mm.RetrieveAllMonsters().Count(), Is.EqualTo(count));
        }

        //[Test]
        //public void AssertThatGetNameByID_Returns_CorrectNameOfAilment()
        //{
        //    using var db = new MonsterHunterJournalDBContext();
        //    var query = db.Ailments.Select(a => new { a.Name, a.AilmentId }).FirstOrDefault();
        //    Assert.That(_am.GetAilmentNameFromID(query.AilmentId), Is.EqualTo(query.Name));
        //}
        //[Test]
        //public void AssertThatGetIDByName_Returns_CorrectIDOfAilment()
        //{
        //    using var db = new MonsterHunterJournalDBContext();
        //    var query = db.Ailments.Select(a => new { a.Name, a.AilmentId }).FirstOrDefault();
        //    Assert.That(_am.getAilmentIDFromName(query.Name), Is.EqualTo(query.AilmentId));
        //}

        [TearDown]
        public void TearDown()
        {

        }
    }
}
