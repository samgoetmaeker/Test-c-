//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FirstEDM
{
    using System;
    using System.Collections.Generic;
    
    public partial class Docent
    {
        public Docent()
        {
            this.Naam = new Naam();
        }
    
        public int DocentNr { get; set; }
        public decimal Wedde { get; set; }
        public int CampusNr { get; set; }
        public Nullable<Geslacht> Geslacht { get; set; }
    
        public Naam Naam { get; set; }
    
        public virtual Campus Campus { get; set; }
    }
}
