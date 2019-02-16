using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace frmGenesys
{
    public partial class frmGenesys : Form
    {
        public frmGenesys()
        {
            InitializeComponent();
        }

        const int NUM_SKILLS = 44;

        private string characterName = "";
        private string species = "";
        private string subSpecies = "";
        private string career = "";

        private int brawn = 2;
        private int agility = 2;
        private int intellect = 2;
        private int cunning = 2;
        private int willpower = 2;
        private int presence = 2;

        private int armor = 0;
        private int soak = 0;
        private int defenseRanged = 0;
        private int defenseMelee = 0;
        private int woundThreshold = 10;
        private int woundCurrent = 0;
        private int strainThreshold = 10;
        private int strainCurrent = 0;

        private int totalXP = 0;
        private int remainXP = 0;
        public static int usedXP = 0;

        public static string[,] skills =
        {
            { "Alchemy", "Int", "Description", "no", "0", "gen" }, //0
            { "Athletics", "Br", "Description", "no", "0", "gen" }, //1
            { "Cool", "Pr", "Description", "no", "0", "gen" }, //2
            { "Coordination", "Ag", "Description", "no", "0", "gen" }, //3
            { "Discipline", "Will", "Description", "no", "0", "gen" }, //4
            { "Mechanics", "Int", "Description", "no", "0", "gen" }, //5
            { "Medicine", "Int", "Description", "no", "0", "gen" }, //6
            { "Perception", "Cun", "Description", "no", "0", "gen" }, //7
            { "Resilience", "Br", "Description", "no", "0", "gen" }, //8
            { "Riding", "Ag", "Description", "no", "0", "gen" }, //9
            { "Skullduggery", "Cun", "Description", "no", "0", "gen" }, //10
            { "Stealth", "Ag", "Description", "no", "0", "gen" }, //11
            { "Streetwise", "Cun", "Description", "no", "0", "gen" }, //12
            { "Survival", "Cun", "Description", "no", "0", "gen" }, //13
            { "Vigilance", "Will", "Description", "no", "0", "gen" }, //14
            { "Custom Skill", "", "Description", "no", "0", "gen" }, //15
            { "Brawl", "Br", "Description", "no", "0", "com" }, //16
            { "Melee-Heavy", "Br", "Description", "no", "0", "com" }, //17
            { "Melee-Light", "Br", "Description", "no", "0", "com" }, //18
            { "Ranged", "Ag", "Description", "no", "0", "com" }, //19
            { "Custom Skill", "", "Description", "no", "0", "com" }, //20
            { "Custom Skill", "", "Description", "no", "0", "com" }, //21
            { "Charm", "Pr", "Description", "no", "0", "soc" }, //22
            { "Coercion", "Will", "Description", "no", "0", "soc" }, //23
            { "Deception", "Cun", "Description", "no", "0", "soc" }, //24
            { "Leadership", "Pr", "Description", "no", "0", "soc" }, //25
            { "Negotiation", "Pr", "Description", "no", "0", "soc" }, //26
            { "Custom Skill", "", "Description", "no", "0", "soc" }, //27
            { "Custom Skill", "", "Description", "no", "0", "soc" }, //28
            { "Custom Skill", "", "Description", "no", "0", "soc" }, //29
            { "Arcana", "Int", "Description", "no", "0", "mag" }, //30
            { "Divine", "Will", "Description", "no", "0", "mag" }, //31
            { "Primal", "Cun", "Description", "no", "0", "mag" }, //32
            { "Rune", "Int", "Description", "no", "0", "mag" }, //33
            { "Verse", "Pr", "Description", "no", "0", "mag" }, //34
            { "Custom Skill", "", "Description", "no", "0", "mag" }, //35
            { "Adventuring", "Int", "Description", "no", "0", "kno" }, //36
            { "Forbidden", "Int", "Description", "no", "0", "kno" }, //37
            { "Lore", "Int", "Description", "no", "0", "kno" }, //38
            { "Geography", "Int", "Description", "no", "0", "kno" }, //39
            { "Custom Skill", "Int", "Description", "no", "0", "kno" }, //40
            { "Custom Skill", "Int", "Description", "no", "0", "kno" }, //41
            { "Custom Skill", "Int", "Description", "no", "0", "kno" }, //42
            { "Custom Skill", "Int", "Description", "no", "0", "kno" }, //43
        };

        public static string[,] talents =
        {
            { "Talent", "Description", "false", "0", "1" }, //0
            { "Talent", "Description", "false", "0", "1" }, //1
            { "Talent", "Description", "false", "0", "1" }, //2
            { "Talent", "Description", "false", "0", "1" }, //3
            { "Talent", "Description", "false", "0", "1" }, //4
            { "Talent", "Description", "false", "0", "1" }, //5
            { "Talent", "Description", "false", "0", "1" }, //6
            { "Talent", "Description", "false", "0", "2" }, //7
            { "Talent", "Description", "false", "0", "2" }, //8
            { "Talent", "Description", "false", "0", "2" }, //9
            { "Talent", "Description", "false", "0", "2" }, //10
            { "Talent", "Description", "false", "0", "2" }, //11
            { "Talent", "Description", "false", "0", "2" }, //12
            { "Talent", "Description", "false", "0", "3" }, //13
            { "Talent", "Description", "false", "0", "3" }, //14
            { "Talent", "Description", "false", "0", "3" }, //15
            { "Talent", "Description", "false", "0", "3" }, //16
            { "Talent", "Description", "false", "0", "3" }, //17
            { "Talent", "Description", "false", "0", "4" }, //18
            { "Talent", "Description", "false", "0", "4" }, //19
            { "Talent", "Description", "false", "0", "4" }, //20
            { "Talent", "Description", "false", "0", "4" }, //21
            { "Talent", "Description", "false", "0", "5" }, //22
            { "Talent", "Description", "false", "0", "5" }, //23
            { "Talent", "Description", "false", "0", "5" }, //24
        };

        public static string abilities1 = "";
        public static string abilities2 = "";

        private void frmGenesys_Load(object sender, EventArgs e)
        {
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
            lblSoak.Text = "";
            lblWoundThreshold.Text = (woundThreshold + brawn).ToString();
            txtWoundsCurrent.Text = woundCurrent.ToString();
            lblStrainThreshold.Text = (strainThreshold + willpower).ToString();
            txtStrainCurrent.Text = strainCurrent.ToString();
            lblDefenseRanged.Text = "";
            lblDefenseMelee.Text = "";
            lblBrawnVal.Text = brawn.ToString();
            lblAgilityVal.Text = agility.ToString();
            lblIntellectVal.Text = intellect.ToString();
            lblCunningVal.Text = cunning.ToString();
            lblWillpowerVal.Text = willpower.ToString();
            lblPresenceVal.Text = presence.ToString();
            updateSkills();

            //txtCharacterName = Color.Transparent;
        }

        void Text_Change(Object sender, EventArgs e)
        {
            characterName = txtCharacterName.Text;
        }

        //updates form with species info when drop down value is selected.
        //populates species sub menu with sub species selection for species.
        //eventually plan to read this info from a .dat file in an array
        //to allow for selection of different genres or worlds.
        void Selection_Change(Object sender, EventArgs e)
        {
            clearChkSkills();
            ResetXP();
            species = cboSpecies.Text;
            switch (species)
            {
                case "Human":
                    cboSubSpecies.Items.Clear();
                    cboSubSpecies.Items.Add("");
                    cboSubSpecies.SelectedIndex = 0;
                    brawn = 2;
                    agility = 2;
                    intellect = 2;
                    cunning = 2;
                    willpower = 2;
                    presence = 2;
                    woundThreshold = 10;
                    strainThreshold = 10;
                    totalXP = 110;
                    usedXP = 0;
                    //2 free skills
                    break;
                case "CatFolk":
                    cboSubSpecies.Items.Clear();
                    cboSubSpecies.Items.Add("");
                    cboSubSpecies.Items.Add("");
                    cboSubSpecies.SelectedIndex = 0;
                    skills[7, 4] = "1";
                    brawn = 2;
                    agility = 2;
                    intellect = 1;
                    cunning = 3;
                    willpower = 2;
                    presence = 2;
                    woundThreshold = 9;
                    strainThreshold = 8;
                    totalXP = 90;
                    usedXP = 15;
                    //Claws
                    //Fleet of Paw
                    break;
                case "Half CatFolk":
                    cboSubSpecies.Items.Clear();
                    cboSubSpecies.Items.Add("");
                    cboSubSpecies.Items.Add("");
                    cboSubSpecies.SelectedIndex = 0;
                    skills[2, 4] = "1";
                    brawn = 2;
                    agility = 2;
                    intellect = 2;
                    cunning = 2;
                    willpower = 2;
                    presence = 2;
                    woundThreshold = 10;
                    strainThreshold = 9;
                    totalXP = 100;
                    usedXP = 15;
                    //Claws or Fleet of Paw
                    break;
                case "Dwarf":
                    cboSubSpecies.Items.Clear();
                    cboSubSpecies.Items.Add("");
                    cboSubSpecies.Items.Add("Dunwarr Dwarf");
                    cboSubSpecies.Items.Add("Forge Dwarf");
                    cboSubSpecies.SelectedIndex = 0;
                    brawn = 2;
                    agility = 1;
                    intellect = 2;
                    cunning = 2;
                    willpower = 3;
                    presence = 2;
                    woundThreshold = 11;
                    strainThreshold = 10;
                    totalXP = 90;
                    usedXP = 0;
                    break;
                case "Elf":
                    cboSubSpecies.Items.Clear();
                    cboSubSpecies.Items.Add("");
                    cboSubSpecies.Items.Add("Deep Elf");
                    cboSubSpecies.Items.Add("Free Cities Elf");
                    cboSubSpecies.Items.Add("Highborn Elf");
                    cboSubSpecies.Items.Add("Lowborn Elf");
                    cboSubSpecies.SelectedIndex = 0;
                    brawn = 2;
                    agility = 3;
                    intellect = 2;
                    cunning = 2;
                    willpower = 1;
                    presence = 2;
                    woundThreshold = 9;
                    strainThreshold = 10;
                    totalXP = 90;
                    usedXP = 0;
                    break;
                case "Gnome":
                    cboSubSpecies.Items.Clear();
                    cboSubSpecies.Items.Add("");
                    cboSubSpecies.Items.Add("Burrow Gnome");
                    cboSubSpecies.Items.Add("Wanderer Gnome");
                    cboSubSpecies.SelectedIndex = 0;
                    brawn = 1;
                    agility = 2;
                    intellect = 2;
                    cunning = 3;
                    willpower = 1;
                    presence = 3;
                    woundThreshold = 6;
                    strainThreshold = 11;
                    totalXP = 90;
                    usedXP = 0;
                    //small
                    break;
                case "Orc":
                    cboSubSpecies.Items.Clear();
                    cboSubSpecies.Items.Add("");
                    cboSubSpecies.Items.Add("Broken Plains Orc");
                    cboSubSpecies.Items.Add("Stone-Dweller Orc");
                    cboSubSpecies.Items.Add("Sunderlands Orc");
                    cboSubSpecies.SelectedIndex = 0;
                    brawn = 3;
                    agility = 2;
                    intellect = 2;
                    cunning = 2;
                    willpower = 2;
                    presence = 1;
                    woundThreshold = 12;
                    strainThreshold = 8;
                    totalXP = 100;
                    usedXP = 0;
                    break;
            }

            lblBrawnVal.Text = brawn.ToString();
            lblAgilityVal.Text = agility.ToString();
            lblIntellectVal.Text = intellect.ToString();
            lblCunningVal.Text = cunning.ToString();
            lblWillpowerVal.Text = willpower.ToString();
            lblPresenceVal.Text = presence.ToString();

            runUpdates();
        }

        //updates form with sub species info when drop down value is selected.
        void SubSelection_Change(object sender, EventArgs e)
        {
            clearChkSkills();
            ResetXP();
            updateXP();
            subSpecies = cboSubSpecies.Text;
            switch (subSpecies)
            {
                case "Dunwarr Dwarf":
                    skills[8, 4] = "1";
                    totalXP = 90;
                    usedXP = 15;
                    //dark vision
                    //tough as nails
                    break;
                case "Forge Dwarf":
                    skills[26, 4] = "1";
                    totalXP = 90;
                    usedXP = 15;
                    //stubborn
                    //tough as nails
                    break;
                case "Deep Elf":
                    skills[4, 4] = "1";
                    skills[37, 3] = "yes";
                    chkSkill37.Checked = true;
                    skills[37, 4] = "2";
                    totalXP = 90;
                    usedXP = 30;
                    break;
                case "Free Cities Elf":
                    skills[12, 4] = "1";
                    defenseRanged = 1;
                    defenseMelee = 1;
                    totalXP = 90;
                    usedXP = 15;
                    break;
                case "Highborn Elf":
                    skills[26, 4] = "1";
                    skills[31, 3] = "yes";
                    chkSkill31.Checked = true;
                    skills[31, 4] = "1";
                    totalXP = 90;
                    usedXP = 25;
                    break;
                case "Lowborn Elf":
                    skills[13, 4] = "1";
                    defenseRanged = 1;
                    defenseMelee = 1;
                    totalXP = 90;
                    usedXP = 15;
                    break;
                case "Burrow Gnome":
                    skills[22, 4] = "1";
                    skills[8, 4] = "1";
                    totalXP = 90;
                    usedXP = 30;
                    //militia training
                    break;
                case "Wanderer Gnome":
                    skills[22, 4] = "1";
                    skills[11, 4] = "1";
                    totalXP = 90;
                    usedXP = 30;
                    //tricksy
                    break;
                case "Broken Plains Orc":
                    skills[23, 4] = "1";
                    totalXP = 100;
                    usedXP = 15;
                    //Battle Rage
                    break;
                case "Stone-Dweller Orc":
                    skills[2, 4] = "1";
                    totalXP = 100;
                    usedXP = 15;
                    //hot tempered
                    break;
                case "Sunderlands Orc":
                    skills[0, 4] = "1";
                    totalXP = 100;
                    usedXP = 15;
                    //tenacious
                    break;
            }

            runUpdates();
        }

        //updates form with sub species info when drop down value is selected.
        void CareerSelection_Change(object sender, EventArgs e)
        {
            career = cboCareer.Text;
            switch (career)
            {
                case "Disciple":
                    skills[1, 3] = "yes";
                    skills[22, 3] = "yes";
                    skills[4, 3] = "yes";
                    skills[31, 3] = "yes";
                    skills[38, 3] = "yes";
                    skills[25, 3] = "yes";
                    skills[18, 3] = "yes";
                    skills[8, 3] = "yes";
                    chkSkill1.Checked = true;
                    chkSkill22.Checked = true;
                    chkSkill4.Checked = true;
                    chkSkill31.Checked = true;
                    chkSkill38.Checked = true;
                    chkSkill25.Checked = true;
                    chkSkill18.Checked = true;
                    chkSkill8.Checked = true;
                    break;
                case "Envoy":
                    skills[22, 3] = "yes";
                    skills[2, 3] = "yes";
                    skills[24, 3] = "yes";
                    skills[39, 3] = "yes";
                    skills[25, 3] = "yes";
                    skills[18, 3] = "yes";
                    skills[26, 3] = "yes";
                    skills[14, 3] = "yes";
                    chkSkill22.Checked = true;
                    chkSkill2.Checked = true;
                    chkSkill24.Checked = true;
                    chkSkill39.Checked = true;
                    chkSkill25.Checked = true;
                    chkSkill18.Checked = true;
                    chkSkill26.Checked = true;
                    chkSkill14.Checked = true;
                    break;
                case "Mage":
                    skills[0, 3] = "yes";
                    skills[30, 3] = "yes";
                    skills[2, 3] = "yes";
                    skills[4, 3] = "yes";
                    skills[36, 3] = "yes";
                    skills[37, 3] = "yes";
                    skills[38, 3] = "yes";
                    skills[7, 3] = "yes";
                    chkSkill0.Checked = true;
                    chkSkill30.Checked = true;
                    chkSkill2.Checked = true;
                    chkSkill4.Checked = true;
                    chkSkill36.Checked = true;
                    chkSkill37.Checked = true;
                    chkSkill38.Checked = true;
                    chkSkill7.Checked = true;
                    break;
                case "Primalist":
                    skills[0, 3] = "yes";
                    skills[16, 3] = "yes";
                    skills[4, 3] = "yes";
                    skills[38, 3] = "yes";
                    skills[6, 3] = "yes";
                    skills[17, 3] = "yes";
                    skills[32, 3] = "yes";
                    skills[13, 3] = "yes";
                    chkSkill0.Checked = true;
                    chkSkill16.Checked = true;
                    chkSkill4.Checked = true;
                    chkSkill38.Checked = true;
                    chkSkill6.Checked = true;
                    chkSkill17.Checked = true;
                    chkSkill32.Checked = true;
                    chkSkill13.Checked = true;
                    break;
                case "Runemaster":
                    skills[0, 3] = "yes";
                    skills[2, 3] = "yes";
                    skills[4, 3] = "yes";
                    skills[36, 3] = "yes";
                    skills[37, 3] = "yes";
                    skills[38, 3] = "yes";
                    skills[7, 3] = "yes";
                    skills[33, 3] = "yes";
                    chkSkill0.Checked = true;
                    chkSkill2.Checked = true;
                    chkSkill4.Checked = true;
                    chkSkill36.Checked = true;
                    chkSkill37.Checked = true;
                    chkSkill38.Checked = true;
                    chkSkill7.Checked = true;
                    chkSkill33.Checked = true;
                    break;
                case "Scholar":
                    skills[0, 3] = "yes";
                    skills[37, 3] = "yes";
                    skills[39, 3] = "yes";
                    skills[38, 3] = "yes";
                    skills[5, 3] = "yes";
                    skills[6, 3] = "yes";
                    skills[7, 3] = "yes";
                    skills[33, 3] = "yes";
                    chkSkill0.Checked = true;
                    chkSkill37.Checked = true;
                    chkSkill39.Checked = true;
                    chkSkill38.Checked = true;
                    chkSkill5.Checked = true;
                    chkSkill6.Checked = true;
                    chkSkill7.Checked = true;
                    chkSkill33.Checked = true;
                    break;
                case "Scoundrel":
                    skills[22, 3] = "yes";
                    skills[2, 3] = "yes";
                    skills[3, 3] = "yes";
                    skills[24, 3] = "yes";
                    skills[19, 3] = "yes";
                    skills[10, 3] = "yes";
                    skills[11, 3] = "yes";
                    skills[12, 3] = "yes";
                    chkSkill22.Checked = true;
                    chkSkill2.Checked = true;
                    chkSkill3.Checked = true;
                    chkSkill24.Checked = true;
                    chkSkill19.Checked = true;
                    chkSkill10.Checked = true;
                    chkSkill11.Checked = true;
                    chkSkill12.Checked = true;
                    break;
                case "Scout":
                    skills[36, 3] = "yes";
                    skills[39, 3] = "yes";
                    skills[7, 3] = "yes";
                    skills[19, 3] = "yes";
                    skills[9, 3] = "yes";
                    skills[11, 3] = "yes";
                    skills[13, 3] = "yes";
                    skills[14, 3] = "yes";
                    chkSkill36.Checked = true;
                    chkSkill39.Checked = true;
                    chkSkill7.Checked = true;
                    chkSkill19.Checked = true;
                    chkSkill9.Checked = true;
                    chkSkill11.Checked = true;
                    chkSkill13.Checked = true;
                    chkSkill14.Checked = true;
                    break;
                case "Warrior":
                    skills[16, 3] = "yes";
                    skills[23, 3] = "yes";
                    skills[25, 3] = "yes";
                    skills[17, 3] = "yes";
                    skills[18, 3] = "yes";
                    skills[8, 3] = "yes";
                    skills[9, 3] = "yes";
                    skills[14, 3] = "yes";
                    chkSkill16.Checked = true;
                    chkSkill23.Checked = true;
                    chkSkill25.Checked = true;
                    chkSkill17.Checked = true;
                    chkSkill18.Checked = true;
                    chkSkill8.Checked = true;
                    chkSkill9.Checked = true;
                    chkSkill14.Checked = true;
                    break;
            }
        }

        //click event to increment characteristics when "plus" button is clicked
        private void btnPlus_Click(object sender, EventArgs e)
        {
            Button myButton;
            myButton = (Button)sender;

            int buttonNumber = int.Parse(myButton.Name.Substring(4));
            switch (buttonNumber)
            {
                case 1:
                    incrementCharacteristicUp(ref brawn);
                    break;
                case 2:
                    incrementCharacteristicUp(ref agility);
                    break;
                case 3:
                    incrementCharacteristicUp(ref intellect);
                    break;
                case 4:
                    incrementCharacteristicUp(ref cunning);
                    break;
                case 5:
                    incrementCharacteristicUp(ref willpower);
                    break;
                case 6:
                    incrementCharacteristicUp(ref presence);
                    break;
            }
        }

        //click event to increment characteristics when "minus" button is clicked
        private void btnMinus_Click(object sender, EventArgs e)
        {
            Button myButton;
            myButton = (Button)sender;

            int buttonNumber = int.Parse(myButton.Name.Substring(4));
            switch (buttonNumber)
            {
                case 1:
                    incrementCharacteristicDown(ref brawn);
                    break;
                case 2:
                    incrementCharacteristicDown(ref agility);
                    break;
                case 3:
                    incrementCharacteristicDown(ref intellect);
                    break;
                case 4:
                    incrementCharacteristicDown(ref cunning);
                    break;
                case 5:
                    incrementCharacteristicDown(ref willpower);
                    break;
                case 6:
                    incrementCharacteristicDown(ref presence);
                    break;
            }
        }

        //function to increment characteristic and used XP up
        private void incrementCharacteristicUp(ref int characteristic)
        {
            if (characteristic < 5)
            {
                characteristic += 1;
                usedXP += characteristic * 10;
                runUpdates();
            }
        }

        //function to increment characteristic and used XP down
        private void incrementCharacteristicDown(ref int characteristic)
        {
            if (characteristic > 1)
            {
                usedXP -= characteristic * 10;
                characteristic -= 1;
                runUpdates();
            }
        }

        //function to update XP values, called by various click events
        private void updateXP()
        {
            remainXP = totalXP - usedXP;
            lblXPTotal.Text = totalXP.ToString();
            lblXPRemaining.Text = remainXP.ToString();
        }

        //function to update characteristics, called by various click events
        private void updateCharacteristics()
        {
            lblBrawnVal.Text = brawn.ToString();
            lblAgilityVal.Text = agility.ToString();
            lblIntellectVal.Text = intellect.ToString();
            lblCunningVal.Text = cunning.ToString();
            lblWillpowerVal.Text = willpower.ToString();
            lblPresenceVal.Text = presence.ToString();
        }

        //function to update derived stats, called by various click events
        private void updateDerivedStats()
        {
            soak = brawn + armor;
            lblSoak.Text = soak.ToString();
            lblDefenseRanged.Text = defenseRanged.ToString();
            lblDefenseMelee.Text = defenseMelee.ToString();
            lblWoundThreshold.Text = (woundThreshold + brawn).ToString();
            lblStrainThreshold.Text = (strainThreshold + willpower).ToString();
        }

        class SkillNUD : NumericUpDown
        {
            public override void UpButton()
            {
                base.UpButton();
            }
            public override void DownButton()
            {
                base.DownButton();
            }
        }

        private static int numSkills = 0;
        private void incrementSkill(object sender, EventArgs e)
        {
            NumericUpDown mySkill = (NumericUpDown)sender;
            int skillNumber = int.Parse(mySkill.Name.Substring(8));

            if (mySkill.Value > Convert.ToInt32(skills[skillNumber, 4]))
            {
                usedXP += ((Int32)mySkill.Value * 5);
                if (skills[skillNumber, 3] != "yes")
                {
                    numSkills++;
                    if (numSkills < 3)
                    {

                    }
                    else if (numSkills > 3)
                    {
                        usedXP += 5;
                    }
                    else { }
                }

                skills[skillNumber, 4] = mySkill.Value.ToString();
            }
            else if (mySkill.Value <= Convert.ToInt32(skills[skillNumber, 4]))
            {
                usedXP -= (5 + (Int32)mySkill.Value * 5);
                if (skills[skillNumber, 3] != "yes")
                {
                    usedXP -= 5;
                }

                skills[skillNumber, 4] = mySkill.Value.ToString();
            }
            else { }

            updateSkills();
            updateXP();
        }

        //function to update skills, called by various click events
        private void updateSkills()
        {
            /*
             *  Once I can figure out how to populate the textbox names using "linkSkill" + i.ToString(),
             *  turn this function into a loop.
            for (int i = 0; i < NUM_SKILLS; i++)
            {
                linkSkill__.Text = skills[i, 0] + " (" + skills[i, 1] + ")";
            }
            */

            //General Skills
            linkSkill0.Text = skills[0, 0] + " (" + skills[0, 1] + ")";
            linkSkill1.Text = skills[1, 0] + " (" + skills[1, 1] + ")";
            linkSkill2.Text = skills[2, 0] + " (" + skills[2, 1] + ")";
            linkSkill3.Text = skills[3, 0] + " (" + skills[3, 1] + ")";
            linkSkill4.Text = skills[4, 0] + " (" + skills[4, 1] + ")";
            linkSkill5.Text = skills[5, 0] + " (" + skills[5, 1] + ")";
            linkSkill6.Text = skills[6, 0] + " (" + skills[6, 1] + ")";
            linkSkill7.Text = skills[7, 0] + " (" + skills[7, 1] + ")";
            linkSkill8.Text = skills[8, 0] + " (" + skills[8, 1] + ")";
            linkSkill9.Text = skills[9, 0] + " (" + skills[9, 1] + ")";
            linkSkill10.Text = skills[10, 0] + " (" + skills[10, 1] + ")";
            linkSkill11.Text = skills[11, 0] + " (" + skills[11, 1] + ")";
            linkSkill12.Text = skills[12, 0] + " (" + skills[12, 1] + ")";
            linkSkill13.Text = skills[13, 0] + " (" + skills[13, 1] + ")";
            linkSkill14.Text = skills[14, 0] + " (" + skills[14, 1] + ")";
            linkSkill15.Text = skills[15, 0] + " (" + skills[15, 1] + ")";
            //Combat Skills
            linkSkill16.Text = skills[16, 0] + " (" + skills[16, 1] + ")";
            linkSkill17.Text = skills[17, 0] + " (" + skills[17, 1] + ")";
            linkSkill18.Text = skills[18, 0] + " (" + skills[18, 1] + ")";
            linkSkill19.Text = skills[19, 0] + " (" + skills[19, 1] + ")";
            linkSkill20.Text = skills[20, 0] + " (" + skills[20, 1] + ")";
            linkSkill21.Text = skills[21, 0] + " (" + skills[21, 1] + ")";
            //Social Skills
            linkSkill22.Text = skills[22, 0] + " (" + skills[22, 1] + ")";
            linkSkill23.Text = skills[23, 0] + " (" + skills[23, 1] + ")";
            linkSkill24.Text = skills[24, 0] + " (" + skills[24, 1] + ")";
            linkSkill25.Text = skills[25, 0] + " (" + skills[25, 1] + ")";
            linkSkill26.Text = skills[26, 0] + " (" + skills[26, 1] + ")";
            linkSkill27.Text = skills[27, 0] + " (" + skills[27, 1] + ")";
            linkSkill28.Text = skills[28, 0] + " (" + skills[28, 1] + ")";
            linkSkill29.Text = skills[29, 0] + " (" + skills[29, 1] + ")";
            //Magic Skills
            linkSkill30.Text = skills[30, 0] + " (" + skills[30, 1] + ")";
            linkSkill31.Text = skills[31, 0] + " (" + skills[31, 1] + ")";
            linkSkill32.Text = skills[32, 0] + " (" + skills[32, 1] + ")";
            linkSkill33.Text = skills[33, 0] + " (" + skills[33, 1] + ")";
            linkSkill34.Text = skills[34, 0] + " (" + skills[34, 1] + ")";
            linkSkill35.Text = skills[35, 0] + " (" + skills[35, 1] + ")";
            //Knowledge Skills
            linkSkill36.Text = skills[36, 0] + " (" + skills[36, 1] + ")";
            linkSkill37.Text = skills[37, 0] + " (" + skills[37, 1] + ")";
            linkSkill38.Text = skills[38, 0] + " (" + skills[38, 1] + ")";
            linkSkill39.Text = skills[39, 0] + " (" + skills[39, 1] + ")";
            linkSkill40.Text = skills[40, 0] + " (" + skills[40, 1] + ")";
            linkSkill41.Text = skills[41, 0] + " (" + skills[41, 1] + ")";
            linkSkill42.Text = skills[42, 0] + " (" + skills[42, 1] + ")";
            linkSkill43.Text = skills[43, 0] + " (" + skills[43, 1] + ")";

            nudSkill0.Text = skills[0, 4];
            nudSkill1.Text = skills[1, 4];
            nudSkill2.Text = skills[2, 4];
            nudSkill3.Text = skills[3, 4];
            nudSkill4.Text = skills[4, 4];
            nudSkill5.Text = skills[5, 4];
            nudSkill6.Text = skills[6, 4];
            nudSkill7.Text = skills[7, 4];
            nudSkill8.Text = skills[8, 4];
            nudSkill9.Text = skills[9, 4];
            nudSkill10.Text = skills[10, 4];
            nudSkill11.Text = skills[11, 4];
            nudSkill12.Text = skills[12, 4];
            nudSkill13.Text = skills[13, 4];
            nudSkill14.Text = skills[14, 4];
            nudSkill15.Text = skills[15, 4];
            //Combat Skills
            nudSkill16.Text = skills[16, 4];
            nudSkill17.Text = skills[17, 4];
            nudSkill18.Text = skills[18, 4];
            nudSkill19.Text = skills[19, 4];
            nudSkill20.Text = skills[20, 4];
            nudSkill21.Text = skills[21, 4];
            //Social Skills
            nudSkill22.Text = skills[22, 4];
            nudSkill23.Text = skills[23, 4];
            nudSkill24.Text = skills[24, 4];
            nudSkill25.Text = skills[25, 4];
            nudSkill26.Text = skills[26, 4];
            nudSkill27.Text = skills[27, 4];
            nudSkill28.Text = skills[28, 4];
            nudSkill29.Text = skills[29, 4];
            //Magic Skills
            nudSkill30.Text = skills[30, 4];
            nudSkill31.Text = skills[31, 4];
            nudSkill32.Text = skills[32, 4];
            nudSkill33.Text = skills[33, 4];
            nudSkill34.Text = skills[34, 4];
            nudSkill35.Text = skills[35, 4];
            //Knowledge Skills
            nudSkill36.Text = skills[36, 4];
            nudSkill37.Text = skills[37, 4];
            nudSkill38.Text = skills[38, 4];
            nudSkill39.Text = skills[39, 4];
            nudSkill40.Text = skills[40, 4];
            nudSkill41.Text = skills[41, 4];
            nudSkill42.Text = skills[42, 4];
            nudSkill43.Text = skills[43, 4];
        }

        private void runUpdates()
        {
            txtCharacterName.Text = characterName;
            cboSpecies.Text = species;
            cboSubSpecies.Text = subSpecies;
            cboCareer.Text = career;
            updateXP();
            updateCharacteristics();
            updateDerivedStats();
            updateSkills();
        }

        private void ResetXP()
        {
            totalXP = 0;
            remainXP = 0;
            usedXP = 0;
            lblXPTotal.Text = totalXP.ToString();
            lblXPRemaining.Text = remainXP.ToString();
        }

        //function to reset all values when "reset" button is clicked
        private void btnReset_Click(object sender, EventArgs e)
        {
            clearChkSkills();
            characterName = "";
            species = "";
            subSpecies = "";
            cboSubSpecies.Items.Clear();
            career = "";
            brawn = 2;
            agility = 2;
            intellect = 2;
            cunning = 2;
            willpower = 2;
            presence = 2;
            armor = 0;
            soak = 0;
            woundThreshold = 10;
            strainThreshold = 10;
            ResetXP();
            runUpdates();
            

            cboSpecies.Text = species.ToString();
            cboSubSpecies.Text = subSpecies.ToString();
            cboCareer.Text = career.ToString();
            txtWoundsCurrent.Clear();
            txtStrainCurrent.Clear();
            runUpdates();
            ResetXP();
        }

        private void clearChkSkills()
        {
            chkSkill0.Checked = false;
            chkSkill1.Checked = false;
            chkSkill2.Checked = false;
            chkSkill3.Checked = false;
            chkSkill4.Checked = false;
            chkSkill5.Checked = false;
            chkSkill6.Checked = false;
            chkSkill7.Checked = false;
            chkSkill8.Checked = false;
            chkSkill9.Checked = false;
            chkSkill10.Checked = false;
            chkSkill11.Checked = false;
            chkSkill12.Checked = false;
            chkSkill13.Checked = false;
            chkSkill14.Checked = false;
            chkSkill15.Checked = false;
            chkSkill16.Checked = false;
            chkSkill17.Checked = false;
            chkSkill18.Checked = false;
            chkSkill19.Checked = false;
            chkSkill20.Checked = false;
            chkSkill21.Checked = false;
            chkSkill22.Checked = false;
            chkSkill22.Checked = false;
            chkSkill23.Checked = false;
            chkSkill24.Checked = false;
            chkSkill25.Checked = false;
            chkSkill26.Checked = false;
            chkSkill27.Checked = false;
            chkSkill28.Checked = false;
            chkSkill29.Checked = false;
            chkSkill30.Checked = false;
            chkSkill31.Checked = false;
            chkSkill32.Checked = false;
            chkSkill33.Checked = false;
            chkSkill34.Checked = false;
            chkSkill35.Checked = false;
            chkSkill36.Checked = false;
            chkSkill37.Checked = false;
            chkSkill38.Checked = false;
            chkSkill39.Checked = false;
            chkSkill40.Checked = false;
            chkSkill41.Checked = false;
            chkSkill42.Checked = false;
            chkSkill43.Checked = false;

            skills[0, 4] = "0";
            skills[1, 4] = "0";
            skills[1, 4] = "0";
            skills[2, 4] = "0";
            skills[3, 4] = "0";
            skills[4, 4] = "0";
            skills[5, 4] = "0";
            skills[6, 4] = "0";
            skills[7, 4] = "0";
            skills[8, 4] = "0";
            skills[9, 4] = "0";
            skills[10, 4] = "0";
            skills[11, 4] = "0";
            skills[12, 4] = "0";
            skills[13, 4] = "0";
            skills[14, 4] = "0";
            skills[15, 4] = "0";
            skills[16, 4] = "0";
            skills[17, 4] = "0";
            skills[18, 4] = "0";
            skills[19, 4] = "0";
            skills[20, 4] = "0";
            skills[21, 4] = "0";
            skills[22, 4] = "0";
            skills[23, 4] = "0";
            skills[24, 4] = "0";
            skills[25, 4] = "0";
            skills[26, 4] = "0";
            skills[27, 4] = "0";
            skills[28, 4] = "0";
            skills[29, 4] = "0";
            skills[30, 4] = "0";
            skills[31, 4] = "0";
            skills[32, 4] = "0";
            skills[33, 4] = "0";
            skills[34, 4] = "0";
            skills[35, 4] = "0";
            skills[36, 4] = "0";
            skills[37, 4] = "0";
            skills[38, 4] = "0";
            skills[39, 4] = "0";
            skills[40, 4] = "0";
            skills[41, 4] = "0";
            skills[42, 4] = "0";
            skills[43, 4] = "0";
        }

        //function to update form when "update" button is clicked
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            runUpdates();
        }

        private void updateSkillCheckbox(object sender, EventArgs e)
        {
            CheckBox myCheckBox;
            myCheckBox = (CheckBox)sender;

            int checkNumber = int.Parse(myCheckBox.Name.Substring(8));

            if (myCheckBox.Checked)
            {
                skills[checkNumber, 3] = "yes";
            }
            else
            {
                skills[checkNumber, 3] = "no";
            }
        }

        //form exit
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //function to open the skills page
        public void linkSkills_Click(object sender, EventArgs e)
        {
            LinkLabel myLink;
            myLink = (LinkLabel)sender;
            int linkNumber = int.Parse(myLink.Name.Substring(9));
            string skillName = skills[linkNumber, 0];
            string characteristic = skills[linkNumber, 1];
            string description = skills[linkNumber, 2];
            string careerSkill = skills[linkNumber, 3];
            string rank = skills[linkNumber, 4];

            frmSkillPage skillsPage = new frmSkillPage(ref skillName, ref characteristic, ref description, ref career, ref rank, linkNumber);
            skillsPage.ShowDialog();
            this.Show();

            runUpdates();
        }

        //function to open the talent tree page
        private void btnTalents_Click(object sender, EventArgs e)
        {
            frmTalentsPage talentsPage = new frmTalentsPage();
            talentsPage.ShowDialog();
            this.Show();

            runUpdates();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
} 

