                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   using M_tracker.DataAccess.Data;
using M_tracker.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_tracker.DataAccess.Repository
{

    public class DashBoardRepository : Repository<Task>,IDashBoardRepository
    {
        private readonly ApplicationDataContext _db;

        public DashBoardRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public Array GetAllExpensesCategories(string user)
        {
            var ExList = (from e in _db.Expenses
                          join u in _db.Users on e.UserId equals u.Id
                          join et in _db.ExpensesTypes on e.ExpensesTypeId equals et.Id
                          where e.UserId == user
                          group e by  new { et.Type} into exgrp
                          select new
                          {
                              Amount = exgrp.Sum(u => u.Amount),
                              exgrp.Key.Type,
                             

                          }).ToArray();

            return ExList;
        }

        public Array GetGroupAmounts(string user)
        {
            var List = (from gt in _db.GroupTotals
                        where gt.UserId == user
                        group gt by new {  gt.ProcessDate } into grp
                        select new
                        {
                            TotalAmount = grp.Sum(c => c.TotalAmount),
                            grp.Key.ProcessDate,
                        }).ToArray();

            return List;

        }

        public Array GetAllExIncomeList(string user)
        {
            var ExList = (from e in _db.Expenses
                          where e.UserId==user
                          group e by new { e.ExpensesDate.Year,e.ExpensesDate.Month } into grpex
                          select new
                          {
                              Total = grpex.Sum(u => u.Amount),
                              Date = string.Format("{0}|{1}", grpex.Key.Year, grpex.Key.Month),
                              
                          }).ToArray();

 

            return ExList;

        }

        public Array GetAllIncomeList(string user)
        {
            var Income = (from i in _db.Incomes
                          where i.UserId == user
                          group i by new { i.IncomeDate.Year, i.IncomeDate.Month } into gincome
                          select new
                          {
                              Total = gincome.Sum(t => t.Amount),
                              Date = string.Format("{0}|{1}", gincome.Key.Year, gincome.Key.Month),
                          }).ToArray();

            return Income;
        }
    }
}
