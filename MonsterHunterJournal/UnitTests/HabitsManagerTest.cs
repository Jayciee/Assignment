using NUnit.Framework;
using DataLayer;
using BusinessLayer;
using System.Linq;
namespace UnitTests
{
    class HabitsManagerTest
    {
        HabitsManager _hactm = new HabitsManager();
        MonsterManager _mm = new MonsterManager();
        string _testMonsterName = "testBot123";
        string _testDescription = "I'm part of a test";
        string _type = "TestMonster";
        int _threatLevel = 1;
        int _primaryElementId = 1;
        int _primaryAilmentId = 1;
        int _sizeID = 4;

        string _testHabit = "TestHabit";
        int _weaponTypeId = 1;

        [SetUp]
        public void SetUp()
        {
            using var db = new MonsterHunterJournalDBContext();
            var monster =
                from r in db.Monsters
                where r.Name == _testMonsterName
                select r;

            db.Monsters.RemoveRange(monster);
            var habit =
                from h in db.Habits
                where h.HabitName == _testHabit
                select h;

            db.Habits.RemoveRange(habit);
            db.SaveChanges();

        }
        
        [Test]
        public void AssertThatGivenMonsterID_Return_ListOfHabits()
        {
            using var db = new MonsterHunterJournalDBContext();
            var getMonster = db.Monsters.FirstOrDefault();
            var query = from h in db.Habits
                        join mh in db.MonstersHabits on h.HabitId equals mh.HabitId
                        join m in db.Monsters on mh.MonsterId equals m.MonsterId
                        where m.MonsterId == getMonster.MonsterId
                        select h;
            int count = query.ToList().Count;
            Assert.That(_hactm.GetListOfHabitsFromMonster(getMonster.MonsterId).ToList().Count, Is.EqualTo(count));
        }
        [Test]
        public void AssertThatCreateNewHabit_IncrementsHabitsListBy1()
        {
            using var db = new MonsterHunterJournalDBContext();
            int preCount = db.Habits.ToList().Count;
            _hactm.CreateNewHabit(_testHabit, _testDescription);
            int postCount = db.Habits.ToList().Count;
            Assert.That(preCount + 1, Is.EqualTo(postCount));
        }
        [TearDown]
        public void TearDown()
        {
            using var db = new MonsterHunterJournalDBContext();
            var monster =
                from r in db.Monsters
                where r.Name == _testMonsterName
                select r;

            
            var habit =
                from h in db.Habits
                where h.HabitName == _testHabit
                select h;

            db.Monsters.RemoveRange(monster);
            
            db.Habits.RemoveRange(habit);

            
            db.SaveChanges();
        }
    }
}
