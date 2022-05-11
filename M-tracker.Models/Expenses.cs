using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_tracker.Models
{
    public class Expenses
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        [Display(Name = "Date")]
        public DateTime ExpensesDate { get; set; }
        public string? UserId { get; set; }
        [ForeignKey("UserId")]

        public virtual IdentityUser IdentityUser { get; set; }
        [Required]
        [Display(Name = "Expenses Type")]
        public int ExpensesTypeId { get; set; }
        [ForeignKey("ExpensesTypeId")]
        public virtual ExpensesType ExpensesType { get; set; }
        [Required]
        [Display(Name = "Type Method")]
        public int? IncomeMethodId { get; set; }
        [ForeignKey("IncomeMethodId")]

        public virtual IncomeMethod IncomeMethod { get; set; }

    }
}
