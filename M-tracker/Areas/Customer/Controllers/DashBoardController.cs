using M_tracker.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace M_tracker.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class DashBoardController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;



        public DashBoardController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LoadGroupAmount()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var LoadList = _unitOfWork.DashBoard.GetGroupAmounts(claim.Value);

            return Json(new { data = LoadList });
        }
        [HttpGet]
        public IActionResult LoadAllExpensesTypes()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var LoadEx = _unitOfWork.DashBoard.GetAllExpensesCategories(claim.Value);

            return Json(new {data = LoadEx});
        }
        [HttpGet]
        public async Task<IActionResult> LoadExpensesIncome()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var LoadExIncome = _unitOfWork.DashBoard.GetAllExIncomeList(claim.Value);

            return Json(new {data= LoadExIncome });
        }
        [HttpGet]
        public async Task<IActionResult> LoadIncome()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var LoadIncome = _unitOfWork.DashBoard.GetAllIncomeList(claim.Value);

            return Json(new {data = LoadIncome });
        }
    }
}
