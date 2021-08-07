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

        [Test]
        public void AssertThatGetIDByName_Returns_CorrectNameOfMonster()
        {
            using var db = new MonsterHunterJournalDBContext();
            var query = db.Monsters.Select(a => new { a.Name, a.MonsterId }).FirstOrDefault();
            Assert.That(_mm.GetMonsterIDByName(query.Name), Is.EqualTo(query.MonsterId));
        }

        [Test]
        public void AssertThatGetNameByID_Returns_CorrectIDOfAilment()
        {
            using var db = new MonsterHunterJournalDBContext();
            var query = db.Monsters.Select(a => new { a.Name, a.MonsterId}).FirstOrDefault();
            Assert.That(_mm.GetMonsterNameByID(query.MonsterId), Is.EqualTo(query.Name));
        }

        public void AssertThatGetListOfHabitsFromMonsterID_Returns_ReturnsListOfHabits()
        {
            using var db = new MonsterHunterJournalDBContext();
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}
