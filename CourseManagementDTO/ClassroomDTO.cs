using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseManagementDTO
{
    public class ClassroomDTO
    {
        public string ClassID { get; set; }
        public int TypeStudy { get; set; }
        public Nullable<System.DateTime> DateStarted { get; set; }
        public Nullable<System.DateTime> DateEnded { get; set; }
        public string TeacherID { get; set; }
        public string CourseID { get; set; }
        public int MaxStudent { get; set; }
        
    }
}
