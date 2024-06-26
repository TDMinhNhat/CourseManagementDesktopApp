//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CourseManagementModel
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public partial class Course : DbSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            this.ClassRooms = new HashSet<ClassRoom>();
        }
    
        public string CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string CateID { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModifier { get; set; }
        public string Image { get; set; }
    
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClassRoom> ClassRooms { get; set; }
    }
}
