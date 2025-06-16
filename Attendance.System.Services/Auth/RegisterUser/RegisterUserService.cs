
using System.Text.RegularExpressions;

using Attendance.System.Model;
using Attendance.System.Model.Model;
using Attendance.System.Model.Model.DTOs;
using Attendance.System.Model.Returns;
using Attendance.System.Services.Security.Encryption;
using Microsoft.EntityFrameworkCore;

namespace Attendance.System.Services.Auth.RegisterUser
{
    public class RegisterUserService: IRegisterUserService
    {
        AttendanceSystemDbContext _dbContext;
        IEncryptionService _encryptionService;

        public RegisterUserService(AttendanceSystemDbContext dbContext, IEncryptionService encryptionService)
        {
            _dbContext = dbContext;
            _encryptionService = encryptionService;
        }

        public async Task<StatusMessageReturn> RegisterUser(string email, string password, int academicNumber, string userNames,
                                        string userSurname,string phone, int roleId)
        {
            var lowerCaseEmail = email.ToLower();
            if (string.IsNullOrEmpty(lowerCaseEmail)) 
            {
                return new StatusMessageReturn
                {
                    Status = false,
                    Message = "Email cannot be empty."
                };
            }

            if (string.IsNullOrWhiteSpace(userNames))
            {
                return new StatusMessageReturn
                {
                    Status = false,
                    Message = "User name(s) cannot be empty."
                };
            }
            if (string.IsNullOrWhiteSpace(userSurname))
            {
                return new StatusMessageReturn
                {
                    Status = false,
                    Message = "User surname cannot be empty."
                };
            }
            if (academicNumber == 0)
            {
                return new StatusMessageReturn
                {
                    Status = false,
                    Message = "Staff/Student number cannot be empty."
                };
            }
         
            var emailExists = await _dbContext.UserAccounts.AnyAsync(s => s.Email == lowerCaseEmail);
            if (emailExists)
            {
                return new StatusMessageReturn
                {
                    Status = false,
                    Message = "Email already used."
                };
            }
            var staffNoExists = await _dbContext.Staffs.AnyAsync(s => s.StaffNumber == academicNumber);

            if (staffNoExists)
            {
                return new StatusMessageReturn
                {
                    Status = false,
                    Message = "Staff number already used."
                };
            }
            var adminNoExists = await _dbContext.Admins.AnyAsync(a => a.StaffNumber == academicNumber);

            if (adminNoExists)
            {
                return new StatusMessageReturn
                {
                    Status = false,
                    Message = "Staff number already used."
                };
            }
            var studentNoExists = await _dbContext.Students.AnyAsync(s => s.StudentNumber == academicNumber);

            if (studentNoExists)
            {
                return new StatusMessageReturn
                {
                    Status = false,
                    Message = "Student number already used."
                };
            }

            var hashedPassword = _encryptionService.Hash(password);
            var user = new UserAccount
            {
                Email = lowerCaseEmail,
                Password = hashedPassword,
                RoleId = roleId,
                IsPasswordSet = false,
                IsDisabled = false,
                IsPasswordResetVerified = false,
                CreatedAt = DateTime.UtcNow,
            };

            _dbContext.UserAccounts.Add(user);
            await _dbContext.SaveChangesAsync();

            var fullUser = await _dbContext.UserAccounts.FindAsync(user.UserId);
            var role = await _dbContext.Roles.FindAsync(fullUser.RoleId);
            var roleName = role.RoleName;

            if (roleName == null)
            {
                return new StatusMessageReturn
                {
                    Status = false,
                    Message = "failed to fetch role."
                };
            }
            else
            {
                switch (roleName)
                {
                    case "ADMIN":
                        _dbContext.Admins.Add(new Admin
                        {
                            StaffNumber = academicNumber,
                            AdminNames = userNames,
                            AdminSurname = userSurname,
                            Phone = phone,
                            UserId = fullUser.UserId,
                            UserAccount = fullUser!
                        });
                        break;

                    case "HOD":
                    case "LECTURER":
                        _dbContext.Staffs.Add(new Staff
                        {
                            StaffNumber = academicNumber,
                            StaffNames = userNames,
                            StaffSurname = userSurname,
                            Phone = phone,
                            UserId = fullUser.UserId,
                            UserAccount = fullUser!
                        });
                        break;

                    case "STUDENT":
                        _dbContext.Students.Add(new Student
                        {
                            StudentNumber = academicNumber,
                            StudentNames = userNames,
                            StudentSurname = userSurname,
                            Phone = phone,
                            UserId = fullUser.UserId,
                            UserAccount = fullUser!
                        });
                        break;

                    default:
                        return new StatusMessageReturn
                        {
                            Status = false,
                            Message = "No valid role given."
                        };
                }
                await _dbContext.SaveChangesAsync();
            }
            return new StatusMessageReturn
            {
                Status = true,
                Message = "User account created successfully."
            };


        }

        //If email validation is requered.
        public bool IsValidEmail(string email)
        {
            if (!email.Contains("@tut4life.ac.za") || !email.Contains("@tut.ac.za"))
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

            if (email.Contains("@tut4life.ac.za"))
            {
                if (localPart.Length != 9 || !Regex.IsMatch(localPart, @"^\d{9}$"))
                {
                    return false;
                }

            }

            if (domainPart != "tut4life.ac.za" || domainPart != "tut.ac.za")
            {
                return false;
            }

            return true;
        }
    }
}
