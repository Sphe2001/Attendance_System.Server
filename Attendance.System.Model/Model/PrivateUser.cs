using System.ComponentModel.DataAnnotations;

namespace Attendance.System.Model.Model
{
    public class PrivateUser
    {
        [Key]
        public int Id { get; set; }
        public string UserNumber { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string ProfilePicture { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public string Course { get; set; }
        public string Job { get; set; }
        public string Password { get; set; }
        public bool AddedToPlatform { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}
    }
}
