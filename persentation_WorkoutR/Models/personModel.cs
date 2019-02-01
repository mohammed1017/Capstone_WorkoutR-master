using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace persentation_WorkoutR.Models
{
    public class personModel
    {
        // adding properties to person model class
        [DisplayName("Person ID")]
        public int personID { get; set; }

        [DisplayName("First Name")]
        public string personFirstName { get; set; }

        [DisplayName("Last Name")]

        public string personLastName { get; set; }

        [DisplayName("Address")]

        public string personAddress { get; set; }

        [DisplayName("City")]

        public string personCity { get; set; }

        [DisplayName("State")]

        public string personState { get; set; }

        [DisplayName("Zipcode")]

        public string personZip { get; set; }

        [DisplayName("Phone #")]

        public string personPhone { get; set; }

        [DisplayName("Role")]
        public int FK_roleID { get; set; }

        [Required]
        [DisplayName("Username")]
        public string personUsername { get; set; }

        [Required]
        [DisplayName("Password")]
        [StringLength(35, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string personPassword { get; set; }

    }
}