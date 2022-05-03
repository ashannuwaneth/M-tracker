using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_tracker.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IExpensesTypeRepository ExpensesType { get; }

        IGroupTypeRepository GroupType { get; }

        IGroupTypeUserRepository GroupTypeUser { get; }

        IGroupUserRepository GroupUser { get; }

        IGroupExManageRepository groupExManage { get; }

        IGroupTotalRepository GroupTotal { get; }
        void Save();
    }
}
