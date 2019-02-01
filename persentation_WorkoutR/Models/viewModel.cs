using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace persentation_WorkoutR.Models
{
    public class viewModel
    {

        public exerciseModel singleExercise { get; set; }
        public List<exerciseModel> exerciseList { get; set; }

        public bodyPartModel singleBodyPart { get; set; }
        public List<bodyPartModel> bodyPartList { get; set; }

        public personModel singlePerson { get; set; }
        public List<personModel> personList { get; set; }

        public routineModel singleRoutine { get; set; }
        public List<routineModel> routineList { get; set; }

        public routineWorkoutModel singleRoutineWorkout { get; set; }
        public List<routineWorkoutModel> routineWorkoutList { get; set; }

        public roleModel singleRole { get; set; }
        public List<roleModel> roleList { get; set; }




        public viewModel()
        {
        

            singleExercise = new exerciseModel();
            exerciseList = new List<exerciseModel>();

            singleBodyPart = new bodyPartModel();
            bodyPartList = new List<bodyPartModel>();

            singlePerson = new personModel();
            personList = new List<personModel>();

            singleRoutine = new routineModel();
            routineList = new List<routineModel>();

            singleRoutineWorkout = new routineWorkoutModel();
            routineWorkoutList = new List<routineWorkoutModel>();

            singleRole = new roleModel();
            roleList = new List<roleModel>();

        }
    }
}