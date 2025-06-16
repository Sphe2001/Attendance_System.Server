using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.System.Model.Model
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }

        public Department Department { get; set; }
        public ICollection<Module> Modules { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
