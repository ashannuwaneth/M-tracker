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
    internal class ExpensesTypeRepository : Repository<ExpensesType>, IExpensesTypeRepository
    {
        private readonly ApplicationDataContext _db;
        public ExpensesTypeRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ExpensesType obj)
        {
            _db.ExpensesTypes.Update(obj);
        }
    }
}
