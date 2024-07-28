using Microsoft.AspNetCore.Mvc;

namespace Traversal.Areas.Member.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
