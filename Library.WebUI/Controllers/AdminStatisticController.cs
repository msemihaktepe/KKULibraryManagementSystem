using Library.Business.Abstract;
using Library.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebUI.Controllers
{
    [Authorize]
    public class AdminStatisticController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IUserService _userService;
        private readonly ITypeService _typeService;
        private readonly IMessageService _messageService;
        private readonly IBookService _bookService;
        private readonly IBorrowedBookService _borrowedBookService;

        public AdminStatisticController(IAuthorService authorService, IUserService userService, ITypeService typeService, IMessageService messageService, IBookService bookService, IBorrowedBookService borrowedBookService)
        {
            _authorService = authorService;
            _userService = userService;
            _typeService = typeService;
            _messageService = messageService;
            _bookService = bookService;
            _borrowedBookService = borrowedBookService;
        }

        public IActionResult Index()
        {

            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }

            var model = new StatisticViewModel
            {
                AuthorsNumber = _authorService.TGetAllByStatus().Data.Count,
                BooksNumber = _bookService.TGetAllByStatus().Data.Count,
                BorrowedBooksNumber = _borrowedBookService.TGetAllByStatus().Data.Count,
                MessagesNumber = _messageService.TGetAll().Data.Count,                
                TypesNumber = _typeService.TGetAllByStatus().Data.Count,
                UsersNumber = _userService.TGetAllByStatus().Data.Count
            };
            return View(model);
        }
    }
}
