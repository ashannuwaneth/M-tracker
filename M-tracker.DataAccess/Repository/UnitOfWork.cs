using M_tracker.DataAccess.Data;
using M_tracker.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_tracker.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDataContext _db;
        public UnitOfWork(ApplicationDataContext db)
        {
            _db = db;
            ExpensesType = new ExpensesTypeRepository(_db);
            GroupType = new GroupTypeRepository(_db);
            GroupTypeUser = new GroupTypeUserRepository(_db);
            GroupUser = new GroupUserRepository(_db);
            groupExManage = new GroupExManageRepository(_db);
            GroupTotal = new GroupTotalRepository(_db);
        }

        public IExpensesTypeRepository ExpensesType { get;private set; }

        public IGroupTypeRepository GroupType { get;private set; }

        public IGroupTypeUserRepository GroupTypeUser { get; private set; }

        public IGroupUserRepository GroupUser { get; private set; }

        public IGroupExManageRepository groupExManage { get;private set; }

        public IGroupTotalRepository GroupTotal { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
