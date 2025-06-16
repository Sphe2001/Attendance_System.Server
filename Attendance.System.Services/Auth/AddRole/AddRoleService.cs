using Attendance.System.Model;
using Attendance.System.Model.Model;
using Attendance.System.Model.Returns;
using Microsoft.EntityFrameworkCore;


namespace Attendance.System.Services.Auth.AddRole
{
    public class AddRoleService : IAddRoleService
    {
        AttendanceSystemDbContext _dbContext;

        public AddRoleService(AttendanceSystemDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<StatusMessageReturn> AddRoleAsyc(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName))
            {
                return new StatusMessageReturn
                {
                    Status = false,
                    Message = "Role name cannot be empty."
                };
            }

            var exists = await _dbContext.Roles
                .AnyAsync(p => p.RoleName == roleName);

            if (exists)
            {
                return new StatusMessageReturn
                {
                    Status = false,
                    Message = "Role already exist."
                };
            }

            var role = new Role
            {
                RoleName = roleName.ToUpper(),
            };

            _dbContext.Roles.Add(role);
            await _dbContext.SaveChangesAsync();

            return new StatusMessageReturn
            {
                Status = true,
                Message = "Role created successfully."
            };
        }

        public async Task<StatusMessageReturn> DeleteRoleAsync(int roleId)
        {
            var role = await _dbContext.Roles.FirstOrDefaultAsync(r =>  r.RoleId == roleId);
            if (role == null) 
            {
                return new StatusMessageReturn
                {
                    Status = false,
                    Message = "Role not found."
                };
            }

            _dbContext.Remove(role);
            await _dbContext.SaveChangesAsync();
            return new StatusMessageReturn
            {
                Status = true,
                Message = "Role successfully removed"
            };
        }
    }
}
