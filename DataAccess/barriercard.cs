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
    
    public partial class barriercard
    {
        public barriercard()
        {
            this.removedbarriercards = new HashSet<removedbarriercard>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int AdventureDeckId { get; set; }
    
        public virtual adventuredeck adventuredeck { get; set; }
        public virtual ICollection<removedbarriercard> removedbarriercards { get; set; }
    }
}
