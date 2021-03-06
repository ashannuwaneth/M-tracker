using M_tracker.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_tracker.DataAccess.Repository.IRepository
{
    public interface IExpensesRepository : IRepository<Expenses>
    {
        IEnumerable<SelectListItem> ExpenseseList();
        IEnumerable<SelectListItem> ExpenseseMethod();
        Array GetAllExpensesList(string user);
        void Update(Expenses Expenses);

    }
}
