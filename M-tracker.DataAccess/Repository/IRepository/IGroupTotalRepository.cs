using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_tracker.DataAccess.Repository.IRepository
{
    public interface IGroupTotalRepository
    {
        Array GetMonths(string TypeId, string UserId);
        bool ProcessExpenses(string txtGroupId, string txtDate,string user);
        Array LoadGroupAmount(string groupid);
    }
}
