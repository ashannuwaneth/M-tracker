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
    public class GroupTypeUserRepository : Repository<GroupTypeUser>, IGroupTypeUserRepository
    {
        private readonly ApplicationDataContext _db;
        public GroupTypeUserRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

    }
}
