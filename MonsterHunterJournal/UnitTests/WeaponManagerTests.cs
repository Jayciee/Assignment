using NUnit.Framework;
using DataLayer;
using BusinessLayer;
using System.Linq;

namespace UnitTests
{
    class WeaponManagerTests
    {
        WeaponManager _wm = new WeaponManager();
        [SetUp]
        public void Setup()
        {
            
        }
        [Test]
        public void AssertThatRetrieveAllWeapons_Returns_CorrectAmountOfWeapons()
        {
            using var db = new MonsterHunterJournalDBContext();
            int count = db.Weapons.ToList().Count;
            Assert.That(_wm.RetrieveAllWeapons().Count, Is.EqualTo(count));
        }
        [Test]
        public void AssertThatGetWeaponIdByName_Returns_CorrectID()
        {
            using var db = new MonsterHunterJournalDBContext();
            var query = db.Weapons.FirstOrDefault();
            Assert.That(_wm.GetWeaponIDByName(query.Name), Is.EqualTo(query.WeaponId));
        }
        [Test]
        public void AssertThatGetWeaponNameById_Returns_CorrectWeaponName()
        {
            using var db = new MonsterHunterJournalDBContext();
            var query = db.Weapons.FirstOrDefault();
            Assert.That(_wm.GetWeaponNameByID(query.WeaponId), Is.EqualTo(query.Name));
        }
        [Test]
        public void AssertThatGetWeaponById_Returns_CorrectWeapon()
        {
            using var db = new MonsterHunterJournalDBContext();
            var query = db.Weapons.FirstOrDefault();
            Weapon toTest = _wm.GetWeaponById(query.WeaponId);
            Assert.That(toTest.WeaponId,Is.EqualTo(query.WeaponId));
            Assert.That(toTest.Name, Is.EqualTo(query.Name));
            Assert.That(toTest.Rarity, Is.EqualTo(query.Rarity));
            Assert.That(toTest.AilmentId, Is.EqualTo(query.AilmentId));
            Assert.That(toTest.WeaponTypeId, Is.EqualTo(query.WeaponTypeId));
        }
    }
}
