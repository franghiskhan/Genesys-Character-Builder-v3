using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace Genesys_Character_Builder
{
    public partial class frmGenesys : Form
    {
        public frmGenesys()
        {
            InitializeComponent();
        }
        //constants
        private const int NUM_SKILLS = 44;
        private const int NUM_TALENTS = 25;
        private const int NUM_TALENT_TIERS = 5;
        //static counters
        private static int activeSkillLink;
        private static int activeTalentLink;
        private static int careerSkillsNum = 0;
        
        //myCharacter: object to store all character details
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
            MotivationBackground = "",

            Gender = "",
            Age = "",
            Height = "",
            Build = "",
            Hair = "",
            Eyes = "",
            Features = "",
        };

        //private LinkLabel[] skillLinks = new LinkLabel[NUM_SKILLS];

        //array of Terrinoth skills
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

        //array of android skills
        private SkillsTemplate[] androidSkills = new SkillsTemplate[]
        {
            //general
            new SkillsTemplate("Athletics", "Br", "TalentDescription", false, 0), //0
            new SkillsTemplate("Computers-Hacking", "Int", "TalentDescription", false, 0), //1
            new SkillsTemplate("Computers-SysOps", "Int", "TalentDescription", false, 0), //2
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
            new SkillsTemplate("Ranged-Heavy", "Ag", "TalentDescription", false, 0), //25
            new SkillsTemplate("Ranged-Light", "Ag", "TalentDescription", false, 0), //26
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

        //array for storing talents
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

        //array for storing weapons
        private WeaponsTemplate[] weaponsList =
        {
            new WeaponsTemplate("", "", "", "", "", ""),
            new WeaponsTemplate("", "", "", "", "", ""),
            new WeaponsTemplate("", "", "", "", "", ""),
            new WeaponsTemplate("", "", "", "", "", "")
        };

        //array for storing skill rank text
        //used by redrawSkillRanks function
        private Label[] skillRanksDisplay = new Label[NUM_SKILLS];
        private PictureBox[] skillsTest = new PictureBox[5];

        //load event
        private void frmGenesys_Load(object sender, EventArgs e)
        {
            cboSetting.Items.Clear();
            cboSetting.Items.Add("Android");
            cboSetting.Items.Add("Terrinoth");
            //cboSetting.Items.Add("Kirinioth");
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
            txtWoundsCurrent.Text = myCharacter.WoundCurrent.ToString();
            lblStrainThreshold.Text = myCharacter.StrainThreshold.ToString();
            txtStrainCurrent.Text = myCharacter.StrainCurrent.ToString();
            lblDefenseMelee.Text = myCharacter.DefenseMelee.ToString();
            lblDefenseRanged.Text = myCharacter.DefenseRanged.ToString();

            /*
            skillsTest[0] = this.pictureBox1;
            skillsTest[1] = this.pictureBox2;
            skillsTest[2] = this.pictureBox3;
            skillsTest[3] = this.pictureBox4;
            skillsTest[4] = this.pictureBox5;
            */

            skillRanksDisplay[0] = this.lblGreenRank0;
            skillRanksDisplay[1] = this.lblGreenRank1;
            skillRanksDisplay[2] = this.lblGreenRank2;
            skillRanksDisplay[3] = this.lblGreenRank3;
            skillRanksDisplay[4] = this.lblGreenRank4;
            skillRanksDisplay[5] = this.lblGreenRank5;
            skillRanksDisplay[6] = this.lblGreenRank6;
            skillRanksDisplay[7] = this.lblGreenRank7;
            skillRanksDisplay[8] = this.lblGreenRank8;
            skillRanksDisplay[9] = this.lblGreenRank9;
            skillRanksDisplay[10] = this.lblGreenRank10;
            skillRanksDisplay[11] = this.lblGreenRank11;
            skillRanksDisplay[12] = this.lblGreenRank12;
            skillRanksDisplay[13] = this.lblGreenRank13;
            skillRanksDisplay[14] = this.lblGreenRank14;
            skillRanksDisplay[15] = this.lblGreenRank15;
            skillRanksDisplay[16] = this.lblGreenRank16;
            skillRanksDisplay[17] = this.lblGreenRank17;
            skillRanksDisplay[18] = this.lblGreenRank18;
            skillRanksDisplay[19] = this.lblGreenRank19;
            skillRanksDisplay[20] = this.lblGreenRank20;
            skillRanksDisplay[21] = this.lblGreenRank21;
            skillRanksDisplay[22] = this.lblGreenRank22;
            skillRanksDisplay[23] = this.lblGreenRank23;
            skillRanksDisplay[24] = this.lblGreenRank24;
            skillRanksDisplay[25] = this.lblGreenRank25;
            skillRanksDisplay[26] = this.lblGreenRank26;
            skillRanksDisplay[27] = this.lblGreenRank27;
            skillRanksDisplay[28] = this.lblGreenRank28;
            skillRanksDisplay[29] = this.lblGreenRank29;
            skillRanksDisplay[30] = this.lblGreenRank30;
            skillRanksDisplay[31] = this.lblGreenRank31;
            skillRanksDisplay[32] = this.lblGreenRank32;
            skillRanksDisplay[33] = this.lblGreenRank33;
            skillRanksDisplay[34] = this.lblGreenRank34;
            skillRanksDisplay[35] = this.lblGreenRank35;
            skillRanksDisplay[36] = this.lblGreenRank36;
            skillRanksDisplay[37] = this.lblGreenRank37;
            skillRanksDisplay[38] = this.lblGreenRank38;
            skillRanksDisplay[39] = this.lblGreenRank39;
            skillRanksDisplay[40] = this.lblGreenRank40;
            skillRanksDisplay[41] = this.lblGreenRank41;
            skillRanksDisplay[42] = this.lblGreenRank42;
            skillRanksDisplay[43] = this.lblGreenRank43;

            redrawSkillRanks();
            //generateSkillLinks();
            updateTalents();
        }

        //function to update form when setting is selected
        private void cboSetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            myCharacter.Setting = cboSetting.Text;
            switch (myCharacter.Setting)
            {
                case "Android":
                    this.BackgroundImage = Properties.Resources.android_background;
                    txtCharacterName.Width = 230;
                    lblSpecies.Text = "Archetype:";
                    lblSubSpecies.Visible = false;
                    cboSubSpecies.Visible = false;
                    cboSpecies.Items.Clear();
                    cboSpecies.Items.Add("");
                    cboSpecies.Items.Add("Natural");
                    cboSpecies.Items.Add("Bioroid");
                    cboSpecies.Items.Add("Clone");
                    cboSpecies.Items.Add("Cyborg");
                    cboSpecies.Items.Add("G-Mod");
                    cboSpecies.Items.Add("Loonie");
                    cboSpecies.SelectedIndex = 0;
                    cboCareer.Items.Clear();
                    cboCareer.Items.Add("");
                    cboCareer.Items.Add("Academic");
                    cboCareer.Items.Add("Bounty Hunter");
                    cboCareer.Items.Add("Con Artist");
                    cboCareer.Items.Add("Courier");
                    cboCareer.Items.Add("Investigator");
                    cboCareer.Items.Add("Ristie");
                    cboCareer.Items.Add("Roughneck");
                    cboCareer.Items.Add("Runner");
                    cboCareer.Items.Add("Soldier");
                    cboCareer.Items.Add("Tech");
                    lblSkillsMagic.Text = "Custom Skills";
                    Array.Copy(androidSkills, myCharacter.Skills, myCharacter.Skills.Length);
                    Array.Copy(talentsList, myCharacter.Talents, myCharacter.Talents.Length);
                    Array.Copy(weaponsList, myCharacter.Weapons, myCharacter.Weapons.Length);
                    break;
                case "Kirinioth":
                    this.BackgroundImage = Properties.Resources.terrinoth_background;
                    txtCharacterName.Width = 296;
                    lblSpecies.Text = "Species:";
                    lblSubSpecies.Visible = true;
                    cboSubSpecies.Visible = true;
                    cboSpecies.Items.Clear();
                    cboSpecies.Items.Add("");
                    cboSpecies.Items.Add("Human");
                    cboSpecies.Items.Add("Barbarian");
                    cboSpecies.Items.Add("Dwarf");
                    cboSpecies.Items.Add("Elf");
                    cboSpecies.Items.Add("Hobbit");
                    cboSpecies.Items.Add("Genasi");
                    cboSpecies.SelectedIndex = 0;
                    cboCareer.Items.Clear();
                    cboCareer.Items.Add("");
                    cboCareer.Items.Add("Avatar");
                    cboCareer.Items.Add("Druid");
                    cboCareer.Items.Add("Envoy");
                    cboCareer.Items.Add("Mage");
                    cboCareer.Items.Add("Scholar");
                    cboCareer.Items.Add("Scoundrel");
                    cboCareer.Items.Add("Scout");
                    cboCareer.Items.Add("Warrior");
                    cboCareer.SelectedIndex = 0;
                    lblSkillsMagic.Text = "Magic Skills";
                    Array.Copy(terrinothSkills, myCharacter.Skills, myCharacter.Skills.Length);
                    Array.Copy(talentsList, myCharacter.Talents, myCharacter.Talents.Length);
                    break;
                case "Terrinoth":
                    this.BackgroundImage = Properties.Resources.terrinoth_background;
                    txtCharacterName.Width = 296;
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
            panelSkills.Visible = false;
            panelTalents.Visible = false;
            panelAbilities.Visible = false;
            panelGear.Visible = false;
            panelMotivations.Visible = false;
        }

        //function to update form when species is selected
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
                case "Barbarian":
                    cboSubSpecies.Items.Clear();
                    cboSubSpecies.Items.Add("");
                    cboSubSpecies.SelectedIndex = 0;
                    myCharacter.Brawn = 3;
                    myCharacter.Agility = 2;
                    myCharacter.Intellect = 2;
                    myCharacter.Cunning = 2;
                    myCharacter.Willpower = 1;
                    myCharacter.Presence = 2;
                    myCharacter.WoundThreshold = 11;
                    myCharacter.StrainThreshold = 11;
                    myCharacter.TotalXP = 100;
                    myCharacter.UsedXP = 0;
                    addRankToStartingSkills("Survival"); //+1 Survival
                    //Frozen Wastes Dweller
                    break;
                case "Natural":
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
                    myCharacter.TotalXP = 120;
                    myCharacter.UsedXP = 0;
                    //2 free skill ranks
                    //ready for anything
                    break;
                case "Bioroid":
                    cboSubSpecies.Items.Clear();
                    cboSubSpecies.Items.Add("");
                    cboSubSpecies.SelectedIndex = 0;
                    myCharacter.Brawn = 3;
                    myCharacter.Agility = 1;
                    myCharacter.Intellect = 1;
                    myCharacter.Cunning = 1;
                    myCharacter.Willpower = 1;
                    myCharacter.Presence = 1;
                    myCharacter.WoundThreshold = 11;
                    myCharacter.StrainThreshold = 8;
                    myCharacter.TotalXP = 170;
                    myCharacter.UsedXP = 0;
                    //Bioroid
                    //Inorganic
                    break;
                case "Clone":
                    cboSubSpecies.Items.Clear();
                    cboSubSpecies.Items.Add("");
                    cboSubSpecies.SelectedIndex = 0;
                    myCharacter.Brawn = 2;
                    myCharacter.Agility = 2;
                    myCharacter.Intellect = 2;
                    myCharacter.Cunning = 2;
                    myCharacter.Willpower = 2;
                    myCharacter.Presence = 2;
                    myCharacter.WoundThreshold = 9;
                    myCharacter.StrainThreshold = 9;
                    myCharacter.TotalXP = 85;
                    myCharacter.UsedXP = 0;
                    //2 free skill ranks
                    //Underestimated
                    break;
                case "Cyborg":
                    cboSubSpecies.Items.Clear();
                    cboSubSpecies.Items.Add("");
                    cboSubSpecies.SelectedIndex = 0;
                    myCharacter.Brawn = 3;
                    myCharacter.Agility = 2;
                    myCharacter.Intellect = 2;
                    myCharacter.Cunning = 2;
                    myCharacter.Willpower = 2;
                    myCharacter.Presence = 1;
                    myCharacter.WoundThreshold = 11;
                    myCharacter.StrainThreshold = 8;
                    myCharacter.TotalXP = 100;
                    myCharacter.UsedXP = 0;
                    addRankToStartingSkills("Mechanics"); //Mechanics +1
                    //Adjusted to Cybernetics
                    //Cyborg (one cybernetic worth =<1000 credits without reducing strain threshold)
                    break;
                case "G-Mod":
                    cboSubSpecies.Items.Clear();
                    cboSubSpecies.Items.Add("");
                    cboSubSpecies.SelectedIndex = 0;
                    myCharacter.Brawn = 2;
                    myCharacter.Agility = 2;
                    myCharacter.Intellect = 3;
                    myCharacter.Cunning = 2;
                    myCharacter.Willpower = 1;
                    myCharacter.Presence = 2;
                    myCharacter.WoundThreshold = 11;
                    myCharacter.StrainThreshold = 11;
                    myCharacter.TotalXP = 90;
                    myCharacter.UsedXP = 0;
                    addRankToStartingSkills("Resilience"); // Resilience +1
                    //Enhanced Genetic Modification
                    //G-Mod
                    break;
                case "Loonie":
                    cboSubSpecies.Items.Clear();
                    cboSubSpecies.Items.Add("");
                    cboSubSpecies.SelectedIndex = 0;
                    myCharacter.Brawn = 1;
                    myCharacter.Agility = 3;
                    myCharacter.Intellect = 2;
                    myCharacter.Cunning = 2;
                    myCharacter.Willpower = 2;
                    myCharacter.Presence = 2;
                    myCharacter.WoundThreshold = 9;
                    myCharacter.StrainThreshold = 11;
                    myCharacter.TotalXP = 100;
                    myCharacter.UsedXP = 0;
                    addRankToStartingSkills("Coordination"); //Coordination +1
                    //Zero-G Adept
                    //Resourceful
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
                    myCharacter.UsedXP = 0;
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
                    myCharacter.UsedXP = 0;
                    //Claws or Fleet of Paw
                    break;
                case "Dwarf":
                    cboSubSpecies.Items.Clear();
                    cboSubSpecies.Items.Add("");
                    if (myCharacter.Setting == "Terrinoth")
                    {
                        cboSubSpecies.Items.Add("Dunwarr Dwarf");
                        cboSubSpecies.Items.Add("Forge Dwarf");
                    }
                    if (myCharacter.Setting == "Kirinoth")
                    {
                        cboSubSpecies.Items.Add("Forge Dwarf");
                        cboSubSpecies.Items.Add("Mountain Dwarf");
                    }
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
                case "Genasi":
                    cboSubSpecies.Items.Clear();
                    cboSubSpecies.Items.Add("");
                    if (myCharacter.Setting == "Terrinoth")
                    {
                        cboSubSpecies.Items.Add("Dunwarr Dwarf");
                        cboSubSpecies.Items.Add("Forge Dwarf");
                    }
                    if (myCharacter.Setting == "Kirinoth")
                    {
                        cboSubSpecies.Items.Add("Forge Dwarf");
                        cboSubSpecies.Items.Add("Mountain Dwarf");
                    }
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
                    if (myCharacter.Setting == "Terrinoth")
                    {
                        cboSubSpecies.Items.Add("Deep Elf");
                        cboSubSpecies.Items.Add("Free Cities Elf");
                        cboSubSpecies.Items.Add("Highborn Elf");
                        cboSubSpecies.Items.Add("Lowborn Elf");
                    }
                    if (myCharacter.Setting == "Kirinioth")
                    {
                        cboSubSpecies.Items.Add("City Elf");
                        cboSubSpecies.Items.Add("High Elf");
                        cboSubSpecies.Items.Add("Wood Elf");
                    }
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
                case "Hobbit":
                    cboSubSpecies.Items.Clear();
                    cboSubSpecies.Items.Add("");
                    cboSubSpecies.Items.Add("Burrow Hobbit");
                    cboSubSpecies.Items.Add("Wanderer Hobbit");
                    cboSubSpecies.SelectedIndex = 0;
                    myCharacter.Brawn = 1;
                    myCharacter.Agility = 2;
                    myCharacter.Intellect = 2;
                    myCharacter.Cunning = 2;
                    myCharacter.Willpower = 2;
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

        //function to update form when subspecies is selected
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
                case "Mountain Dwarf":
                    addRankToStartingSkills("Mechanics"); //Mechanics +1
                    myCharacter.TotalXP = 90;
                    myCharacter.UsedXP = 0;
                    //dark vision
                    //resistant to magic
                    break;
                case "City Elf":
                    addRankToStartingSkills("Vigilance"); //Vigilance +1
                    myCharacter.DefenseRanged = 1;
                    myCharacter.DefenseMelee = 1;
                    myCharacter.TotalXP = 90;
                    myCharacter.UsedXP = 0;
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
                case "High Elf":
                    addRankToStartingSkills("Perception");//Perception +1
                    addRankToStartingSkills("Arcana");//Arcana +1
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
                case "Wood Elf":
                    addRankToStartingSkills("Survival"); //Survival +1
                    myCharacter.DefenseRanged = 0;
                    myCharacter.DefenseMelee = 0;
                    myCharacter.TotalXP = 90;
                    myCharacter.UsedXP = 0;
                    //expert archer
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
                case "Burrow Hobbit":
                    addRankToStartingSkills("Charm"); //Charm +1
                    addRankToStartingSkills("Resilience"); //Resilience +1
                    myCharacter.TotalXP = 90;
                    myCharacter.UsedXP = 0;
                    //militia training
                    break;
                case "Wanderer Hobbit":
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
                case "Air":
                    myCharacter.Brawn = 2;
                    myCharacter.Agility = 3;
                    myCharacter.Intellect = 2;
                    myCharacter.Cunning = 2;
                    myCharacter.Willpower = 1;
                    myCharacter.Presence = 2;
                    myCharacter.WoundThreshold = 8;
                    myCharacter.StrainThreshold = 10;
                    myCharacter.TotalXP = 90;
                    myCharacter.UsedXP = 0;
                    //light on their feet
                    break;
                case "Earth":
                    myCharacter.Brawn = 3;
                    myCharacter.Agility = 1;
                    myCharacter.Intellect = 2;
                    myCharacter.Cunning = 2;
                    myCharacter.Willpower = 2;
                    myCharacter.Presence = 2;
                    myCharacter.WoundThreshold = 11;
                    myCharacter.StrainThreshold = 9;
                    myCharacter.TotalXP = 90;
                    myCharacter.UsedXP = 0;
                    //one with the earth
                    break;
                case "Fire":
                    myCharacter.Brawn = 2;
                    myCharacter.Agility = 2;
                    myCharacter.Intellect = 3;
                    myCharacter.Cunning = 2;
                    myCharacter.Willpower = 1;
                    myCharacter.Presence = 2;
                    myCharacter.WoundThreshold = 10;
                    myCharacter.StrainThreshold = 10;
                    myCharacter.TotalXP = 90;
                    myCharacter.UsedXP = 0;
                    //hot-blooded
                    break;
                case "Water":
                    myCharacter.Brawn = 2;
                    myCharacter.Agility = 2;
                    myCharacter.Intellect = 1;
                    myCharacter.Cunning = 2;
                    myCharacter.Willpower = 3;
                    myCharacter.Presence = 2;
                    myCharacter.WoundThreshold = 10;
                    myCharacter.StrainThreshold = 10;
                    myCharacter.TotalXP = 90;
                    myCharacter.UsedXP = 0;
                    //amphibious
                    break;
            }

            updateForm();
        }

        //function to update form when career is selected
        private void cboCareer_SelectedIndexChanged(object sender, EventArgs e)
        {
            myCharacter.Career = cboCareer.Text;
            switch (myCharacter.Career)
            {
                case "Academic":
                    MarkCareerSkill("Discipline");
                    MarkCareerSkill("Science");
                    MarkCareerSkill("Society");
                    MarkCareerSkill("The Net");
                    MarkCareerSkill("Leadership");
                    MarkCareerSkill("Medicine");
                    MarkCareerSkill("Melee");
                    MarkCareerSkill("Negotiation");
                    //Gear:
                    //a stun gun or a monoblade
                    //Concealed buckyweave or durable clothing and a PAD
                    //emergency medkit or smartspecs
                    //2 slap-patches and a portable comlink
                    //100 + 1d100 credits
                    break;
                case "Avatar":
                    MarkCareerSkill("Athletics");
                    MarkCareerSkill("Charm");
                    MarkCareerSkill("Discipline");
                    MarkCareerSkill("Divine");
                    MarkCareerSkill("Lore");
                    MarkCareerSkill("Leadership");
                    MarkCareerSkill("Melee-Light");
                    MarkCareerSkill("Resilience");
                    //Gear:
                    //a shortsword or spear
                    //a shield and leather armor
                    //a lantern and 2 herbs of healing or traveling gear (backpack, bedroll, rope, flint and steel, 3 torches, waterskin
                    //1d100 silver coins
                    break;
                case "Bounty Hunter":
                    MarkCareerSkill("Brawl");
                    MarkCareerSkill("Coercion");
                    MarkCareerSkill("Discipline");
                    MarkCareerSkill("Driving");
                    MarkCareerSkill("Melee");
                    MarkCareerSkill("Ranged-Heavy");
                    MarkCareerSkill("Resilience");
                    MarkCareerSkill("Streetwise");
                    //Gear:
                    //Bullpup carbine or a stun baton, 2 glop grenades, and light body armor
                    //brass knuckles or 2 slap patches
                    //3 snap locks and a utlity belt
                    //1d100 credits
                    break;
                case "Con Artist":
                    MarkCareerSkill("Charm");
                    MarkCareerSkill("Coordination");
                    MarkCareerSkill("Deception");
                    MarkCareerSkill("Melee");
                    MarkCareerSkill("Negotiation");
                    MarkCareerSkill("Ranged-Light");
                    MarkCareerSkill("Skullduggery");
                    MarkCareerSkill("Stealth");
                    //Gear:
                    //a fletcher pistol or a monoblade and 3 stun grenades
                    //Concealed buckyweave or a disguisekit and a lockpick set
                    //2 slap-patches or one dose of sting
                    //1d100 credits
                    break;
                case "Courier":
                    MarkCareerSkill("Athletics");
                    MarkCareerSkill("Brawl");
                    MarkCareerSkill("Charm");
                    MarkCareerSkill("Coordination");
                    MarkCareerSkill("Driving");
                    MarkCareerSkill("Piloting");
                    MarkCareerSkill("Stealth");
                    MarkCareerSkill("Survival");
                    //Gear:
                    //A synap pistol and durable clothing or concealed buckyweave and a palm stunner
                    //A modular backpack or a cross body bag and load bearing gear
                    //A PAD and smartspecs or a monocam, personal comlink, and reader
                    //1d100 credits
                    break;
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
                    //a lantern and 2 herbs of healing or traveling gear (backpack, bedroll, rope, flint and steel, 3 torches, waterskin
                    //1d100 silver coins
                    break;
                case "Druid":
                    if (myCharacter.Setting == "")
                    {
                        MarkCareerSkill("Athletics");
                        MarkCareerSkill("Brawl");
                        MarkCareerSkill("Coordination");
                        MarkCareerSkill("Melee");
                        MarkCareerSkill("Primal");
                        MarkCareerSkill("Resilience");
                        MarkCareerSkill("Survival");
                        MarkCareerSkill("Vigilance");
                    }
                    if (myCharacter.Setting == "Kirinioth")
                    {
                        MarkCareerSkill("Alchemy");
                        MarkCareerSkill("Brawl");
                        MarkCareerSkill("Discipline");
                        MarkCareerSkill("Lore");
                        MarkCareerSkill("Medicine");
                        MarkCareerSkill("Melee-Heavy");
                        MarkCareerSkill("Primal");
                        MarkCareerSkill("Survival");
                    }
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
                    if (myCharacter.Setting == "Terrinoth")
                    { MarkCareerSkill("Resilience"); }
                    if (myCharacter.Setting == "Kirinioth")
                    { MarkCareerSkill("Negotiation"); }
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
                case "Investigator":
                    MarkCareerSkill("Coercion");
                    MarkCareerSkill("Computers-Hacking");
                    MarkCareerSkill("Society");
                    MarkCareerSkill("Leadership");
                    MarkCareerSkill("Perception");
                    MarkCareerSkill("Ranged-Light");
                    MarkCareerSkill("Streetwise");
                    MarkCareerSkill("Vigilance");
                    //Gear:
                    //A fletcher pistol or a hand cannon
                    //Concealed buckyweave and a light pistol or a forensic kit
                    //A personal comlink, 2 slap - patches, and 2 doses of stim.
                    //1d100 credits
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
                case "Ristie":
                    MarkCareerSkill("Charm");
                    MarkCareerSkill("Cool");
                    MarkCareerSkill("Deception");
                    MarkCareerSkill("Society");
                    MarkCareerSkill("Leadership");
                    MarkCareerSkill("Negotiation");
                    MarkCareerSkill("Perception");
                    MarkCareerSkill("Vigilance");
                    //Gear:
                    //A laser pistol or a charged crystal katana
                    //A personal comlink and one slap-patch
                    //1 dose of Lo - Fi and 4 doses of stims or 2 doses of Sting
                    //200 + 1d100 credits
                    break;
                case "Roughneck":
                    MarkCareerSkill("Athletics");
                    MarkCareerSkill("Gunnery");
                    MarkCareerSkill("Mechanics");
                    MarkCareerSkill("Operating");
                    MarkCareerSkill("Piloting");
                    MarkCareerSkill("Ranged-Heavy");
                    MarkCareerSkill("Resilience");
                    MarkCareerSkill("Vigilance");
                    //Gear:
                    //2 brass knuckles or a sledgehammer
                    //A space suit or an environmental hardsuit and a portable toolkit
                    //A a hand - held diagnostic scanner or a micro - welder
                    //1d100 credits
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
                case "Runner":
                    MarkCareerSkill("Computers-Hacking");
                    MarkCareerSkill("Computers-SySops");
                    MarkCareerSkill("Cool");
                    MarkCareerSkill("Deception");
                    MarkCareerSkill("The Net");
                    MarkCareerSkill("Perception");
                    MarkCareerSkill("Skullduggery");
                    MarkCareerSkill("Streetwise");
                    //Gear:
                    //Durable clothing and a palm stunner or a light pistol
                    //A PAD with Ice Wall and Battering Ram or a PAD with Garrote and Gordian Blade
                    //A personal comlink
                    //1d100 credits
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
                    MarkCareerSkill("Athletics");
                    MarkCareerSkill("Coercion");
                    MarkCareerSkill("Gunnery");
                    MarkCareerSkill("Melee");
                    MarkCareerSkill("Ranged-Light");
                    MarkCareerSkill("Ranged-Heavy");
                    MarkCareerSkill("Resilience");
                    MarkCareerSkill("Survival");
                    //Gear:
                    //A pistol and light body armor or a bullpup carbine
                    //Durable clothing or a utility belt
                    //2 slap - patches or 1 doses of Sting
                    //1d100 credits
                    break;
                case "Tech":
                    MarkCareerSkill("Brawl");
                    MarkCareerSkill("Computers-SysOps");
                    MarkCareerSkill("Science");
                    MarkCareerSkill("The Net");
                    MarkCareerSkill("Mechanics");
                    MarkCareerSkill("Medicine");
                    MarkCareerSkill("Operating");
                    MarkCareerSkill("Piloting");
                    //Gear:
                    //A synap pistol or an environmental hardsuit and brass knuckles
                    //A modular backpack or a utility belt and 2 emergency repair patches
                    //A portable toolkit and las - scanner or a PAD with authenticator
                    //50 + 1d100 credits
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

        //shared button click event to increment characteristic up
        //increments 10XP per rank being raised to
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
            redrawSkillRanks();
        }

        //shared button click event to increment characteristic down
        //refunds 10XP per rank being reduced from
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
            redrawSkillRanks();
        }

        //function to update text color(s) to match selected setting
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

                    linkSkill0.LinkColor = Color.Blue;
                    linkSkill1.LinkColor = Color.Blue;
                    linkSkill2.LinkColor = Color.Blue;
                    linkSkill3.LinkColor = Color.Blue;
                    linkSkill4.LinkColor = Color.Blue;
                    linkSkill5.LinkColor = Color.Blue;
                    linkSkill6.LinkColor = Color.Blue;
                    linkSkill7.LinkColor = Color.Blue;
                    linkSkill8.LinkColor = Color.Blue;
                    linkSkill9.LinkColor = Color.Blue;
                    linkSkill10.LinkColor = Color.Blue;
                    linkSkill11.LinkColor = Color.Blue;
                    linkSkill12.LinkColor = Color.Blue;
                    linkSkill13.LinkColor = Color.Blue;
                    linkSkill14.LinkColor = Color.Blue;
                    linkSkill15.LinkColor = Color.Blue;
                    linkSkill16.LinkColor = Color.Blue;
                    linkSkill17.LinkColor = Color.Blue;
                    linkSkill18.LinkColor = Color.Blue;
                    linkSkill19.LinkColor = Color.Blue;
                    linkSkill20.LinkColor = Color.Blue;
                    linkSkill21.LinkColor = Color.Blue;
                    linkSkill22.LinkColor = Color.Blue;
                    linkSkill23.LinkColor = Color.Blue;
                    linkSkill24.LinkColor = Color.Blue;
                    linkSkill25.LinkColor = Color.Blue;
                    linkSkill26.LinkColor = Color.Blue;
                    linkSkill27.LinkColor = Color.Blue;
                    linkSkill28.LinkColor = Color.Blue;
                    linkSkill29.LinkColor = Color.Blue;
                    linkSkill30.LinkColor = Color.Blue;
                    linkSkill31.LinkColor = Color.Blue;
                    linkSkill32.LinkColor = Color.Blue;
                    linkSkill33.LinkColor = Color.Blue;
                    linkSkill34.LinkColor = Color.Blue;
                    linkSkill35.LinkColor = Color.Blue;
                    linkSkill36.LinkColor = Color.Blue;
                    linkSkill37.LinkColor = Color.Blue;
                    linkSkill38.LinkColor = Color.Blue;
                    linkSkill39.LinkColor = Color.Blue;
                    linkSkill40.LinkColor = Color.Blue;
                    linkSkill41.LinkColor = Color.Blue;
                    linkSkill42.LinkColor = Color.Blue;
                    linkSkill43.LinkColor = Color.Blue;

                    linkTalent0.LinkColor = Color.Blue;
                    linkTalent1.LinkColor = Color.Blue;
                    linkTalent2.LinkColor = Color.Blue;
                    linkTalent3.LinkColor = Color.Blue;
                    linkTalent4.LinkColor = Color.Blue;
                    linkTalent5.LinkColor = Color.Blue;
                    linkTalent6.LinkColor = Color.Blue;
                    linkTalent7.LinkColor = Color.Blue;
                    linkTalent8.LinkColor = Color.Blue;
                    linkTalent9.LinkColor = Color.Blue;
                    linkTalent10.LinkColor = Color.Blue;
                    linkTalent11.LinkColor = Color.Blue;
                    linkTalent12.LinkColor = Color.Blue;
                    linkTalent13.LinkColor = Color.Blue;
                    linkTalent14.LinkColor = Color.Blue;
                    linkTalent15.LinkColor = Color.Blue;
                    linkTalent16.LinkColor = Color.Blue;
                    linkTalent17.LinkColor = Color.Blue;
                    linkTalent18.LinkColor = Color.Blue;
                    linkTalent19.LinkColor = Color.Blue;
                    linkTalent20.LinkColor = Color.Blue;
                    linkTalent21.LinkColor = Color.Blue;
                    linkTalent22.LinkColor = Color.Blue;
                    linkTalent23.LinkColor = Color.Blue;
                    linkTalent24.LinkColor = Color.Blue;
                    break;
                case "Kirinioth":
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

                    linkSkill0.LinkColor = Color.SaddleBrown;
                    linkSkill1.LinkColor = Color.SaddleBrown;
                    linkSkill2.LinkColor = Color.SaddleBrown;
                    linkSkill3.LinkColor = Color.SaddleBrown;
                    linkSkill4.LinkColor = Color.SaddleBrown;
                    linkSkill5.LinkColor = Color.SaddleBrown;
                    linkSkill6.LinkColor = Color.SaddleBrown;
                    linkSkill7.LinkColor = Color.SaddleBrown;
                    linkSkill8.LinkColor = Color.SaddleBrown;
                    linkSkill9.LinkColor = Color.SaddleBrown;
                    linkSkill10.LinkColor = Color.SaddleBrown;
                    linkSkill11.LinkColor = Color.SaddleBrown;
                    linkSkill12.LinkColor = Color.SaddleBrown;
                    linkSkill13.LinkColor = Color.SaddleBrown;
                    linkSkill14.LinkColor = Color.SaddleBrown;
                    linkSkill15.LinkColor = Color.SaddleBrown;
                    linkSkill16.LinkColor = Color.SaddleBrown;
                    linkSkill17.LinkColor = Color.SaddleBrown;
                    linkSkill18.LinkColor = Color.SaddleBrown;
                    linkSkill19.LinkColor = Color.SaddleBrown;
                    linkSkill20.LinkColor = Color.SaddleBrown;
                    linkSkill21.LinkColor = Color.SaddleBrown;
                    linkSkill22.LinkColor = Color.SaddleBrown;
                    linkSkill23.LinkColor = Color.SaddleBrown;
                    linkSkill24.LinkColor = Color.SaddleBrown;
                    linkSkill25.LinkColor = Color.SaddleBrown;
                    linkSkill26.LinkColor = Color.SaddleBrown;
                    linkSkill27.LinkColor = Color.SaddleBrown;
                    linkSkill28.LinkColor = Color.SaddleBrown;
                    linkSkill29.LinkColor = Color.SaddleBrown;
                    linkSkill30.LinkColor = Color.SaddleBrown;
                    linkSkill31.LinkColor = Color.SaddleBrown;
                    linkSkill32.LinkColor = Color.SaddleBrown;
                    linkSkill33.LinkColor = Color.SaddleBrown;
                    linkSkill34.LinkColor = Color.SaddleBrown;
                    linkSkill35.LinkColor = Color.SaddleBrown;
                    linkSkill36.LinkColor = Color.SaddleBrown;
                    linkSkill37.LinkColor = Color.SaddleBrown;
                    linkSkill38.LinkColor = Color.SaddleBrown;
                    linkSkill39.LinkColor = Color.SaddleBrown;
                    linkSkill40.LinkColor = Color.SaddleBrown;
                    linkSkill41.LinkColor = Color.SaddleBrown;
                    linkSkill42.LinkColor = Color.SaddleBrown;
                    linkSkill43.LinkColor = Color.SaddleBrown;

                    linkTalent0.LinkColor = Color.SaddleBrown;
                    linkTalent1.LinkColor = Color.SaddleBrown;
                    linkTalent2.LinkColor = Color.SaddleBrown;
                    linkTalent3.LinkColor = Color.SaddleBrown;
                    linkTalent4.LinkColor = Color.SaddleBrown;
                    linkTalent5.LinkColor = Color.SaddleBrown;
                    linkTalent6.LinkColor = Color.SaddleBrown;
                    linkTalent7.LinkColor = Color.SaddleBrown;
                    linkTalent8.LinkColor = Color.SaddleBrown;
                    linkTalent9.LinkColor = Color.SaddleBrown;
                    linkTalent10.LinkColor = Color.SaddleBrown;
                    linkTalent11.LinkColor = Color.SaddleBrown;
                    linkTalent12.LinkColor = Color.SaddleBrown;
                    linkTalent13.LinkColor = Color.SaddleBrown;
                    linkTalent14.LinkColor = Color.SaddleBrown;
                    linkTalent15.LinkColor = Color.SaddleBrown;
                    linkTalent16.LinkColor = Color.SaddleBrown;
                    linkTalent17.LinkColor = Color.SaddleBrown;
                    linkTalent18.LinkColor = Color.SaddleBrown;
                    linkTalent19.LinkColor = Color.SaddleBrown;
                    linkTalent20.LinkColor = Color.SaddleBrown;
                    linkTalent21.LinkColor = Color.SaddleBrown;
                    linkTalent22.LinkColor = Color.SaddleBrown;
                    linkTalent23.LinkColor = Color.SaddleBrown;
                    linkTalent24.LinkColor = Color.SaddleBrown;
                    break;
            }
        }

        //function to update skill rank for skills given by species/sub-species
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

        //function to mark checkbox for career skills
        //(this can probably be edited to activeSkill, original build included checkbox for each skill)
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

        //function to update skill links with name and characteristic
        //if career skill, link is changed to bold
        private void updateSkills()
        {
            /*
            for (int i = 0; i < NUM_SKILLS; i++)
            {
                skillLinks[i].Text = myCharacter.Skills[i].SkillName + " (" + myCharacter.Skills[i].Characteristic + ")";
                if (myCharacter.Skills[0].Career == true) { linkSkill0.Font = new Font(linkSkill0.Font, FontStyle.Bold); }
                else { linkSkill0.Font = new Font(linkSkill0.Font, FontStyle.Regular); }
            }
            */
            
            linkSkill0.Text = myCharacter.Skills[0].SkillName + " (" + myCharacter.Skills[0].Characteristic + ")";
            if (myCharacter.Skills[0].Career == true) { linkSkill0.Font = new Font(linkSkill0.Font, FontStyle.Bold); }
            else { linkSkill0.Font = new Font(linkSkill0.Font, FontStyle.Regular); }
            linkSkill1.Text = myCharacter.Skills[1].SkillName + " (" + myCharacter.Skills[1].Characteristic + ")";
            if (myCharacter.Skills[1].Career == true) { linkSkill1.Font = new Font(linkSkill1.Font, FontStyle.Bold); }
            else { linkSkill1.Font = new Font(linkSkill1.Font, FontStyle.Regular); }
            linkSkill2.Text = myCharacter.Skills[2].SkillName + " (" + myCharacter.Skills[2].Characteristic + ")";
            if (myCharacter.Skills[2].Career == true) { linkSkill2.Font = new Font(linkSkill2.Font, FontStyle.Bold); }
            else { linkSkill2.Font = new Font(linkSkill2.Font, FontStyle.Regular); }
            linkSkill3.Text = myCharacter.Skills[3].SkillName + " (" + myCharacter.Skills[3].Characteristic + ")";
            if (myCharacter.Skills[3].Career == true) { linkSkill3.Font = new Font(linkSkill3.Font, FontStyle.Bold); }
            else { linkSkill3.Font = new Font(linkSkill3.Font, FontStyle.Regular); }
            linkSkill4.Text = myCharacter.Skills[4].SkillName + " (" + myCharacter.Skills[4].Characteristic + ")";
            if (myCharacter.Skills[4].Career == true) { linkSkill4.Font = new Font(linkSkill4.Font, FontStyle.Bold); }
            else { linkSkill4.Font = new Font(linkSkill4.Font, FontStyle.Regular); }
            linkSkill5.Text = myCharacter.Skills[5].SkillName + " (" + myCharacter.Skills[5].Characteristic + ")";
            if (myCharacter.Skills[5].Career == true) { linkSkill5.Font = new Font(linkSkill5.Font, FontStyle.Bold); }
            else { linkSkill5.Font = new Font(linkSkill5.Font, FontStyle.Regular); }
            linkSkill6.Text = myCharacter.Skills[6].SkillName + " (" + myCharacter.Skills[6].Characteristic + ")";
            if (myCharacter.Skills[6].Career == true) { linkSkill6.Font = new Font(linkSkill6.Font, FontStyle.Bold); }
            else { linkSkill6.Font = new Font(linkSkill6.Font, FontStyle.Regular); }
            linkSkill7.Text = myCharacter.Skills[7].SkillName + " (" + myCharacter.Skills[7].Characteristic + ")";
            if (myCharacter.Skills[7].Career == true) { linkSkill7.Font = new Font(linkSkill7.Font, FontStyle.Bold); }
            else { linkSkill7.Font = new Font(linkSkill7.Font, FontStyle.Regular); }
            linkSkill8.Text = myCharacter.Skills[8].SkillName + " (" + myCharacter.Skills[8].Characteristic + ")";
            if (myCharacter.Skills[8].Career == true) { linkSkill8.Font = new Font(linkSkill8.Font, FontStyle.Bold); }
            else { linkSkill8.Font = new Font(linkSkill8.Font, FontStyle.Regular); }
            linkSkill9.Text = myCharacter.Skills[9].SkillName + " (" + myCharacter.Skills[9].Characteristic + ")";
            if (myCharacter.Skills[9].Career == true) { linkSkill9.Font = new Font(linkSkill9.Font, FontStyle.Bold); }
            else { linkSkill9.Font = new Font(linkSkill9.Font, FontStyle.Regular); }
            linkSkill10.Text = myCharacter.Skills[10].SkillName + " (" + myCharacter.Skills[10].Characteristic + ")";
            if (myCharacter.Skills[10].Career == true) { linkSkill10.Font = new Font(linkSkill10.Font, FontStyle.Bold); }
            else { linkSkill10.Font = new Font(linkSkill10.Font, FontStyle.Regular); }
            linkSkill11.Text = myCharacter.Skills[11].SkillName + " (" + myCharacter.Skills[11].Characteristic + ")";
            if (myCharacter.Skills[11].Career == true) { linkSkill11.Font = new Font(linkSkill11.Font, FontStyle.Bold); }
            else { linkSkill11.Font = new Font(linkSkill11.Font, FontStyle.Regular); }
            linkSkill12.Text = myCharacter.Skills[12].SkillName + " (" + myCharacter.Skills[12].Characteristic + ")";
            if (myCharacter.Skills[12].Career == true) { linkSkill12.Font = new Font(linkSkill12.Font, FontStyle.Bold); }
            else { linkSkill12.Font = new Font(linkSkill12.Font, FontStyle.Regular); }
            linkSkill13.Text = myCharacter.Skills[13].SkillName + " (" + myCharacter.Skills[13].Characteristic + ")";
            if (myCharacter.Skills[13].Career == true) { linkSkill13.Font = new Font(linkSkill13.Font, FontStyle.Bold); }
            else { linkSkill13.Font = new Font(linkSkill13.Font, FontStyle.Regular); }
            linkSkill14.Text = myCharacter.Skills[14].SkillName + " (" + myCharacter.Skills[14].Characteristic + ")";
            if (myCharacter.Skills[14].Career == true) { linkSkill14.Font = new Font(linkSkill14.Font, FontStyle.Bold); }
            else { linkSkill14.Font = new Font(linkSkill14.Font, FontStyle.Regular); }
            linkSkill15.Text = myCharacter.Skills[15].SkillName + " (" + myCharacter.Skills[15].Characteristic + ")";
            if (myCharacter.Skills[15].Career == true) { linkSkill15.Font = new Font(linkSkill15.Font, FontStyle.Bold); }
            else { linkSkill15.Font = new Font(linkSkill15.Font, FontStyle.Regular); }
            linkSkill16.Text = myCharacter.Skills[16].SkillName + " (" + myCharacter.Skills[16].Characteristic + ")";
            if (myCharacter.Skills[16].Career == true) { linkSkill16.Font = new Font(linkSkill16.Font, FontStyle.Bold); }
            else { linkSkill16.Font = new Font(linkSkill16.Font, FontStyle.Regular); }
            linkSkill17.Text = myCharacter.Skills[17].SkillName + " (" + myCharacter.Skills[17].Characteristic + ")";
            if (myCharacter.Skills[17].Career == true) { linkSkill17.Font = new Font(linkSkill17.Font, FontStyle.Bold); }
            else { linkSkill17.Font = new Font(linkSkill17.Font, FontStyle.Regular); }
            linkSkill18.Text = myCharacter.Skills[18].SkillName + " (" + myCharacter.Skills[18].Characteristic + ")";
            if (myCharacter.Skills[18].Career == true) { linkSkill18.Font = new Font(linkSkill18.Font, FontStyle.Bold); }
            else { linkSkill18.Font = new Font(linkSkill18.Font, FontStyle.Regular); }
            linkSkill19.Text = myCharacter.Skills[19].SkillName + " (" + myCharacter.Skills[19].Characteristic + ")";
            if (myCharacter.Skills[19].Career == true) { linkSkill19.Font = new Font(linkSkill19.Font, FontStyle.Bold); }
            else { linkSkill19.Font = new Font(linkSkill19.Font, FontStyle.Regular); }
            linkSkill20.Text = myCharacter.Skills[20].SkillName + " (" + myCharacter.Skills[20].Characteristic + ")";
            if (myCharacter.Skills[20].Career == true) { linkSkill20.Font = new Font(linkSkill20.Font, FontStyle.Bold); }
            else { linkSkill20.Font = new Font(linkSkill20.Font, FontStyle.Regular); }
            linkSkill21.Text = myCharacter.Skills[21].SkillName + " (" + myCharacter.Skills[21].Characteristic + ")";
            if (myCharacter.Skills[21].Career == true) { linkSkill21.Font = new Font(linkSkill21.Font, FontStyle.Bold); }
            else { linkSkill21.Font = new Font(linkSkill21.Font, FontStyle.Regular); }
            linkSkill22.Text = myCharacter.Skills[22].SkillName + " (" + myCharacter.Skills[22].Characteristic + ")";
            if (myCharacter.Skills[22].Career == true) { linkSkill22.Font = new Font(linkSkill22.Font, FontStyle.Bold); }
            else { linkSkill22.Font = new Font(linkSkill22.Font, FontStyle.Regular); }
            linkSkill23.Text = myCharacter.Skills[23].SkillName + " (" + myCharacter.Skills[23].Characteristic + ")";
            if (myCharacter.Skills[23].Career == true) { linkSkill23.Font = new Font(linkSkill23.Font, FontStyle.Bold); }
            else { linkSkill23.Font = new Font(linkSkill23.Font, FontStyle.Regular); }
            linkSkill24.Text = myCharacter.Skills[24].SkillName + " (" + myCharacter.Skills[24].Characteristic + ")";
            if (myCharacter.Skills[24].Career == true) { linkSkill24.Font = new Font(linkSkill24.Font, FontStyle.Bold); }
            else { linkSkill24.Font = new Font(linkSkill24.Font, FontStyle.Regular); }
            linkSkill25.Text = myCharacter.Skills[25].SkillName + " (" + myCharacter.Skills[25].Characteristic + ")";
            if (myCharacter.Skills[25].Career == true) { linkSkill25.Font = new Font(linkSkill25.Font, FontStyle.Bold); }
            else { linkSkill25.Font = new Font(linkSkill25.Font, FontStyle.Regular); }
            linkSkill26.Text = myCharacter.Skills[26].SkillName + " (" + myCharacter.Skills[26].Characteristic + ")";
            if (myCharacter.Skills[26].Career == true) { linkSkill26.Font = new Font(linkSkill26.Font, FontStyle.Bold); }
            else { linkSkill26.Font = new Font(linkSkill26.Font, FontStyle.Regular); }
            linkSkill27.Text = myCharacter.Skills[27].SkillName + " (" + myCharacter.Skills[27].Characteristic + ")";
            if (myCharacter.Skills[27].Career == true) { linkSkill27.Font = new Font(linkSkill27.Font, FontStyle.Bold); }
            else { linkSkill27.Font = new Font(linkSkill27.Font, FontStyle.Regular); }
            linkSkill28.Text = myCharacter.Skills[28].SkillName + " (" + myCharacter.Skills[28].Characteristic + ")";
            if (myCharacter.Skills[28].Career == true) { linkSkill28.Font = new Font(linkSkill28.Font, FontStyle.Bold); }
            else { linkSkill28.Font = new Font(linkSkill28.Font, FontStyle.Regular); }
            linkSkill29.Text = myCharacter.Skills[29].SkillName + " (" + myCharacter.Skills[29].Characteristic + ")";
            if (myCharacter.Skills[29].Career == true) { linkSkill29.Font = new Font(linkSkill29.Font, FontStyle.Bold); }
            else { linkSkill29.Font = new Font(linkSkill29.Font, FontStyle.Regular); }
            linkSkill30.Text = myCharacter.Skills[30].SkillName + " (" + myCharacter.Skills[30].Characteristic + ")";
            if (myCharacter.Skills[30].Career == true) { linkSkill30.Font = new Font(linkSkill30.Font, FontStyle.Bold); }
            else { linkSkill30.Font = new Font(linkSkill30.Font, FontStyle.Regular); }
            linkSkill31.Text = myCharacter.Skills[31].SkillName + " (" + myCharacter.Skills[31].Characteristic + ")";
            if (myCharacter.Skills[31].Career == true) { linkSkill31.Font = new Font(linkSkill31.Font, FontStyle.Bold); }
            else { linkSkill31.Font = new Font(linkSkill31.Font, FontStyle.Regular); }
            linkSkill32.Text = myCharacter.Skills[32].SkillName + " (" + myCharacter.Skills[32].Characteristic + ")";
            if (myCharacter.Skills[32].Career == true) { linkSkill32.Font = new Font(linkSkill32.Font, FontStyle.Bold); }
            else { linkSkill32.Font = new Font(linkSkill32.Font, FontStyle.Regular); }
            linkSkill33.Text = myCharacter.Skills[33].SkillName + " (" + myCharacter.Skills[33].Characteristic + ")";
            if (myCharacter.Skills[33].Career == true) { linkSkill33.Font = new Font(linkSkill33.Font, FontStyle.Bold); }
            else { linkSkill33.Font = new Font(linkSkill33.Font, FontStyle.Regular); }
            linkSkill34.Text = myCharacter.Skills[34].SkillName + " (" + myCharacter.Skills[34].Characteristic + ")";
            if (myCharacter.Skills[34].Career == true) { linkSkill34.Font = new Font(linkSkill34.Font, FontStyle.Bold); }
            else { linkSkill34.Font = new Font(linkSkill34.Font, FontStyle.Regular); }
            linkSkill35.Text = myCharacter.Skills[35].SkillName + " (" + myCharacter.Skills[35].Characteristic + ")";
            if (myCharacter.Skills[35].Career == true) { linkSkill35.Font = new Font(linkSkill35.Font, FontStyle.Bold); }
            else { linkSkill35.Font = new Font(linkSkill35.Font, FontStyle.Regular); }
            linkSkill36.Text = myCharacter.Skills[36].SkillName + " (" + myCharacter.Skills[36].Characteristic + ")";
            if (myCharacter.Skills[36].Career == true) { linkSkill36.Font = new Font(linkSkill36.Font, FontStyle.Bold); }
            else { linkSkill36.Font = new Font(linkSkill36.Font, FontStyle.Regular); }
            linkSkill37.Text = myCharacter.Skills[37].SkillName + " (" + myCharacter.Skills[37].Characteristic + ")";
            if (myCharacter.Skills[37].Career == true) { linkSkill37.Font = new Font(linkSkill37.Font, FontStyle.Bold); }
            else { linkSkill37.Font = new Font(linkSkill37.Font, FontStyle.Regular); }
            linkSkill38.Text = myCharacter.Skills[38].SkillName + " (" + myCharacter.Skills[38].Characteristic + ")";
            if (myCharacter.Skills[38].Career == true) { linkSkill38.Font = new Font(linkSkill38.Font, FontStyle.Bold); }
            else { linkSkill38.Font = new Font(linkSkill38.Font, FontStyle.Regular); }
            linkSkill39.Text = myCharacter.Skills[39].SkillName + " (" + myCharacter.Skills[39].Characteristic + ")";
            if (myCharacter.Skills[39].Career == true) { linkSkill39.Font = new Font(linkSkill39.Font, FontStyle.Bold); }
            else { linkSkill39.Font = new Font(linkSkill39.Font, FontStyle.Regular); }
            linkSkill40.Text = myCharacter.Skills[40].SkillName + " (" + myCharacter.Skills[40].Characteristic + ")";
            if (myCharacter.Skills[40].Career == true) { linkSkill40.Font = new Font(linkSkill40.Font, FontStyle.Bold); }
            else { linkSkill40.Font = new Font(linkSkill40.Font, FontStyle.Regular); }
            linkSkill41.Text = myCharacter.Skills[41].SkillName + " (" + myCharacter.Skills[41].Characteristic + ")";
            if (myCharacter.Skills[41].Career == true) { linkSkill41.Font = new Font(linkSkill41.Font, FontStyle.Bold); }
            else { linkSkill41.Font = new Font(linkSkill41.Font, FontStyle.Regular); }
            linkSkill42.Text = myCharacter.Skills[42].SkillName + " (" + myCharacter.Skills[42].Characteristic + ")";
            if (myCharacter.Skills[42].Career == true) { linkSkill42.Font = new Font(linkSkill42.Font, FontStyle.Bold); }
            else { linkSkill42.Font = new Font(linkSkill42.Font, FontStyle.Regular); }
            linkSkill43.Text = myCharacter.Skills[43].SkillName + " (" + myCharacter.Skills[43].Characteristic + ")";
            if (myCharacter.Skills[43].Career == true) { linkSkill43.Font = new Font(linkSkill43.Font, FontStyle.Bold); }
            else { linkSkill43.Font = new Font(linkSkill43.Font, FontStyle.Regular); }
        }

        //function to update individual talent panels on talents panel
        //makes eligible talent panels visible
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

        //makes skill detail panel visible
        //populates fields on skill detail panel for active SkillsTemplate from myCharacter
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
            else { chkCareer.Checked = false; }
            lblSkillRank.Text = myCharacter.Skills[activeSkillLink].Rank.ToString();

            //myCharacter.Skills[skillLinkNumber].SkillName = txtSkill.Text;
            //myCharacter.Skills[skillLinkNumber].Characteristic = cboCharacteristic.Text;
            //myCharacter.Skills[skillLinkNumber].Description = txtSkillDescription.Text;

            updateForm();
        }

        //button click event to increment active skill rank up
        //increments usedXP by 5 per rank, +5 if non-career skill
        //does not increment XP for first rank in first 4 career skills
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
            //redrawSingleSkillRanks(activeSkillLink);
            redrawSkillRanks();
        }

        //button click event to increment active skill rank down
        //refends usedXP by 5 per rank, +5 if non-career skill
        //does not refund XP for first rank in first 4 career skills
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
            //redrawSingleSkillRanks(activeSkillLink);
            redrawSkillRanks();
        }

        //makes talent detail panel visible
        //populates fields on talent detail panel for active TalentsTemplate from myCharacter
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

        //function to update XP fields
        private void updateXP()
        {
            myCharacter.RemainXP = myCharacter.TotalXP - myCharacter.UsedXP;
            lblXPTotal.Text = myCharacter.TotalXP.ToString();
            lblXPRemaining.Text = myCharacter.RemainXP.ToString();
        }

        //single function to update various text fields from myCharacter
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

        //not used
        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        //resets all fields in myCharacter to starting values
        private void btnReset_Click(object sender, EventArgs e)
        {
            myCharacter.Setting = "";
            myCharacter.CharacterName = "";
            myCharacter.Species = "";
            myCharacter.SubSpecies = "";
            myCharacter.Career = "";

            myCharacter.Brawn = 2;
            myCharacter.Agility = 2;
            myCharacter.Intellect = 2;
            myCharacter.Cunning = 2;
            myCharacter.Willpower = 2;
            myCharacter.Presence = 2;

            myCharacter.Soak = 0;
            myCharacter.WoundThreshold = 10;
            myCharacter.WoundCurrent = 0;
            myCharacter.StrainThreshold = 10;
            myCharacter.StrainCurrent = 0;
            myCharacter.DefenseRanged = 0;
            myCharacter.DefenseMelee = 0;
            myCharacter.CriticalInjuries = null;

            myCharacter.TotalXP = 0;
            myCharacter.RemainXP = 0;
            myCharacter.UsedXP = 0;

            for (int i = 0; i < NUM_SKILLS; i++)
            {
                myCharacter.Skills[i].SkillName = "";
                myCharacter.Skills[i].Characteristic = "";
                myCharacter.Skills[i].Description = "";
                myCharacter.Skills[i].Career = false;
                myCharacter.Skills[i].Rank = 0;
            }
            for (int i = 0; i < NUM_TALENTS; i++)
            {
                myCharacter.Talents[i].TalentName = "";
                myCharacter.Talents[i].TalentDescription = "";
                myCharacter.Talents[i].Active = false;
                myCharacter.Talents[i].Ranked = false;
                myCharacter.Talents[i].Tier = 0;
                myCharacter.Talents[i].Page = "";
            }
            myCharacter.Abilities = null;
            for (int i = 0; i < 4; i++)
            {
                myCharacter.Weapons[i].WeaponName = "";
                myCharacter.Weapons[i].WeaponSkill = "";
                myCharacter.Weapons[i].WeaponDamage = "";
                myCharacter.Weapons[i].WeaponCrit = "";
                myCharacter.Weapons[i].WeaponRange = "";
                myCharacter.Weapons[i].WeaponSpecial = "";
            }
            myCharacter.WeaponsAndArmor = null;
            myCharacter.PersonalGear = null;
            myCharacter.Currency = null;

            myCharacter.MotivationStrength = "";
            myCharacter.MotivationFlaw = "";
            myCharacter.MotivationDesire = "";
            myCharacter.MotivationFear = "";
            myCharacter.MotivationBackground = "";

            myCharacter.Gender = "";
            myCharacter.Age = "";
            myCharacter.Height = "";
            myCharacter.Build = "";
            myCharacter.Hair = "";
            myCharacter.Eyes = "";
            myCharacter.Features = "";

            cboSetting.Items.Clear();
            cboSetting.Items.Add("Android");
            cboSetting.Items.Add("Terrinoth");
            cboSetting.Items.Add("Kirinioth");
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
            txtWoundsCurrent.Text = myCharacter.WoundCurrent.ToString();
            lblStrainThreshold.Text = myCharacter.StrainThreshold.ToString();
            txtStrainCurrent.Text = myCharacter.StrainCurrent.ToString();
            lblDefenseMelee.Text = myCharacter.DefenseMelee.ToString();
            lblDefenseRanged.Text = myCharacter.DefenseRanged.ToString();

            redrawSkillRanks();
            //generateSkillLinks();
            updateTalents();
        }

        //exits form
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //makes skill panel visible and hides all other panels
        //populates text fields with data from myCharacter
        //calls redrawSkillRanks()
        private void btnSkills_Click(object sender, EventArgs e)
        {
            panelSkills.Visible = true;
            panelSkillDetail.Visible = false;
            redrawSkillRanks();
            panelTalents.Visible = false;
            panelAbilities.Visible = false;
            panelGear.Visible = false;
            panelMotivations.Visible = false;
        }

        //updates SkillsTemplate in myCharacter from fields on skill detail panel
        //cakks updateSkills() and redrawSkillRanks()
        private void btnSkillsSave_Click(object sender, EventArgs e)
        {
            myCharacter.Skills[activeSkillLink].SkillName = txtSkill.Text;
            myCharacter.Skills[activeSkillLink].Characteristic = cboCharacteristic.Text;
            myCharacter.Skills[activeSkillLink].Description = txtSkillDescription.Text;
            if (chkCareer.Checked == true)
            {
                myCharacter.Skills[activeSkillLink].Career = true;
            }
            else { myCharacter.Skills[activeSkillLink].Career = false; }

            updateSkills();
            //redrawSingleSkillRanks(activeSkillLink);
            redrawSkillRanks();
        }

        //hides skill deatil panel without saving changes
        private void btnSkillsCancel_Click(object sender, EventArgs e)
        {
            panelSkillDetail.Visible = false;
        }

        //makes talents panel visible and hides all other panels
        private void btnTalents_Click(object sender, EventArgs e)
        {
            panelSkills.Visible = false;
            panelTalents.Visible = true;
            panelTalentDetail.Visible = false;
            panelGear.Visible = false;
            panelMotivations.Visible = false;
        }

        //saves data in skill detail panel to myCharacter
        //increments XP for used talents
        //calls updateTalents()
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

        //hides talent detail panel without saving changes
        private void btnTalentCancel_Click(object sender, EventArgs e)
        {
            panelTalentDetail.Visible = false;
        }

        //makes gear panel visible and hides all other panels
        //calls loadGearTab() to populate data from myCharacter
        private void lblGear_Click(object sender, EventArgs e)
        {
            panelSkills.Visible = false;
            panelTalents.Visible = false;
            panelAbilities.Visible = false;
            panelGear.Visible = true;
            panelMotivations.Visible = false;

            loadGearTab();
        }

        //makes abilities panel visible and hides all other panels
        //populates text fields with data from myCharacter
        private void btnAbilities_Click(object sender, EventArgs e)
        {
            panelSkills.Visible = false;
            panelTalents.Visible = false;
            panelAbilities.Visible = true;
            panelGear.Visible = false;
            panelMotivations.Visible = false;
        }

        //saves text fields on gear panel to Weapons array in myCharacter
        //saves text in text boxes on gear panel to myCharacter
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

        //calls loadGearTab() to reload fields with data from myCharacter without saving changes
        private void btnGearCancel_Click(object sender, EventArgs e)
        {
            loadGearTab();
        }

        //populates text fields of gear panel with data from myCharacter
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

        //makes motivations panel visible and hides all other panels
        //populates text fields with data from myCharacter
        private void btnMotivations_Click(object sender, EventArgs e)
        {
            panelSkills.Visible = false;
            panelTalents.Visible = false;
            panelAbilities.Visible = false;
            panelGear.Visible = false;
            panelMotivations.Visible = true;

            txtMotivationStrength.Text = myCharacter.MotivationStrength;
            txtMotivationFlaw.Text = myCharacter.MotivationFlaw;
            txtMotivationDesire.Text = myCharacter.MotivationDesire;
            txtMotivationFear.Text = myCharacter.MotivationFear;

            txtGender.Text = myCharacter.Gender;
            txtAge.Text = myCharacter.Age;
            txtHeight.Text = myCharacter.Height;
            txtBuild.Text = myCharacter.Build;
            txtHair.Text = myCharacter.Hair;
            txtEyes.Text = myCharacter.Eyes;
            txtNotableFeatures.Text = myCharacter.Features;
        }

        //function to redraw dice pool for each skill
        //calls updateSkills() after skill ranks have been converted to "c"s and "d"s (to use EotE Font)
        private void redrawSkillRanks()
        {
            for (int i = 0; i < NUM_SKILLS; i++)
            {
                skillRanksDisplay[i].Text = "";
                int yellowRanks = 0;
                int greenranks = 0;
                int high = GetMax(getSkillCharacteristic(myCharacter.Skills[i].Characteristic), myCharacter.Skills[i].Rank);
                int low = GetMin(getSkillCharacteristic(myCharacter.Skills[i].Characteristic), myCharacter.Skills[i].Rank);
                yellowRanks = high - low;
                greenranks = low;
                for (int j = 0; j < yellowRanks; j++)
                {
                    skillRanksDisplay[i].Text += "d";
                    //skillsTest[j].Image = Properties.Resources.yellow_transparent;
                }
                for (int j = 0; j < greenranks; j++)
                {
                    skillRanksDisplay[i].Text += "c";
                    //skillsTest[j + yellowRanks].Image = Properties.Resources.green_transparent;
                }
            }
            updateSkills();
        }

        //function to obtain characteristic from myCharacter for abbreviation in SkillsTemplate Class
        private int getSkillCharacteristic(string characteristic)
        {
            int skillCharacteristic = 0;

            switch (characteristic)
            {
                case "Br":
                    skillCharacteristic = myCharacter.Brawn;
                    break;
                case "Ag":
                    skillCharacteristic = myCharacter.Agility;
                    break;
                case "Int":
                    skillCharacteristic = myCharacter.Intellect;
                    break;
                case "Cun":
                    skillCharacteristic = myCharacter.Cunning;
                    break;
                case "Will":
                    skillCharacteristic = myCharacter.Willpower;
                    break;
                case "Pr":
                    skillCharacteristic = myCharacter.Presence;
                    break;
            }

            return skillCharacteristic;
        }

        //generic function to obtain maximum between two int values
        private int GetMax(int first, int second)
        {
            return first > second ? first : second;
        }

        //generic function to obtain minimum between two int values
        private int GetMin(int first, int second)
        {
            return first < second ? first : second;
        }

        //saves all changes made on the motivations panel to myCharacter
        private void btnMotivationSave_Click(object sender, EventArgs e)
        {
            myCharacter.MotivationStrength = txtMotivationStrength.Text;
            myCharacter.MotivationFlaw = txtMotivationFlaw.Text;
            myCharacter.MotivationDesire = txtMotivationDesire.Text;
            myCharacter.MotivationFear = txtMotivationFear.Text;

            myCharacter.Gender = txtGender.Text;
            myCharacter.Age = txtAge.Text;
            myCharacter.Height = txtHeight.Text;
            myCharacter.Build = txtBuild.Text;
            myCharacter.Hair = txtHair.Text;
            myCharacter.Eyes = txtEyes.Text;
            myCharacter.Features = txtNotableFeatures.Text;
        }

        //hides the motivations panel without saving changes
        private void btnMotivationsCancel_Click(object sender, EventArgs e)
        {
            panelMotivations.Visible = false;
        }
    }
}
