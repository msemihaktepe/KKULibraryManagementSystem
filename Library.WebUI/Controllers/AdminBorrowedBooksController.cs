using AspNetCoreHero.ToastNotification.Abstractions;
using Library.Business.Abstract;
using Library.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebUI.Controllers
{
    [Authorize]
    public class AdminBorrowedBooksController : Controller
    {
        private readonly IBorrowedBookService _borrowedBookService;
        private readonly IBookService _bookService;
        private readonly INotyfService _notyfService;

        public AdminBorrowedBooksController(IBorrowedBookService borrowedBookService, IBookService bookService, INotyfService notyfService)
        {
            _borrowedBookService = borrowedBookService;
            _bookService = bookService;
            _notyfService = notyfService;
        }

        public IActionResult Index()
        {

            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }

            var model = new BorrowedBookViewModel
            {
                BorrowedBooks = _borrowedBookService.TGetAllByStatusFK().Data
            };
            return View(model);
        }
        


        // ÖNCEDEN KİRALAN KİTAPLAR
        public IActionResult ArchiveBorrowedBooks()
        {

            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }

            var model = new BorrowedBookViewModel
            {
                BorrowedBooks = _borrowedBookService.TGetAllByStatus2FK().Data
            };
            return View(model);
        }


        // KİRALANAN KİTABI GERİ ALMA
        public IActionResult RevokeBorrowedBook(int id)
        {

            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }

            var borrowBook = _borrowedBookService.TGetById(id).Data;
            borrowBook.BorrowedBookStatus = false;
            borrowBook.ReturnDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            var book = _bookService.TGetById(borrowBook.BookID).Data;
            book.BookStatus = true;
            _bookService.TUpdate(book);
            _borrowedBookService.TUpdate(borrowBook);
            _notyfService.Success("Ödünç Verilen Kitap Geri Alındı.", 3);
            return RedirectToAction("Index");
        }


        // KİRALANAN KİTAPLARI SİLME
        public IActionResult DeleteBorrowedBook(int id)
        {

            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }

            var borrowBook = _borrowedBookService.TGetById(id).Data;
            _borrowedBookService.TDelete(borrowBook);
            _notyfService.Error("Kiralanmış Kitap Bilgisi Silindi", 3);
            return RedirectToAction("ArchiveBorrowedBooks");
        }

    }
}
