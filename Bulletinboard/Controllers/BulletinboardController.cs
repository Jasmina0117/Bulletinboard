using Microsoft.AspNetCore.Mvc;

namespace Bulletinboard.Controllers
{
    public class BulletinboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
