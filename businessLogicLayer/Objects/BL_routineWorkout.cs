using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace businessLogicLayer.Objects
{
    public class BL_routineWorkout
    {
        // constructors 
        public int routineWorkoutID { get; set; }
        public string routineWorkoutName { get; set; }
        public int FK_exerciseID { get; set; }
        public int FK_routineWorkoutID { get; set; }
        public int routineWSets { get; set; }
        public int routineWReps { get; set; }
        public int routineWRest { get; set; }

        public List<BL_routineWorkout> routineWList { get; set; }
    }

    public class BL_routine
    {
        // constructors
        public int routineID { get; set; }
        public string routineName { get; set; }
        public int FK_personID { get; set; }
        public DateTime login { get; set; }
        public int totalSets { get; set; }
        public int totalReps { get; set; }
        public int totalExercise { get; set; }

        public List<BL_routine> routineList { get; set; }
    }

   
}
