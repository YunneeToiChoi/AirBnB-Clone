//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AirBnB_Clone_project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Room
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Room()
        {
            this.Reservations = new HashSet<Reservation>();
        }
    
        public int Id_Room { get; set; }
        public string Room_Name { get; set; }
        public string Place { get; set; }
        public string Images_Room { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Home_types { get; set; }
        public string Room_types { get; set; }
        public Nullable<int> ID_Host { get; set; }
        public Nullable<int> ID_Cate { get; set; }
        public string Name_Cate { get; set; }
    
        public virtual Host Host { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
