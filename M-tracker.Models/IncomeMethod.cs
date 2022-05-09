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
    public class IncomeMethod
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string IncomeMethods { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public virtual IdentityUser IdentityUser { get; set; }
    }
}
