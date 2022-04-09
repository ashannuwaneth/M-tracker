using Microsoft.AspNetCore.Mvc;

namespace M_tracker.Areas.Admin.Controllers
{
    public class GroupUserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
