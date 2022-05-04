using M_tracker.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_tracker.DataAccess.Repository.IRepository
{
    public interface IGroupExManageRepository : IRepository<GroupExpensesManage>
    {

       Array GetAllExepense(string UserId,string ExpensesDate);
       IEnumerable<SelectListItem> GroupList(string user);
    }
}
