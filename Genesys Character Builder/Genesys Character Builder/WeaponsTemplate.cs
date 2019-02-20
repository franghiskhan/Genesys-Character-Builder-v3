using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesys_Character_Builder
{
    class WeaponsTemplate
    {
        private string weaponName;
        private string weaponSkill;
        private string weaponDamage;
        private string weaponCrit;
        private string weaponRange;
        private string weaponSpecial;

        public WeaponsTemplate() { }
        public WeaponsTemplate(string weaponName, string weaponSkill, string weaponDamage, string weaponCrit, string weaponRange, string weaponSpecial)
        {
            this.WeaponName = weaponName;
            this.WeaponSkill = weaponSkill;
            this.WeaponDamage = weaponDamage;
            this.WeaponCrit = weaponCrit;
            this.WeaponRange = weaponRange;
            this.WeaponSpecial = weaponSpecial;
        }

        public string WeaponName { get; set; }
        public string WeaponSkill { get; set; }
        public string WeaponDamage { get; set; }
        public string WeaponCrit { get; set; }
        public string WeaponRange { get; set; }
        public string WeaponSpecial { get; set; }
    }
}
