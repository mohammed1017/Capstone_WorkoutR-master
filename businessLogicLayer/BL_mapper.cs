using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dataAccessLayer.Objects;
using businessLogicLayer.Objects;

namespace businessLogicLayer
{
    public class BL_mapper
    {
        
        public routineWorkoutDAO map(BL_routineWorkout _routineWorkoutToMap)
        {
            // put all the  info in business logic routine exerices from databases 
            routineWorkoutDAO _routineWorkoutToReturn = new routineWorkoutDAO();
            _routineWorkoutToReturn.routineWorkoutID = _routineWorkoutToMap.routineWorkoutID;
            _routineWorkoutToReturn.FK_exerciseID = _routineWorkoutToMap.FK_exerciseID;
            _routineWorkoutToReturn.FK_routineWorkoutID = _routineWorkoutToMap.FK_routineWorkoutID;
            _routineWorkoutToReturn.routineWSets = _routineWorkoutToMap.routineWSets;
            _routineWorkoutToReturn.routineWReps = _routineWorkoutToMap.routineWReps;
            _routineWorkoutToReturn.routineWRest = _routineWorkoutToMap.routineWRest;


            return _routineWorkoutToReturn;
        }

        public BL_routineWorkout map(routineWorkoutDAO _routineWorkoutToMap)
        {
            // put all the  info in business logic routine exerices from databases 
            BL_routineWorkout _routineWorkoutToReturn = new BL_routineWorkout();
            _routineWorkoutToReturn.routineWorkoutID = _routineWorkoutToMap.routineWorkoutID;
            _routineWorkoutToReturn.FK_exerciseID = _routineWorkoutToMap.FK_exerciseID;
            _routineWorkoutToReturn.FK_routineWorkoutID = _routineWorkoutToMap.FK_routineWorkoutID;
            _routineWorkoutToReturn.routineWSets = _routineWorkoutToMap.routineWSets;
            _routineWorkoutToReturn.routineWReps = _routineWorkoutToMap.routineWReps;
            _routineWorkoutToReturn.routineWRest = _routineWorkoutToMap.routineWRest;

            return _routineWorkoutToReturn;
        }

        public routineDAO map(BL_routine _routineToMap)
        {
            routineDAO _routineRetMod = new routineDAO();
            _routineRetMod.routineID = _routineToMap.routineID;
            _routineRetMod.routineName = _routineToMap.routineName;
            _routineRetMod.FK_personID = _routineToMap.FK_personID;
            _routineRetMod.login = _routineToMap.login;
            _routineRetMod.totalSets = _routineToMap.totalSets;
            _routineRetMod.totalReps = _routineToMap.totalReps;
            _routineRetMod.totalExercise = _routineToMap.totalExercise;

            return _routineRetMod;
        }

        public BL_routine map(routineDAO _routineToMap)
        {
            BL_routine _routineRetMod = new BL_routine();
            _routineRetMod.routineID = _routineToMap.routineID;
            _routineRetMod.routineName = _routineToMap.routineName;
            _routineRetMod.FK_personID = _routineToMap.FK_personID;
            _routineRetMod.login = _routineToMap.login;
            _routineRetMod.totalSets = _routineToMap.totalSets;
            _routineRetMod.totalReps = _routineToMap.totalReps;
            _routineRetMod.totalExercise = _routineToMap.totalExercise;

            return _routineRetMod;
        }

        public List<BL_routineWorkout> map(List<routineWorkoutDAO> _dataRoutineWorkout)
        {
            List<BL_routineWorkout> _pressRoutineWorkout = new List<BL_routineWorkout>();
            foreach (routineWorkoutDAO _dRoutineWorkout in _dataRoutineWorkout)
            {
                BL_routineWorkout _pRoutineWorkout = new BL_routineWorkout();
                _pRoutineWorkout.routineWorkoutID = _dRoutineWorkout.routineWorkoutID;
                _pRoutineWorkout.FK_exerciseID = _dRoutineWorkout.FK_exerciseID;
                _pRoutineWorkout.FK_routineWorkoutID = _dRoutineWorkout.FK_routineWorkoutID
;
                _pRoutineWorkout.routineWSets = _dRoutineWorkout.routineWSets;
                _pRoutineWorkout.routineWReps = _dRoutineWorkout.routineWReps;
                _pRoutineWorkout.routineWRest = _dRoutineWorkout.routineWRest;

                _pressRoutineWorkout.Add(_pRoutineWorkout);
            }
            return _pressRoutineWorkout;

        }
        public List<BL_routine> map(List<routineDAO> _dataRoutine)
        {
            List<BL_routine> _pressRoutine = new List<BL_routine>();
            foreach (routineDAO _dRoutine in _dataRoutine)
            {
                BL_routine _pRoutine = new BL_routine();
                _pRoutine.routineID = _dRoutine.routineID;
                _pRoutine.routineName = _dRoutine.routineName;
                _pRoutine.FK_personID = _dRoutine.FK_personID;
                _pRoutine.login = _dRoutine.login;
                _pRoutine.totalSets = _dRoutine.totalSets;
                _pRoutine.totalReps = _dRoutine.totalReps;
                _pRoutine.totalExercise = _dRoutine.totalExercise;

                _pressRoutine.Add(_pRoutine);
            }
            return _pressRoutine;
        }
    }
}
