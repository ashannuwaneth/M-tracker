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
    public class IncomeRepository : Repository<Income>, IIncomeRepository
    {
        private readonly ApplicationDataContext _db;
        public IncomeRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

       public IEnumerable<SelectListItem> IncomeTypeList()
        {

            var List = (from i in _db.IncomeTypes
                       select new  SelectListItem
                       {
                           Text = i.IncomeTypes,
                           Value= i.Id.ToString(),
                           
                       }).ToArray();
            return List;
        }

        public IEnumerable<SelectListItem> IncomeMethodList()
        {
            var MethodList = (from i in _db.IncomeMethods
                              select new SelectListItem { 
                                  Text = i.IncomeMethods,
                                  Value = i.Id.ToString()
                              }).ToArray();

            return MethodList;
        }

        public void Update(Income income)
        {
            _db.Incomes.Update(income);
        }

        public Array  IncomeList()
        {
            var list = (from i in _db.Incomes
                        join ty in _db.IncomeTypes on i.IncomeTypeId equals ty.Id
                        join m in _db.IncomeMethods on i.IncomeMethodId equals m.Id
                        select new
                        {
                            i.Id,
                            IncomeDate =i.IncomeDate.ToString("yyyy-MM-dd"),
                            i.Amount,
                            ty.IncomeTypes,
                            m.IncomeMethods
                        }).ToArray();

            return list;
        }
    }
}
