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
    
    public partial class TeamsGamers
    {
        public int ID { get; set; }
        public int GamerID { get; set; }
        public int TeamID { get; set; }
        public Nullable<int> PlayBegin { get; set; }
        public Nullable<int> PlayEnd { get; set; }
    
        public virtual Player Player { get; set; }
        public virtual Teams Teams { get; set; }
    }
}
