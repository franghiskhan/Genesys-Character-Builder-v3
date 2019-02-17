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
            Setting = "",
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

            Array.Copy(terrinothSkills, myCharacter.Skills, myCharacter.Skills.Length);
            Array.Copy(talentsList, myCharacter.Talents, myCharacter.Talents.Length);
        }

        private void cboSetting_SelectedIndexChanged(object sender, EventArgs e)
        {
            myCharacter.Setting = cboSetting.Text;
            switch (myCharacter.Setting)
            {
                case "Android":
                    this.BackgroundImage = Properties.Resources.android_background;
                    lblSpecies.Text = "Archetype:";
                    lblSubSpecies.Visible = false;
                    cboSubSpecies.Visible = false;
                    cboSpecies.Items.Clear();
                    cboSpecies.Items.Add("");
                    
                    cboSpecies.SelectedIndex = 0;
                    cboCareer.Items.Clear();
                    Array.Copy(terrinothSkills, myCharacter.Skills, myCharacter.Skills.Length);
                    Array.Copy(talentsList, myCharacter.Talents, myCharacter.Talents.Length);
                    break;
                case "Terrinoth":
                    this.BackgroundImage = Properties.Resources.terrinoth_background;
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
                    Array.Copy(terrinothSkills, myCharacter.Skills, myCharacter.Skills.Length);
                    Array.Copy(talentsList, myCharacter.Talents, myCharacter.Talents.Length);
                    break;
            }

            updateSkills();
        }

        private void updateSkills()
        {
            linkSkill0.Text = myCharacter.Skills[0].SkillName + " (" + myCharacter.Skills[0].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[1].SkillName + " (" + myCharacter.Skills[1].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[2].SkillName + " (" + myCharacter.Skills[2].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[3].SkillName + " (" + myCharacter.Skills[3].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[4].SkillName + " (" + myCharacter.Skills[4].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[5].SkillName + " (" + myCharacter.Skills[5].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[6].SkillName + " (" + myCharacter.Skills[6].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[7].SkillName + " (" + myCharacter.Skills[7].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[8].SkillName + " (" + myCharacter.Skills[8].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[9].SkillName + " (" + myCharacter.Skills[9].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[10].SkillName + " (" + myCharacter.Skills[10].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[11].SkillName + " (" + myCharacter.Skills[11].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[12].SkillName + " (" + myCharacter.Skills[12].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[13].SkillName + " (" + myCharacter.Skills[13].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[14].SkillName + " (" + myCharacter.Skills[14].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[15].SkillName + " (" + myCharacter.Skills[15].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[16].SkillName + " (" + myCharacter.Skills[16].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[17].SkillName + " (" + myCharacter.Skills[17].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[18].SkillName + " (" + myCharacter.Skills[18].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[19].SkillName + " (" + myCharacter.Skills[19].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[20].SkillName + " (" + myCharacter.Skills[20].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[21].SkillName + " (" + myCharacter.Skills[21].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[22].SkillName + " (" + myCharacter.Skills[22].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[23].SkillName + " (" + myCharacter.Skills[23].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[24].SkillName + " (" + myCharacter.Skills[24].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[25].SkillName + " (" + myCharacter.Skills[25].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[26].SkillName + " (" + myCharacter.Skills[26].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[27].SkillName + " (" + myCharacter.Skills[27].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[28].SkillName + " (" + myCharacter.Skills[28].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[29].SkillName + " (" + myCharacter.Skills[29].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[30].SkillName + " (" + myCharacter.Skills[30].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[31].SkillName + " (" + myCharacter.Skills[31].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[32].SkillName + " (" + myCharacter.Skills[32].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[33].SkillName + " (" + myCharacter.Skills[33].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[34].SkillName + " (" + myCharacter.Skills[34].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[35].SkillName + " (" + myCharacter.Skills[35].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[36].SkillName + " (" + myCharacter.Skills[36].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[37].SkillName + " (" + myCharacter.Skills[37].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[38].SkillName + " (" + myCharacter.Skills[38].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[39].SkillName + " (" + myCharacter.Skills[39].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[40].SkillName + " (" + myCharacter.Skills[40].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[41].SkillName + " (" + myCharacter.Skills[41].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[42].SkillName + " (" + myCharacter.Skills[42].Characteristic + ")";
            linkSkill0.Text = myCharacter.Skills[43].SkillName + " (" + myCharacter.Skills[43].Characteristic + ")";
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
