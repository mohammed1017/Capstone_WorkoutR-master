using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dataAccessLayer.Objects;

namespace persentation_WorkoutR.Models
{
    public class presentationMapper
    {
        // mapping data  to exercise model
        public exerciseDAO map(exerciseModel _exerciseMod)
        {
            // making new instance of exercise dao
            exerciseDAO _exerciseRetMod = new exerciseDAO();
            _exerciseRetMod.exerciseID = _exerciseMod.exerciseID;
            _exerciseRetMod.exerciseName = _exerciseMod.exerciseName;
            _exerciseRetMod.exerciseDescription = _exerciseMod.exerciseDescription;
            _exerciseRetMod.FK_bodyPart = _exerciseMod.FK_bodyPart;

            return _exerciseRetMod;
        }

        // mapping data back to exercise DAO
        public exerciseModel map(exerciseDAO _exerciseMod)
        {
            // making new instance of exercise model
            exerciseModel _exerciseRetMod = new exerciseModel();
            _exerciseRetMod.exerciseID = _exerciseMod.exerciseID;
            _exerciseRetMod.exerciseName = _exerciseMod.exerciseName;
            _exerciseRetMod.exerciseDescription = _exerciseMod.exerciseDescription;
            _exerciseRetMod.FK_bodyPart = _exerciseMod.FK_bodyPart;

            return _exerciseRetMod;
        }

        // mapping data to person model
        public personDAO map(personModel _personMod)
        {
            // making new instance of person dao
            personDAO _personRetMod = new personDAO();
            _personRetMod.personID = _personMod.personID;
            _personRetMod.personFirstName = _personMod.personFirstName;
            _personRetMod.personLastName = _personMod.personLastName;
            _personRetMod.personAddress = _personMod.personAddress;
            _personRetMod.personCity = _personMod.personCity;
            _personRetMod.personState = _personMod.personState;
            _personRetMod.personZip = _personMod.personZip;
            _personRetMod.personPhone = _personMod.personPhone;
            _personRetMod.FK_roleID = _personMod.FK_roleID;
            _personRetMod.personUsername = _personMod.personUsername;
            _personRetMod.personPassword = _personMod.personPassword;


            return _personRetMod;
        }

        // mapping data back to person DAO
        public personModel map(personDAO _personMod)
        {
            // making new instance of person model
            personModel _personRetMod = new personModel();
            _personRetMod.personID = _personMod.personID;
            _personRetMod.personFirstName = _personMod.personFirstName;
            _personRetMod.personLastName = _personMod.personLastName;
            _personRetMod.personAddress = _personMod.personAddress;
            _personRetMod.personCity = _personMod.personCity;
            _personRetMod.personState = _personMod.personState;
            _personRetMod.personZip = _personMod.personZip;
            _personRetMod.personPhone = _personMod.personPhone;
            _personRetMod.FK_roleID = _personMod.FK_roleID;
            _personRetMod.personUsername = _personMod.personUsername;
            _personRetMod.personPassword = _personMod.personPassword;


            return _personRetMod;
        }

        // mapping data to routine model
        public routineDAO map(routineModel _routineMod)
        {
            // making new instance of routine dao
            routineDAO _routineRetMod = new routineDAO();
            _routineRetMod.routineID = _routineMod.routineID;
            _routineRetMod.routineName = _routineMod.routineName;
            _routineRetMod.FK_personID = _routineMod.FK_personID;
            _routineRetMod.login = _routineMod.login;
            _routineRetMod.totalSets = _routineMod.totalSets;
            _routineRetMod.totalReps = _routineMod.totalReps;
            _routineRetMod.totalExercise = _routineMod.totalExercise;

            return _routineRetMod;
        }

        // mapping data back to routine DAO
        public routineModel map(routineDAO _routineMod)
        {
            // making new instance of routine model
            routineModel _routineRetMod = new routineModel();
            _routineRetMod.routineID = _routineMod.routineID;
            _routineRetMod.routineName = _routineMod.routineName;
            _routineRetMod.FK_personID = _routineMod.FK_personID;
            _routineRetMod.login = _routineMod.login;
            _routineRetMod.totalSets = _routineMod.totalSets;
            _routineRetMod.totalReps = _routineMod.totalReps;
            _routineRetMod.totalExercise = _routineMod.totalExercise;


            return _routineRetMod;
        }

        // mapping data to routineWorkout Model
        public routineWorkoutDAO map(routineWorkoutModel _routineWorkoutMod)
        {
            // making new instance of routineWorkout dao
            routineWorkoutDAO _routineWorkoutRetMod = new routineWorkoutDAO();
            _routineWorkoutRetMod.routineWorkoutID = _routineWorkoutMod.routineWorkoutID;
            _routineWorkoutRetMod.FK_exerciseID = _routineWorkoutMod.FK_exerciseID;
            _routineWorkoutRetMod.FK_routineWorkoutID = _routineWorkoutMod.FK_routineWorkoutID;
            _routineWorkoutRetMod.routineWSets = _routineWorkoutMod.routineWSets;
            _routineWorkoutRetMod.routineWReps = _routineWorkoutMod.routineWReps;
            _routineWorkoutRetMod.routineWRest = _routineWorkoutMod.routineWRest;

            return _routineWorkoutRetMod;

        }

        // mapping data back to routineWorkout DAO
        public routineWorkoutModel map(routineWorkoutDAO _routineWorkoutMod)
        {
            // making new instance of routineWorkout model
            routineWorkoutModel _routineWorkoutRetMod = new routineWorkoutModel();
            _routineWorkoutRetMod.routineWorkoutID = _routineWorkoutMod.routineWorkoutID;
            _routineWorkoutRetMod.FK_exerciseID = _routineWorkoutMod.FK_exerciseID;
            _routineWorkoutRetMod.FK_routineWorkoutID = _routineWorkoutMod.FK_routineWorkoutID;
            _routineWorkoutRetMod.routineWSets = _routineWorkoutMod.routineWSets;
            _routineWorkoutRetMod.routineWReps = _routineWorkoutMod.routineWReps;
            _routineWorkoutRetMod.routineWRest = _routineWorkoutMod.routineWRest;

            return _routineWorkoutRetMod;
        }

        public weightsModel map(weightsDAO _weightsMod)
        {
            weightsModel _weightsRetMod = new weightsModel();
            _weightsRetMod.WeightsID = _weightsMod.WeightsID;
            _weightsRetMod.lbs = _weightsMod.lbs;
            _weightsRetMod.FK_routineWorkID = _weightsMod.FK_routineWorkID;

            return _weightsRetMod;
        }

        public weightsDAO map(weightsModel _weightsMod)
        {
            weightsDAO _weightsRedMod = new weightsDAO();
            _weightsRedMod.WeightsID = _weightsMod.WeightsID;
            _weightsRedMod.lbs = _weightsMod.lbs;
            _weightsRedMod.FK_routineWorkID = _weightsMod.FK_routineWorkID;

            return _weightsRedMod;
        }




        // making list of role model from rolesDAO
        public List<roleModel> map(List<rolesDAO> _dataRoles)
        {
            // making new list of role model
            List<roleModel> _pressRoles = new List<roleModel>();
            foreach (rolesDAO _dRoles in _dataRoles)
            {
                roleModel _pRoles = new roleModel();
                _pRoles.roleID = _dRoles.roleID;
                _pRoles.roleName = _dRoles.roleName;
                _pRoles.roleDescription = _dRoles.roleDescription;

                _pressRoles.Add(_pRoles);
            }
            return _pressRoles;

        }
        // making list of exercise model from exerciseDAO
        public List<exerciseModel> map(List<exerciseDAO> _dataExercise)
        {
            // making new list of exercise model
            List<exerciseModel> _pressExercise = new List<exerciseModel>();
            foreach (exerciseDAO _dExercise in _dataExercise)
            {
                exerciseModel _pExercise = new exerciseModel();
                _pExercise.exerciseID = _dExercise.exerciseID;
                _pExercise.exerciseName = _dExercise.exerciseName;
                _pExercise.exerciseDescription = _dExercise.exerciseDescription;
                _pExercise.FK_bodyPart= _dExercise.FK_bodyPart;

                _pressExercise.Add(_pExercise);
            }
            return _pressExercise;

        }
        // making list of person model from personDAO
        public List<personModel> map(List<personDAO> _dataPerson)
        {
            // making new list of person model
            List<personModel> _pressPerson = new List<personModel>();
            foreach (personDAO _dPerson in _dataPerson)
            {
                personModel _pPerson = new personModel();
                _pPerson.personID = _dPerson.personID;
                _pPerson.personFirstName = _dPerson.personFirstName;
                _pPerson.personLastName = _dPerson.personLastName;
                _pPerson.personAddress = _dPerson.personAddress;
                _pPerson.personCity = _dPerson.personCity;
                _pPerson.personState = _dPerson.personState;
                _pPerson.personZip = _dPerson.personZip;
                _pPerson.personPhone = _dPerson.personPhone;
                _pPerson.FK_roleID = _dPerson.FK_roleID;
                _pPerson.personUsername = _dPerson.personUsername;
                _pPerson.personPassword = _dPerson.personPassword;

                _pressPerson.Add(_pPerson);
            }
            return _pressPerson
;

        }
        // making list of routine model from routineDAO
        public List<routineModel> map(List<routineDAO> _dataRoutine)
        {
            // making new list of routine model
            List<routineModel> _pressRoutine = new List<routineModel>();
            foreach (routineDAO _dRoutine in _dataRoutine)
            {
                routineModel _pRoutine = new routineModel();
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
        // making list of routineWorkout model from routinWorkoutDAO
        public List<routineWorkoutModel> map(List<routineWorkoutDAO> _dataRoutineWorkout)
        {
            // making new list of routineWorkout model
            List<routineWorkoutModel> _pressRoutineWorkout = new List<routineWorkoutModel>();
            foreach (routineWorkoutDAO _dRoutineWorkout in _dataRoutineWorkout)
            {
                routineWorkoutModel _pRoutineWorkout = new routineWorkoutModel();
                _pRoutineWorkout.routineWorkoutID = _dRoutineWorkout.routineWorkoutID;
                _pRoutineWorkout.exerciseName = _dRoutineWorkout.exerciseName;
                _pRoutineWorkout.routineName = _dRoutineWorkout.routineName;
                _pRoutineWorkout.routineWSets= _dRoutineWorkout.routineWSets;
                _pRoutineWorkout.routineWReps = _dRoutineWorkout.routineWReps;
                _pRoutineWorkout.routineWRest = _dRoutineWorkout.routineWRest;

                _pressRoutineWorkout.Add(_pRoutineWorkout);
            }
            return _pressRoutineWorkout;

        }

        // making list of bodyPart model from bodypartDAO
        public List<bodyPartModel> map(List<bodyPartDAO> _dataBodyPart)
        {
            // making new list of routineWorkout model
            List<bodyPartModel> _pressBodyPart = new List<bodyPartModel>();
            foreach (bodyPartDAO _dBodyPart in _dataBodyPart)
            {
                bodyPartModel _pBodyPart = new bodyPartModel();
                _pBodyPart.bodyPartID = _dBodyPart.bodyPartID;
                _pBodyPart.bodyPartName= _dBodyPart.bodyPartName;


                _pressBodyPart.Add(_pBodyPart);
            }
            return _pressBodyPart;

        }

        public List<weightsModel> map(List<weightsDAO> _dataWeights)
        {
            List<weightsModel> _pressWeights = new List<weightsModel>();
            foreach(weightsDAO _dWeights in _dataWeights)
            {
                weightsModel _pWeights = new weightsModel();
                _pWeights.WeightsID = _dWeights.WeightsID;
                _pWeights.lbs = _dWeights.lbs;
                _pWeights.FK_routineWorkID = _pWeights.FK_routineWorkID;

                _pressWeights.Add(_pWeights);
            }

            return _pressWeights;
        }


    }
}