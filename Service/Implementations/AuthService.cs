using Microsoft.Extensions.Configuration;
using Repository.Interfaces;
using Service.Interfaces;
using System.Text;
namespace Service.Implementations;
public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepo;
    private readonly IRoleRepository _roleRepo;
    private readonly IConfiguration _config;
    private readonly IEmailService _emailService;

    public AuthService(
        IUserRepository userRepo,
        IRoleRepository roleRepo,
        IConfiguration config,
        IEmailService emailService)
    {
        _roleRepo = roleRepo;
        _userRepo = userRepo;
        _config = config;
        _emailService = emailService;
    }

    public async Task<bool> LoginAsync(string email, string password)
    {
        var encryptedPass = EncryptPassword(password);
        var user = _userRepo.GetUserByEmail(email);
        return user?.Password == encryptedPass;
    }
    public bool IsCorrectPassword(string email, string Password)
    {
        return _userRepo.IsCorrectPassword(email, EncryptPassword(Password));
    }
    public void SendPasswordResetEmail(string email)
    {
        if (_userRepo.IsUserExists(email))
        {
            _emailService.SendPasswordResetEmail(email);
        }
    }
    public bool IsUserExists(string email)
    {
        return _userRepo.IsUserExists(email);
    }
    public void ResetPassword(string email, string newPassword)
    {
        var user = _userRepo.GetUserByEmail(email);
        if (user != null)
        {
            user.Password = EncryptPassword(newPassword);
            _userRepo.UpdateUser(user);
        }
    }
    public string GetUserNameByEmail(string email){
        return _userRepo.GetUserNameByEmail(email);
    }
    public async Task<string> GetRoleByEmail(string email)
    {
        int roleId = _userRepo.GetRoleIdByEmail(email);
        return await _roleRepo.GetRoleById(roleId);
    }
    public async Task<string> GetRoleById(int roleid){
        return await _roleRepo.GetRoleById(roleid);
    }
    public string EncryptPassword(string pass)
    {
        var encode = Encoding.UTF8.GetBytes(pass);
        return Convert.ToBase64String(encode);
    }
    public int GetUserIdByEmail(string email){
        return _userRepo.GetUserIdByEmail(email);
    }
}