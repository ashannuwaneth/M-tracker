
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_tracker.Models
{
    public class ExpensesType
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [ValidateNever]
        public DateTime CreatedDate { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }



    }
}
