﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CourseManagementEntities : DbContext
    {
        public CourseManagementEntities()
            : base("name=CourseManagementEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ClassRoom> ClassRooms { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<EnrollCourse> EnrollCourses { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<TeacherInfo> TeacherInfoes { get; set; }
        public virtual DbSet<TeacherSkill> TeacherSkills { get; set; }
    }
}
