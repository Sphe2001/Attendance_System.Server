using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.System.Model.Model.DTOs
{
    public class StudentDto
    {
        public string Email { get; set; }
        public int StudentNumber { get; set; }
        public string StudentNames { get; set; }
        public string StudentSurname { get; set; }
        public string Course { get; set; }
        public string Role { get; set; }
    }
}
