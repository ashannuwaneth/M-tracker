using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_tracker.DataAccess.Repository.IRepository
{
    public interface IDashBoardRepository 
    {
        Array GetGroupAmounts(string user);
        Array GetAllExpensesCategories(string user);

        Array GetAllExIncomeList(string user);

        Array GetAllIncomeList(string user);
    }
}
