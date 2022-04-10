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
    public class GroupTypeUser
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public virtual IdentityUser IdentityUser { get; set; }
        public int? GroupId { get; set; }
        [ForeignKey("GroupId")]
        [ValidateNever]
        public  GroupUser GroupUser { get; set; }
        [Required]
        public int? GroupTypeId { get; set; }
        [ForeignKey("GroupTypeId")]
        [ValidateNever]
        public virtual GroupType GroupType { get; set; }
    }
}
