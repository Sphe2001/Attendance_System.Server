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
        [ForeignKey("GroupId")]
        public int GroupId { get; set; }
        public int StudentNumber { get; set; }
        public string StudentNames { get; set; }
        public string StudentSurname { get; set; }

        public UserAccount UserAccount { get; set; }
        public Group Group { get; set; }
        public FaceData FaceData { get; set; }
        public ICollection<StudentAttendance> Attendances { get; set; }
    }
}
