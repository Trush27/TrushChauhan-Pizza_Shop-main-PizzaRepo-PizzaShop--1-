namespace Service.Interfaces;

public interface IAuthService
{
    Task<bool> LoginAsync(string email, string password);
    void SendPasswordResetEmail(string email);
    void ResetPassword(string email, string newPassword);
    string EncryptPassword(string password);
    bool IsUserExists(string email);
    bool IsCorrectPassword(string email,string Password);
    Task<string> GetRoleByEmail(string email);
    string GetUserNameByEmail(string email);
    Task<string> GetRoleById(int roleid);
    int GetUserIdByEmail(string email);
}
