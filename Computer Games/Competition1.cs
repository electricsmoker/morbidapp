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
    
    public partial class Competition1
    {
        public Competition1()
        {
            this.CompetitionsGamers = new HashSet<CompetitionsGamers>();
            this.CompetitionsTeams = new HashSet<CompetitionsTeams>();
            this.TeamsPlay = new HashSet<TeamsPlay>();
        }
    
        public int ID { get; set; }
        public int CompetitionID { get; set; }
        public System.DateTime Date { get; set; }
        public int GameID { get; set; }
    
        public virtual Competition Competition { get; set; }
        public virtual Games Games { get; set; }
        public virtual ICollection<CompetitionsGamers> CompetitionsGamers { get; set; }
        public virtual ICollection<CompetitionsTeams> CompetitionsTeams { get; set; }
        public virtual ICollection<TeamsPlay> TeamsPlay { get; set; }
    }
}
