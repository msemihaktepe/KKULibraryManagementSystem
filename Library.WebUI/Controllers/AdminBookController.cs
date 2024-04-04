using AspNetCoreHero.ToastNotification.Abstractions;
using Library.Business.Abstract;
using Library.Entity.Concrete;
using Library.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebUI.Controllers
{
    [Authorize]
    public class AdminBookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly ITypeService _typeService;
        private readonly INotyfService _notyfService;

        public AdminBookController(IBookService bookService, IAuthorService authorService, ITypeService typeService, INotyfService notyfService)
        {
            _bookService = bookService;
            _authorService = authorService;
            _typeService = typeService;
            _notyfService = notyfService;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }

            var bookViewModel = new BookViewModel
            {
                Books = _bookService.TGetAllByStatusFK().Data
            };
            return View(bookViewModel);
        }

        // KİTAP EKLEME
        public IActionResult AddBook()
        {
            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }

            List<AuthorWithFullNameModel> authorWithFullName = new List<AuthorWithFullNameModel>();

            foreach (var author in _authorService.TGetAllByStatus().Data)
            {
                AuthorWithFullNameModel authorName = new AuthorWithFullNameModel { Id = author.AuthorID, FullName = author.AuthorFirstName + " " + author.AuthorLastName };
                authorWithFullName.Add(authorName);
            }
            var model = new BookViewModel
            {
                ImageBook = new BookImageViewModel(),
                Authors = authorWithFullName,
                Types = _typeService.TGetAllByStatus().Data
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddBook(BookImageViewModel imageBook)
        {
            if (!ModelState.IsValid)
            {
                List<AuthorWithFullNameModel> authorWithFullName = new List<AuthorWithFullNameModel>();

                foreach (var author in _authorService.TGetAllByStatus().Data)
                {
                    AuthorWithFullNameModel authorFullName = new AuthorWithFullNameModel { Id = author.AuthorID, FullName = author.AuthorFirstName + " " + author.AuthorLastName };
                    authorWithFullName.Add(authorFullName);
                }
                var model = new BookViewModel
                {
                    ImageBook = imageBook,
                    Authors = authorWithFullName,
                    Types = _typeService.TGetAllByStatus().Data
                };
                return View(model);
            }

            Book book = new Book();

            if (imageBook.Image != null)
            {
                var ext = Path.GetExtension(imageBook.Image.FileName);
                var guidImageName = Guid.NewGuid() + ext;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image/", guidImageName);
                var stream = new FileStream(path, FileMode.Create);
                imageBook.Image.CopyTo(stream);
                book.BookImage = guidImageName;
            }
            else
            {
                book.BookImage = "Default.jpg";
            }
            book.BookName = imageBook.Name;
            book.NumberOfPage = imageBook.NumberOfPage;
            book.AuthorID = imageBook.AuthorId;
            book.TypeID = imageBook.TypeId;
            book.BookStatus = true;
            _bookService.TAdd(book);
            _notyfService.Success("Kitap Ekleme İşlemi Başarıyla Tamamlandı", 3);
            return RedirectToAction("Index", "AdminBook");
        }


        // KİTAP GÜNCELLEME
        public IActionResult UpdateBook(int id)
        {
            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }

            List<AuthorWithFullNameModel> authorWithFullName = new List<AuthorWithFullNameModel>();

            foreach (var author in _authorService.TGetAllByStatus().Data)
            {
                AuthorWithFullNameModel authorFullName = new AuthorWithFullNameModel { Id = author.AuthorID, FullName = author.AuthorFirstName + " " + author.AuthorLastName };
                authorWithFullName.Add(authorFullName);
            }

            var book = _bookService.TGetById(id).Data;
            var imageBook = new BookImageViewModel { Id = book.BookID, AuthorId = book.AuthorID, Name = book.BookName, NumberOfPage = book.NumberOfPage, TypeId = book.TypeID };
            var model = new BookViewModel
            {
                ImageBook = imageBook,
                Authors = authorWithFullName,
                Types = _typeService.TGetAllByStatus().Data
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateBook(BookImageViewModel imageBook)
        {
            if (!ModelState.IsValid)
            {
                List<AuthorWithFullNameModel> authorWithFullName = new List<AuthorWithFullNameModel>();

                foreach (var author in _authorService.TGetAllByStatus().Data)
                {
                    AuthorWithFullNameModel authorFullName = new AuthorWithFullNameModel { Id = author.AuthorID, FullName = author.AuthorFirstName + " " + author.AuthorLastName };
                    authorWithFullName.Add(authorFullName);
                }
                var model = new BookViewModel
                {
                    ImageBook = imageBook,
                    Authors = authorWithFullName,
                    Types = _typeService.TGetAllByStatus().Data
                };
                return View(model);
            }
            Book book = new Book();

            if (imageBook.Image != null)
            {
                var ext = Path.GetExtension(imageBook.Image.FileName);
                var guidImageName = Guid.NewGuid() + ext;
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image/", guidImageName);
                var stream = new FileStream(path, FileMode.Create);
                imageBook.Image.CopyTo(stream);
                book.BookImage = guidImageName;
            }
            else
            {
                book.BookImage = "Default.jpg";
            }
            book.BookID = imageBook.Id;
            book.BookName = imageBook.Name;
            book.NumberOfPage = imageBook.NumberOfPage;
            book.AuthorID = imageBook.AuthorId;
            book.TypeID = imageBook.TypeId;
            book.BookStatus = true;
            _bookService.TUpdate(book);
            _notyfService.Warning("Kitap Güncelleme İşlemi Başarıyla Tamamlandı", 3);
            return RedirectToAction("Index", "AdminBook");
        }

        // KİTAP SİLME 
        public IActionResult DeleteBook(int id)
        {
            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }

            var bookDelete = _bookService.TGetById(id).Data;
            _bookService.TDelete(bookDelete);
            _notyfService.Error("Kitap Silme İşlemi Başarılıyla Tamamlandı", 3);
            return RedirectToAction("Index", "AdminBook");
        }

    }
}
