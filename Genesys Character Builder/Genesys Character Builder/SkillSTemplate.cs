using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesys_Character_Builder
{
    public class SkillsTemplate
    {
        private string skillName;
        private string characteristic;
        private string description;
        private bool career;
        private int rank;

        public SkillsTemplate() { }
        public SkillsTemplate(string skillName, string characteristic, string description, bool career, int rank)
        {
            this.SkillName = skillName;
            this.Characteristic = characteristic;
            this.Description = description;
            this.Career = career;
            this.Rank = rank;
        }

        public string SkillName { get; set; }
        public string Characteristic { get; set; }
        public string Description { get; set; }
        public bool Career { get; set; }
        public int Rank { get; set; }
    }
}
