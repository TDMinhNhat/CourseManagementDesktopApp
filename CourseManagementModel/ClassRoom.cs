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

    public partial class ClassRoom : DbSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClassRoom()
        {
            this.EnrollCourses = new HashSet<EnrollCourse>();
        }
    
        public string ClassID { get; set; }
        public string ClassDescription { get; set; }
        public int TypeStudy { get; set; }
        public System.DateTime DateStarted { get; set; }
        public System.DateTime DateEnded { get; set; }
        public int MaxStudent { get; set; }
        public string TeacherID { get; set; }
        public string CourseID { get; set; }
        public string ClassStatus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EnrollCourse> EnrollCourses { get; set; }
        public virtual Course Course { get; set; }
        public virtual Person Person { get; set; }
    }
}
