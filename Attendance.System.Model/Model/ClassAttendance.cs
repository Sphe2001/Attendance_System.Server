using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.System.Model.Model
{
    public class ClassAttendance
    {
        [Key]
        public int ClassAttendanceId { get; set; }
        [ForeignKey("ClassId")]
        public int ClassId { get; set; }
        public int NumberOfStudents { get; set; }
        public DateTime Date {  get; set; }

        public Class Class { get; set; }
    }
}
