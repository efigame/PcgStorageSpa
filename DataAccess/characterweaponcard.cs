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
    
    public partial class characterweaponcard
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public int WeaponCardId { get; set; }
        public int Count { get; set; }
    
        public virtual character character { get; set; }
        public virtual weaponcard weaponcard { get; set; }
    }
}
