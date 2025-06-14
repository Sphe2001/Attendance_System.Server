using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.System.Model.Model
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        [ForeignKey("FacultyId")]
        public int FacultyId { get; set; }
        public int StaffNumber { get; set; }
        public string AdminNames { get; set; }
        public string AdminSurname { get; set; }
        public string Phone { get; set; }

        public UserAccount UserAccount { get; set; }
        public Faculty Faculty { get; set; }
    }
}
