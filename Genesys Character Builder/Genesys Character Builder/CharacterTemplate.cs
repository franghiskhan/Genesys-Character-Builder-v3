using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesys_Character_Builder
{
    class CharacterTemplate
    {
        private string setting;
        private string characterName;
        private string species;
        private string subSpecies;
        private string career;

        private int brawn;
        private int agility;
        private int intellect;
        private int cunning;
        private int willpower;
        private int presence;

        private int soak;
        private int woundThreshold;
        private int woundCurrent;
        private int strainThreshold;
        private int strainCurrent;
        private int defenseRanged;
        private int defenseMelee;
        private string[,] criticalInjuries;

        private int totalXP;
        private int remainXP;
        private int usedXP;

        private SkillsTemplate[] skills;
        private TalentsTemplate[] talents;
        private string[,] abilities;
        private WeaponsTemplate[] weapons;
        private string weaponsAndArmor;
        private string personalGear;
        private string currency;

        private string motivationStrength;
        private string motivationFlaw;
        private string motivationDesire;
        private string motivationFear;
        private string motivationBackground;

        private string gender;
        private string age;
        private string height;
        private string build;
        private string hair;
        private string eyes;
        private string features;

        public CharacterTemplate() { }

        public CharacterTemplate(string setting, string characterName, string species, string subSpecies, string career,
                int brawn, int agility, int intellect, int cunning, int willpower, int presence, int soak,
                int woundThreshold, int woundCurrent, int strainThreshold, int strainCurrent, int defenseRanged,
                int defenseMelee, string[,] criticalInjuries, int totalXP, int remainXP, int usedXP,
                SkillsTemplate[] skills, TalentsTemplate[] talents, string[,] abilities, WeaponsTemplate[] weapons,
                string weaponsAndArmor, string personalGear, string currency, string motivationStrength,
                string motivationFlaw, string motivationDesire, string motivationFear, string motivationBackground, string gender, string age,
                string height, string build, string hair, string eyes, string features)
        {
            this.Setting = setting;
            this.CharacterName = characterName;
            this.Species = species;
            this.SubSpecies = subSpecies;
            this.Career = career;

            this.Brawn = brawn;
            this.Agility = agility;
            this.Intellect = intellect;
            this.Cunning = cunning;
            this.Willpower = willpower;
            this.Presence = presence;

            this.Soak = soak;
            this.WoundThreshold = woundThreshold;
            this.WoundCurrent = woundCurrent;
            this.StrainThreshold = strainThreshold;
            this.StrainCurrent = strainCurrent;
            this.DefenseRanged = defenseRanged;
            this.DefenseMelee = defenseMelee;
            this.CriticalInjuries = criticalInjuries;

            this.TotalXP = totalXP;
            this.RemainXP = remainXP;
            this.UsedXP = usedXP;

            this.Skills = skills;
            this.Talents = talents;
            this.Abilities = abilities;
            this.Weapons = weapons;
            this.WeaponsAndArmor = weaponsAndArmor;
            this.PersonalGear = personalGear;
            this.Currency = currency;

            this.MotivationStrength = motivationStrength;
            this.MotivationFlaw = motivationFlaw;
            this.MotivationDesire = motivationDesire;
            this.MotivationFear = motivationFear;
            this.MotivationBackground = motivationBackground;

            this.Gender = gender;
            this.Age = age;
            this.Height = height;
            this.Build = build;
            this.Hair = hair;
            this.Eyes = eyes;
            this.Features = features;
        }

        public string Setting { get; set; }
        public string CharacterName { get; set; }
        public string Species { get; set; }
        public string SubSpecies { get; set; }
        public string Career { get; set; }

        public int Brawn { get; set; }
        public int Agility { get; set; }
        public int Intellect { get; set; }
        public int Cunning { get; set; }
        public int Willpower { get; set; }
        public int Presence { get; set; }

        public int Soak { get; set; }
        public int WoundThreshold { get; set; }
        public int WoundCurrent { get; set; }
        public int StrainThreshold { get; set; }
        public int StrainCurrent { get; set; }
        public int DefenseRanged { get; set; }
        public int DefenseMelee { get; set; }
        public string[,] CriticalInjuries { get; set; }

        public int TotalXP { get; set; }
        public int RemainXP { get; set; }
        public int UsedXP { get; set; }

        public SkillsTemplate[] Skills { get; set; }
        public TalentsTemplate[] Talents { get; set; }
        public string[,] Abilities { get; set; }
        public WeaponsTemplate[] Weapons { get; set; }
        public string WeaponsAndArmor { get; set; }
        public string PersonalGear { get; set; }
        public string Currency { get; set; }

        public string MotivationStrength { get; set; }
        public string MotivationFlaw { get; set; }
        public string MotivationDesire { get; set; }
        public string MotivationFear { get; set; }
        public string MotivationBackground { get; set; }

        public string Gender { get; set; }
        public string Age { get; set; }
        public string Height { get; set; }
        public string Build { get; set; }
        public string Hair { get; set; }
        public string Eyes { get; set; }
        public string Features { get; set; }
    }
}
