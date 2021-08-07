using NUnit.Framework;
using DataLayer;
using BusinessLayer;
using System.Linq;
namespace UnitTests
{
    class HabitsAndCountersTacticsManagerTests
    {
        HabitsAndCounterTacticsManager _hactm = new HabitsAndCounterTacticsManager();
        MonsterManager _mm = new MonsterManager();
        string _testMonsterName = "testBot123";
        string _description = "I'm a testbot";
        string _type = "TestMonster";
        int _threatLevel = 1;
        int _primaryElementId = 1;
        int _primaryAilmentId = 1;
        int _sizeID = 4;

        [SetUp]
        public void SetUp()
        {
            
        }
        [Test]
        [Ignore("Need a create new monster method to continue")]
        public void AssertThat_CreateNewCounterTactic_IncrementsNumberOfCountertacticsBy1()
        {
            //_hactm.CreateNewCounterTactic()
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
            Assert.That(_hactm.GetCounterTactic(getWeapon.WeaponTypeId,getHabit.HabitId), Is.EqualTo(query));
        }
        
        [Test]
        [Ignore("Haven't created test monster to return default value")]
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
            Assert.That(_hactm.GetCounterTactic(getWeapon.WeaponTypeId, getHabit.HabitId), Is.EqualTo("No one has added a countertactic for this habit yet"));
        }
        [TearDown]
        public void TearDown()
        {

        }
    }
}
