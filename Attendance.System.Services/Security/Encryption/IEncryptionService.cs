

namespace Attendance.System.Services.Security.Encryption
{
    public interface IEncryptionService
    {
        string Hash(string input);

        bool Verify(string input, string hashedInput);
    }
}
