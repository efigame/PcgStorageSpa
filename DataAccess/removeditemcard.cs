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
    
    public partial class removeditemcard
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public int PartyId { get; set; }
        public int ItemCardId { get; set; }
    
        public virtual itemcard itemcard { get; set; }
        public virtual party party { get; set; }
    }
}
