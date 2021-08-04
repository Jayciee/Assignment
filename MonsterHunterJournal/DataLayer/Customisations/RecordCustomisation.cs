using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public partial class Record
    {
        public override string ToString()
        {
            string huntResult = HuntSucceeded ? "Succeeded" : "Failed";
            return $"{HunterName} hunted a(n) {GetMonsterName(MonsterId)} with a {GetWeaponName(WeaponId)} and they {huntResult}";
        }
        private string GetMonsterName(int monsterIDToSearch)
        {
            using var db = new MonsterHunterJournalDBContext();
            string name = db.Monsters.Where(m => m.MonsterId == monsterIDToSearch).Select(m => m.Name).FirstOrDefault().ToString();
            return name;
        }
        private string GetWeaponName(int weaponIDToSearch)
        {
            using var db = new MonsterHunterJournalDBContext();
            string name = db.Weapons.Where(w => w.WeaponId == weaponIDToSearch).Select(w => w.Name).FirstOrDefault().ToString();
            return name;
        }
    }
}
