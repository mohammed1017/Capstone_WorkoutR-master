using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace persentation_WorkoutR.Models
{
    public class loginModel
    {
        [Required]
        [DisplayName("Username")]
        public string personUsername { get; set; }

        [Required]
        [DisplayName("Password")]
        // [StringLength(15, ErrorMessage = "The {0} cannot be more than {1} characters long.")]
        public string personPassword { get; set; }
    }
}