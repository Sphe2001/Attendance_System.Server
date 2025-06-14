using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.System.Model.Model
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        [ForeignKey("GroupId")]
        public int GroupId { get; set; }
        [ForeignKey("ModuleId")]
        public int ModuleId { get; set; }
        [ForeignKey("StaffId")]
        public int StaffId { get; set; }
        public string SessionType { get; set; }
        public DateOnly Date {  get; set; }
        public TimeOnly Time { get; set; }
        public string Venue {  get; set; }
        public string qrCodeToken { get; set; }

        public Group Group { get; set; }
        public Module Module { get; set; }
        public Staff Staff { get; set; }
        public ICollection<StudentAttendance> StudentAttendances { get; set; }
        public ICollection<ClassAttendance> ClassAttendances { get; set; }
        


    }
}
