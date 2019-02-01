using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace persentation_WorkoutR.Models
{
    public class routineWorkoutModel : bodyPartModel
    {
        [DisplayName("Routine Exercise ID")]
        public int routineWorkoutID { get; set; }

        [DisplayName("Exercise Name")]
        [Required]
        public int FK_exerciseID { get; set; }
        [DisplayName("Routine Exercise ID ")]
        public int FK_routineWorkoutID { get; set; }

        [DisplayName("Sets")]
        [Range(1,10, ErrorMessage = " {0} Must be between 1 and 15")]
        [Required]
        public int routineWSets { get; set; }

        [DisplayName("Reps")]
        [Range(2,100, ErrorMessage = " {0} Must be  between 2 and 100 ")]
        [Required]
        public int routineWReps { get; set; }

        [DisplayName("Rest(Seconds)")]
        [Range(5,300, ErrorMessage = " {0} Must be  between 5 and 300 ")]
        [Required]
        public int routineWRest { get; set; }

        [DisplayName("Exercise Name")]
        public string exerciseName { get; set; }

        [DisplayName("Routine")]
        public string routineName { get; set; }

        public List<exerciseModel> exerciseList {get; set;}
        public List<bodyPartModel> bodyPartList { get; set; }
    }
}