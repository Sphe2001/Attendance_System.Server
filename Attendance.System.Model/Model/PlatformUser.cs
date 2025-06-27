using System.ComponentModel.DataAnnotations;

namespace Attendance.System.Model.Model
{
    public class PlatformUser
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
        public string Signature { get; set; }
        public bool IsActive { get; set; }
        public bool ClockedIn { get; set; }
        public bool OnBreak { get; set; }
        public bool FinishedBreak { get; set; }
        public int SupervisorId { get; set; }
        public string DeviceId { get; set; }
        public int LogInCode {  get; set; }
        public ICollection<UserAttendance> UserAttendances { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
