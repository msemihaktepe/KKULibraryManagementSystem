using AspNetCoreHero.ToastNotification.Abstractions;
using Library.Business.Abstract;
using Library.Entity.Concrete;
using Library.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace Library.WebUI.Controllers
{
    public class LoginoutController : Controller
    {
        private readonly IUserService _userService;
        private readonly INotyfService _notyfService;
        private readonly IPositionService _positionService;

        public LoginoutController(IUserService userService, INotyfService notyfService, IPositionService positionService)
        {
            _userService = userService;
            _notyfService = notyfService;
            _positionService = positionService;
        }

        public IActionResult Login()
        {
            var model = new UserViewModel
            {
                User = new User()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            var result = _userService.TCheckUser(user);
            if (!result.Success)
            {
                _notyfService.Error("Parola veya Kullanıcı Adı Hatalı!", 3);
                var model = new UserViewModel
                {
                    User = new User()
                };
                return View(model);
            }
            var result2 = _userService.TGetByUsername(user.UserName);
            HttpContext.Session.SetString("id", result2.Data.UserID.ToString());
            HttpContext.Session.SetString("name", result2.Data.UserFirstName);
            HttpContext.Session.SetString("lastname", result2.Data.UserLastName);
            HttpContext.Session.SetString("position", result2.Data.Position.PositionName);
            var claim = new List<Claim> { new Claim(ClaimTypes.Name, user.UserName) };
            var userIdentity = new ClaimsIdentity(claim, "Login");
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
            await HttpContext.SignInAsync(principal);
            _notyfService.Success("Hoşgeldiniz..", 3);
            if (result2.Data.Position.PositionName == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBooks");
            }
            return RedirectToAction("Index", "AdminBook");
        }


        // Çıkış Yap
        public async Task<IActionResult> Logout()
        {
            Response.Cookies.Delete("id");
            Response.Cookies.Delete("name");
            Response.Cookies.Delete("lastname");
            Response.Cookies.Delete("position");
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Loginout");
        }

    }
}
