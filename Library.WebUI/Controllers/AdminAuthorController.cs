using AspNetCoreHero.ToastNotification.Abstractions;
using Library.Business.Abstract;
using Library.Entity.Concrete;
using Library.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebUI.Controllers
{
    [Authorize]
    public class AdminAuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;
        private readonly INotyfService _notyfService;

        public AdminAuthorController(IAuthorService authorService, IBookService bookService, INotyfService notyfService)
        {
            _authorService = authorService;
            _bookService = bookService;
            _notyfService = notyfService;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }

            var authors = _authorService.TGetAllByStatus().Data;
            var authorsWithBooks = new List<AuthorWithBookModel>();
            foreach (var author in authors)
            {
                authorsWithBooks.Add(new AuthorWithBookModel
                {
                    Id = author.AuthorID,
                    FirstName = author.AuthorFirstName,
                    LastName = author.AuthorLastName,
                    NumberOfBook = _bookService.TNumberOfBooksAuthor(author.AuthorID).Data
                });
            }
            var model = new AuthorViewModel
            {
                AuthorWithBooks = authorsWithBooks
            };
            return View(model);
        }

        // YAZAR EKLEME
        public IActionResult AddAuthor()
        {
            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }

            var model = new AuthorViewModel
            {
                Author = new Author()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddAuthor(Author author)
        {
            if (!ModelState.IsValid)
            {
                var model = new AuthorViewModel
                {
                    Author = author
                };
                return View(model);
            }
            author.AuthorStatus = true;
            _authorService.TAdd(author);
            _notyfService.Success("Yazar Ekleme İşlemi Başarıyla Tamamlandı", 3);
            return RedirectToAction("Index");
        }

        
        // YAZAR GÜNCELLEME
        public IActionResult UpdateAuthor(int id)
        {
            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }

            var model = new AuthorViewModel
            {
                Author = _authorService.TGetById(id).Data
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult UpdateAuthor(Author author)
        {
            if (!ModelState.IsValid)
            {
                var model = new AuthorViewModel
                {
                    Author = author
                };
                return View(model);
            }
            author.AuthorStatus = true;
            _authorService.TUpdate(author);
            _notyfService.Warning("Yazar Güncelleme İşlemi Başarıyla Tamamlandı", 3);
            return RedirectToAction("Index");
        }


        // YAZAR SİLME
        public IActionResult DeleteAuthor(int id)
        {
            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }

            var author = _authorService.TGetById(id).Data;
            author.AuthorStatus = false;
            _authorService.TUpdate(author);
            _notyfService.Error("Yazar Silme İşlemi Başarıyla Tamamlandı", 3);
            return RedirectToAction("Index");
        }
    }
}
