using M_tracker.DataAccess.Repository.IRepository;
using M_tracker.Models;
using M_tracker.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace M_tracker.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class GroupUserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public GroupUserVM GroupUserVM { get; set; }

        public GroupUserController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {

            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;

        }

        public IActionResult Index(int? id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            GroupUserVM GroupUserVM = new()
            {

                GroupTypeUser = new GroupTypeUser(),
                GroupTypeList = _unitOfWork.GroupType.GetAll(u => u.UserId == Convert.ToString(claim.Value)).Select(u => new SelectListItem
                {

                    Text = u.Type,
                    Value = u.Id.ToString()
                }),
                
            };

            if (id == null || id == 0)
            {
                GroupUserVM.GroupTypeUser.Id = 0;
                return View(GroupUserVM);
            }
            else
            {
                

                GroupUserVM.GroupTypeUser = _unitOfWork.GroupTypeUser.GetFirstOrDefault(u => u.Id == id);
                GroupUserVM.GroupUser = _unitOfWork.GroupUser.GetFirstOrDefault(u => u.Id == GroupUserVM.GroupTypeUser.GroupId);
                GroupUserVM.GroupTypeUser.UserId = _unitOfWork.GroupUser.GetUserName(GroupUserVM.GroupTypeUser.UserId);
     

                return View(GroupUserVM);
            }  
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InsertUpdateUser(GroupUserVM obj)
        {

            string Message="";

            if (obj.GroupUser.Id == 0)
            {

                obj.GroupUser.CreatedDate = DateTime.Now;
                _unitOfWork.GroupUser.Add(obj.GroupUser);
                _unitOfWork.Save();

                obj.GroupTypeUser.GroupId = obj.GroupUser.Id;
                obj.GroupTypeUser.UserId = obj.UserIdGet;

                _unitOfWork.GroupTypeUser.Add(obj.GroupTypeUser);

                Message = "Created";
            }
            else
            {

                var UpdateRecords = _unitOfWork.GroupUser.GetFirstOrDefault(u => u.Id==obj.GroupUser.Id);

                UpdateRecords.CreatedDate = DateTime.Now;
                UpdateRecords.IsAdmin = obj.GroupUser.IsAdmin;
                UpdateRecords.IsActive = obj.GroupUser.IsActive;

                _unitOfWork.GroupUser.Update(UpdateRecords);
                Message = "Updated";
            }

            _unitOfWork.Save();

            TempData["success"] = "Group User "+ Message + " successfully";
            return RedirectToAction("Index");


        }

        [HttpPost]
        public JsonResult search(string prefix)
        {
            var list = _unitOfWork.GroupUser.GetAll(prefix);
            return Json(list);
        }
        [HttpGet]
        public IActionResult UserList()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var List = _unitOfWork.GroupUser.ListAllUsers(claim.Value);
            return Json(new {data= List});
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var DeleteTypeUser = _unitOfWork.GroupTypeUser.GetFirstOrDefault(u => u.Id == id);
            var DeleteGroupUser = _unitOfWork.GroupUser.GetFirstOrDefault(u => u.Id == DeleteTypeUser.GroupId);

            if (DeleteTypeUser == null || DeleteGroupUser == null)
            {
                return Json(new { success = false , message = "Error While Deleteing" });
            }
            else
            {
                _unitOfWork.GroupTypeUser.Remove(DeleteTypeUser);
                _unitOfWork.GroupUser.Remove(DeleteGroupUser);
                _unitOfWork.Save();

                return Json(new { success = true, message = "Group User Has been Deleted" });
                
            }
        }
    }
}
