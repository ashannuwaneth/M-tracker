using M_tracker.DataAccess.Repository.IRepository;
using M_tracker.Models;
using M_tracker.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Claims;


namespace M_tracker.Areas.Customer.Controllers
{


    [Area("Customer")]
    public class GroupExpensesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        private object request;

        public GroupExpensesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            GroupExpensesVM groupExpensesVM = new()
            {
                GroupExpensesManage = new GroupExpensesManage(),
                ExpensesType = _unitOfWork.ExpensesType.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Type,
                    Value = u.Id.ToString()
                }),
                GroupList = _unitOfWork.GroupType.GetAll(u => u.UserId == Convert.ToString(claim.Value)).Select(u => new SelectListItem { 
                Text = u.Type,
                Value = u.Id.ToString()
                
                })
            };

            return View(groupExpensesVM);
        }



        [HttpPost]
        public async Task<ActionResult>  Save([FromBody] List<GroupExpensesManage> Expenses)
        {

            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            foreach (GroupExpensesManage e in Expenses)
            {
                e.UserId = Convert.ToString(claim.Value);
                _unitOfWork.groupExManage.Add(e);
            }

            _unitOfWork.Save();
            TempData["success"] = "Expenses  has been Added successfully";
            return Json(new {success=true});
        }
    }
}
