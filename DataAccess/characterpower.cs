//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class characterpower
    {
        public int Id { get; set; }
        public int PartyCharacterId { get; set; }
        public int PowerId { get; set; }
        public int SelectedPowers { get; set; }
    
        public virtual partycharacter partycharacter { get; set; }
        public virtual power power { get; set; }
    }
}