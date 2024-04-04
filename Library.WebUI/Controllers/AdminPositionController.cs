using AspNetCoreHero.ToastNotification.Abstractions;
using Library.Business.Abstract;
using Library.Entity.Concrete;
using Library.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebUI.Controllers
{
    [Authorize]
    public class AdminPositionController : Controller
    {
        private readonly IPositionService _positionService;
        private readonly INotyfService _notyfService;
        private readonly IUserService _userService;

        public AdminPositionController(IPositionService positionService, INotyfService notyfService, IUserService userService)
        {
            _positionService = positionService;
            _notyfService = notyfService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }
            
            var positions = _positionService.TGetAllByStatus().Data;
            var positionWithUsers = new List<PositionWithUserModel>();
            foreach (var position in positions)
            {
                positionWithUsers.Add(new PositionWithUserModel
                {
                    Id = position.PositionID,
                    Name = position.PositionName,
                    NumberOfUsers = _userService.TNumberOfPositionUsers(position.PositionID).Data
                });
            }
            var model = new PositionViewModel
            {
                PositionWithUsers = positionWithUsers
            };
            return View(model);
        }


        //Pozisyon Ekle
        public IActionResult AddPosition()
        {
            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }

            var model = new PositionViewModel
            {
                Position = new Position()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult AddPosition(Position position)
        {
            if (!ModelState.IsValid)
            {
                var model = new PositionViewModel
                {
                    Position = position
                };
                return View(model);
            }
            position.PositionStatus = true;
            _positionService.TAdd(position);
            _notyfService.Success("Pozisyon Ekleme İşlemi Başarıyla Tamamlandı", 3);
            return RedirectToAction("Index");
        }

        //Posizyon Güncelle
        public IActionResult UpdatePosition(int id)
        {

            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }

            var model = new PositionViewModel
            {
                Position = _positionService.TGetById(id).Data
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdatePosition(Position position)
        {
            if (!ModelState.IsValid)
            {
                var model = new PositionViewModel
                {
                    Position = position
                };
                return View(model);
            }
            position.PositionStatus = true;
            _positionService.TUpdate(position);
            _notyfService.Warning("Pozisyon Güncelleme İşlemi Başarıyla Tamamlandı", 3);
            return RedirectToAction("Index");
        }


        //Pozisyon Sil
        public IActionResult DeletePosition(int id)
        {
            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }

            var position = _positionService.TGetById(id).Data;
            position.PositionStatus = false;
            _positionService.TUpdate(position);
            _notyfService.Error("Pozisyon Silme İşlemi Başarıyla Tamamlandı", 3);
            return RedirectToAction("Index");
        }


    }
}
