using Microsoft.AspNetCore.Mvc;

namespace M_tracker.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class GroupExpensesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
