using M_tracker.DataAccess.Repository.IRepository;
using M_tracker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace M_tracker.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class GroupTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public GroupTypeController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateGroup(int? id)
        {
            GroupType groupType = new GroupType();
            if (id == 0 || id == null)
            {
                return PartialView("_CreateGroup",groupType);
            }
            else
            {
                var Groups = _unitOfWork.GroupType.GetFirstOrDefault(x => x.Id == id);
                if (Groups != null)
                {
                    return PartialView("_CreateGroup", Groups);
                }
                else
                {
                    return RedirectToAction("Index");
                }
                
            }
        }
         [HttpPost]
         [ValidateAntiForgeryToken]
         public IActionResult CreateUpdateGroup(GroupType obj)
        {

            obj.CreatedDate = DateTime.Now;
            if (obj.Description == null)
            {
                obj.Description = obj.Type;
            }
            if ( obj.Id !=0)
            {
                _unitOfWork.GroupType.Update(obj);
            }
            else
            {
                var claimsIdentity = (ClaimsIdentity)User.Identity;
                var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

                obj.UserId = Convert.ToString(claim.Value);
                _unitOfWork.GroupType.Add(obj);
            }
            _unitOfWork.Save();
            TempData["success"] = "Group created successfully";
            return RedirectToAction("Index");

        }

        [AcceptVerbs("GET", "POST")]
        public JsonResult VerifyGroups(string Type,int Id)
        {
            bool isexists = _unitOfWork.GroupType.isGroupexists(Type,Id);
            if (isexists)
            {
                return Json(data: false);
            }
            else
            {
                return Json(data: true);

            }
        }

        #region
        [HttpGet]
        public IActionResult GetAllGroup()
        {
            var AllGroup = _unitOfWork.GroupType.GetAll();
            return Json(new {data = AllGroup });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.GroupType.GetFirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error While Deleteing" });
            }
            else
            {
                _unitOfWork.GroupType.Remove(obj);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Group has been Deleted" });
            }
        }
        #endregion
    }
}
