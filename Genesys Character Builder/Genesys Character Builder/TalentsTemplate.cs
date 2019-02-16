using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genesys_Character_Builder
{
    class TalentsTemplate
    {
        private string talentName;
        private string description;
        private bool active;
        private bool ranked;
        private int tier;
        private int page;

        public TalentsTemplate() { }
        public TalentsTemplate(string talentName, string description, bool active, bool ranked, int tier, int page)
        {
            this.TalentName = talentName;
            this.Description = description;
            this.Active = active;
            this.Ranked = ranked;
            this.Tier = tier;
            this.Page = page;
        }

        public string TalentName { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public bool Ranked { get; set; }
        public int Tier { get; set; }
        public int Page { get; set; }
    }
}
