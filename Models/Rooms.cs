﻿//------------------------------------------------------------------------------
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
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public partial class Rooms
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rooms()
        {
            this.Reservation = new HashSet<Reservation>();
            Images_Room = "~/Content/image/pngtree-plus-icon-3d-illustration-png-image_8957667.png";
            Images_Cate = "~/Content/image/pngtree-plus-icon-3d-illustration-png-image_8957667.png";
        }
        [NotMapped]
        public HttpPostedFileBase UploadImage{ get; set; }
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
        public string Images_Cate { get; set; }
    
        public virtual Host Host { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservation> Reservation { get; set; }
        public List<Rooms> ListCate { get; internal set; }
    }
}
