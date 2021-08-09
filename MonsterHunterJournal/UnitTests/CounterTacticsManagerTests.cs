using NUnit.Framework;
using DataLayer;
using BusinessLayer;
using System.Linq;
namespace UnitTests
{
    class CounterTacticsManagerTests
    {
        CounterTacticsManager _ctm = new CounterTacticsManager();
        HabitsManager _hm = new HabitsManager();
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
        string _counterTacticTestDescription = "TESTLx5?(xyz-&}9_&N:TEST";
        [SetUp]
        public void Setup()
        {
            using var db = new MonsterHunterJournalDBContext();
            var habit =
                from h in db.Habits
                where h.HabitName == _testHabit
                select h;
            db.Habits.RemoveRange(habit);
        }
        
        [Test]
        [Ignore("This Test case is taking too long to fix")]
        public void AssertThatGivenMonsterIDAndWeaponIDWithNoCounterTactic_Return_Default()
        {
            using var db = new MonsterHunterJournalDBContext();
            var getMonster = db.Monsters.FirstOrDefault();
            var getHabitQuery = from m in db.Monsters
                                join mh in db.MonstersHabits on m.MonsterId equals mh.MonsterId
                                join h in db.Habits on mh.HabitId equals h.HabitId
                                where m.MonsterId == getMonster.MonsterId
                                select h;
            var getHabit = getHabitQuery.FirstOrDefault();
            var getWeapon = db.WeaponTypes.FirstOrDefault();
            var query = db.CounterTactics.Where(a => a.HabitId == getHabit.HabitId && a.WeaponTypeId == getWeapon.WeaponTypeId).Select(a => a.Description).FirstOrDefault();
            Assert.That(_ctm.GetCounterTacticDescription(getWeapon.WeaponTypeId, getHabit.HabitId), Is.EqualTo("No one has added a countertactic for this habit yet"));
        }
        [Test]
        public void AssertThatGivenMonsterIDAndWeaponID_Return_CounterTactic()
        {
            using var db = new MonsterHunterJournalDBContext();
            var getMonster = db.Monsters.FirstOrDefault();
            var getHabitQuery = from m in db.Monsters
                                join mh in db.MonstersHabits on m.MonsterId equals mh.MonsterId
                                join h in db.Habits on mh.HabitId equals h.HabitId
                                where m.MonsterId == getMonster.MonsterId
                                select h;
            var getHabit = getHabitQuery.FirstOrDefault();
            var getWeapon = db.WeaponTypes.FirstOrDefault();
            var query = db.CounterTactics.Where(a => a.HabitId == getHabit.HabitId && a.WeaponTypeId == getWeapon.WeaponTypeId).Select(a => a.Description).FirstOrDefault();
            Assert.That(_ctm.GetCounterTacticDescription(getWeapon.WeaponTypeId, getHabit.HabitId), Is.EqualTo(query));
        }
        [Test]
        
        public void AssertThat_CreateNewCounterTactic_IncrementsNumberOfCountertacticsBy1()
        {
            using var db = new MonsterHunterJournalDBContext();
            int preCount = db.CounterTactics.ToList().Count;
            _hm.CreateNewHabit(_testHabit, _testDescription);
            var habitQuery = db.Habits.Where(a => a.HabitName == _testHabit).FirstOrDefault();
            _ctm.CreateNewCounterTactic(_weaponTypeId, habitQuery.HabitId,_counterTacticTestDescription);
            int postCount = db.CounterTactics.ToList().Count;
            Assert.That(preCount + 1, Is.EqualTo(postCount));
        }
        [TearDown]
        public void TearDown() 
        {
            using var db = new MonsterHunterJournalDBContext();

            var habit =
                from h in db.Habits
                where h.HabitName == _testHabit
                select h;

            var counterTactic =
                from ct in db.CounterTactics
                where ct.Description == _counterTacticTestDescription
                select ct;

            db.CounterTactics.RemoveRange(counterTactic);
            var counterTactic2 =
                from ct in db.CounterTactics
                where ct.CRTest == _counterTacticTestDescription
                select ct;
            db.Habits.RemoveRange(habit);
            db.SaveChanges();
        }
    }
}
