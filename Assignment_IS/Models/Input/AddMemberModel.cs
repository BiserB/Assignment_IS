using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_IS.Models.Input
{
    public class AddMemberModel
    {
        [Required]
        public Guid FamilyId { get; set; }

        [Required]
        public Guid MemberId { get; set; }
    }
}
