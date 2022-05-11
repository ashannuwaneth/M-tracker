using M_tracker.DataAccess.Repository.IRepository;
using M_tracker.Models;
using M_tracker.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace M_tracker.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class IncomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public IncomeVM IncomeVM { get; set; }
        public IncomeController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index(int? id)
        {


            IncomeVM List = new() {

                Income = new Income(),
                IncomeType = new IncomeType(),
                IncomeMethod = new IncomeMethod(),
                IncomeList = _unitOfWork.Income.IncomeTypeList(),
                IncomeMethodList = _unitOfWork.Income.IncomeMethodList(),
            };
            if (id == null || id ==0)
            {
                List.Income.Id = 0;
                return View(List);
            }
            else
            {
                List.Income = _unitOfWork.Income.GetFirstOrDefault(a => a.Id == id);
                return View(List);
            }           
        }
        [HttpGet]
        public IActionResult GetAllIncome()
        {
            var List = _unitOfWork.Income.IncomeList();

            return Json(new {data= List});
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InsertUpdateIncome(IncomeVM In)
        {

            string Message = "";
            if (In.Income.Id !=0)
            {
                 _unitOfWork.Income.Update(In.Income);
                Message = "Updated";
            }
            else
            {
                _unitOfWork.Income.Add(In.Income);
                Message = "Inserted";
            }
            _unitOfWork.Save();
            TempData["success"] = "Income " + Message + " successfully";
            return RedirectToAction("Index");

        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var DeleteIncome = _unitOfWork.Income.GetFirstOrDefault(u => u.Id == id);


            if (DeleteIncome == null || DeleteIncome == null)
            {
                return Json(new { success = false, message = "Error While Deleteing" });
            }
            else
            {
                _unitOfWork.Income.Remove(DeleteIncome);
                _unitOfWork.Save();

                return Json(new { success = true, message = "Record Has been Deleted" });

            }
        }
    }
}
