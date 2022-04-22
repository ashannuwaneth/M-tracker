using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_tracker.Models
{
    public class GroupExpensesManage
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        public string DateFrom { get; set; }
        [Required]
        public string DateTo { get; set; }
        [Display(Name ="Group")]
        public int? GroupTypeId { get; set; }
        [ForeignKey("GroupTypeId")]
        [ValidateNever]
        public virtual GroupType GroupType { get; set; }
        [Display(Name ="Expenses Type")]
        public int? ExpensesTypeId { get; set; }
        [ForeignKey("ExpensesTypeId")]
        [ValidateNever]
        public virtual ExpensesType ExpensesType { get; set; }
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public virtual IdentityUser IdentityUser { get; set; }
        [NotMapped]
        public bool IsUpdate { get; set; }


    }
}
