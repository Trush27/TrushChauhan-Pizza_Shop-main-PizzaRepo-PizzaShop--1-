using Microsoft.Extensions.Configuration;
using Service.Interfaces;
using System.Net;
using System.Net.Mail;
namespace Service.Implementations
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _config;
        private readonly SmtpClient _smtpClient;
        public EmailService(IConfiguration config)
        {
            _config = config;
            _smtpClient = InitializeSmtpClient();
        }
        private SmtpClient InitializeSmtpClient()
        {
            var smtpSettings = _config.GetSection("SmtpSettings");
            return new SmtpClient(smtpSettings["Host"])
            {
                Port = int.Parse(smtpSettings["Port"]),
                Credentials = new NetworkCredential(smtpSettings["Email"], smtpSettings["Password"]),
                EnableSsl = bool.Parse(smtpSettings["EnableSsl"])
            };
        }
        private MailMessage CreateMailMessage(string toEmail, string subject, string body)
        {
            var smtpSettings = _config.GetSection("SmtpSettings");
            var mail = new MailMessage
            {
                From = new MailAddress(smtpSettings["Email"]),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            mail.To.Add(toEmail);
            return mail;
        }
        public void SendPasswordResetEmail(string email)
        {
            try
            {
                string emailBody = $@"<a href='http://localhost:5150/Home/ResetPassword?email={WebUtility.UrlEncode(email)}'>Reset Password</a>";
                var mail = CreateMailMessage(email, "Reset Password for PizzaShop", emailBody);
                _smtpClient.Send(mail); 
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to send password reset email.", ex);
            }
        }
        public void SendEmailToNewUser(string email, string password)
        {
            try
            {
                string emailBody = $@"  
                <h>Login Details</h>  
                <div>useremail = {email} </div>  
                <div> Temporary Password = {password}";
                var mail = CreateMailMessage(email, "Login Details for PizzaShop", emailBody);
                _smtpClient.Send(mail); 
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to send new user email.", ex);
            }
        }
    }
} 