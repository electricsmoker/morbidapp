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
    
    public partial class Teams
    {
        public Teams()
        {
            this.CoachTrain = new HashSet<CoachTrain>();
            this.CompetitionsTeams = new HashSet<CompetitionsTeams>();
            this.Results = new HashSet<Results>();
            this.Results1 = new HashSet<Results>();
            this.Results2 = new HashSet<Results>();
            this.TeamsGamers = new HashSet<TeamsGamers>();
            this.TeamsPlay = new HashSet<TeamsPlay>();
        }
    
        public int ID { get; set; }
        public string TeamName { get; set; }
        public int CityID { get; set; }
        public string President { get; set; }
    
        public virtual City City { get; set; }
        public virtual ICollection<CoachTrain> CoachTrain { get; set; }
        public virtual ICollection<CompetitionsTeams> CompetitionsTeams { get; set; }
        public virtual ICollection<Results> Results { get; set; }
        public virtual ICollection<Results> Results1 { get; set; }
        public virtual ICollection<Results> Results2 { get; set; }
        public virtual ICollection<TeamsGamers> TeamsGamers { get; set; }
        public virtual ICollection<TeamsPlay> TeamsPlay { get; set; }
    }
}