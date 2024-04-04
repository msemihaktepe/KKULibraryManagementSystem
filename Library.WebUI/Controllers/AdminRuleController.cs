using AspNetCoreHero.ToastNotification.Abstractions;
using Library.Business.Abstract;
using Library.Entity.Concrete;
using Library.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebUI.Controllers
{
    [Authorize]
    public class AdminRuleController : Controller
    {
        private readonly IRuleService _ruleService;
        private readonly INotyfService _notyfService;

        public AdminRuleController(IRuleService ruleService, INotyfService notyfService)
        {
            _ruleService = ruleService;
            _notyfService = notyfService;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }

            var model = new RuleViewModel
            {
                Rules = _ruleService.TGetAllByStatus().Data
            };
            return View(model);
        }


        // Kural Ekleme
        public IActionResult AddRule()
        {
            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }

            var model = new RuleViewModel
            {
                Rule = new Rule()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult AddRule(Rule rule)
        {
            if (!ModelState.IsValid)
            {
                var model = new RuleViewModel
                {
                    Rule = rule
                };
                return View(model);
            }
            rule.RuleStatus = true;
            _ruleService.TAdd(rule);
            _notyfService.Success("Kural Ekleme İşlemi Başarıyla Tamamlandı", 3);
            return RedirectToAction("Index");
        }

        // Kural Güncelleme
        public IActionResult UpdateRule(int id)
        {
            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }

            var model = new RuleViewModel
            {
                Rule = _ruleService.TGetById(id).Data
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateRule(Rule rule)
        {
            if (!ModelState.IsValid)
            {
                var model = new RuleViewModel
                {
                    Rule = rule
                };
                return View(model);
            }
            rule.RuleStatus = true;
            _ruleService.TUpdate(rule);
            _notyfService.Warning("Kural Güncelleme İşlemi Başarıyla Tamamlandı", 3);
            return RedirectToAction("Index");
        }

        // Kural Silme
        public IActionResult DeleteRule(int id)
        {
            if (HttpContext.Session.GetString("position") == "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "UserBook");
            }

            var rule = _ruleService.TGetById(id).Data;
            rule.RuleStatus = false;
            _ruleService.TUpdate(rule);
            _notyfService.Error("Kural Silme İşlemi Başarıyla Tamamlandı", 3);
            return RedirectToAction("Index");
        }
    }
}
