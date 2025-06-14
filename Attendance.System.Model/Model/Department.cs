using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.System.Model.Model
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [ForeignKey("FacultyId")]
        public int FacultyId { get; set; }
        public string FacultyName { get; set; }

        public Faculty Faculty { get; set; }
        public ICollection<Staff> Staffs { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
