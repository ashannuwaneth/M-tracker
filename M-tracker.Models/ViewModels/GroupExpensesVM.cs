using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_tracker.Models.ViewModels
{
    public class GroupExpensesVM
    {
        public GroupExpensesManage GroupExpensesManage { get; set; }

        public IEnumerable<SelectListItem> GroupList { get; set; }

        public IEnumerable<SelectListItem> ExpensesType { get; set; }

    }
}
