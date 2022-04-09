using M_tracker.DataAccess.Repository.IRepository;
using M_tracker.Models;
using M_tracker.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


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

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddUser(int? id)
        {
            GroupUserVM groupUserVM = new()
            {
                GroupUser = new GroupUser(),
                GroupTypeUser = new GroupTypeUser()
            };

            if (id == 0 || id == null)
            {
                return PartialView("_GroupUser", groupUserVM);
            }
            else
            {
                groupUserVM.GroupUser = _unitOfWork.GroupUser.GetFirstOrDefault(u => u.Id == id);
                return PartialView("_GroupUser", groupUserVM);

            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InsertUpdateUser(GroupUserVM obj)
        {


            obj.GroupUser.CreatedDate = DateTime.Now;
            _unitOfWork.GroupUser.Add(obj.GroupUser);
            _unitOfWork.Save();


            int GroupId = obj.GroupUser.Id;
            obj.GroupTypeUser.GroupId = GroupId;


            _unitOfWork.GroupTypeUser.Add(obj.GroupTypeUser);
            _unitOfWork.Save();

            TempData["success"] = "Group User created successfully";
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
            var List = _unitOfWork.GroupUser.ListAllUsers();
            return Json(new {data= List});
        }


    }
}
