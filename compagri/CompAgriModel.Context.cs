﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CompAgri
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB_9BA48E_xmldbEntities : DbContext
    {
        public DB_9BA48E_xmldbEntities()
            : base("name=DB_9BA48E_xmldbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Connection> Connection { get; set; }
        public virtual DbSet<Property> Property { get; set; }
        public virtual DbSet<Relation> Relation { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Term> Term { get; set; }
        public virtual DbSet<XmlFile> XmlFile { get; set; }
    }
}
