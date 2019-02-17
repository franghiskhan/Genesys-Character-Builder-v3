using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genesys_Character_Builder
{
    public partial class frmGenesys : Form
    {
        public frmGenesys()
        {
            InitializeComponent();
        }

        private CharacterTemplate myCharacter = new CharacterTemplate
        {
            CharacterName = "",
            Species = "",
            SubSpecies = "",
            Career = "",

            Brawn = 2, Agility = 2, Intellect = 2, Cunning = 2, Willpower = 2, Presence = 2,

            Soak = 0,
            WoundThreshold = 10,
            WoundCurrent = 0,
            StrainThreshold = 10,
            StrainCurrent = 0,
            DefenseRanged = 0,
            DefenseMelee = 0,
            CriticalInjuries = null,

            TotalXP = 0,
            RemainXP = 0,
            UsedXP = 0,

            Skills = new SkillsTemplate[44],
            Talents = new TalentsTemplate[25],
            Abilities = null,

            MotivationStrength = "",
            MotivationFlaw = "",
            MotivationDesire = "",
            MotivationFear = "",

            Gender = "",
            Age = "",
            Height = "",
            Build = "",
            Hair = "",
            Eyes = "",
            Features = "",
        };

    private SkillsTemplate[] terrinothSkills = new SkillsTemplate[]
    {
            //general
            new SkillsTemplate("Alchemy", "Int", "Description", false, 0), //0
            new SkillsTemplate("Athletics", "Br", "Description", false, 0), //1
            new SkillsTemplate("Cool", "Pr", "Description", false, 0), //2
            new SkillsTemplate("Coordination", "Ag", "Description", false, 0), //3
            new SkillsTemplate("Discipline", "Will", "Description", false, 0), //4
            new SkillsTemplate("Mechanics", "Int", "Description", false, 0), //5
            new SkillsTemplate("Medicine", "Int", "Description", false, 0), //6
            new SkillsTemplate("Perception", "Cun", "Description", false, 0), //7
            new SkillsTemplate("Resilience", "Br", "Description", false, 0), //8
            new SkillsTemplate("Riding", "Ag", "Description", false, 0), //9
            new SkillsTemplate("Skullduggery", "Cun", "Description", false, 0), //10
            new SkillsTemplate("Stealth", "Ag", "Description", false, 0), //11
            new SkillsTemplate("Streetwise", "Cun", "Description", false, 0), //12
            new SkillsTemplate("Survival", "Cun", "Description", false, 0), //13
            new SkillsTemplate("Vigilance", "Will", "Description", false, 0), //14
            new SkillsTemplate("Custom Skill", "--", "Description", false, 0), //15
            new SkillsTemplate("Custom Skill", "--", "Description", false, 0), //16
            new SkillsTemplate("Custom Skill", "--", "Description", false, 0), //17
            //magic
            new SkillsTemplate("Arcana", "Int", "Description", false, 0), //18
            new SkillsTemplate("Divine", "Will", "Description", false, 0), //19
            new SkillsTemplate("Primal", "Cun", "Description", false, 0), //20
            new SkillsTemplate("Rune", "Int", "Description", false, 0), //21
            new SkillsTemplate("Verse", "Pr", "Description", false, 0), //22
            //combat
            new SkillsTemplate("Brawl", "Br", "Description", false, 0), //23
            new SkillsTemplate("Melee-Heavy", "Br", "Description", false, 0), //24
            new SkillsTemplate("Melee-Light", "Br", "Description", false, 0), //25
            new SkillsTemplate("Ranged", "Ag", "Description", false, 0), //26
            new SkillsTemplate("Custom Skill", "--", "Description", false, 0), //27
            new SkillsTemplate("Custom Skill", "--", "Description", false, 0), //28
            //social
            new SkillsTemplate("Charm", "Pr", "Description", false, 0), //29
            new SkillsTemplate("Coercion", "Will", "Description", false, 0), //30
            new SkillsTemplate("Deception", "Cun", "Description", false, 0), //31
            new SkillsTemplate("Leadership", "Pr", "Description", false, 0), //32
            new SkillsTemplate("Negotiation", "Pr", "Description", false, 0), //33
            //knowledge
            new SkillsTemplate("Adventuring", "Int", "Description", false, 0), //34
            new SkillsTemplate("Forbidden", "Int", "Description", false, 0), //35
            new SkillsTemplate("Lore", "Int", "Description", false, 0), //36
            new SkillsTemplate("Geography", "Int", "Description", false, 0), //37
            new SkillsTemplate("Custom Skill", "Int", "Description", false, 0), //38
            //custom skills
            new SkillsTemplate("Custom Skill", "Int", "Description", false, 0), //39
            new SkillsTemplate("Custom Skill", "Int", "Description", false, 0), //40
            new SkillsTemplate("Custom Skill", "Int", "Description", false, 0), //41
            new SkillsTemplate("Custom Skill", "Int", "Description", false, 0), //42
            new SkillsTemplate("Custom Skill", "Int", "Description", false, 0), //43
    };

    private SkillsTemplate[] androidSkills = new SkillsTemplate[]
    {
            //general
            new SkillsTemplate("Athletics", "Br", "Description", false, 0), //0
            new SkillsTemplate("Comp (Hacking)", "Int", "Description", false, 0), //1
            new SkillsTemplate("Comp (SysOps)", "Int", "Description", false, 0), //2
            new SkillsTemplate("Cool", "Pr", "Description", false, 0), //3
            new SkillsTemplate("Coordination", "Ag", "Description", false, 0), //4
            new SkillsTemplate("Discipline", "Will", "Description", false, 0), //5
            new SkillsTemplate("Driving", "Ag", "Description", false, 0), //6
            new SkillsTemplate("Mechanics", "Int", "Description", false, 0), //7
            new SkillsTemplate("Medicine", "Int", "Description", false, 0), //8
            new SkillsTemplate("Operating", "Int", "Description", false, 0), //9
            new SkillsTemplate("Perception", "Cun", "Description", false, 0), //10
            new SkillsTemplate("Piloting", "Int", "Description", false, 0), //11
            new SkillsTemplate("Resilience", "Br", "Description", false, 0), //12
            new SkillsTemplate("Skullduggery", "Cun", "Description", false, 0), //13
            new SkillsTemplate("Stealth", "Ag", "Description", false, 0), //14
            new SkillsTemplate("Streetwise", "Cun", "Description", false, 0), //15
            new SkillsTemplate("Survival", "Cun", "Description", false, 0), //16
            new SkillsTemplate("Vigilance", "Will", "Description", false, 0), //17
            //custom skills
            new SkillsTemplate("Custom Skill", "Int", "Description", false, 0), //18
            new SkillsTemplate("Custom Skill", "", "Description", false, 0), //19
            new SkillsTemplate("Custom Skill", "Int", "Description", false, 0), //20
            new SkillsTemplate("Custom Skill", "", "Description", false, 0), //21
            new SkillsTemplate("Custom Skill", "Int", "Description", false, 0), //22
            //combat
            new SkillsTemplate("Brawl", "Br", "Description", false, 0), //23
            new SkillsTemplate("Melee", "Br", "Description", false, 0), //24
            new SkillsTemplate("Ranged (Heavy)", "Ag", "Description", false, 0), //25
            new SkillsTemplate("Ranged (Light)", "Ag", "Description", false, 0), //26
            new SkillsTemplate("Gunnery", "Ag", "Description", false, 0), //27
            new SkillsTemplate("Custom Skill", "Int", "Description", false, 0), //28
            //social
            new SkillsTemplate("Charm", "Pr", "Description", false, 0), //29
            new SkillsTemplate("Coercion", "Will", "Description", false, 0), //30
            new SkillsTemplate("Deception", "Cun", "Description", false, 0), //31
            new SkillsTemplate("Leadership", "Pr", "Description", false, 0), //32
            new SkillsTemplate("Negotiation", "Pr", "Description", false, 0), //33
            //knowledge
            new SkillsTemplate("Science", "Int", "Description", false, 0), //34
            new SkillsTemplate("Society", "Int", "Description", false, 0), //35
            new SkillsTemplate("The Net", "Int", "Description", false, 0), //36
            new SkillsTemplate("Custom Skill", "Int", "Description", false, 0), //37
            new SkillsTemplate("Custom Skill", "Int", "Description", false, 0), //38
            //custom
            new SkillsTemplate("Custom Skill", "Int", "Description", false, 0), //39
            new SkillsTemplate("Custom Skill", "Int", "Description", false, 0), //40
            new SkillsTemplate("Custom Skill", "Int", "Description", false, 0), //41
            new SkillsTemplate("Custom Skill", "Int", "Description", false, 0), //42
            new SkillsTemplate("Custom Skill", "Int", "Description", false, 0), //43
    };

    private TalentsTemplate[] talentsList =
    {
            //tier 1
            new TalentsTemplate("Talent", "Description", false, false, 1, 0), //0
            new TalentsTemplate("Talent", "Description", false, false, 1, 0), //1
            new TalentsTemplate("Talent", "Description", false, false, 1, 0), //2
            new TalentsTemplate("Talent", "Description", false, false, 1, 0), //3
            new TalentsTemplate("Talent", "Description", false, false, 1, 0), //4
            new TalentsTemplate("Talent", "Description", false, false, 1, 0), //5
            new TalentsTemplate("Talent", "Description", false, false, 1, 0), //6
            //tier 2
            new TalentsTemplate("Talent", "Description", false, false, 2, 0), //7
            new TalentsTemplate("Talent", "Description", false, false, 2, 0), //8
            new TalentsTemplate("Talent", "Description", false, false, 2, 0), //9
            new TalentsTemplate("Talent", "Description", false, false, 2, 0), //10
            new TalentsTemplate("Talent", "Description", false, false, 2, 0), //11
            new TalentsTemplate("Talent", "Description", false, false, 2, 0), //12
            //tier 3
            new TalentsTemplate("Talent", "Description", false, false, 3, 0), //13
            new TalentsTemplate("Talent", "Description", false, false, 3, 0), //14
            new TalentsTemplate("Talent", "Description", false, false, 3, 0), //15
            new TalentsTemplate("Talent", "Description", false, false, 3, 0), //16
            new TalentsTemplate("Talent", "Description", false, false, 3, 0), //17
            //tier 4
            new TalentsTemplate("Talent", "Description", false, false, 4, 0), //18
            new TalentsTemplate("Talent", "Description", false, false, 4, 0), //19
            new TalentsTemplate("Talent", "Description", false, false, 4, 0), //20
            new TalentsTemplate("Talent", "Description", false, false, 4, 0), //21
            //tier 5
            new TalentsTemplate("Talent", "Description", false, false, 5, 0), //22
            new TalentsTemplate("Talent", "Description", false, false, 5, 0), //23
            new TalentsTemplate("Talent", "Description", false, false, 5, 0), //24
        };

    private void frmGenesys_Load()
        {
            
        }

        private void linkSkill_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelSkillDetail.Visible = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
