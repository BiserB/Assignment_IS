using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_IS.Models.Input
{
    public class CreateToDoListModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
