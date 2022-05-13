using M_tracker.DataAccess.Repository.IRepository;
using M_tracker.Models;
using M_tracker.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace M_tracker.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ExpensesTypeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ExpensesTypeController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateType(int? id)
        {
            ExpensesType expenses = new ExpensesType();
            if (id == 0 || id == null)
            {
                return PartialView("_CreateType", expenses);
            }
            else
            {
                expenses = _unitOfWork.ExpensesType.GetFirstOrDefault(x => x.Id == id);
                return PartialView("_CreateType",expenses);
            }
              
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateUpdateType(ExpensesType obj, IFormFile file)
        {
            obj.CreatedDate = DateTime.Now;

            //if (ModelState.IsValid)
            //{
                string wwwRootPath = _hostEnvironment.WebRootPath;

            if (file != null)
            {
                string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\ExpensesTypes");
                    var extension = Path.GetExtension(file.FileName);

                    if (obj.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.ImageUrl = @"\images\ExpensesTypes\" + fileName + extension;

                //}

                if (obj.Id == 0)
                {
                    _unitOfWork.ExpensesType.Add(obj);
                }
                else
                {
                    _unitOfWork.ExpensesType.Update(obj);
                }
                _unitOfWork.Save();
                TempData["success"] = "Type created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return RedirectToAction("Index");
            }
           
        }

        #region Api call from javascript
        [HttpGet]
        public IActionResult GetAllTypes()
        {
            var TypeList = _unitOfWork.ExpensesType.GetAll();
            return Json(new {data = TypeList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.ExpensesType.GetFirstOrDefault(x => x.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error While Deleteing" });
            }
            else
            {
                _unitOfWork.ExpensesType.Remove(obj);
                _unitOfWork.Save();
                return Json(new { success = true,message="Type has been Deleted"});
            }
        }

        #endregion
    }
}


