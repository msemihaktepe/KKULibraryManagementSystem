using Library.Business.Abstract;
using Library.Entity.Concrete;
using Library.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebUI.Controllers
{
    [Authorize]
    public class UserRulesController : Controller
    {
        private readonly IRuleService _ruleService;

        public UserRulesController(IRuleService ruleService)
        {
            _ruleService = ruleService;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("position") != "ÖĞRENCİ")
            {
                return RedirectToAction("Index", "AdminBook");
            }

            var model = new RuleViewModel();
            model.Rules = _ruleService.TGetAllByStatus().Data;
            return View(model);
        }
    }
}
