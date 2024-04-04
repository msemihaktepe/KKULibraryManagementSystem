using AspNetCoreHero.ToastNotification.Abstractions;
using Library.Business.Abstract;
using Library.Entity.Concrete;
using Library.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebUI.Controllers
{
    [Authorize]
    public class UserContactController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly INotyfService _notyfService;

        public UserContactController(IMessageService messageService, INotyfService notyfService)
        {
            _messageService = messageService;
            _notyfService = notyfService;
        }

        public IActionResult Index()
        {

            if (HttpContext.Session.GetString("position") != "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "AdminBook");
            }

            var model = new MessageViewModel
            {
                Message = new  Message()
            };
            return View(model);
        }


        [HttpPost]
        public IActionResult Index(Message message)
        {
            if (!ModelState.IsValid)
            {
                var model = new MessageViewModel
                {
                    Message = message
                };
                _notyfService.Error("Mesaj Gönderme İşlemi Sırasında Hata Oluştu.", 3);
                return View(model);
            }
            message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            message.UserID = Convert.ToInt32(HttpContext.Session.GetString("id"));
            message.MessageStatus = true;
            _messageService.TAdd(message);
            _notyfService.Success("Mesaj Gönderme İşlemi Başarıyla Tamamlandı");
            return RedirectToAction("Index");
        }

    }
}
