using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_tracker.Models.ViewModels
{
    public class ExpensesVM
    {
        public Expenses Expenses { get; set; }
        public IEnumerable<SelectListItem> ExpensesList { get; set; }
        public IEnumerable<SelectListItem> ExpensesMethod { get; set; }
    }
}
