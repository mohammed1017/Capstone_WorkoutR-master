using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace persentation_WorkoutR.Models
{
    public class roleModel
    {
        [DisplayName("Role ID")]
        public int roleID { get; set; }
        [DisplayName("Role Name")]
        public string roleName { get; set; }
        [DisplayName("Role Description")]
        public string roleDescription { get; set; }
    }
}