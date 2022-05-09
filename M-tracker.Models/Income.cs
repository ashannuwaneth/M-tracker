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
    public class Income
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double Amount { get; set; }
        [Required]
        [Display(Name ="Date")]
        public DateTime IncomeDate { get; set; }
        public string? UserId { get; set; }
        [ForeignKey("UserId")]

        public virtual IdentityUser IdentityUser { get; set; }
        [Required]
        [Display(Name ="Income Type")]
        public int IncomeTypeId { get; set; }
        [ForeignKey("IncomeTypeId")]

        public virtual IncomeType IncomeType { get; set; }
        [Required]
        [Display(Name = "Type Method")]
        public int? IncomeMethodId { get; set; }
        [ForeignKey("IncomeMethodId")]
 
        public virtual IncomeMethod IncomeMethod { get; set; }


    }
}
