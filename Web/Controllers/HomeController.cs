using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Service.Interfaces;
using Entity.ViewModel;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
namespace Web.Controllers;

public class HomeController : Controller
{
    private readonly IAuthService _authService;
    private readonly IConfiguration _config;

    public HomeController(IAuthService authService, IConfiguration config)
    {
        _authService = authService;
        _config = config;
    }
    public IActionResult Index()
    {
        if (Request.Cookies["Email"] != null)
        {
            return RedirectToAction("Users", "Main");
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserDemo model)
    {
        var success = await _authService.LoginAsync(model.Email, model.Password);
        if (success)
        {
            var userRole = await _authService.GetRoleByEmail(model.Email);
            string UserName = _authService.GetUserNameByEmail(model.Email);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, model.Email),
                new Claim(ClaimTypes.Email, model.Email),
                new Claim(ClaimTypes.Role, userRole)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            HttpContext.Session.SetString("Token", tokenString);
            HttpContext.Session.SetString("Email", model.Email);
            HttpContext.Session.SetString("Role", userRole);
            CookieOptions cookie = new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(30)
            };
            Response.Cookies.Append("Jwt", tokenString, cookie);
            if (model.IsRemember)
            {

                Response.Cookies.Append("Email", model.Email, cookie);
            }

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, model.Email),
            new Claim(ClaimTypes.Role, userRole)
        };

            var identity = new ClaimsIdentity(claims, "Cookies");
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                "Cookies",
                principal,
                new AuthenticationProperties
                {
                    IsPersistent = model.IsRemember,
                    ExpiresUtc = model.IsRemember ? DateTime.UtcNow.AddDays(30) : null
                });
            return RedirectToAction("Users", "Main");
        }

        TempData["Message"] = "Invalid credentials";
        return RedirectToAction("Index");
    }
    public IActionResult AccessDenied()
    {
        return View();
    }
    public IActionResult ForgotPassword(string email)
    {
        var userExists = _authService.IsUserExists(email);
        if (!userExists)
        {
            TempData["Message"] = "Enter right Email Address";
            return RedirectToAction("Index", "Home");
        }
        var vm = new userEmail(email);
        return View(vm);
    }
    [HttpPost]
    public IActionResult SendEmailLink(userEmail model)
    {
        string toemail = model.Email;
        SendEmail(toemail);
        return RedirectToAction("Index", "Home");
    }
    public void SendEmail(string toemail)
    {
        _authService.SendPasswordResetEmail(toemail);
    }
    [HttpGet]
    public IActionResult ResetPassword(string email)
    {
        return View(new ResetPasswordModel { Email = email });
    }
    [HttpPost]
    public IActionResult ResetPassword(ResetPasswordModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = _authService.IsUserExists(model.Email);
        if (!user)
        {
            return RedirectToAction("Index", "Home");
        }

        _authService.ResetPassword(model.Email, model.NewPassword);

        return RedirectToAction("Index", "Home");
    }

}
