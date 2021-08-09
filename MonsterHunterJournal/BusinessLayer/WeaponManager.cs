using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;

namespace BusinessLayer
{
    public class WeaponManager
    {
        public void CreateNewWeapon(string name, int weaponId, int rarity, int elementId, int ailmentId)
        {
            using var db = new MonsterHunterJournalDBContext();
            Weapon weapon = new Weapon { Name = name, WeaponId = weaponId, Rarity = rarity, ElementId = elementId, AilmentId = ailmentId };
            db.Weapons.Add(weapon);
            db.SaveChanges();
        }
        public List<WeaponType> RetrieveAllWeaponTypes()
        {
            using (var db = new MonsterHunterJournalDBContext())
            {
                return db.WeaponTypes.ToList();
            }
        }
        public List<Weapon> RetrieveAllWeapons()
        {
            using (var db = new MonsterHunterJournalDBContext())
            {
                return db.Weapons.ToList();
            }
        }
        public int GetWeaponIDByName(string weaponName)
        {
            using var db = new MonsterHunterJournalDBContext();
            int idToReturn = db.Weapons.Where(w => w.Name == weaponName).Select(w => w.WeaponId).FirstOrDefault();
            return idToReturn;
        }

        public string GetWeaponNameByID(int weaponId)
        {
            using var db = new MonsterHunterJournalDBContext();
            string weaponNameToReturn = db.Weapons.Where(w => w.WeaponId == weaponId).Select(w => w.Name).FirstOrDefault();
            return weaponNameToReturn;
        }

        public Weapon GetWeaponById(int weaponId)
        {
            using var db = new MonsterHunterJournalDBContext();
            return db.Weapons.Where(w => w.WeaponId == weaponId).FirstOrDefault();
        }
        public string GetWeaponTypeNameByWeaponID(int weaponId) // Needs unit test
        {
            using var db = new MonsterHunterJournalDBContext();
            var query = from w in db.Weapons
                        join wt in db.WeaponTypes on w.WeaponTypeId equals wt.WeaponTypeId
                        where w.WeaponId == weaponId
                        select wt.TypeName;
            return query.FirstOrDefault();
        }
        public int GetWeaponTypeIdByWeaponTypeName(string weaponTypeName)
        {
            using var db = new MonsterHunterJournalDBContext();
            return db.WeaponTypes.Where(w => w.TypeName == weaponTypeName).Select(w=>w.WeaponTypeId).FirstOrDefault();
        }
    }
}
