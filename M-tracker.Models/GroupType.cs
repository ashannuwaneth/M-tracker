using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    public class GroupType 
    {
        public int Id { get; set; }
        [Required]
        [Remote("VerifyGroups", "GroupType",AdditionalFields ="Id", ErrorMessage = "Group Name already being used")]
        public string Type { get; set; }
        [ValidateNever]
        public string? Description { get; set; }
        [ValidateNever]
        public DateTime CreatedDate { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public virtual IdentityUser IdentityUser { get; set; }


    }
}
