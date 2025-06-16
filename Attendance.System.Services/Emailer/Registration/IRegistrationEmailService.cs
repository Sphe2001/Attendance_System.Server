

namespace Attendance.System.Services.Emailer.Registration
{
    public interface IRegistrationEmailService
    {
        Task sendRegistrationEmail(string email, string password);
    }
}
