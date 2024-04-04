using AspNetCoreHero.ToastNotification.Abstractions;
using Library.Business.Abstract;
using Library.Entity.Concrete;
using Library.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Type = Library.Entity.Concrete.Type;

namespace Library.WebUI.Controllers
{
    [Authorize]
    public class AdminTypeController : Controller
    {
        private readonly ITypeService _typeService;
        private readonly IBookService _bookService;
        private readonly INotyfService _notyfService;

        public AdminTypeController(ITypeService typeService, IBookService bookService, INotyfService notyfService)
        {
            _typeService = typeService;
            _bookService = bookService;
            _notyfService = notyfService;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }
            var types = _typeService.TGetAllByStatus().Data;
            var typeWithBooks = new List<TypeWithBookModel>();
            foreach (var type in types)
            {
                typeWithBooks.Add(new TypeWithBookModel
                {
                    Id = type.TypeID,
                    Name = type.TypeName,
                    NumberOfBook = _bookService.TNumberOfBooksType(type.TypeID).Data
                });
            }
            var model = new TypeViewModel
            {
                TypeWithBooks = typeWithBooks
            };
            return View(model);
        }

        // KİTAP TÜRÜ EKLEME
        public IActionResult AddType()
        {
            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }

            var model = new TypeViewModel
            {
                Type = new Type()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddType(Type type)
        {
            if (!ModelState.IsValid)
            {
                var model = new TypeViewModel
                {
                    Type = type
                };
                return View(model);
            }
            type.TypeStatus = true;
            _typeService.TAdd(type);
            _notyfService.Success("Tür Ekleme İşlemi Başarıyla Tamamlandı", 3);
            return RedirectToAction("Index");
        }


        // KİTAP TÜRÜ GÜNCELLEME
        public IActionResult UpdateType(int id)
        {
            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }

            var model = new TypeViewModel
            {
                Type = _typeService.TGetById(id).Data
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateType(Type type)
        {
            if (!ModelState.IsValid)
            {
                var model = new TypeViewModel
                {
                    Type = type
                };
                return View(model);
            }
            type.TypeStatus = true;
            _typeService.TUpdate(type);
            _notyfService.Warning("Tür Güncelleme İşlemi Başarıyla Tamamlandı", 3);
            return RedirectToAction("Index");
        }


        // KİTAP TÜRÜ SİLME
        public IActionResult DeleteType(int id)
        {
            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }

            var type = _typeService.TGetById(id).Data;
            type.TypeStatus = false;
            _typeService.TUpdate(type);
            _notyfService.Error("Tür Silme İşlemi Başarıyla Tamamlandı", 3);
            return RedirectToAction("Index");
        }
    }
}
