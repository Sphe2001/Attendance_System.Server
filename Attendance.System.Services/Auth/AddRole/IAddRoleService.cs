
using Attendance.System.Model.Returns;

namespace Attendance.System.Services.Auth.AddRole
{
    public interface IAddRoleService
    {
        Task<StatusMessageReturn> AddRoleAsyc(string roleName);
        Task<StatusMessageReturn> DeleteRoleAsync(int roleId);
        
    }
}
