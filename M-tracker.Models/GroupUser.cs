using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_tracker.Models
{
    public class GroupUser
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        [Display(Name ="Is Active")]
        public bool IsActive { get; set; }
        [Display(Name = "Is Admin")]
        public bool IsAdmin { get; set; }
    }
}
