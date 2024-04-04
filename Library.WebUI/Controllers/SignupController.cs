using AspNetCoreHero.ToastNotification.Abstractions;
using Library.Business.Abstract;
using Library.Entity.Concrete;
using Library.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebUI.Controllers
{
    public class SignupController : Controller
    {
        private readonly IPositionService _positionService;
        private readonly IUserService _userService;
        private readonly INotyfService _notyfService;

        public SignupController(IPositionService positionService, IUserService userService, INotyfService notyfService)
        {
            _positionService = positionService;
            _userService = userService;
            _notyfService = notyfService;
        }

        public IActionResult Signup()
        {
            var model = new UserViewModel
            {
                User = new User()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Signup(User user)
        {
            user.UserStatus = true;
            user.PositionID = _positionService.TGetByName("ÖĞRENCİ").Data.PositionID;
            if (!ModelState.IsValid)
            {
                var model = new UserViewModel
                {
                    User = user
                };
                return View(model);
            }
            var result = _userService.TAdd(user);
            if (!result.Success)
            {
                _notyfService.Error("Üye Olma İşlemi Sırasında Bir Hata Meydana Geldi.");
                var model = new UserViewModel
                {
                    User = new User()
                };
                return View(model);
            }
            _notyfService.Success("Üye Olma İşlemi Başarılı Bir Şekilde Tamamlandı");
            return RedirectToAction("Login", "Loginout");
        }        

    }
}
