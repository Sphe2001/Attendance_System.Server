using Attendance.System.Model.Model;
using Attendance.System.Model.Returns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Attendance.System.Services.Auth.UserRegistration
{
    public interface IRegistrationService
    {
        Task<StatusMessageReturn> RegisterUserAsync(string email, string firstName, string lastName, string gender, string phoneNumber,
                                                    int userNumber, string password, string course, string job);
    }
}
