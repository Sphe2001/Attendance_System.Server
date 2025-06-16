using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.System.Model.Model.DTOs
{
    public class AdminDto
    {
        public string Email { get; set; }
        public int StaffNumber { get; set; }
        public string AdminNames { get; set; }
        public string AdminSurname { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
        public string Faculty { get; set; }
    }
}
