//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Term
    {
        public Term()
        {
            this.Connection = new HashSet<Connection>();
            this.Connection1 = new HashSet<Connection>();
            this.Property = new HashSet<Property>();
            this.Relation = new HashSet<Relation>();
            this.Relation1 = new HashSet<Relation>();
        }
    
        public int Term_Id { get; set; }
        public Nullable<int> Term_XmlFile_Id { get; set; }
        public string Term_Title { get; set; }
    
        public virtual ICollection<Connection> Connection { get; set; }
        public virtual ICollection<Connection> Connection1 { get; set; }
        public virtual ICollection<Property> Property { get; set; }
        public virtual ICollection<Relation> Relation { get; set; }
        public virtual ICollection<Relation> Relation1 { get; set; }
        public virtual XmlFile XmlFile { get; set; }
    }
}
