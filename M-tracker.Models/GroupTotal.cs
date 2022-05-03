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
    public class GroupTotal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime SubmitDate { get; set; }
        [Required]
        public double Amount { get; set; }
        public double DueAmount { get; set; }
        public double TotalAmount { get; set; }
        public string ProcessDate { get; set; }
        [ValidateNever]
        [Display(Name ="Group Type")]
        public int? GroupTypeId { get; set; }
        [ForeignKey("GroupTypeId")]
        [ValidateNever]
        public virtual GroupType GroupType { get; set; }
        [ValidateNever]
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public virtual IdentityUser IdentityUser { get; set; }

    }
}
