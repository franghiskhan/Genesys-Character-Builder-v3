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
        private string talentDescription;
        private bool active;
        private bool ranked;
        private int tier;
        private string page;

        public TalentsTemplate() { }
        public TalentsTemplate(string talentName, string talentDescription, bool active, bool ranked, int tier, string page)
        {
            this.TalentName = talentName;
            this.TalentDescription = talentDescription;
            this.Active = active;
            this.Ranked = ranked;
            this.Tier = tier;
            this.Page = page;
        }

        public string TalentName { get; set; }
        public string TalentDescription { get; set; }
        public bool Active { get; set; }
        public bool Ranked { get; set; }
        public int Tier { get; set; }
        public string Page { get; set; }
    }
}
