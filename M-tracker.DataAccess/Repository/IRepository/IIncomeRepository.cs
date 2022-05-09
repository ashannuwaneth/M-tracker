using M_tracker.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_tracker.DataAccess.Repository.IRepository
{
    public interface IIncomeRepository : IRepository<Income>
    {
        IEnumerable<SelectListItem> IncomeTypeList();
        IEnumerable<SelectListItem> IncomeMethodList();
        void Update(Income income);
        Array IncomeList();

    }
}
