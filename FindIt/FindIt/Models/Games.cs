//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FindIt.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Games
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Games()
        {
            this.PlayedGames = new HashSet<PlayedGames>();
        }
    
        public System.Guid GameId { get; set; }
        public System.Guid Question1Id { get; set; }
        public System.Guid Question2Id { get; set; }
        public System.Guid Question3Id { get; set; }
        public System.Guid Question4Id { get; set; }
        public System.Guid Question5Id { get; set; }
        public System.Guid Question6Id { get; set; }
        public System.Guid Question7Id { get; set; }
        public System.Guid Question8Id { get; set; }
        public System.Guid Question9Id { get; set; }
        public System.Guid Question10Id { get; set; }
    
        public virtual Questions Questions { get; set; }
        public virtual Questions Questions1 { get; set; }
        public virtual Questions Questions2 { get; set; }
        public virtual Questions Questions3 { get; set; }
        public virtual Questions Questions4 { get; set; }
        public virtual Questions Questions5 { get; set; }
        public virtual Questions Questions6 { get; set; }
        public virtual Questions Questions7 { get; set; }
        public virtual Questions Questions8 { get; set; }
        public virtual Questions Questions9 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlayedGames> PlayedGames { get; set; }
    }
}
