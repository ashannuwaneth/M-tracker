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
    public class GroupTypeRepository : Repository<GroupType>, IGroupTypeRepository
    {
        private readonly ApplicationDataContext _db;
        public GroupTypeRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public bool isGroupexists(string Type)
        {
            var count = _db.GroupTypes.Select(x => x.Type == Type).Count();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool isGroupexists(string Type,int Id)
        {



            var GroupCount = _db.GroupTypes
                               .Where(s => s.Id != Id && s.Type == Type)
                               .ToList().Count();
            if (GroupCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Update(GroupType obj)
        {
            _db.GroupTypes.Update(obj);
        }
    }
}
