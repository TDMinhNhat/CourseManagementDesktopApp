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

    public partial class Skill : DbSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Skill()
        {
            this.TeacherSkills = new HashSet<TeacherSkill>();
            this.Skill1 = new HashSet<Skill>();
        }
    
        public long SkillID { get; set; }
        public string SkillName { get; set; }
        public Nullable<long> SkillParent { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeacherSkill> TeacherSkills { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Skill> Skill1 { get; set; }
        public virtual Skill Skill2 { get; set; }
    }
}
