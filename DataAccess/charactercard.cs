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
    
    public partial class charactercard
    {
        public charactercard()
        {
            this.powers = new HashSet<power>();
            this.skills = new HashSet<skill>();
            this.characters = new HashSet<character>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int BaseHandSize { get; set; }
        public int BaseLightArmors { get; set; }
        public int BaseHeavyArmors { get; set; }
        public int BaseWeapons { get; set; }
        public int BaseWeaponCards { get; set; }
        public int BaseSpellCards { get; set; }
        public int BaseArmorCards { get; set; }
        public int BaseItemCards { get; set; }
        public int BaseAllyCards { get; set; }
        public int BaseBlessingCards { get; set; }
        public int PossibleHandSize { get; set; }
        public int PossibleWeaponCards { get; set; }
        public int PossibleSpellCards { get; set; }
        public int PossibleArmorCards { get; set; }
        public int PossibleItemCards { get; set; }
        public int PossibleAllyCards { get; set; }
        public int PossibleBlessingCards { get; set; }
        public string FavoredCardType { get; set; }
    
        public virtual ICollection<power> powers { get; set; }
        public virtual ICollection<skill> skills { get; set; }
        public virtual ICollection<character> characters { get; set; }
    }
}
