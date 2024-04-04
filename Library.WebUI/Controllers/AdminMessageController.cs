using AspNetCoreHero.ToastNotification.Abstractions;
using Library.Business.Abstract;
using Library.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebUI.Controllers
{
    [Authorize]
    public class AdminMessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly INotyfService _notyfService;

        public AdminMessageController(IMessageService messageService, INotyfService notyfService)
        {
            _messageService = messageService;
            _notyfService = notyfService;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }
            var model = new MessageViewModel
            {
                Messages = _messageService.TGetAllByStatusFK().Data
            };
            return View(model);
        }


        // Okunmuş Mesajlar
        public IActionResult ReadMessages()
        {
            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }
            var model = new MessageViewModel
            {
                Messages = _messageService.TGetAllByStatus2FK().Data
            };
            return View(model);
        }

        // Okundu Sayfasına Gönder
        public IActionResult MarkAsReadMessage(int id)
        {
            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }
            var message = _messageService.TGetById(id).Data;
            message.MessageStatus = false;
            _messageService.TUpdate(message);
            _notyfService.Error("Gelen Mesaj Okundu Olarak İşaretlendi.", 3);
            return RedirectToAction("Index");
        }


        // Okundu Sayfasından Sil
        public IActionResult DeletedMessage(int id)
        {
            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }
            var message = _messageService.TGetById(id).Data;
            _messageService.TDelete(message);
            _notyfService.Error("Mesaj Silme İşlemi Başarıyla Tamamlandı", 3);
            return RedirectToAction("ReadMessages");
        }

        

    }
}
