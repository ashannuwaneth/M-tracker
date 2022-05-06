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
    }
}
