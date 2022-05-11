using M_tracker.DataAccess.Data;
using M_tracker.DataAccess.Repository.IRepository;
using M_tracker.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_tracker.DataAccess.Repository
{
    public class ExpensesRepository : Repository<Expenses>, IExpensesRepository
    {
        private readonly ApplicationDataContext _db;
        public ExpensesRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> ExpenseseList()
        {
            var List = (from e in _db.ExpensesTypes
                        select new SelectListItem
                        {
                            Text = e.Type,
                            Value = e.Id.ToString(),
                        });

            return List;
        }

        public IEnumerable<SelectListItem> ExpenseseMethod()
        {
            var MethodList = (from m in _db.IncomeMethods
                              select new SelectListItem
                              {
                                  Text = m.IncomeMethods,
                                  Value = m.Id.ToString(),
                              });

            return MethodList;
        }

        public Array GetAllExpensesList(string user)
        {
            var List = (from ep in _db.Expenses
                      join et in _db.ExpensesTypes on ep.ExpensesTypeId equals et.Id
                      join it in _db.IncomeTypes on ep.IncomeMethodId equals it.Id
                        where ep.UserId == user
                        select new
                        {
                            ep.Id,
                            ep.Amount,
                            ExpensesDate= ep.ExpensesDate.ToString("yyyy-MM-dd"),
                            et.Type,
                            it.IncomeTypes
                        }).ToArray();

            return List;
        }

        public void Update(Expenses Expenses)
        {
           _db.Update(Expenses);
        }
    }
}
