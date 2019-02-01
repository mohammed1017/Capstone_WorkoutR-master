using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace persentation_WorkoutR.Models
{
    public class bodyPartModel
    {
        // adding properties to exercise model class

        [DisplayName("Body Part")]
        public int bodyPartID { get; set; }

        [DisplayName("Body Part Name")]
        public string bodyPartName { get; set; }
    }

}