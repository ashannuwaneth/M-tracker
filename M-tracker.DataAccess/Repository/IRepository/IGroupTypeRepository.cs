using M_tracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_tracker.DataAccess.Repository.IRepository
{
    public interface IGroupTypeRepository : IRepository<GroupType>
    {
        void Update(GroupType obj);
        bool isGroupexists(string Type,int Id);
    }
}
