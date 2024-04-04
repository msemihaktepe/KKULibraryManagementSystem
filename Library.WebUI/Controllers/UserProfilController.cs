using AspNetCoreHero.ToastNotification.Abstractions;
using Library.Business.Abstract;
using Library.Entity.Concrete;
using Library.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebUI.Controllers
{
    [Authorize]
    public class UserProfilController : Controller
    {
        private readonly IBorrowedBookService _borrowedBookService;
        private readonly IUserService _userService;
        private readonly INotyfService _notyfService;
        private readonly IBookService _bookService;

        public UserProfilController(IBorrowedBookService borrowedBookService, IUserService userService, INotyfService notyfService, IBookService bookService)
        {
            _borrowedBookService = borrowedBookService;
            _userService = userService;
            _notyfService = notyfService;
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("position") != "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "AdminBook");
            }

            BorrowedBook borrowedBook = null;

            if (_borrowedBookService.TGetUserId(Convert.ToInt32(HttpContext.Session.GetString("id"))).Success)
            {
                borrowedBook = _borrowedBookService.TGetUserId(Convert.ToInt32(HttpContext.Session.GetString("id"))).Data;
            }
            var model = new UserViewModel
            {
                User = _userService.TGetById(Convert.ToInt32(HttpContext.Session.GetString("id"))).Data,
                BorrowedBook = borrowedBook
            };
            return View(model);
        }


        [HttpPost]
        public IActionResult Index(User user)
        {
            BorrowedBook borrowedBook = null;

            if (_borrowedBookService.TGetUserId(Convert.ToInt32(HttpContext.Session.GetString("id"))).Success)
            {
                borrowedBook = _borrowedBookService.TGetUserId(Convert.ToInt32(HttpContext.Session.GetString("id"))).Data;
            }

            if (ModelState.ErrorCount == 1)
            {
                user.UserStatus = true;
                HttpContext.Session.SetString("name", user.UserFirstName);
                HttpContext.Session.SetString("lastname", user.UserLastName);
                _userService.TUpdate(user);
                _notyfService.Success("Profil Bilgileriniz Başarıyla Güncellendi.", 3);
                return RedirectToAction("Index");
            }
            var model = new UserViewModel
            {
                User = user,
                BorrowedBook = borrowedBook
            };
            _notyfService.Error("Profil Bilgileriniz Güncellenirken Hata Oluştu.", 3);
            return View(model);
        }


        // Kitap İade İşlemi
        public IActionResult BorrowBack(int id)
        {
            if (HttpContext.Session.GetString("position") != "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "AdminBook");
            }

            var result = _borrowedBookService.TGetUserId(Convert.ToInt32(HttpContext.Session.GetString("id"))).Data;
            result.BorrowedBookStatus = false;
            result.ReturnDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            var book = _bookService.TGetById(id).Data;
            book.BookStatus = true;
            _bookService.TUpdate(book);
            _borrowedBookService.TUpdate(result);
            _notyfService.Warning("Kitap İade İşlemi Başarıyla Tamamlandı.", 3);
            return RedirectToAction("Index");
        }

    }
}
