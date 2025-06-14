using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.System.Model.Model
{
    public class StudentAttendance
    {
        [Key]
        public int AttendanceId { get; set; }
        [ForeignKey("StudentId")]
        public int StudentId { get; set; }
        [ForeignKey("ModuleId")]
        public int ModuleId { get; set; }
        public bool Status { get; set; }
        public bool IsFaceVerified { get; set; }
        public bool IsLocationVerified { get; set; }
        public DateTime TimeStamp { get; set; }

        public Student Student { get; set; }
        public Module Module { get; set; }
        public Class Class { get; set; }
    }
}
