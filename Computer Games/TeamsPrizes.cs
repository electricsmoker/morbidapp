//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Computer_Games
{
    using System;
    using System.Collections.Generic;
    
    public partial class TeamsPrizes
    {
        public TeamsPrizes()
        {
            this.CompetitionsTeams = new HashSet<CompetitionsTeams>();
        }
    
        public int ID { get; set; }
        public string PrizeName { get; set; }
    
        public virtual ICollection<CompetitionsTeams> CompetitionsTeams { get; set; }
    }
}
