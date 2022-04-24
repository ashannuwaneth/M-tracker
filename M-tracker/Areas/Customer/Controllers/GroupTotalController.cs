using Microsoft.AspNetCore.Mvc;

namespace M_tracker.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class GroupTotalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
