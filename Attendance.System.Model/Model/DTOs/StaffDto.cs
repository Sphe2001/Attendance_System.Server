using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.System.Model.Model.DTOs
{
    public class StaffDto
    {
        public string Email { get; set; }
        public int StaffNumber { get; set; }
        public string StaffNames { get; set; }
        public string StaffSurname { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public string Department{ get; set; }
    }
}
