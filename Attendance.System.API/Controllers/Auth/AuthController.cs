using System.Numerics;
using System.Security.Cryptography;
using Attendance.System.Model.Model;
using Attendance.System.Model.Model.DTOs;
using Attendance.System.Model.Requests.Auth;
using Attendance.System.Services.Auth.AddRole;
using Attendance.System.Services.Auth.RegisterUser;
using Attendance.System.Services.Emailer.Registration;
using Hangfire;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Attendance.System.API.Controllers.Auth
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : Controller
    {
        private readonly IAddRoleService _roleService;
        private readonly IRegisterUserService _registerUserService;
        private readonly IRegistrationEmailService _registrationEmailService;

        public AuthController(IAddRoleService roleService, IRegisterUserService registerUserService, IRegistrationEmailService registrationEmailService)
        {
            _roleService = roleService;
            _registerUserService = registerUserService;
            _registrationEmailService = registrationEmailService;
        }

        [HttpPost]
        public async Task<IActionResult> AddRole([FromBody] AddRoleRequest request)
        {
            var result = await _roleService.AddRoleAsyc(request.RoleName);

            if (result.Status)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddUserAccount([FromBody] AddUserRequest request)
        {
            var password = RandomNumberGenerator.GetInt32(100000, 999999).ToString();

            var result = await _registerUserService.RegisterUser(request.Email, password, request.AcademicNumber, request.UserNames, request.UserSurname,
                            request.Phone, request.RoleId);

            if (result.Status)
            {
                BackgroundJob.Enqueue(() => _registrationEmailService.sendRegistrationEmail(request.Email, password));
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
