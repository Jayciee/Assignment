using System.Collections.Generic;
using System.Linq;
using DataLayer;

namespace BusinessLayer
{
    public class WeaponManager
    {
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
    }
}
