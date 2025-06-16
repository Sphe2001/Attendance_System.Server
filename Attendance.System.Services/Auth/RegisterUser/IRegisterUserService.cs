
using Attendance.System.Model.Model.DTOs;
using Attendance.System.Model.Returns;

namespace Attendance.System.Services.Auth.RegisterUser
{
    public interface IRegisterUserService
    {
        Task<StatusMessageReturn> RegisterUser(string email, string password, int academicNumber, string userNames, string userSurname,
                            string phone, int roleId);
    }
}
