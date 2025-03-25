namespace Service.Interfaces;

public interface IEmailService
{
    void SendPasswordResetEmail(string email);
    void SendEmailToNewUser(string email,string Password); 
}
