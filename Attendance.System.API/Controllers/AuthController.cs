using System.Security.Cryptography;
using System.Text;
using Attendance.System.Model.Requests;
using Attendance.System.Services.Auth.UserRegistration;
using Attendance.System.Services.Emailer.Registration;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace Attendance.System.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : Controller
    {
        private readonly IRegistrationEmailService _registrationEmailService;
        private readonly IRegistrationService _registrationService;
       
        public AuthController(IRegistrationEmailService registrationEmailService, IRegistrationService registrationService)
        {
            _registrationEmailService = registrationEmailService;
            _registrationService = registrationService;
        }
        public static string GenerateRandomPassword()
        {
            char[] specialCharacters = { '@', '*', '#', '!' };
            StringBuilder password = new StringBuilder();

            Random random = new Random();

            for (int i = 0; i < 2; i++)
            {
                char randUpper = (char)random.Next(65, 91);
                char randSpecial = specialCharacters[random.Next(specialCharacters.Length)];
                password.Append(randUpper).Append(randSpecial);
            }


            for (int i = 0; i < 2; i++)
            {
                char randLower = (char)random.Next(97, 123);
                int randDigit = random.Next(0, 10);
                password.Append(randLower).Append(randDigit);
            }

            return password.ToString();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] AddUserRequest request)
        {
            var password = GenerateRandomPassword();

            var result = await _registrationService.RegisterUserAsync(request.Email, request.FirstName, request.LastName, request.Gender,
                    request.PhoneNumber, password, request.UserNumber, request.Course, request.Job, request.Role);

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
