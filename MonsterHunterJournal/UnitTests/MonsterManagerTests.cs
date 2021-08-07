using NUnit.Framework;
using DataLayer;
using BusinessLayer;
using System.Linq;

namespace UnitTests
{
    class MonsterManagerTests
    {
        MonsterManager _mm = new MonsterManager();
        string _testMonsterName = "testBot123";
        string _description = "I'm a testbot";
        string _type = "TestMonster";
        int _threatLevel = 1;
        int _primaryElementId = 1;
        int _primaryAilmentId = 1;
        int _sizeID= 4;

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
        public void AssertThatCreateNewMonster_IncrementsListOfMonstersByOne()
        {
            using var db = new MonsterHunterJournalDBContext();
            int preCount = db.Monsters.ToList().Count;
            _mm.CreateNewMonsters(_testMonsterName, _description, _type, _threatLevel, _primaryElementId, _primaryAilmentId, _sizeID);
            int postCount = db.Monsters.ToList().Count;
            Assert.That(preCount+1, Is.EqualTo(postCount));
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
            using var db = new MonsterHunterJournalDBContext();
            var monster =
                from r in db.Monsters
                where r.Name == _testMonsterName
                select r;

            db.Monsters.RemoveRange(monster);
            db.SaveChanges();
        }
    }
}
