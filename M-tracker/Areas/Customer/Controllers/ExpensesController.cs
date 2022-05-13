using M_tracker.DataAccess.Repository.IRepository;
using M_tracker.Models;
using M_tracker.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace M_tracker.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class ExpensesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;
        public ExpensesController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index(int? id)
        {
            ExpensesVM evm = new()
            {
                Expenses = new Expenses(),
                ExpensesList = _unitOfWork.Expenses.ExpenseseList(),
                ExpensesMethod = _unitOfWork.Expenses.ExpenseseMethod(),
            };


            if (id ==0|| id == null)
            {
                evm.Expenses.Id = 0;
                return View(evm);
            }
            else
            {
                var List = _unitOfWork.Expenses.GetFirstOrDefault(u => u.Id == id);
                evm.Expenses = List;
                return View(evm);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult InsertUpdateExpenses(ExpensesVM em)
        {
            var edit = _unitOfWork.Expenses.GetFirstOrDefault(e => e.Id == em.Expenses.Id);
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            string Message="";
            if (em.Expenses.Id !=0)
            {
                em.Expenses.UserId = claim.Value;
                Message = "Updated";
                _unitOfWork.Expenses.Update(em.Expenses);
            }
            else
            {
                em.Expenses.UserId = claim.Value;
                _unitOfWork.Expenses.Add(em.Expenses);
                Message = "Inserted";
            }

            _unitOfWork.Save();
            TempData["success"] = "Income " + Message + " successfully";
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult GetAllExpenses()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            var ExList = _unitOfWork.Expenses.GetAllExpensesList(claim.Value);
            return Json(new {data= ExList});  
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var GetDeleteList = _unitOfWork.Expenses.GetFirstOrDefault(u => u.Id==id);

            if (GetDeleteList != null)
            {
                _unitOfWork.Expenses.Remove(GetDeleteList);
                _unitOfWork.Save();
                return Json(new { success = true, message = "Record Has been Deleted" });
            }
            else
            {
                return Json(new { success = false, message = "Error While Deleteing" });
            }
        }
    }
}
