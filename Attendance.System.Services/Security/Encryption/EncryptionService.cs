using System;
using System.Collections.Generic;


namespace Attendance.System.Services.Security.Encryption
{
    public class EncryptionService : IEncryptionService
    {
        public string Hash(string input)
        {
            string hashedInput = BCrypt.Net.BCrypt.HashPassword(input);

            return hashedInput;
        }

        public bool Verify(string input, string hashedInput)
        {
            bool isValid = BCrypt.Net.BCrypt.Verify(input, hashedInput);

            return isValid;
        }
    }
}
