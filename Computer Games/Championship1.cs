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
    
    public partial class Championship1
    {
        public Championship1()
        {
            this.Results = new HashSet<Results>();
        }
    
        public int ID { get; set; }
        public int YearOfStart { get; set; }
        public long PrizeFond { get; set; }
        public int GamesID { get; set; }
        public Nullable<int> NameOfChampionshipID { get; set; }
    
        public virtual Championship Championship { get; set; }
        public virtual Games Games { get; set; }
        public virtual ICollection<Results> Results { get; set; }
    }
}