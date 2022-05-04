using M_tracker.DataAccess.Repository.IRepository;
using M_tracker.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace M_tracker.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class GroupTotalController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public GroupTotalController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var GroupList = _unitOfWork.GroupTotal.GropList(claim.Value);

            GroupTotalVM GroupTotalVM = new()
            {
                GroupTypeList = GroupList
            };

            return View(GroupTotalVM);
        }
        [HttpGet]
        public IActionResult LoadMonths(string TypeIdGet)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var MonthsList = _unitOfWork.GroupTotal.GetMonths(TypeIdGet, claim.Value);

            return Json(new {data = MonthsList });
        }
        
        [HttpPost]
        public IActionResult ExpensesProcess(string txtGroupId,string txtDate)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            bool result = _unitOfWork.GroupTotal.ProcessExpenses(txtGroupId, txtDate, claim.Value);

            return Json(new { success = true, message = "Process has been successfull" });
        }

        [HttpGet]
        public IActionResult LoadGroupTotalData(string GroupId)
        {
            var List = _unitOfWork.GroupTotal.LoadGroupAmount(GroupId);
            return Json(new {data = List });
        }
    }
}
