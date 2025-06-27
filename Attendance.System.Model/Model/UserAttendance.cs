using System.ComponentModel.DataAnnotations;

namespace Attendance.System.Model.Model
{
    public class UserAttendance
    {
        [Key]
        public int Id { get; set; }
        public DateTime ClockIn { get; set; }
        public DateTime ClockOut { get; set; }
        public DateTime StartBreak { get; set; }
        public DateTime EndBreak { get; set; }
        public bool Manual { get; set; }
        public DateOnly TodayDate { get; set; }
        public PlatformUser PlatformUser { get; set; }
    }
}
