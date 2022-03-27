using Microsoft.AspNetCore.Mvc;

namespace M_tracker.Areas.Admin.Controllers
{
    public class ExpensesTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
