using M_tracker.DataAccess.Data;
using M_tracker.DataAccess.Repository.IRepository;
using M_tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_tracker.DataAccess.Repository
{
    public class GroupExManageRepository : Repository<GroupExpensesManage>,IGroupExManageRepository
    {
        private readonly ApplicationDataContext _db;
        public GroupExManageRepository(ApplicationDataContext db) : base(db)
        {
            _db = db; 
        }

        public Array GetAllExepense(string UserId, string DateFrom, String DateTo)
        {
            var ExpensesList = (from ex in _db.GroupExpensesManages
                                join g in _db.GroupTypes on ex.GroupTypeId equals g.Id
                                join et in _db.ExpensesTypes on ex.ExpensesTypeId equals et.Id
                                where ex.UserId == UserId && ex.DateFrom == DateFrom && ex.DateTo == DateTo
                                select new
                                {
                                    CellId = ex.Id.ToString(),
                                    Group = g.Type.ToString(),
                                    Type = et.Type.ToString(),
                                    Description = ex.Description,
                                    Amount = ex.Amount.ToString(),
                                    IsUpdate = true


                                }).ToArray();
            return ExpensesList; 
        }
    }
}
