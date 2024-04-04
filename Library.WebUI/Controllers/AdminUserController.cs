using AspNetCoreHero.ToastNotification.Abstractions;
using Library.Business.Abstract;
using Library.Entity.Concrete;
using Library.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebUI.Controllers
{
    [Authorize]
    public class AdminUserController : Controller
    {
        private readonly IUserService _userService;
        private readonly INotyfService _notyfService;
        private readonly IPositionService _positionService;

        public AdminUserController(IUserService userService, INotyfService notyfService, IPositionService positionService)
        {
            _userService = userService;
            _notyfService = notyfService;
            _positionService = positionService;
        }


        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }           

            var model = new UserViewModel
            {
                Users = _userService.TGetAllByStatusFK().Data
            };
            return View(model);
        }


        // Kullanıcı Ekleme
        public IActionResult AddUser()
        {
            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }

            var model = new UserViewModel
            {
                User = new User(),
                Positions = _positionService.TGetAllByStatus().Data
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddUser(User user)
        {
            if (!ModelState.IsValid)
            {
                var model = new UserViewModel
                {
                    User = user,
                    Positions = _positionService.TGetAllByStatus().Data
                };
                return View(model);
            }
            user.UserStatus = true;
            _userService.TAdd(user);
            _notyfService.Success("Kullanıcı Ekleme İşlemi Başarıyla Tamamlandı", 3);
            return RedirectToAction("Index");
        }


        // Kullanıcı Güncelleme
        public IActionResult UpdateUser(int id)
        {
            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }
            var model = new UserViewModel
            {
                User = _userService.TGetById(id).Data,
                Positions = _positionService.TGetAllByStatus().Data
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateUser(User user)
        {
            user.UserStatus = true;
            _userService.TUpdate(user);
            _notyfService.Warning("Kullanıcı Güncelleme İşlemi Başarıyla Tamamlandı", 3);
            return RedirectToAction("Index");
        }

        // Kullanıcı Silme
        public IActionResult DeleteUser(int id)
        {
            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }
            var user = _userService.TGetById(id).Data;
            user.UserStatus = false;
            _userService.TUpdate(user);
            _notyfService.Error("Kullanıcı Silme İşlemi Başarıyla Tamamlandı", 3);
            return RedirectToAction("Index");
        }


    }
}
