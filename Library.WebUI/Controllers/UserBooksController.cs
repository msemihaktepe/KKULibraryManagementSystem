using AspNetCoreHero.ToastNotification.Abstractions;
using Library.Business.Abstract;
using Library.Entity.Concrete;
using Library.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebUI.Controllers
{
    [Authorize]
    public class UserBooksController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IBorrowedBookService _borrowedBookService;
        private readonly INotyfService _notyfService;

        public UserBooksController(IBookService bookService, IBorrowedBookService borrowedBookService, INotyfService notyfService)
        {
            _bookService = bookService;
            _borrowedBookService = borrowedBookService;
            _notyfService = notyfService;
        }

        public IActionResult Index(string searchString)
        {
            if (HttpContext.Session.GetString("position") != "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "AdminBook");
            }
            var model = new BookViewModel();
            if (String.IsNullOrEmpty(searchString))
            {
                model.Books = _bookService.TGetAllByStatus().Data;
            }
            else
            {
                model.Books = _bookService.TGetAllSearch(searchString).Data;
            }
            return View(model);
        }


        // Öğrencinin Kitabı Kiralama İşlemi
        public IActionResult BorrowBook(int id)
        {
            if (HttpContext.Session.GetString("position") != "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "AdminBook");
            }


            if (_borrowedBookService.TGetUserId(Convert.ToInt32(HttpContext.Session.GetString("id"))).Data != null)
            {
                _notyfService.Error("Ödünç Almış Olduğunuz Kitabı İade Etmeniz Gerekmektedir!", 3);
                return RedirectToAction("Index");
            }


            var borrowedBook = new BorrowedBook
            {
                BorrowDate = DateTime.Parse(DateTime.Now.ToShortDateString()),
                ReturnDate = DateTime.Parse(DateTime.Now.AddDays(15).ToShortDateString()),
                BorrowedBookStatus = true,
                BookID = id,
                UserID = Convert.ToInt32(HttpContext.Session.GetString("id"))
            };


            var book = _bookService.TGetById(id).Data;
            book.BookStatus = false;
            _bookService.TUpdate(book);
            _borrowedBookService.TAdd(borrowedBook);
            _notyfService.Success("Ödünç Alma İşlemi Başarıyla Tamamlandı", 3);
            return RedirectToAction("Index");
        }

    }
}
