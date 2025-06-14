using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Attendance.System.Model.Model
{
    public class UserAccount
    {
        [Key]
        public int UserId { get; set; }
        public string Email { get; set; }   
        public string Password { get; set; }
        [ForeignKey("RoleId")]
        public int RoleId { get; set; } 
        public DateTime CreatedAt { get; set; }

        public Role Role { get; set; }
        public Admin Admin { get; set; }
        public Staff Staff { get; set; }
        public Student Student { get; set; }
    }
}
