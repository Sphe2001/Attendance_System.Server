using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.System.Model.Model
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [ForeignKey("CourseId")]
        public int? CourseId { get; set; }
        public int StudentNumber { get; set; }
        public string StudentNames { get; set; }
        public string StudentSurname { get; set; }
        public string Phone {  get; set; }

        public UserAccount UserAccount { get; set; }
        public Course Course { get; set; }
        public ICollection<Module> Modules { get; set; }
        public ICollection<Group> Groups { get; set; }
        public FaceData FaceData { get; set; }
        public ICollection<StudentAttendance> Attendances { get; set; }
    }
}
