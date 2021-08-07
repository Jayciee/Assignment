using NUnit.Framework;
using DataLayer;
using BusinessLayer;
using System.Linq;

namespace UnitTests
{
    class ElementManagerTests
    {
        ElementsManager _em = new ElementsManager();

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void AssertThatRetrieveAllElements_Returns_CorrectNumberOfElements()
        {
            using var db = new MonsterHunterJournalDBContext();
            int count = db.Elements.ToList().Count();
            Assert.That(_em.RetrieveAllElements().Count(), Is.EqualTo(count));
        }
        [Test]
        public void AssertThatGetNameByID_Returns_CorrectNameOfElement()
        {
            using var db = new MonsterHunterJournalDBContext();
            var query = db.Elements.Select(a => new { a.Name, a.ElementId }).FirstOrDefault();
            Assert.That(_em.GetElementNameFromID(query.ElementId), Is.EqualTo(query.Name));
        }
        [Test]
        public void AssertThatGetIDByName_Returns_CorrectIDOfElement()
        {
            using var db = new MonsterHunterJournalDBContext();
            var query = db.Elements.Select(a => new { a.Name, a.ElementId }).FirstOrDefault();
            Assert.That(_em.getElementIDFromName(query.Name), Is.EqualTo(query.ElementId));
        }

        [TearDown]
        public void TearDown()
        {

        }
    }
}
