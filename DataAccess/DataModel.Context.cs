﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PcgStorageEntities : DbContext
    {
        public PcgStorageEntities()
            : base("name=PcgStorageEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<party> parties { get; set; }
        public virtual DbSet<pcguser> pcgusers { get; set; }
        public virtual DbSet<skill> skills { get; set; }
        public virtual DbSet<subskill> subskills { get; set; }
        public virtual DbSet<power> powers { get; set; }
        public virtual DbSet<charactercard> charactercards { get; set; }
        public virtual DbSet<card> cards { get; set; }
        public virtual DbSet<cardtype> cardtypes { get; set; }
        public virtual DbSet<adventurepath> adventurepaths { get; set; }
        public virtual DbSet<adventuredeck> adventuredecks { get; set; }
        public virtual DbSet<character> characters { get; set; }
        public virtual DbSet<scenario> scenarios { get; set; }
        public virtual DbSet<characterdeck> characterdecks { get; set; }
        public virtual DbSet<characterpower> characterpowers { get; set; }
        public virtual DbSet<characterskill> characterskills { get; set; }
        public virtual DbSet<characterscenario> characterscenarios { get; set; }
        public virtual DbSet<allycard> allycards { get; set; }
        public virtual DbSet<armorcard> armorcards { get; set; }
        public virtual DbSet<blessingcard> blessingcards { get; set; }
        public virtual DbSet<itemcard> itemcards { get; set; }
        public virtual DbSet<spellcard> spellcards { get; set; }
        public virtual DbSet<weaponcard> weaponcards { get; set; }
    }
}
