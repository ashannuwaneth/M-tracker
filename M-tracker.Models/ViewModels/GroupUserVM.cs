using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_tracker.Models.ViewModels
{
    public class GroupUserVM
    {
        public GroupUser GroupUser { get; set; }

        public GroupTypeUser GroupTypeUser {get;set;}

    }
}
