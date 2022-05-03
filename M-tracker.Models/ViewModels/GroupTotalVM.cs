using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_tracker.Models.ViewModels
{
    public class GroupTotalVM
    {
        public  GroupTotal GroupTotal { get; set; }
        public IEnumerable<SelectListItem> GroupTypeList { get; set; }

        public IEnumerable<SelectListItem> ExpensesMonths { get; set; }
    }
}
