using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dataAccessLayer;
using dataAccessLayer.Objects;
using businessLogicLayer.Objects;
using utilityLogger;

namespace businessLogicLayer
{
    public class workoutLogic
    {
        // new instance of the logger
        static logger _logger = new logger();
        // new instane of routine data access
        routineDataAccess routineData = new routineDataAccess();
        // new instance of routine Workout data access
        routineWorkoutDataAccess routineWData = new routineWorkoutDataAccess();
        // business logic mapper
        BL_mapper _mapper = new BL_mapper();


        public void addSets(BL_routine routine, int routineID, int personID)
        {
            try
            {
                // making new list routine list
                List<BL_routine> routineList = new List<BL_routine>();
                {
                    // adding routines to the list
                    routineList.Add(routine);
                }

                // making ints for routineid and personid 
                int personIDBL = personID;
                int routineIDBL = routineID;

                // making new instance of object routine workout
                BL_routineWorkout routineWorkoutList = new BL_routineWorkout();

                // getting the lift of exercise based on the routine passing person id and routine id
                routineWorkoutList.routineWList = _mapper.map(routineWData.listAllRoutineWorkout(personIDBL, routineID));

                //making the new list of routine exercise 
                List<BL_routineWorkout> BL_routineWList = new List<BL_routineWorkout>();
                {
                    for (int i = 0; i < routineWorkoutList.routineWList.Count(); i++)
                    {
                        // adding exercise to routineWlist
                        BL_routineWList.Add(routineWorkoutList.routineWList[i]);
                    }
                }

                int sets = 0;// setting sets to 0
                int reps = 0;// setting reps to 0
                int exercise = BL_routineWList.Count;// using the the count of routine list and setting as exercise

                routineWorkoutList.FK_routineWorkoutID = routine.routineID;
                // for loop for going through the list of routines 
                for (int i = 0; i < BL_routineWList.Count(); i++)
                {

                    // adding routine sets to the total sets
                    sets += BL_routineWList[i].routineWSets;
                    // adding reps to total reps
                    reps += BL_routineWList[i].routineWReps;
                }
                // setting sets and reps to routine sets and reps
                routine.totalSets = sets;
                routine.totalReps = reps;
                routine.totalExercise = exercise;

                // calling data access to update the  total sets and reps
                routineData.updateSetsReps(_mapper.map(routine), routineIDBL);
            }
            // log error
            catch (Exception _error)
            {
                // putting errors into a text file
                _logger.logError(_error);
            }
        }

    }

}