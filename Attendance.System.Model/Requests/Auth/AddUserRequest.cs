using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.System.Model.Requests.Auth
{
    public class AddUserRequest
    {
        public string Email { get; set; }
        public int AcademicNumber { get; set; }
        public string UserNames { get; set; }
        public string UserSurname { get; set; }
        public string Phone { get; set; }
        public int RoleId { get; set; }
    }
}
