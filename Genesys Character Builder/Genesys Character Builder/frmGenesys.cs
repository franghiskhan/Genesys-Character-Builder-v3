using System;
using System.Collections;
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

        private static int activeSkillLink;
        private static int activeTalentLink;
        private static int careerSkillsNum = 0;
        private const int NUM_SKILLS = 44;
        private const int NUM_TALENTS = 25;
        private const int NUM_TALENT_TIERS = 5;

        private CharacterTemplate myCharacter = new CharacterTemplate
        {
            Setting = "",
            CharacterName = "",
            Species = "",
            SubSpecies = "",
            Career = "",

            Brawn = 2,
            Agility = 2,
            Intellect = 2,
            Cunning = 2,
            Willpower = 2,
            Presence = 2,

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

            Skills = new SkillsTemplate[NUM_SKILLS],
            Talents = new TalentsTemplate[NUM_TALENTS],
            Abilities = null,
            Weapons = new WeaponsTemplate[4],
            WeaponsAndArmor = null,
            PersonalGear = null,
            Currency = null,

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
            new SkillsTemplate("Alchemy", "Int", "TalentDescription", false, 0), //0
            new SkillsTemplate("Athletics", "Br", "TalentDescription", false, 0), //1
            new SkillsTemplate("Cool", "Pr", "TalentDescription", false, 0), //2
            new SkillsTemplate("Coordination", "Ag", "TalentDescription", false, 0), //3
            new SkillsTemplate("Discipline", "Will", "TalentDescription", false, 0), //4
            new SkillsTemplate("Mechanics", "Int", "TalentDescription", false, 0), //5
            new SkillsTemplate("Medicine", "Int", "TalentDescription", false, 0), //6
            new SkillsTemplate("Perception", "Cun", "TalentDescription", false, 0), //7
            new SkillsTemplate("Resilience", "Br", "TalentDescription", false, 0), //8
            new SkillsTemplate("Riding", "Ag", "TalentDescription", false, 0), //9
            new SkillsTemplate("Skullduggery", "Cun", "TalentDescription", false, 0), //10
            new SkillsTemplate("Stealth", "Ag", "TalentDescription", false, 0), //11
            new SkillsTemplate("Streetwise", "Cun", "TalentDescription", false, 0), //12
            new SkillsTemplate("Survival", "Cun", "TalentDescription", false, 0), //13
            new SkillsTemplate("Vigilance", "Will", "TalentDescription", false, 0), //14
            new SkillsTemplate("Custom Skill", "--", "TalentDescription", false, 0), //15
            new SkillsTemplate("Custom Skill", "--", "TalentDescription", false, 0), //16
            new SkillsTemplate("Custom Skill", "--", "TalentDescription", false, 0), //17
            //magic
            new SkillsTemplate("Arcana", "Int", "TalentDescription", false, 0), //18
            new SkillsTemplate("Divine", "Will", "TalentDescription", false, 0), //19
            new SkillsTemplate("Primal", "Cun", "TalentDescription", false, 0), //20
            new SkillsTemplate("Rune", "Int", "TalentDescription", false, 0), //21
            new SkillsTemplate("Verse", "Pr", "TalentDescription", false, 0), //22
            //combat
            new SkillsTemplate("Brawl", "Br", "TalentDescription", false, 0), //23
            new SkillsTemplate("Melee-Heavy", "Br", "TalentDescription", false, 0), //24
            new SkillsTemplate("Melee-Light", "Br", "TalentDescription", false, 0), //25
            new SkillsTemplate("Ranged", "Ag", "TalentDescription", false, 0), //26
            new SkillsTemplate("Custom Skill", "--", "TalentDescription", false, 0), //27
            new SkillsTemplate("Custom Skill", "--", "TalentDescription", false, 0), //28
            //social
            new SkillsTemplate("Charm", "Pr", "TalentDescription", false, 0), //29
            new SkillsTemplate("Coercion", "Will", "TalentDescription", false, 0), //30
            new SkillsTemplate("Deception", "Cun", "TalentDescription", false, 0), //31
            new SkillsTemplate("Leadership", "Pr", "TalentDescription", false, 0), //32
            new SkillsTemplate("Negotiation", "Pr", "TalentDescription", false, 0), //33
            //knowledge
            new SkillsTemplate("Adventuring", "Int", "TalentDescription", false, 0), //34
            new SkillsTemplate("Forbidden", "Int", "TalentDescription", false, 0), //35
            new SkillsTemplate("Lore", "Int", "TalentDescription", false, 0), //36
            new SkillsTemplate("Geography", "Int", "TalentDescription", false, 0), //37
            new SkillsTemplate("Custom Skill", "--", "TalentDescription", false, 0), //38
            //custom skills
            new SkillsTemplate("Custom Skill", "--", "TalentDescription", false, 0), //39
            new SkillsTemplate("Custom Skill", "--", "TalentDescription", false, 0), //40
            new SkillsTemplate("Custom Skill", "--", "TalentDescription", false, 0), //41
            new SkillsTemplate("Custom Skill", "--", "TalentDescription", false, 0), //42
            new SkillsTemplate("Custom Skill", "--", "TalentDescription", false, 0), //43
        };

        private SkillsTemplate[] androidSkills = new SkillsTemplate[]
        {
            //general
            new SkillsTemplate("Athletics", "Br", "TalentDescription", false, 0), //0
            new SkillsTemplate("Comp (Hacking)", "Int", "TalentDescription", false, 0), //1
            new SkillsTemplate("Comp (SysOps)", "Int", "TalentDescription", false, 0), //2
            new SkillsTemplate("Cool", "Pr", "TalentDescription", false, 0), //3
            new SkillsTemplate("Coordination", "Ag", "TalentDescription", false, 0), //4
            new SkillsTemplate("Discipline", "Will", "TalentDescription", false, 0), //5
            new SkillsTemplate("Driving", "Ag", "TalentDescription", false, 0), //6
            new SkillsTemplate("Mechanics", "Int", "TalentDescription", false, 0), //7
            new SkillsTemplate("Medicine", "Int", "TalentDescription", false, 0), //8
            new SkillsTemplate("Operating", "Int", "TalentDescription", false, 0), //9
            new SkillsTemplate("Perception", "Cun", "TalentDescription", false, 0), //10
            new SkillsTemplate("Piloting", "Int", "TalentDescription", false, 0), //11
            new SkillsTemplate("Resilience", "Br", "TalentDescription", false, 0), //12
            new SkillsTemplate("Skullduggery", "Cun", "TalentDescription", false, 0), //13
            new SkillsTemplate("Stealth", "Ag", "TalentDescription", false, 0), //14
            new SkillsTemplate("Streetwise", "Cun", "TalentDescription", false, 0), //15
            new SkillsTemplate("Survival", "Cun", "TalentDescription", false, 0), //16
            new SkillsTemplate("Vigilance", "Will", "TalentDescription", false, 0), //17
            //custom skills
            new SkillsTemplate("Custom Skill", "--", "TalentDescription", false, 0), //18
            new SkillsTemplate("Custom Skill", "--", "TalentDescription", false, 0), //19
            new SkillsTemplate("Custom Skill", "--", "TalentDescription", false, 0), //20
            new SkillsTemplate("Custom Skill", "--", "TalentDescription", false, 0), //21
            new SkillsTemplate("Custom Skill", "--", "TalentDescription", false, 0), //22
            //combat
            new SkillsTemplate("Brawl", "Br", "TalentDescription", false, 0), //23
            new SkillsTemplate("Melee", "Br", "TalentDescription", false, 0), //24
            new SkillsTemplate("Ranged (Heavy)", "Ag", "TalentDescription", false, 0), //25
            new SkillsTemplate("Ranged (Light)", "Ag", "TalentDescription", false, 0), //26
            new SkillsTemplate("Gunnery", "Ag", "TalentDescription", false, 0), //27
            new SkillsTemplate("Custom Skill", "--", "TalentDescription", false, 0), //28
            //social
            new SkillsTemplate("Charm", "Pr", "TalentDescription", false, 0), //29
            new SkillsTemplate("Coercion", "Will", "TalentDescription", false, 0), //30
            new SkillsTemplate("Deception", "Cun", "TalentDescription", false, 0), //31
            new SkillsTemplate("Leadership", "Pr", "TalentDescription", false, 0), //32
            new SkillsTemplate("Negotiation", "Pr", "TalentDescription", false, 0), //33
            //knowledge
            new SkillsTemplate("Science", "Int", "TalentDescription", false, 0), //34
            new SkillsTemplate("Society", "Int", "TalentDescription", false, 0), //35
            new SkillsTemplate("The Net", "Int", "TalentDescription", false, 0), //36
            new SkillsTemplate("Custom Skill", "--", "TalentDescription", false, 0), //37
            new SkillsTemplate("Custom Skill", "--", "TalentDescription", false, 0), //38
            //custom
            new SkillsTemplate("Custom Skill", "--", "TalentDescription", false, 0), //39
            new SkillsTemplate("Custom Skill", "--", "TalentDescription", false, 0), //40
            new SkillsTemplate("Custom Skill", "--", "TalentDescription", false, 0), //41
            new SkillsTemplate("Custom Skill", "--", "TalentDescription", false, 0), //42
            new SkillsTemplate("Custom Skill", "--", "TalentDescription", false, 0), //43
        };

        private TalentsTemplate[] talentsList =
        {
            //tier 1
            new TalentsTemplate("Talent", "TalentDescription", false, false, 1, ""), //0
            new TalentsTemplate("Talent", "TalentDescription", false, false, 1, ""), //1
            new TalentsTemplate("Talent", "TalentDescription", false, false, 1, ""), //2
            new TalentsTemplate("Talent", "TalentDescription", false, false, 1, ""), //3
            new TalentsTemplate("Talent", "TalentDescription", false, false, 1, ""), //4
            new TalentsTemplate("Talent", "TalentDescription", false, false, 1, ""), //5
            new TalentsTemplate("Talent", "TalentDescription", false, false, 1, ""), //6
            //tier 2
            new TalentsTemplate("Talent", "TalentDescription", false, false, 2, ""), //7
            new TalentsTemplate("Talent", "TalentDescription", false, false, 2, ""), //8
            new TalentsTemplate("Talent", "TalentDescription", false, false, 2, ""), //9
            new TalentsTemplate("Talent", "TalentDescription", false, false, 2, ""), //10
            new TalentsTemplate("Talent", "TalentDescription", false, false, 2, ""), //11
            new TalentsTemplate("Talent", "TalentDescription", false, false, 2, ""), //12
            //tier 3
            new TalentsTemplate("Talent", "TalentDescription", false, false, 3, ""), //13
            new TalentsTemplate("Talent", "TalentDescription", false, false, 3, ""), //14
            new TalentsTemplate("Talent", "TalentDescription", false, false, 3, ""), //15
            new TalentsTemplate("Talent", "TalentDescription", false, false, 3, ""), //16
            new TalentsTemplate("Talent", "TalentDescription", false, false, 3, ""), //17
            //tier 4
            new TalentsTemplate("Talent", "TalentDescription", false, false, 4, ""), //18
            new TalentsTemplate("Talent", "TalentDescription", false, false, 4, ""), //19
            new TalentsTemplate("Talent", "TalentDescription", false, false, 4, ""), //20
            new TalentsTemplate("Talent", "TalentDescription", false, false, 4, ""), //21
            //tier 5
            new TalentsTemplate("Talent", "TalentDescription", false, false, 5, ""), //22
            new TalentsTemplate("Talent", "TalentDescription", false, false, 5, ""), //23
            new TalentsTemplate("Talent", "TalentDescription", false, false, 5, ""), //24
        };

        private WeaponsTemplate[] weaponsList =
        {
            new WeaponsTemplate("", "", "", "", "", ""),
            new WeaponsTemplate("", "", "", "", "", ""),
            new WeaponsTemplate("", "", "", "", "", ""),
            new WeaponsTemplate("", "", "", "", "", "")
        };

        private void frmGenesys_Load(object sender, EventArgs e)
        {
            cboSetting.Items.Clear();
            cboSetting.Items.Add("Android");
            cboSetting.Items.Add("Terrinoth");
            cboSetting.SelectedIndex = 0;

            cboSetting.Text = myCharacter.Setting;
            txtCharacterName.Text = myCharacter.CharacterName;
            cboSpecies.Text = myCharacter.Species;
            cboSubSpecies.Text = myCharacter.SubSpecies;
            cboCareer.Text = myCharacter.Career;

            lblBrawnVal.Text = myCharacter.Brawn.ToString();
            lblAgilityVal.Text = myCharacter.Agility.ToString();
            lblIntellectVal.Text = myCharacter.Intellect.ToString();
            lblCunningVal.Text = myCharacter.Cunning.ToString();
            lblWillpowerVal.Text = myCharacter.Willpower.ToString();
            lblPresenceVal.Text = myCharacter.Presence.ToString();

            lblSoak.Text = myCharacter.Soak.ToString();
            lblWoundThreshold.Text = myCharacter.WoundThreshold.ToString();
            lblWoundCurrent.Text = myCharacter.WoundCurrent.ToString();
            lblStrainThreshold.Text = myCharacter.StrainThreshold.ToString();
            lblStrainCurrent.Text = myCharacter.StrainCurrent.ToString();
            lblDefenseMelee.Text = myCharacter.DefenseMelee.ToString();
            lblDefenseRanged.Text = myCharacter.DefenseRanged.ToString();

            updateTalents();
        }

        private void cboSetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            myCharacter.Setting = cboSetting.Text;
            switch (myCharacter.Setting)
            {
                case "Android":
                    this.BackgroundImage = Properties.Resources.android_background;
                    txtCharacterName.Width = 220;
                    lblSpecies.Text = "Archetype:";
                    lblSubSpecies.Visible = false;
                    cboSubSpecies.Visible = false;
                    cboSpecies.Items.Clear();
                    cboSpecies.Items.Add("");

                    cboSpecies.SelectedIndex = 0;
                    cboCareer.Items.Clear();
                    lblSkillsMagic.Text = "Custom Skills";
                    Array.Copy(androidSkills, myCharacter.Skills, myCharacter.Skills.Length);
                    Array.Copy(talentsList, myCharacter.Talents, myCharacter.Talents.Length);
                    Array.Copy(weaponsList, myCharacter.Weapons, myCharacter.Weapons.Length);
                    break;
                case "Terrinoth":
                    this.BackgroundImage = Properties.Resources.terrinoth_background;
                    txtCharacterName.Width = 257;
                    lblSpecies.Text = "Species:";
                    lblSubSpecies.Visible = true;
                    cboSubSpecies.Visible = true;
                    cboSpecies.Items.Clear();
                    cboSpecies.Items.Add("");
                    cboSpecies.Items.Add("Human");
                    cboSpecies.Items.Add("CatFolk");
                    cboSpecies.Items.Add("Half CatFolk");
                    cboSpecies.Items.Add("Dwarf");
                    cboSpecies.Items.Add("Elf");
                    cboSpecies.Items.Add("Gnome");
                    cboSpecies.Items.Add("Orc");
                    cboSpecies.SelectedIndex = 0;
                    cboCareer.Items.Clear();
                    cboCareer.Items.Add("");
                    cboCareer.Items.Add("Disciple");
                    cboCareer.Items.Add("Envoy");
                    cboCareer.Items.Add("Mage");
                    cboCareer.Items.Add("Primalist");
                    cboCareer.Items.Add("Scholar");
                    cboCareer.Items.Add("Scoundrel");
                    cboCareer.Items.Add("Scout");
                    cboCareer.Items.Add("Warrior");
                    cboCareer.SelectedIndex = 0;
                    lblSkillsMagic.Text = "Magic Skills";
                    Array.Copy(terrinothSkills, myCharacter.Skills, myCharacter.Skills.Length);
                    Array.Copy(talentsList, myCharacter.Talents, myCharacter.Talents.Length);
                    break;
            }
            updateLabelColors();
            updateSkills();
        }

        private void cboSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            myCharacter.Species = cboSpecies.Text;

            switch (myCharacter.Species)
            {
                case "Human":
                case "Average Human":
                    cboSubSpecies.Items.Clear();
                    cboSubSpecies.Items.Add("");
                    cboSubSpecies.SelectedIndex = 0;
                    myCharacter.Brawn = 2;
                    myCharacter.Agility = 2;
                    myCharacter.Intellect = 2;
                    myCharacter.Cunning = 2;
                    myCharacter.Willpower = 2;
                    myCharacter.Presence = 2;
                    myCharacter.WoundThreshold = 10;
                    myCharacter.StrainThreshold = 10;
                    myCharacter.TotalXP = 110;
                    myCharacter.UsedXP = 0;
                    //2 free skill ranks
                    //ready for anything
                    break;
                case "The Laborer":
                    cboSubSpecies.Items.Clear();
                    cboSubSpecies.Items.Add("");
                    cboSubSpecies.SelectedIndex = 0;
                    myCharacter.Brawn = 3;
                    myCharacter.Agility = 2;
                    myCharacter.Intellect = 2;
                    myCharacter.Cunning = 2;
                    myCharacter.Willpower = 1;
                    myCharacter.Presence = 2;
                    myCharacter.WoundThreshold = 12;
                    myCharacter.StrainThreshold = 8;
                    myCharacter.TotalXP = 100;
                    myCharacter.UsedXP = 0;
                    addRankToStartingSkills("Athletics"); //+1 Athletics
                    //Tough as Nails
                    break;
                case "The Intellectual":
                    cboSubSpecies.Items.Clear();
                    cboSubSpecies.Items.Add("");
                    cboSubSpecies.SelectedIndex = 0;
                    myCharacter.Brawn = 2;
                    myCharacter.Agility = 1;
                    myCharacter.Intellect = 3;
                    myCharacter.Cunning = 2;
                    myCharacter.Willpower = 2;
                    myCharacter.Presence = 2;
                    myCharacter.WoundThreshold = 8;
                    myCharacter.StrainThreshold = 12;
                    myCharacter.TotalXP = 100;
                    myCharacter.UsedXP = 0;
                    addRankToStartingSkills("Knowledge"); //+1 Knowledge
                    //Brilliant!
                    break;
                case "The Aristocrat":
                    cboSubSpecies.Items.Clear();
                    cboSubSpecies.Items.Add("");
                    cboSubSpecies.SelectedIndex = 0;
                    myCharacter.Brawn = 1;
                    myCharacter.Agility = 2;
                    myCharacter.Intellect = 2;
                    myCharacter.Cunning = 2;
                    myCharacter.Willpower = 2;
                    myCharacter.Presence = 3;
                    myCharacter.WoundThreshold = 10;
                    myCharacter.StrainThreshold = 10;
                    myCharacter.TotalXP = 100;
                    myCharacter.UsedXP = 0;
                    addRankToStartingSkills("Cool"); //+1 Cool
                    //Forceful Personality
                    break;
                case "CatFolk":
                    cboSubSpecies.Items.Clear();
                    cboSubSpecies.Items.Add("");
                    cboSubSpecies.Items.Add("");
                    cboSubSpecies.SelectedIndex = 0;
                    addRankToStartingSkills("Perception"); //Perception +1
                    myCharacter.Brawn = 2;
                    myCharacter.Agility = 2;
                    myCharacter.Intellect = 1;
                    myCharacter.Cunning = 3;
                    myCharacter.Willpower = 2;
                    myCharacter.Presence = 2;
                    myCharacter.WoundThreshold = 9;
                    myCharacter.StrainThreshold = 8;
                    myCharacter.TotalXP = 90;
                    myCharacter.UsedXP = 15;
                    //Claws
                    //Fleet of Paw
                    break;
                case "Half CatFolk":
                    cboSubSpecies.Items.Clear();
                    cboSubSpecies.Items.Add("");
                    cboSubSpecies.Items.Add("");
                    cboSubSpecies.SelectedIndex = 0;
                    addRankToStartingSkills("Cool"); //Cool +1
                    myCharacter.Brawn = 2;
                    myCharacter.Agility = 2;
                    myCharacter.Intellect = 2;
                    myCharacter.Cunning = 2;
                    myCharacter.Willpower = 2;
                    myCharacter.Presence = 2;
                    myCharacter.WoundThreshold = 10;
                    myCharacter.StrainThreshold = 9;
                    myCharacter.TotalXP = 100;
                    myCharacter.UsedXP = 15;
                    //Claws or Fleet of Paw
                    break;
                case "Dwarf":
                    cboSubSpecies.Items.Clear();
                    cboSubSpecies.Items.Add("");
                    cboSubSpecies.Items.Add("Dunwarr Dwarf");
                    cboSubSpecies.Items.Add("Forge Dwarf");
                    cboSubSpecies.SelectedIndex = 0;
                    myCharacter.Brawn = 2;
                    myCharacter.Agility = 1;
                    myCharacter.Intellect = 2;
                    myCharacter.Cunning = 2;
                    myCharacter.Willpower = 3;
                    myCharacter.Presence = 2;
                    myCharacter.WoundThreshold = 11;
                    myCharacter.StrainThreshold = 10;
                    myCharacter.TotalXP = 90;
                    myCharacter.UsedXP = 0;
                    break;
                case "Elf":
                    cboSubSpecies.Items.Clear();
                    cboSubSpecies.Items.Add("");
                    cboSubSpecies.Items.Add("Deep Elf");
                    cboSubSpecies.Items.Add("Free Cities Elf");
                    cboSubSpecies.Items.Add("Highborn Elf");
                    cboSubSpecies.Items.Add("Lowborn Elf");
                    cboSubSpecies.SelectedIndex = 0;
                    myCharacter.Brawn = 2;
                    myCharacter.Agility = 3;
                    myCharacter.Intellect = 2;
                    myCharacter.Cunning = 2;
                    myCharacter.Willpower = 1;
                    myCharacter.Presence = 2;
                    myCharacter.WoundThreshold = 9;
                    myCharacter.StrainThreshold = 10;
                    myCharacter.TotalXP = 90;
                    myCharacter.UsedXP = 0;
                    break;
                case "Gnome":
                    cboSubSpecies.Items.Clear();
                    cboSubSpecies.Items.Add("");
                    cboSubSpecies.Items.Add("Burrow Gnome");
                    cboSubSpecies.Items.Add("Wanderer Gnome");
                    cboSubSpecies.SelectedIndex = 0;
                    myCharacter.Brawn = 1;
                    myCharacter.Agility = 2;
                    myCharacter.Intellect = 2;
                    myCharacter.Cunning = 3;
                    myCharacter.Willpower = 1;
                    myCharacter.Presence = 3;
                    myCharacter.WoundThreshold = 6;
                    myCharacter.StrainThreshold = 11;
                    myCharacter.TotalXP = 90;
                    myCharacter.UsedXP = 0;
                    //small
                    break;
                case "Orc":
                    cboSubSpecies.Items.Clear();
                    cboSubSpecies.Items.Add("");
                    cboSubSpecies.Items.Add("Broken Plains Orc");
                    cboSubSpecies.Items.Add("Stone-Dweller Orc");
                    cboSubSpecies.Items.Add("Sunderlands Orc");
                    cboSubSpecies.SelectedIndex = 0;
                    myCharacter.Brawn = 3;
                    myCharacter.Agility = 2;
                    myCharacter.Intellect = 2;
                    myCharacter.Cunning = 2;
                    myCharacter.Willpower = 2;
                    myCharacter.Presence = 1;
                    myCharacter.WoundThreshold = 12;
                    myCharacter.StrainThreshold = 8;
                    myCharacter.TotalXP = 100;
                    myCharacter.UsedXP = 0;
                    break;
            }

            updateForm();
        }

        private void cboSubSpecies_SelectedIndexChanged(object sender, EventArgs e)
        {
            myCharacter.SubSpecies = cboSubSpecies.Text;
            switch (myCharacter.SubSpecies)
            {
                case "Dunwarr Dwarf":
                    addRankToStartingSkills("Resilience"); //Resilience +1
                    myCharacter.TotalXP = 90;
                    myCharacter.UsedXP = 0;
                    //dark vision
                    //tough as nails
                    break;
                case "Forge Dwarf":
                    addRankToStartingSkills("Negotiation"); //Negotiation +1
                    myCharacter.TotalXP = 90;
                    myCharacter.UsedXP = 0;
                    //stubborn
                    //tough as nails
                    break;
                case "Deep Elf":
                    addRankToStartingSkills("Discipline"); //Discipline +1
                    addRankToStartingSkills("Forbidden"); //knowledge (forbidden) +2
                    addRankToStartingSkills("Forbidden"); //knowledge (forbidden) +2
                    MarkCareerSkill("Forbidden"); //knowledge (forbidden) career true
                    myCharacter.TotalXP = 90;
                    myCharacter.UsedXP = 0;
                    break;
                case "Free Cities Elf":
                    addRankToStartingSkills("Streetwise"); //Streetwise +1
                    myCharacter.DefenseRanged = 1;
                    myCharacter.DefenseMelee = 1;
                    myCharacter.TotalXP = 90;
                    myCharacter.UsedXP = 0;
                    break;
                case "Highborn Elf":
                    addRankToStartingSkills("Negotiation");//Negotiation +1
                    addRankToStartingSkills("Divine");//Divine +1
                    MarkCareerSkill("Divine"); //Divine career true
                    myCharacter.TotalXP = 90;
                    myCharacter.UsedXP = 0;
                    break;
                case "Lowborn Elf":
                    addRankToStartingSkills("Survival"); //Survival +1
                    myCharacter.DefenseRanged = 1;
                    myCharacter.DefenseMelee = 1;
                    myCharacter.TotalXP = 90;
                    myCharacter.UsedXP = 0;
                    break;
                case "Burrow Gnome":
                    addRankToStartingSkills("Divine"); //Divine +1
                    addRankToStartingSkills("Resilience"); //Resilience +1
                    myCharacter.TotalXP = 90;
                    myCharacter.UsedXP = 0;
                    //militia training
                    break;
                case "Wanderer Gnome":
                    addRankToStartingSkills("Charm"); //Charm +1
                    addRankToStartingSkills("Stealth");//Stealth +1
                    myCharacter.TotalXP = 90;
                    myCharacter.UsedXP = 0;
                    //tricksy
                    break;
                case "Broken Plains Orc":
                    addRankToStartingSkills("Coercion"); //Coercion +1
                    myCharacter.TotalXP = 100;
                    myCharacter.UsedXP = 0;
                    //Battle Rage
                    break;
                case "Stone-Dweller Orc":
                    addRankToStartingSkills("Cool"); //Cool +1
                    myCharacter.TotalXP = 100;
                    myCharacter.UsedXP = 0;
                    //hot tempered
                    break;
                case "Sunderlands Orc":
                    addRankToStartingSkills("Alchemy"); //Alchemy +1
                    myCharacter.TotalXP = 100;
                    myCharacter.UsedXP = 0;
                    //tenacious
                    break;
            }

            updateForm();
        }

        private void cboCareer_SelectedIndexChanged(object sender, EventArgs e)
        {
            myCharacter.Career = cboCareer.Text;
            switch (myCharacter.Career)
            {
                case "Disciple":
                    MarkCareerSkill("Athletics");
                    MarkCareerSkill("Charm");
                    MarkCareerSkill("Discipline");
                    MarkCareerSkill("Divine");
                    MarkCareerSkill("Lore");
                    MarkCareerSkill("Leadership");
                    MarkCareerSkill("Melee-Light");
                    MarkCareerSkill("Resilience");
                    //Gear:
                    //a mace
                    //a holy icon or shield and leather armor
                    //a lantern and 2 herbs of healing or traveling gear (backpack, beroll, rope, flint and steel, 3 torches, waterskin
                    //1d100 silver coins
                    break;
                case "Druid":
                    MarkCareerSkill("Athletics");
                    MarkCareerSkill("Brawl");
                    MarkCareerSkill("Coordination");
                    MarkCareerSkill("Melee");
                    MarkCareerSkill("Primal");
                    MarkCareerSkill("Resilience");
                    MarkCareerSkill("Survival");
                    MarkCareerSkill("Vigilance");
                    break;
                case "Entertainer":
                    //Charm
                    //Coordination
                    //Deception
                    //Discipline
                    //Leadership
                    //Melee
                    //Skullduggery
                    //Stealth
                    break;
                case "Envoy":
                    MarkCareerSkill("Charm");
                    MarkCareerSkill("Cool");
                    MarkCareerSkill("Deception");
                    MarkCareerSkill("Geography");
                    MarkCareerSkill("Leadership");
                    MarkCareerSkill("Melee-Light");
                    MarkCareerSkill("Resilience");
                    MarkCareerSkill("Vigilance");
                    //Gear:
                    //a dagger
                    //a sword or musical instrument
                    //a fine cloak or traveling gear (backpack, beroll, rope, flint and steel, 3 torches, waterskin
                    //padded armor
                    //200 + 1d100 silver coins
                    break;
                case "Explorer":
                    //Athletics
                    //Brawl
                    //Coordination
                    //Deception
                    //Perception
                    //Ranged (or Ranged-Heavy)
                    //Stealth
                    //Survival
                    break;
                case "Healer":
                    //Cool
                    //Discipline
                    //Knowledge
                    //Medicine
                    //Melee (or Melee-Light)
                    //Resilience
                    //Survival
                    //Vigilance
                    break;
                case "Leader":
                    //Charm
                    //Coercion
                    //Cool
                    //Discipline
                    //Leadership
                    //Melee (or Melee-Light)
                    //Negotiation
                    //Perception
                    break;
                case "Mage":
                    MarkCareerSkill("Alchemy");
                    MarkCareerSkill("Arcana");
                    MarkCareerSkill("Cool");
                    MarkCareerSkill("Discipline");
                    MarkCareerSkill("Adventuring");
                    MarkCareerSkill("Forbidden");
                    MarkCareerSkill("Lore");
                    MarkCareerSkill("Perception");
                    //Gear:
                    //a magic staff or magic wand
                    //a dagger or sling
                    //heavy robes or 1 stamina elixir
                    //1d100 silver coins
                    break;
                case "Primalist":
                    MarkCareerSkill("Alchemy");
                    MarkCareerSkill("Brawl");
                    MarkCareerSkill("Discipline");
                    MarkCareerSkill("Lore");
                    MarkCareerSkill("Medicine");
                    MarkCareerSkill("Melee-Heavy");
                    MarkCareerSkill("Primal");
                    MarkCareerSkill("Survival");
                    //Gear:
                    //a mace
                    //a holy icon or shield and leather armor
                    //a lantern and 2 herbs of healing or traveling gear (backpack, beroll, rope, flint and steel, 3 torches, waterskin
                    //1d100 silver coins
                    break;
                case "Runemaster":
                    MarkCareerSkill("Alchemy");
                    MarkCareerSkill("Cool");
                    MarkCareerSkill("Discipline");
                    MarkCareerSkill("Adventuring");
                    MarkCareerSkill("Forbidden");
                    MarkCareerSkill("Lore");
                    MarkCareerSkill("Perception");
                    MarkCareerSkill("Runes");
                    //Gear:
                    //a staff or greataxe and leather armor
                    //an apothecary's kit or traveling gear (backpack, beroll, rope, flint and steel, 3 torches, waterskin
                    //1d100 silver coins
                    break;
                case "Scholar":
                    MarkCareerSkill("Alchemy");
                    MarkCareerSkill("Forbidden");
                    MarkCareerSkill("Geography");
                    MarkCareerSkill("Lore");
                    MarkCareerSkill("Mechanics");
                    MarkCareerSkill("Medicine");
                    MarkCareerSkill("Perception");
                    MarkCareerSkill("Runes");
                    //Gear:
                    //a dagger
                    //an alchemist's kit or sword
                    //a fine cloak or traveling gear (backpack, beroll, rope, flint and steel, 3 torches, waterskin
                    //1d100 silver coins
                    break;
                case "Scoundrel":
                    MarkCareerSkill("Charm");
                    MarkCareerSkill("Cool");
                    MarkCareerSkill("Coordination");
                    MarkCareerSkill("Deception");
                    MarkCareerSkill("Ranged");
                    MarkCareerSkill("Skullduggery");
                    MarkCareerSkill("Stealth");
                    MarkCareerSkill("Streetwise");
                    //Gear:
                    //a dagger or cestus
                    //a sword and dagger or a bow
                    //a fine cloak or thieve's tools
                    //traveling gear (backpack, beroll, rope, flint and steel, 3 torches, waterskin
                    //1d100 silver coins
                    break;
                case "Scout":
                    MarkCareerSkill("Adventuring");
                    MarkCareerSkill("Geography");
                    MarkCareerSkill("Perception");
                    MarkCareerSkill("Ranged");
                    MarkCareerSkill("Riding");
                    MarkCareerSkill("Stealth");
                    MarkCareerSkill("Survival");
                    MarkCareerSkill("Vigilance");
                    //Gear:
                    //A bow or light spear and leather armor
                    //a dagger or 2 healing elixirs
                    //leather armor
                    //herbs of healing and climbing gear or winter clothing
                    //traveling gear (backpack, beroll, rope, flint and steel, 3 torches, waterskin
                    //1d100 silver coins
                    break;
                case "Socialite":
                    //Charm
                    //Cool
                    //Deception
                    //Knowledge
                    //Negotiation
                    //Perception
                    //Streetwise
                    //Vigilance
                    break;
                case "Soldier":
                    //Athletics
                    //Brawl (or Gunnery)
                    //Coercion
                    //Melee (or Melee-Heavy)
                    //Perception
                    //Ranged (or Ranged-Heavy
                    //Survival
                    //Vigilance
                    break;
                case "Tradesperson":
                    //Athletics
                    //Brawl
                    //Discipline
                    //Mechanics
                    //Negotiation
                    //Perception
                    //Resilience
                    //Streetwise
                    break;
                case "Warrior":
                    MarkCareerSkill("Brawl");
                    MarkCareerSkill("Coercion");
                    MarkCareerSkill("Leadership");
                    MarkCareerSkill("Melee-Heavy");
                    MarkCareerSkill("Melee-Light");
                    MarkCareerSkill("Resilience");
                    MarkCareerSkill("Riding");
                    MarkCareerSkill("Vigilance");
                    //Gear:
                    //A sword and shield or an axe and shield or a halberd
                    //Leather armor
                    //2 healing elixirs
                    //traveling gear (backpack, beroll, rope, flint and steel, 3 torches, waterskin
                    //1d100 silver coins
                    break;
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            Button myButton;
            myButton = (Button)sender;


            int buttonNumber = int.Parse(myButton.Name.Substring(4));
            switch (buttonNumber)
            {
                case 1:
                    if (myCharacter.Brawn < 5)
                    {
                        myCharacter.Brawn += 1;
                        myCharacter.UsedXP += myCharacter.Brawn * 10;
                    }
                    break;
                case 2:
                    if (myCharacter.Agility < 5)
                    {
                        myCharacter.Agility += 1;
                        myCharacter.UsedXP += myCharacter.Agility * 10;
                    }
                    break;
                case 3:
                    if (myCharacter.Intellect < 5)
                    {
                        myCharacter.Intellect += 1;
                        myCharacter.UsedXP += myCharacter.Intellect * 10;
                    }
                    break;
                case 4:
                    if (myCharacter.Cunning < 5)
                    {
                        myCharacter.Cunning += 1;
                        myCharacter.UsedXP += myCharacter.Cunning * 10;
                    }
                    break;
                case 5:
                    if (myCharacter.Willpower < 5)
                    {
                        myCharacter.Willpower += 1;
                        myCharacter.UsedXP += myCharacter.Willpower * 10;
                    }
                    break;
                case 6:
                    if (myCharacter.Presence < 5)
                    {
                        myCharacter.Presence += 1;
                        myCharacter.UsedXP += myCharacter.Presence * 10;
                    }
                    break;
            }
            updateForm();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            Button myButton;
            myButton = (Button)sender;

            int buttonNumber = int.Parse(myButton.Name.Substring(4));
            switch (buttonNumber)
            {
                case 1:
                    if (myCharacter.Brawn > 1)
                    {
                        myCharacter.UsedXP -= myCharacter.Brawn * 10;
                        myCharacter.Brawn -= 1;
                    }
                    break;
                case 2:
                    if (myCharacter.Agility > 1)
                    {
                        myCharacter.UsedXP -= myCharacter.Agility * 10;
                        myCharacter.Agility -= 1;
                    }
                    break;
                case 3:
                    if (myCharacter.Intellect > 1)
                    {
                        myCharacter.UsedXP -= myCharacter.Intellect * 10;
                        myCharacter.Intellect -= 1;
                    }
                    break;
                case 4:
                    if (myCharacter.Cunning > 1)
                    {
                        myCharacter.UsedXP -= myCharacter.Cunning * 10;
                        myCharacter.Cunning -= 1;
                    }
                    break;
                case 5:
                    if (myCharacter.Willpower > 1)
                    {
                        myCharacter.UsedXP -= myCharacter.Willpower * 10;
                        myCharacter.Willpower -= 1;
                    }
                    break;
                case 6:
                    if (myCharacter.Presence > 1)
                    {
                        myCharacter.UsedXP -= myCharacter.Presence * 10;
                        myCharacter.Presence -= 1;
                    }
                    break;
            }
            updateForm();
        }

        private void updateLabelColors()
        {
            switch (myCharacter.Setting)
            {
                case "Android":
                    lblBrawnLabel.ForeColor = Color.Blue;
                    lblAgilityLabel.ForeColor = Color.Blue;
                    lblIntellectLabel.ForeColor = Color.Blue;
                    lblCunningLabel.ForeColor = Color.Blue;
                    lblWillpowerLabel.ForeColor = Color.Blue;
                    lblPresenceLabel.ForeColor = Color.Blue;
                    lblSoakLabel.ForeColor = Color.Blue;
                    lblWoundsLabel.ForeColor = Color.Blue;
                    lblStrainLabel.ForeColor = Color.Blue;
                    lblDefenseLabel.ForeColor = Color.Blue;
                    lblWoundT.ForeColor = Color.Blue;
                    lblWoundCurrent.ForeColor = Color.Blue;
                    lblStrainT.ForeColor = Color.Blue;
                    lblStrainCurrent.ForeColor = Color.Blue;
                    lblDefenseMeleeLabel.ForeColor = Color.Blue;
                    lblDefenseRangedLabel.ForeColor = Color.Blue;
                    lblTotalXPLabel.ForeColor = Color.Blue;
                    lblRemainingXPLabel.ForeColor = Color.Blue;
                    lblBrawnLabel.Visible = false;
                    lblAgilityLabel.Visible = false;
                    lblIntellectLabel.Visible = false;
                    lblCunningLabel.Visible = false;
                    lblWillpowerLabel.Visible = false;
                    lblPresenceLabel.Visible = false;
                    lblSoakLabel.Visible = false;
                    lblWoundsLabel.Visible = false;
                    lblStrainLabel.Visible = false;
                    lblDefenseLabel.Visible = false;
                    lblWoundT.Visible = true;
                    lblWoundCurrent.Visible = true;
                    lblStrainT.Visible = true;
                    lblStrainCurrent.Visible = true;
                    lblDefenseMeleeLabel.Visible = true;
                    lblDefenseRangedLabel.Visible = true;
                    lblTotalXPLabel.Visible = false;
                    lblRemainingXPLabel.Visible = false;
                    break;
                case "Terrinoth":
                    lblBrawnLabel.ForeColor = Color.White;
                    lblAgilityLabel.ForeColor = Color.White;
                    lblIntellectLabel.ForeColor = Color.White;
                    lblCunningLabel.ForeColor = Color.White;
                    lblWillpowerLabel.ForeColor = Color.White;
                    lblPresenceLabel.ForeColor = Color.White;
                    lblSoakLabel.ForeColor = Color.White;
                    lblWoundsLabel.ForeColor = Color.White;
                    lblStrainLabel.ForeColor = Color.White;
                    lblDefenseLabel.ForeColor = Color.White;
                    lblWoundT.ForeColor = Color.White;
                    lblWoundCurrent.ForeColor = Color.White;
                    lblStrainT.ForeColor = Color.White;
                    lblStrainCurrent.ForeColor = Color.White;
                    lblDefenseMeleeLabel.ForeColor = Color.White;
                    lblDefenseRangedLabel.ForeColor = Color.White;
                    lblTotalXPLabel.ForeColor = Color.White;
                    lblRemainingXPLabel.ForeColor = Color.White;
                    lblBrawnLabel.Visible = true;
                    lblAgilityLabel.Visible = true;
                    lblIntellectLabel.Visible = true;
                    lblCunningLabel.Visible = true;
                    lblWillpowerLabel.Visible = true;
                    lblPresenceLabel.Visible = true;
                    lblSoakLabel.Visible = true;
                    lblWoundsLabel.Visible = true;
                    lblStrainLabel.Visible = true;
                    lblDefenseLabel.Visible = true;
                    lblWoundT.Visible = true;
                    lblWoundCurrent.Visible = true;
                    lblStrainT.Visible = true;
                    lblStrainCurrent.Visible = true;
                    lblDefenseMeleeLabel.Visible = true;
                    lblDefenseRangedLabel.Visible = true;
                    lblTotalXPLabel.Visible = true;
                    lblRemainingXPLabel.Visible = true;
                    break;
            }
        }

        private void addRankToStartingSkills(string skillToCheck)
        {
            for (int i = 0; i < myCharacter.Skills.Length; i++)
            {
                if (myCharacter.Skills[i].SkillName == skillToCheck)
                {
                    myCharacter.Skills[i].Rank += 1;
                }
            }
        }

        private void MarkCareerSkill(string skillToCheck)
        {
            for (int i = 0; i < myCharacter.Skills.Length; i++)
            {
                if (myCharacter.Skills[i].SkillName == skillToCheck)
                {
                    myCharacter.Skills[i].Career = true;
                }
            }
        }

        private void updateSkills()
        {
            linkSkill0.Text = myCharacter.Skills[0].SkillName + " (" + myCharacter.Skills[0].Characteristic + ")";
            linkSkill1.Text = myCharacter.Skills[1].SkillName + " (" + myCharacter.Skills[1].Characteristic + ")";
            linkSkill2.Text = myCharacter.Skills[2].SkillName + " (" + myCharacter.Skills[2].Characteristic + ")";
            linkSkill3.Text = myCharacter.Skills[3].SkillName + " (" + myCharacter.Skills[3].Characteristic + ")";
            linkSkill4.Text = myCharacter.Skills[4].SkillName + " (" + myCharacter.Skills[4].Characteristic + ")";
            linkSkill5.Text = myCharacter.Skills[5].SkillName + " (" + myCharacter.Skills[5].Characteristic + ")";
            linkSkill6.Text = myCharacter.Skills[6].SkillName + " (" + myCharacter.Skills[6].Characteristic + ")";
            linkSkill7.Text = myCharacter.Skills[7].SkillName + " (" + myCharacter.Skills[7].Characteristic + ")";
            linkSkill8.Text = myCharacter.Skills[8].SkillName + " (" + myCharacter.Skills[8].Characteristic + ")";
            linkSkill9.Text = myCharacter.Skills[9].SkillName + " (" + myCharacter.Skills[9].Characteristic + ")";
            linkSkill10.Text = myCharacter.Skills[10].SkillName + " (" + myCharacter.Skills[10].Characteristic + ")";
            linkSkill11.Text = myCharacter.Skills[11].SkillName + " (" + myCharacter.Skills[11].Characteristic + ")";
            linkSkill12.Text = myCharacter.Skills[12].SkillName + " (" + myCharacter.Skills[12].Characteristic + ")";
            linkSkill13.Text = myCharacter.Skills[13].SkillName + " (" + myCharacter.Skills[13].Characteristic + ")";
            linkSkill14.Text = myCharacter.Skills[14].SkillName + " (" + myCharacter.Skills[14].Characteristic + ")";
            linkSkill15.Text = myCharacter.Skills[15].SkillName + " (" + myCharacter.Skills[15].Characteristic + ")";
            linkSkill16.Text = myCharacter.Skills[16].SkillName + " (" + myCharacter.Skills[16].Characteristic + ")";
            linkSkill17.Text = myCharacter.Skills[17].SkillName + " (" + myCharacter.Skills[17].Characteristic + ")";
            linkSkill18.Text = myCharacter.Skills[18].SkillName + " (" + myCharacter.Skills[18].Characteristic + ")";
            linkSkill19.Text = myCharacter.Skills[19].SkillName + " (" + myCharacter.Skills[19].Characteristic + ")";
            linkSkill20.Text = myCharacter.Skills[20].SkillName + " (" + myCharacter.Skills[20].Characteristic + ")";
            linkSkill21.Text = myCharacter.Skills[21].SkillName + " (" + myCharacter.Skills[21].Characteristic + ")";
            linkSkill22.Text = myCharacter.Skills[22].SkillName + " (" + myCharacter.Skills[22].Characteristic + ")";
            linkSkill23.Text = myCharacter.Skills[23].SkillName + " (" + myCharacter.Skills[23].Characteristic + ")";
            linkSkill24.Text = myCharacter.Skills[24].SkillName + " (" + myCharacter.Skills[24].Characteristic + ")";
            linkSkill25.Text = myCharacter.Skills[25].SkillName + " (" + myCharacter.Skills[25].Characteristic + ")";
            linkSkill26.Text = myCharacter.Skills[26].SkillName + " (" + myCharacter.Skills[26].Characteristic + ")";
            linkSkill27.Text = myCharacter.Skills[27].SkillName + " (" + myCharacter.Skills[27].Characteristic + ")";
            linkSkill28.Text = myCharacter.Skills[28].SkillName + " (" + myCharacter.Skills[28].Characteristic + ")";
            linkSkill29.Text = myCharacter.Skills[29].SkillName + " (" + myCharacter.Skills[29].Characteristic + ")";
            linkSkill30.Text = myCharacter.Skills[30].SkillName + " (" + myCharacter.Skills[30].Characteristic + ")";
            linkSkill31.Text = myCharacter.Skills[31].SkillName + " (" + myCharacter.Skills[31].Characteristic + ")";
            linkSkill32.Text = myCharacter.Skills[32].SkillName + " (" + myCharacter.Skills[32].Characteristic + ")";
            linkSkill33.Text = myCharacter.Skills[33].SkillName + " (" + myCharacter.Skills[33].Characteristic + ")";
            linkSkill34.Text = myCharacter.Skills[34].SkillName + " (" + myCharacter.Skills[34].Characteristic + ")";
            linkSkill35.Text = myCharacter.Skills[35].SkillName + " (" + myCharacter.Skills[35].Characteristic + ")";
            linkSkill36.Text = myCharacter.Skills[36].SkillName + " (" + myCharacter.Skills[36].Characteristic + ")";
            linkSkill37.Text = myCharacter.Skills[37].SkillName + " (" + myCharacter.Skills[37].Characteristic + ")";
            linkSkill38.Text = myCharacter.Skills[38].SkillName + " (" + myCharacter.Skills[38].Characteristic + ")";
            linkSkill39.Text = myCharacter.Skills[39].SkillName + " (" + myCharacter.Skills[39].Characteristic + ")";
            linkSkill40.Text = myCharacter.Skills[40].SkillName + " (" + myCharacter.Skills[40].Characteristic + ")";
            linkSkill41.Text = myCharacter.Skills[41].SkillName + " (" + myCharacter.Skills[41].Characteristic + ")";
            linkSkill42.Text = myCharacter.Skills[42].SkillName + " (" + myCharacter.Skills[42].Characteristic + ")";
            linkSkill43.Text = myCharacter.Skills[43].SkillName + " (" + myCharacter.Skills[43].Characteristic + ")";
        }

        private void updateTalents()
        {
            linkTalent0.Text = myCharacter.Talents[0].TalentName; // tier 1
            linkTalent1.Text = myCharacter.Talents[1].TalentName;
            if (myCharacter.Talents[0].TalentName != "Talent")
            {
                panelTalent1.Visible = true;
            }
            linkTalent2.Text = myCharacter.Talents[2].TalentName;
            if (myCharacter.Talents[1].TalentName != "Talent")
            {
                panelTalent2.Visible = true;
            }
            linkTalent3.Text = myCharacter.Talents[3].TalentName;
            if (myCharacter.Talents[2].TalentName != "Talent")
            {
                panelTalent3.Visible = true;
            }
            linkTalent4.Text = myCharacter.Talents[4].TalentName;
            if (myCharacter.Talents[3].TalentName != "Talent")
            {
                panelTalent4.Visible = true;
            }
            linkTalent5.Text = myCharacter.Talents[5].TalentName;
            if (myCharacter.Talents[4].TalentName != "Talent")
            {
                panelTalent5.Visible = true;
            }
            linkTalent6.Text = myCharacter.Talents[6].TalentName;
            if (myCharacter.Talents[5].TalentName != "Talent")
            {
                panelTalent6.Visible = true;
            }
            linkTalent7.Text = myCharacter.Talents[7].TalentName; //tier 2
            if (myCharacter.Talents[1].TalentName != "Talent")
            {
                panelTalent7.Visible = true;
            }
            linkTalent8.Text = myCharacter.Talents[8].TalentName;
            if (myCharacter.Talents[2].TalentName != "Talent" && myCharacter.Talents[7].TalentName != "Talent")
            {
                panelTalent8.Visible = true;
            }
            linkTalent9.Text = myCharacter.Talents[9].TalentName;
            if (myCharacter.Talents[3].TalentName != "Talent" && myCharacter.Talents[8].TalentName != "Talent")
            {
                panelTalent9.Visible = true;
            }
            linkTalent10.Text = myCharacter.Talents[10].TalentName;
            if (myCharacter.Talents[4].TalentName != "Talent" && myCharacter.Talents[9].TalentName != "Talent")
            {
                panelTalent10.Visible = true;
            }
            linkTalent11.Text = myCharacter.Talents[11].TalentName;
            if (myCharacter.Talents[5].TalentName != "Talent" && myCharacter.Talents[10].TalentName != "Talent")
            {
                panelTalent11.Visible = true;
            }
            linkTalent12.Text = myCharacter.Talents[12].TalentName;
            if (myCharacter.Talents[6].TalentName != "Talent" && myCharacter.Talents[11].TalentName != "Talent")
            {
                panelTalent12.Visible = true;
            }
            linkTalent13.Text = myCharacter.Talents[13].TalentName; //tier 3
            if (myCharacter.Talents[8].TalentName != "Talent")
            {
                panelTalent13.Visible = true;
            }
            linkTalent14.Text = myCharacter.Talents[14].TalentName;
            if (myCharacter.Talents[9].TalentName != "Talent" && myCharacter.Talents[13].TalentName != "Talent")
            {
                panelTalent14.Visible = true;
            }
            linkTalent15.Text = myCharacter.Talents[15].TalentName;
            if (myCharacter.Talents[10].TalentName != "Talent" && myCharacter.Talents[14].TalentName != "Talent")
            {
                panelTalent15.Visible = true;
            }
            linkTalent16.Text = myCharacter.Talents[16].TalentName;
            if (myCharacter.Talents[11].TalentName != "Talent" && myCharacter.Talents[15].TalentName != "Talent")
            {
                panelTalent16.Visible = true;
            }
            linkTalent17.Text = myCharacter.Talents[17].TalentName;
            if (myCharacter.Talents[12].TalentName != "Talent" && myCharacter.Talents[16].TalentName != "Talent")
            {
                panelTalent17.Visible = true;
            }
            linkTalent18.Text = myCharacter.Talents[18].TalentName; //tier 4
            if (myCharacter.Talents[14].TalentName != "Talent")
            {
                panelTalent18.Visible = true;
            }
            linkTalent19.Text = myCharacter.Talents[19].TalentName;
            if (myCharacter.Talents[15].TalentName != "Talent" && myCharacter.Talents[18].TalentName != "Talent")
            {
                panelTalent19.Visible = true;
            }
            linkTalent20.Text = myCharacter.Talents[20].TalentName;
            if (myCharacter.Talents[16].TalentName != "Talent" && myCharacter.Talents[19].TalentName != "Talent")
            {
                panelTalent20.Visible = true;
            }
            linkTalent21.Text = myCharacter.Talents[21].TalentName;
            if (myCharacter.Talents[17].TalentName != "Talent" && myCharacter.Talents[20].TalentName != "Talent")
            {
                panelTalent21.Visible = true;
            }
            linkTalent22.Text = myCharacter.Talents[22].TalentName; //tier 5
            if (myCharacter.Talents[19].TalentName != "Talent")
            {
                panelTalent22.Visible = true;
            }
            linkTalent23.Text = myCharacter.Talents[23].TalentName;
            if (myCharacter.Talents[20].TalentName != "Talent" && myCharacter.Talents[22].TalentName != "Talent")
            {
                panelTalent23.Visible = true;
            }
            linkTalent24.Text = myCharacter.Talents[24].TalentName;
            if (myCharacter.Talents[21].TalentName != "Talent" && myCharacter.Talents[23].TalentName != "Talent")
            {
                panelTalent24.Visible = true;
            }

            lblTalentPage0.Text = myCharacter.Talents[0].Page;
            lblTalentPage1.Text = myCharacter.Talents[1].Page;
            lblTalentPage2.Text = myCharacter.Talents[2].Page;
            lblTalentPage3.Text = myCharacter.Talents[3].Page;
            lblTalentPage4.Text = myCharacter.Talents[4].Page;
            lblTalentPage5.Text = myCharacter.Talents[5].Page;
            lblTalentPage6.Text = myCharacter.Talents[6].Page;
            lblTalentPage7.Text = myCharacter.Talents[7].Page;
            lblTalentPage8.Text = myCharacter.Talents[8].Page;
            lblTalentPage9.Text = myCharacter.Talents[9].Page;
            lblTalentPage10.Text = myCharacter.Talents[10].Page;
            lblTalentPage11.Text = myCharacter.Talents[11].Page;
            lblTalentPage12.Text = myCharacter.Talents[12].Page;
            lblTalentPage13.Text = myCharacter.Talents[13].Page;
            lblTalentPage14.Text = myCharacter.Talents[14].Page;
            lblTalentPage15.Text = myCharacter.Talents[15].Page;
            lblTalentPage16.Text = myCharacter.Talents[16].Page;
            lblTalentPage17.Text = myCharacter.Talents[17].Page;
            lblTalentPage18.Text = myCharacter.Talents[18].Page;
            lblTalentPage19.Text = myCharacter.Talents[19].Page;
            lblTalentPage20.Text = myCharacter.Talents[20].Page;
            lblTalentPage21.Text = myCharacter.Talents[21].Page;
            lblTalentPage22.Text = myCharacter.Talents[22].Page;
            lblTalentPage23.Text = myCharacter.Talents[23].Page;
            lblTalentPage24.Text = myCharacter.Talents[24].Page;
        }

        private void linkSkill_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelSkillDetail.Visible = true;
            chkCareer.Checked = false;

            LinkLabel myLink;
            myLink = (LinkLabel)sender;
            int skillLinkNumber = int.Parse(myLink.Name.Substring(9));
            txtSkill.Text = myCharacter.Skills[skillLinkNumber].SkillName;
            cboCharacteristic.Text = myCharacter.Skills[skillLinkNumber].Characteristic;
            txtSkillDescription.Text = myCharacter.Skills[skillLinkNumber].Description;
            
            activeSkillLink = skillLinkNumber;
            if (myCharacter.Skills[activeSkillLink].Career == true)
            {
                chkCareer.Checked = true;
            }
            lblSkillRank.Text = myCharacter.Skills[activeSkillLink].Rank.ToString();

            //myCharacter.Skills[skillLinkNumber].SkillName = txtSkill.Text;
            //myCharacter.Skills[skillLinkNumber].Characteristic = cboCharacteristic.Text;
            //myCharacter.Skills[skillLinkNumber].Description = txtSkillDescription.Text;

            updateForm();
        }

        private void btnSkillPlus_Click(object sender, EventArgs e)
        {
            lblSkillRank.Text = myCharacter.Skills[activeSkillLink].Rank.ToString();

            if (myCharacter.Skills[activeSkillLink].Rank == 0)
            {
                careerSkillsNum++;
            }
            if (careerSkillsNum <= 4 
                && myCharacter.Skills[activeSkillLink].Rank == 0
                && myCharacter.Skills[activeSkillLink].Career == true)
            {
                myCharacter.Skills[activeSkillLink].Rank++;
                lblSkillRank.Text = myCharacter.Skills[activeSkillLink].Rank.ToString();
                updateForm();
            }
            else
            {
                if (myCharacter.Skills[activeSkillLink].Rank < 5)
                {
                    myCharacter.Skills[activeSkillLink].Rank++;
                    myCharacter.UsedXP += myCharacter.Skills[activeSkillLink].Rank * 5;
                    if (myCharacter.Skills[activeSkillLink].Career == false)
                    {
                        myCharacter.UsedXP += 5;
                    }
                }
                lblSkillRank.Text = myCharacter.Skills[activeSkillLink].Rank.ToString();
                updateForm();
            }
        }
        //need to update to account for free rank in first four career skills
        private void btnSkillMinus_Click(object sender, EventArgs e)
        {
            lblSkillRank.Text = myCharacter.Skills[activeSkillLink].Rank.ToString();
            if (myCharacter.Skills[activeSkillLink].Rank > 0)
            {
                myCharacter.UsedXP -= myCharacter.Skills[activeSkillLink].Rank * 5;
                myCharacter.Skills[activeSkillLink].Rank--;
                if (myCharacter.Skills[activeSkillLink].Career == false)
                {
                    myCharacter.UsedXP -= 5;
                }
            }
            lblSkillRank.Text = myCharacter.Skills[activeSkillLink].Rank.ToString();
            updateForm();
        }

        private void linkTalent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panelTalentDetail.Visible = true;

            LinkLabel myLink;
            myLink = (LinkLabel)sender;
            int talentLinkNumber = int.Parse(myLink.Name.Substring(10));
            txtTalentName.Text = myCharacter.Talents[talentLinkNumber].TalentName;
            lblTalentTier.Text = "Tier: " + myCharacter.Talents[talentLinkNumber].Tier.ToString();
            txtTalentDescription.Text = myCharacter.Talents[talentLinkNumber].TalentDescription;
            txtTalentPageNumber.Text = myCharacter.Talents[talentLinkNumber].Page.ToString();
            activeTalentLink = talentLinkNumber;
        }

        private void updateXP()
        {
            myCharacter.RemainXP = myCharacter.TotalXP - myCharacter.UsedXP;
            lblXPTotal.Text = myCharacter.TotalXP.ToString();
            lblXPRemaining.Text = myCharacter.RemainXP.ToString();
        }

        private void updateForm()
        {
            lblBrawnVal.Text = myCharacter.Brawn.ToString();
            lblAgilityVal.Text = myCharacter.Agility.ToString();
            lblIntellectVal.Text = myCharacter.Intellect.ToString();
            lblCunningVal.Text = myCharacter.Cunning.ToString();
            lblWillpowerVal.Text = myCharacter.Willpower.ToString();
            lblPresenceVal.Text = myCharacter.Presence.ToString();
            lblSoak.Text = myCharacter.Soak.ToString();
            lblWoundThreshold.Text = myCharacter.WoundThreshold.ToString();
            lblStrainThreshold.Text = myCharacter.StrainThreshold.ToString();
            lblDefenseMelee.Text = myCharacter.DefenseMelee.ToString();
            lblDefenseRanged.Text = myCharacter.DefenseRanged.ToString();
            lblXPTotal.Text = myCharacter.TotalXP.ToString();
            lblXPRemaining.Text = myCharacter.RemainXP.ToString();

            updateXP();
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

        private void btnSkills_Click(object sender, EventArgs e)
        {
            panelSkills.Visible = true;
            panelTalents.Visible = false;
            panelGear.Visible = false;
        }

        private void btnSkillsSave_Click(object sender, EventArgs e)
        {
            myCharacter.Skills[activeSkillLink].SkillName = txtSkill.Text;
            myCharacter.Skills[activeSkillLink].Characteristic = cboCharacteristic.Text;
            myCharacter.Skills[activeSkillLink].Description = txtSkillDescription.Text;
            if (chkCareer.Checked == true)
            {
                myCharacter.Skills[activeSkillLink].Career = true;
            }

            updateSkills();
        }

        private void btnSkillsCancel_Click(object sender, EventArgs e)
        {
            panelSkillDetail.Visible = false;
        }

        private void btnTalents_Click(object sender, EventArgs e)
        {
            panelSkills.Visible = false;
            panelTalents.Visible = true;
            panelGear.Visible = false;
        }

        //need to set bool for this field so changing name of talent doesn't update cost
        private void btnTalentSave_Click(object sender, EventArgs e)
        {
            string talentChanged = myCharacter.Talents[activeTalentLink].TalentName;
            myCharacter.Talents[activeTalentLink].TalentName = txtTalentName.Text;
            myCharacter.Talents[activeTalentLink].TalentDescription = txtTalentDescription.Text;
            myCharacter.Talents[activeTalentLink].Page = txtTalentPageNumber.Text;

            if (myCharacter.Talents[activeTalentLink].TalentName != "Talent" && talentChanged == "Talent")
            {
                myCharacter.UsedXP += 5 * myCharacter.Talents[activeTalentLink].Tier;
                updateXP();
            }
            
            updateTalents();
        }

        private void btnTalentCancel_Click(object sender, EventArgs e)
        {
            panelTalentDetail.Visible = false;
        }

        private void lblGear_Click(object sender, EventArgs e)
        {
            panelSkills.Visible = false;
            panelTalents.Visible = false;
            panelGear.Visible = true;

            loadGearTab();
        }

        private void btnGearSave_Click(object sender, EventArgs e)
        {
            myCharacter.Weapons[0].WeaponName = txtWeapon0.Text;
            myCharacter.Weapons[1].WeaponName = txtWeapon1.Text;
            myCharacter.Weapons[2].WeaponName = txtWeapon2.Text;
            myCharacter.Weapons[3].WeaponName = txtWeapon3.Text;

            myCharacter.Weapons[0].WeaponSkill = txtWeaponSkill0.Text;
            myCharacter.Weapons[1].WeaponSkill = txtWeaponSkill1.Text;
            myCharacter.Weapons[2].WeaponSkill = txtWeaponSkill2.Text;
            myCharacter.Weapons[3].WeaponSkill = txtWeaponSkill3.Text;

            myCharacter.Weapons[0].WeaponDamage = txtWeaponDamage0.Text;
            myCharacter.Weapons[1].WeaponDamage = txtWeaponDamage1.Text;
            myCharacter.Weapons[2].WeaponDamage = txtWeaponDamage2.Text;
            myCharacter.Weapons[3].WeaponDamage = txtWeaponDamage3.Text;

            myCharacter.Weapons[0].WeaponCrit = txtWeaponCrit0.Text;
            myCharacter.Weapons[1].WeaponCrit = txtWeaponCrit1.Text;
            myCharacter.Weapons[2].WeaponCrit = txtWeaponCrit2.Text;
            myCharacter.Weapons[3].WeaponCrit = txtWeaponCrit3.Text;

            myCharacter.Weapons[0].WeaponRange = txtWeaponRange0.Text;
            myCharacter.Weapons[1].WeaponRange = txtWeaponRange1.Text;
            myCharacter.Weapons[2].WeaponRange = txtWeaponRange2.Text;
            myCharacter.Weapons[3].WeaponRange = txtWeaponRange3.Text;

            myCharacter.Weapons[0].WeaponSpecial = txtWeaponSpecial0.Text;
            myCharacter.Weapons[1].WeaponSpecial = txtWeaponSpecial1.Text;
            myCharacter.Weapons[2].WeaponSpecial = txtWeaponSpecial2.Text;
            myCharacter.Weapons[3].WeaponSpecial = txtWeaponSpecial3.Text;

            myCharacter.WeaponsAndArmor = txtWeaponsAndArmor.Text;
            myCharacter.PersonalGear = txtPersonalGear.Text;
            myCharacter.Currency = txtCurrency.Text;
        }

        private void btnGearCancel_Click(object sender, EventArgs e)
        {
            loadGearTab();
        }

        private void loadGearTab()
        {
            txtWeapon0.Text = myCharacter.Weapons[0].WeaponName;
            txtWeapon1.Text = myCharacter.Weapons[1].WeaponName;
            txtWeapon2.Text = myCharacter.Weapons[2].WeaponName;
            txtWeapon3.Text = myCharacter.Weapons[3].WeaponName;

            txtWeaponSkill0.Text = myCharacter.Weapons[0].WeaponSkill;
            txtWeaponSkill1.Text = myCharacter.Weapons[1].WeaponSkill;
            txtWeaponSkill2.Text = myCharacter.Weapons[2].WeaponSkill;
            txtWeaponSkill3.Text = myCharacter.Weapons[3].WeaponSkill;

            txtWeaponDamage0.Text = myCharacter.Weapons[0].WeaponDamage;
            txtWeaponDamage1.Text = myCharacter.Weapons[1].WeaponDamage;
            txtWeaponDamage2.Text = myCharacter.Weapons[2].WeaponDamage;
            txtWeaponDamage3.Text = myCharacter.Weapons[3].WeaponDamage;

            txtWeaponCrit0.Text = myCharacter.Weapons[0].WeaponCrit;
            txtWeaponCrit1.Text = myCharacter.Weapons[1].WeaponCrit;
            txtWeaponCrit2.Text = myCharacter.Weapons[2].WeaponCrit;
            txtWeaponCrit3.Text = myCharacter.Weapons[3].WeaponCrit;

            txtWeaponRange0.Text = myCharacter.Weapons[0].WeaponRange;
            txtWeaponRange1.Text = myCharacter.Weapons[1].WeaponRange;
            txtWeaponRange2.Text = myCharacter.Weapons[2].WeaponRange;
            txtWeaponRange3.Text = myCharacter.Weapons[3].WeaponRange;

            txtWeaponSpecial0.Text = myCharacter.Weapons[0].WeaponSpecial;
            txtWeaponSpecial1.Text = myCharacter.Weapons[1].WeaponSpecial;
            txtWeaponSpecial2.Text = myCharacter.Weapons[2].WeaponSpecial;
            txtWeaponSpecial3.Text = myCharacter.Weapons[3].WeaponSpecial;

            txtWeaponsAndArmor.Text = myCharacter.WeaponsAndArmor;
            txtPersonalGear.Text = myCharacter.PersonalGear;
            txtCurrency.Text = myCharacter.Currency;
        }
    }

}
