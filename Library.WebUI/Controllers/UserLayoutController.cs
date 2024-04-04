using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.WebUI.Controllers
{
    [Authorize]
    public class UserLayoutController : Controller
    {
        public IActionResult _UserLayout()
        {
            return View();
        }
    }
}
