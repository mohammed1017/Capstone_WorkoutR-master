using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace persentation_WorkoutR.Models
{
    public class routineModel
    {
        [DisplayName("Routine ID")]
        public int routineID { get; set; }

        [DisplayName("Routine Name")]
        [Required]
        public string routineName { get; set; }

        [DisplayName("Person ID")]
        public int FK_personID { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Login Date")]
        [Required]
        public DateTime login { get; set; }

        [DisplayName("Total Sets")]
        public int totalSets { get; set; } = 0;

        [DisplayName("Total Reps")]
        public int totalReps { get; set; } = 0;

        [DisplayName("Total Exercise")]
        public int totalExercise { get; set; } = 0;

    }
}