using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Attendance.System.Model;
using Attendance.System.Model.Model;
using Attendance.System.Model.Returns;
using Attendance.System.Services.Security.Encryption;
using Microsoft.EntityFrameworkCore;

namespace Attendance.System.Services.Auth.UserRegistration
{
    public class RegistrationService : IRegistrationService
    {
        AttendanceSystemDbContext _dbContext;
        IEncryptionService _encryptionService;

        public RegistrationService( AttendanceSystemDbContext dbContext, IEncryptionService encryptionService)
        {
            _dbContext = dbContext;
            _encryptionService = encryptionService;
        }
        public async Task<StatusMessageReturn> RegisterUserAsync(string email, string firstName, string lastName, string gender, string phoneNumber, string userNumber, string course, string job, string role, string password)
        {
            var lowercaseEmail = email.ToLower();

            if (string.IsNullOrWhiteSpace(lowercaseEmail))
            {
                return new StatusMessageReturn
                {
                    Status = false,
                    Message = "Email cannot be empty."
                };
            }
            if (string.IsNullOrWhiteSpace(firstName))
            {
                return new StatusMessageReturn
                {
                    Status = false,
                    Message = "User name cannot be empty."
                };
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                return new StatusMessageReturn
                {
                    Status = false,
                    Message = "User surname cannot be empty."
                };
            }
            if (string.IsNullOrWhiteSpace(gender))
            {
                return new StatusMessageReturn
                {
                    Status = false,
                    Message = "Gender cannot be empty."
                };
            }
            if (string.IsNullOrWhiteSpace(course))
            {
                return new StatusMessageReturn
                {
                    Status = false,
                    Message = "Course cannot be empty."
                };
            }
            if (string.IsNullOrWhiteSpace(job))
            {
                return new StatusMessageReturn
                {
                    Status = false,
                    Message = "User must have a job."
                };
            }
            if (string.IsNullOrWhiteSpace(role))
            {
                return new StatusMessageReturn
                {
                    Status = false,
                    Message = "User must have a role."
                };
            }
            if (string.IsNullOrWhiteSpace(userNumber))
            {
                return new StatusMessageReturn
                {
                    Status = false,
                    Message = "Staff/Student number cannot be empty."
                };
            }
            var userNoExists = await _dbContext.PrivateUsers.AnyAsync(u => u.UserNumber == userNumber);

            if (userNoExists)
            {
                return new StatusMessageReturn
                {
                    Status = false,
                    Message = "Staff/Student number already exists."
                };
            }

            var emailExists = await _dbContext.PrivateUsers.AnyAsync(s => s.Email == lowercaseEmail);

            if (emailExists)
            {
                return new StatusMessageReturn
                {
                    Status = false,
                    Message = "Email already exists."
                };
            }
            if (role == "STUDENT")
            {
                if (!IsStudentEmailValid(email)) 
                {
                    return new StatusMessageReturn
                    {
                        Status = false,
                        Message = "Invalid Email."
                    };
                }
            }else if(role == "STAFF")
            {
                if (!IsStaffEmailValid(email))
                {
                    return new StatusMessageReturn
                    {
                        Status = false,
                        Message = "Invalid Email."
                    };
                }
            }

            var hashedPassword = _encryptionService.Hash(password);

            var newUser = new PrivateUser
            {
                Email = email,
                UserNumber = userNumber,
                FirstName = firstName,
                LastName = lastName,
                Gender = gender,
                PhoneNumber = phoneNumber,
                Course = course,
                Job = job,
                Role = role,
                Password = hashedPassword,
                AddedToPlatform = false,
                CreatedAt = DateTime.Now,
            };

            _dbContext.PrivateUsers.Add(newUser);
            await _dbContext.SaveChangesAsync();

            return new StatusMessageReturn
            {
                Status = true,
                Message = "User created."
            };

            
        }


        public bool IsStudentEmailValid(string email)
        {
            if (string.IsNullOrEmpty(email) || !email.Contains("@tut4life.ac.za"))
            {
                return false;
            }

            var emailParts = email.Split('@');

            if (emailParts.Length != 2)
            {
                return false;
            }

            string localPart = emailParts[0];
            string domainPart = emailParts[1];

            if (localPart.Length != 9 || !Regex.IsMatch(localPart, @"^\d{9}$"))
            {
                return false;
            }

            
            if (domainPart != "tut4life.ac.za")
            {
                return false;
            }

            return true;
        }

        public bool IsStaffEmailValid(string email)
        {
            if (string.IsNullOrEmpty(email) || !email.Contains("@tut.ac.za"))
            {
                return false;
            }

            var emailParts = email.Split('@');

            if (emailParts.Length != 2)
            {
                return false;
            }

            string localPart = emailParts[0];
            string domainPart = emailParts[1];

            if (domainPart != "tut.ac.za")
            {
                return false;
            }

            return true;
        }
    }
}
