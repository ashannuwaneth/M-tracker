﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_tracker.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IExpensesTypeRepository ExpensesType { get; }
        void Save();
    }
}
