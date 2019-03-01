using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace persentation_WorkoutR.Models
{
    public class weightsModel
    {
        public int WeightsID { get; set; }
        public int lbs { get; set; }
        public int FK_routineWorkID { get; set; }

        public List<weightsModel> weightsList { get; set; }

        public weightsModel()
        { }

        public weightsModel(routineWorkoutModel routineWorkout)
        {
            this.FK_routineWorkID = routineWorkout.routineWorkoutID;
        }
    }
}