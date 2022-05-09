using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_tracker.Models.ViewModels
{
    public class IncomeVM
    {
        public Income Income { get; set; }
        public IncomeType IncomeType { get; set; }
        public IncomeMethod IncomeMethod { get; set; }
        public IEnumerable<SelectListItem> IncomeList { get; set; }
        public IEnumerable<SelectListItem> IncomeMethodList { get; set; }
    }
}
