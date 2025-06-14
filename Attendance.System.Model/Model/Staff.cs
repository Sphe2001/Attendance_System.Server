using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.System.Model.Model
{
    public class Staff
    {
        [Key]
        public int StaffId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }
        public int StaffNumber { get; set; }
        public string StaffNames { get; set; }
        public string StaffSurname { get; set; }
        public string Phone {  get; set; }

        public UserAccount UserAccount { get; set; }
        public Department Department { get; set; }

    }
}
